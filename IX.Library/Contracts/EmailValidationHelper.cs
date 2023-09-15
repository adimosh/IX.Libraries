using IX.Library.Collections;
using IX.Library.Globalization;

using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace IX.Library.Contracts;

internal static class EmailValidationHelper
{
    // IANA TLDs
    private static readonly Lazy<string[]> IanaTlds = new(
        () =>
        {
            using var sr = new StreamReader(
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "IX.Library.Contracts.ValidationResources.tlds-alpha-by-domain.txt")!, Encoding.ASCII,
                false,
                1000,
                true);

            List<string> tlds = new();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("#"))
                {
                    continue;
                }

                tlds.Add(line);
            }

            return tlds.ToArray();
        });

    // First validation
    private static readonly Lazy<Regex> EmailBasicFormatRegex = new(() => new(@"^(?<address>.+)@(?<domain>.+)$"));

    // Domain part validation
    private static readonly Lazy<Regex> DomainRegex =
        new(() => new(@"^(?!-)(?:[\w--[_]]+\.)*(?<tld>[\w--[_]]+)(?<!-)$"));

    private static readonly Lazy<Regex> Ipv4Regex = new(
        () => new(@"^\[(?<part1>[\d]{1,3})\.(?<part2>[\d]{1,3})\.(?<part3>[\d]{1,3})\.(?<part4>[\d]{1,3})\]$"));

    private static readonly Lazy<Regex> Ipv6Regex = new(() => new(@"^\[IPv6(?::[a-fA-F0-9]{4}){8}\]$"));

    // Address part validation
    private static readonly Lazy<Regex> StandardAddressRegex =
        new(() => new(@"^(?!\.)(?:[\w!#$%&'*+\-/=?^`{|}~]|(?<!\.)\.){1,64}(?<!\.)$"));

    private static readonly Lazy<Regex> QuotedAddressRegex = new(() => new(@"^""(?:[^""]|(?<=\\)""){1,62}""$"));

    internal static bool IsAddressValid(
        string address,
        bool validateStrict = false)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            // Validation 1: Address is not null, empty or whitespace
            return false;
        }

        Match firstMatch = EmailBasicFormatRegex.Value.Match(address);

        if (!firstMatch.Success)
        {
            // Validation 2: Address contains at least one "@"
            return false;
        }

#region Validate address

        var addressPart = firstMatch.Groups["address"].Value;

        if (!StandardAddressRegex.Value.IsMatch(addressPart))
        {
            // We might have a quoted address
            if (!QuotedAddressRegex.Value.IsMatch(addressPart))
            {
                // Validation 3: Address contains only valid characters and the dot, where the dot is not at the beginning or
                // end, and is not doubled, and the whole address is not enclosed in quotation marks
                // Validation 4: If address is enclosed in quotation marks, everything goes, but quotation marks must be escaped
                return false;
            }
        }

#endregion

#region Validate domain

        var domainPart = firstMatch.Groups["domain"].Value;

        Match domainMatch = DomainRegex.Value.Match(domainPart);

        if (domainMatch.Success)
        {
            // We have a domain match, if it is a strict match let's also check IANA TLDs
            if (validateStrict)
            {
                var tld = domainMatch.Groups["tld"].Value;

                if (tld.Length == domainPart.Length)
                {
                    // Validation 5: Domain only - not allowed by strict ICANN rules, even if it happens to match a IANA TLD
                    return false;
                }

                if (!IanaTlds.Value.Any(
                        (
                            p,
                            innerTld) => p.OrdinalEqualsInsensitive(innerTld), tld))
                {
                    // Validation 6: Strict IANA TLD validation of last domain
                    return false;
                }
            }
        }
        else
        {
            if (!domainPart.StartsWith("[") || !domainPart.EndsWith("]"))
            {
                // Validation 7: IP address matches require [ ]
                return false;
            }

            // Not a domain match, let's see if it is an IPv4 match
            Match ipv4RegexMatch = Ipv4Regex.Value.Match(domainPart);

            if (ipv4RegexMatch.Success)
            {
                // We have an IPv4 match, let's see if the address is valid
                var p1 = int.Parse(ipv4RegexMatch.Groups["part1"].Value);
                var p2 = int.Parse(ipv4RegexMatch.Groups["part2"].Value);
                var p3 = int.Parse(ipv4RegexMatch.Groups["part3"].Value);
                var p4 = int.Parse(ipv4RegexMatch.Groups["part4"].Value);

                if (p1 > 255 || p2 > 255 || p3 > 255 || p4 > 255)
                {
                    // Validation 8: We have an IPv4 match, but the IPv4 address is not actually valid
                    return false;
                }

                if (p1 == 255 && p2 == 255 && p3 == 255 && p4 == 255)
                {
                    // Validation 9: We have an IPv4 match, but the IPv4 address is the general broadcast value
                    return false;
                }

                if (p1 == 0 && p2 == 0 && p3 == 0 && p4 == 0)
                {
                    // Validation 10: We have an IPv4 match, but the IPv4 address is 0
                    return false;
                }
            }
            else
            {
                // Not an IPv4 match, let's see if it is an IPv6 match
                if (!Ipv6Regex.Value.IsMatch(domainPart))
                {
                    // Validation 11: Not an IPv6 address either
                    return false;
                }
            }
        }

#endregion

        // Fully-validated
        return true;
    }
}