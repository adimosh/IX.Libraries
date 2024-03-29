using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Math;

/// <summary>
///     Test data for IX.Math tests.
/// </summary>
public static partial class TestData
{
    /// <summary>
    ///     Provides templated random text data for basic operators and parentheses.
    /// </summary>
    /// <returns>Test data.</returns>
    [SuppressMessage("ReSharper",
        "StringLiteralTypo",
        Justification = "These test specific mathematical formulas, and we're not concenred with correctness.")]
    private static List<object?[]> SpecialCases() => new()
    {
        new object?[]
        {
            "0=0",
            null,
            true,
        },
        new object?[]
        {
            "\"some string\"=\"some string\"",
            null,
            true,
        },
        new object?[]
        {
            "true=true",
            null,
            true,
        },
        new object?[]
        {
            "0=1",
            null,
            false,
        },
        new object?[]
        {
            "\"some string\"=\"spppng\"",
            null,
            false,
        },
        new object?[]
        {
            "false=true",
            null,
            false,
        },
        new object?[]
        {
            "0!=0",
            null,
            false,
        },
        new object?[]
        {
            "\"some string\"!=\"skskskg\"",
            null,
            true,
        },
        new object?[]
        {
            "false!=true",
            null,
            true,
        },
        new object?[]
        {
            @"""3""+6",
            null,
            "36",
        },
        new object?[]
        {
            @"""3""+""6""",
            null,
            "36",
        },
        new object?[]
        {
            @"""3+6""",
            null,
            "3+6",
        },
        new object?[]
        {
            "3+6-2*4",
            null,
            1L,
        },
        new object?[]
        {
            "3+(6-2)*2",
            null,
            11L,
        },
        new object?[]
        {
            "3+(6-2*2)",
            null,
            5L,
        },
        new object?[]
        {
            "1<<2",
            null,
            4L,
        },
        new object?[]
        {
            "3-6+1<<2",
            null,
            1L,
        },
        new object?[]
        {
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 49,
            },
            52L,
        },
        new object?[]
        {
            "x&y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            false,
        },
        new object?[]
        {
            "x&y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = true,
            },
            true,
        },
        new object?[]
        {
            "x|y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            true,
        },
        new object?[]
        {
            "x|(1>2)",
            new Dictionary<string, object>
            {
                ["x"] = true,
            },
            true,
        },
        new object?[]
        {
            "x|y",
            new Dictionary<string, object>
            {
                ["x"] = false,
                ["y"] = false,
            },
            false,
        },
        new object?[]
        {
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = true,
            },
            false,
        },
        new object?[]
        {
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            true,
        },
        new object?[]
        {
            "x<<y",
            new Dictionary<string, object>
            {
                ["x"] = 3,
                ["y"] = 2,
            },
            12L,
        },
        new object?[]
        {
            "x>>y",
            new Dictionary<string, object>
            {
                ["x"] = 3,
                ["y"] = 1,
            },
            1L,
        },
        new object?[]
        {
            "0x1123>>8",
            null,
            17L,
        },
        new object?[]
        {
            "2<<2+1<<2",
            null,
            12L,
        },
        new object?[]
        {
            "1<<1<<2",
            null,
            8L,
        },
        new object?[]
        {
            "1<<2>>2",
            null,
            1L,
        },
        new object?[]
        {
            "((2+3)*2-1)*2",
            null,
            18L,
        },
        new object?[]
        {
            "  3         +        6      ",
            null,
            9L,
        },
        new object?[]
        {
            "3=6",
            null,
            false,
        },
        new object?[]
        {
            "((2+3)*2-1)*2 - x",
            new Dictionary<string, object>
            {
                ["x"] = 12,
            },
            6D,
        },
        new object?[]
        {
            "x^2",
            new Dictionary<string, object>
            {
                ["x"] = 2,
            },
            4.0,
        },
        new object?[]
        {
            "x^3",
            new Dictionary<string, object>
            {
                ["x"] = 3,
            },
            27.0,
        },
        new object?[]
        {
            "x",
            new Dictionary<string, object>
            {
                ["x"] = 12,
            },
            12L,
        },
        new object?[]
        {
            "2*x-7*y",
            new Dictionary<string, object>
            {
                ["x"] = 12,
                ["y"] = 2,
            },
            10D,
        },
        new object?[]
        {
            "textparam = 12",
            new Dictionary<string, object>
            {
                ["textparam"] = 13,
            },
            false,
        },
        new object?[]
        {
            "7+14+79<3+(7*12)",
            null,
            false,
        },
        new object?[]
        {
            "-1.00<-1",
            null,
            false,
        },
        new object?[]
        {
            "1<<1",
            null,
            2L,
        },
        new object?[]
        {
            "1<<1 + 2 << 1",
            null,
            6L,
        },
        new object?[]
        {
            "((1+1)-(1-1))+((1-1)-(1+1))",
            null,
            0L,
        },
        new object?[]
        {
            "((6-3)*(3+3))-1",
            null,
            17L,
        },
        new object?[]
        {
            "2+sqrt(4)+2",
            null,
            6L,
        },
        new object?[]
        {
            "2.0*x-7*y",
            new Dictionary<string, object>
            {
                ["x"] = 12.5D,
                ["y"] = 2,
            },
            11.0D,
        },
        new object?[]
        {
            "!x",
            new Dictionary<string, object>
            {
                ["x"] = 32768,
            },
            -32769L,
        },
        new object?[]
        {
            "strlen(x)",
            new Dictionary<string, object>
            {
                ["x"] = "alabala",
            },
            7L,
        },
        new object?[]
        {
            "21*3-17",
            null,
            46L,
        },
        new object?[]
        {
            "(1+1)*2-3",
            null,
            1L,
        },
        new object?[]
        {
            "sqrt(4)",
            null,
            2L,
        },
        new object?[]
        {
            "sqrt(4.0)",
            null,
            2L,
        },
        new object?[]
        {
            "sqrt(0.49)",
            null,
            0.7,
        },
        new object?[]
        {
            "!4+4",
            null,
            -1L,
        },
        new object?[]
        {
            "212",
            null,
            212L,
        },
        new object?[]
        {
            "String is wonderful",
            null,
            "String is wonderful",
        },
        new object?[]
        {
            "212=String again",
            null,
            "212=String again",
        },
        new object?[]
        {
            "0x10+26",
            null,
            42L,
        },
        new object?[]
        {
            "e",
            null,
            global::System.Math.E,
        },
        new object?[]
        {
            "[pi]",
            null,
            global::System.Math.PI,
        },
        new object?[]
        {
            "e*[pi]",
            null,
            global::System.Math.E * global::System.Math.PI,
        },
        new object?[]
        {
            "min(2,17)",
            null,
            2L,
        },
        new object?[]
        {
            "max(2,17)+1",
            null,
            18L,
        },
        new object?[]
        {
            "(max(2,17)+1)/2",
            null,
            9L,
        },
        new object?[]
        {
            "max(2,17)+max(3,1)",
            null,
            20L,
        },
        new object?[]
        {
            "(sqrt(16)+1)*4-max(20,13)+(27*5-27*4 - sqrt(49))",
            null,
            20L,
        },
        new object?[]
        {
            "strlen(\"This that those\")",
            null,
            15L,
        },
        new object?[]
        {
            "5+strlen(\"This that those\")-10",
            null,
            10L,
        },
        new object?[]
        {
            "min(max(10,5),max(25,10))",
            null,
            10L,
        },
        new object?[]
        {
            "min(max(10,5)+40,3*max(25,10))",
            null,
            50L,
        },
        new object?[]
        {
            "min(max(5+strlen(\"This that those\")-10,5)+40,3*max(25,10))",
            null,
            50L,
        },
        new object?[]
        {
            "1--2",
            null,
            3L,
        },
        new object?[]
        {
            "1*-2",
            null,
            -2L,
        },
        new object?[]
        {
            "(x=0) & (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 1,
            },
            true,
        },
        new object?[]
        {
            "(x=0) | (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 0,
            },
            true,
        },
        new object?[]
        {
            "(x=0) & (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 2,
            },
            false,
        },
        new object?[]
        {
            "(x>0) & (y<1)",
            new Dictionary<string, object>
            {
                ["x"] = 1,
                ["y"] = 0,
            },
            true,
        },
        new object?[]
        {
            "abs(x)",
            new Dictionary<string, object>
            {
                ["x"] = -1,
            },
            1L,
        },
        new object?[]
        {
            "abs(x)",
            new Dictionary<string, object>
            {
                ["x"] = -1D,
            },
            1D,
        },
        new object?[]
        {
            "abs(0x1)",
            null,
            1L,
        },
        new object?[]
        {
            "sqrt(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2,
            },
            global::System.Math.Sqrt(2),
        },
        new object?[]
        {
            "sqrt(x)",
            new Dictionary<string, object>
            {
                ["x"] = 9,
            },
            3D,
        },
        new object?[]
        {
            "ceil(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2.2,
            },
            3D,
        },
        new object?[]
        {
            "floor(x)",
            new Dictionary<string, object>
            {
                ["x"] = 4.9,
            },
            4D,
        },
        new object?[]
        {
            "round(x)",
            new Dictionary<string, object>
            {
                ["x"] = 3.5,
            },
            4D,
        },
        new object?[]
        {
            "round(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2.49,
            },
            2D,
        },
        new object?[]
        {
            "(2*max(x,500)-y)/pow(x,2)",
            new Dictionary<string, object>
            {
                ["x"] = 217,
                ["y"] = 323,
            },
            0.014377030729045,
        },
        new object?[]
        {
            "min(max(x,y),10)",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 3,
            },
            5D,
        },
        new object?[]
        {
            "min(max(x,y),max(y,500)*2-min(995,pow(x,200)))",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 3,
            },
            5D,
        },
        new object?[]
        {
            "max(max(x,y),max(y,500)*2-995)",
            new Dictionary<string, object>
            {
                ["x"] = 5.5,
                ["y"] = 3,
            },
            5.5,
        },
        new object?[]
        {
            "substr(x,y)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
            },
            "bbb",
        },
        new object?[]
        {
            "substr(x,y,z)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
            },
            "bb",
        },
        new object?[]
        {
            "strlen(substr(x,y,z))",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
            },
            2L,
        },
        new object?[]
        {
            "abs((1-17)+3) + abs(14-(1*4))",
            null,
            23L,
        },
        new object?[]
        {
            "substr(x,y,z)+substr(q,y,z)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
                ["q"] = "ccccddd",
            },
            "bbcd",
        },
        new object?[]
        {
            "\"aaa\" + \"bbb\"",
            null,
            "aaabbb",
        },
        new object?[]
        {
            "\"aaa\" + substr(\"bbbbbb\", 1, 1)",
            null,
            "aaab",
        },
        new object?[]
        {
            "\"aaa\" > \"bbb\"",
            null,
            false,
        },
        new object?[]
        {
            "\"aaa\" > x",
            new Dictionary<string, object>
            {
                ["x"] = "z",
            },
            false,
        },
        new object?[]
        {
            "\"aaa\" < \"bbb\"",
            null,
            true,
        },
        new object?[]
        {
            "\"aaa\" < x",
            new Dictionary<string, object>
            {
                ["x"] = "aa",
            },
            false,
        },
        new object?[]
        {
            "\"aaa\" >= \"bbb\"",
            null,
            false,
        },
        new object?[]
        {
            "\"aaa\" >= x",
            new Dictionary<string, object>
            {
                ["x"] = "z",
            },
            false,
        },
        new object?[]
        {
            "\"aaa\" <= \"bbb\"",
            null,
            true,
        },
        new object?[]
        {
            "\"aaa\" <= x",
            new Dictionary<string, object>
            {
                ["x"] = "aa",
            },
            false,
        },
        new object?[]
        {
            "\"aaa\" <= \"aaa\"",
            null,
            true,
        },
        new object?[]
        {
            "\"aaa\" >= \"aaa\"",
            null,
            true,
        },
        new object?[]
        {
            "tempVariable1=2",
            new Dictionary<string, object>
            {
                ["tempVariable1"] = 2,
            },
            true,
        },
        new object?[]
        {
            "6/2*3",
            null,
            9L,
        },
        new object?[]
        {
            "x=\" \"",
            new Dictionary<string, object>
            {
                ["x"] = " ",
            },
            true,
        },
        new object?[]
        {
            "x=\"\"",
            new Dictionary<string, object>
            {
                ["x"] = string.Empty,
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101=0b1001010111010110110010000000010010101110101",
            null,
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101>0b1010111010110110010000000010010101110101",
            null,
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100<0b1001010111010110110010000000010010101110101",
            null,
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101>=0b1010111010110110010000000010010101110101",
            null,
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100<=0b1001010111010110110010000000010010101110101",
            null,
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101<0b1010111010110110010000000010010101110101",
            null,
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100>0b1001010111010110110010000000010010101110101",
            null,
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101<=0b1010111010110110010000000010010101110101",
            null,
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100>=0b1001010111010110110010000000010010101110101",
            null,
            false,
        },
        new object?[]
        {
            "0b1001010111010110110011111000010010101110101=0b1001010111010110110010000000011111101110101",
            null,
            false,
        },
        new object?[]
        {
            "x=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101!=0b1001010111010110110010000000010010101110101",
            null,
            false,
        },
        new object?[]
        {
            "0b1001010111010110110011111000010010101110101!=0b1001010111010110110010000000011111101110101",
            null,
            true,
        },
        new object?[]
        {
            "x!=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101>x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100<x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101>=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100<=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101<x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100>x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110101<=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "0b1001010111010110110010000000010010101110100>=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "x>0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "x<0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true,
        },
        new object?[]
        {
            "x>=0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true,
        },
        new object?[]
        {
            "x<=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true,
        },
        new object?[]
        {
            "x<0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "x>0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false,
        },
        new object?[]
        {
            "x<=0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false,
        },
        new object?[]
        {
            "x>=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false,
        },
        new object?[]
        {
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true,
        },
        new object?[]
        {
            "x<=y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true,
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false,
        },
        new object?[]
        {
            "x<y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false,
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b11111111_11111111_11111111),
                ["y"] = BitConverter.GetBytes(0b11111111_11111111),
            },
            true,
        },
        new object?[]
        {
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b11111111_11111111_00000000),
                ["y"] = BitConverter.GetBytes(0b00000000_11111111_11111111),
            },
            true,
        },
        new object?[]
        {
            "0b11111111_11111111_00000000>0b00000000_11111111_11111111",
            null,
            true,
        },
        new object?[]
        {
            "x*(x+1)*(x+2)",
            new Dictionary<string, object>
            {
                ["x"] = 5,
            },
            210D,
        },
        new object?[]
        {
            "tempVar1+tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5,
            },
            10L,
        },
        new object?[]
        {
            "tempVar1+tempVar2",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5,
                ["tempVar2"] = 5D,
            },
            10D,
        },
        new object?[]
        {
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5D,
            },
            5D,
        },
        new object?[]
        {
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = "aaa",
            },
            "aaa",
        },
        new object?[]
        {
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5L,
            },
            5L,
        },
        new object?[]
        {
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = true,
            },
            true,
        },
        new object?[]
        {
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
        },
        new object?[]
        {
            "2.12+6.274E+1",
            null,
            64.86D,
        },
        new object?[]
        {
            "2.12+6.274E1",
            null,
            64.86D,
        },
        new object?[]
        {
            "2.12+627.4E-2",
            null,
            8.394D,
        },
        new object?[]
        {
            "2.12+6.274e+1",
            null,
            64.86D,
        },
        new object?[]
        {
            "2.12+6.274e1",
            null,
            64.86D,
        },
        new object?[]
        {
            "2.12+627.4e-2",
            null,
            8.394D,
        },
        new object?[]
        {
            "trim(\"   a   \")",
            null,
            "a",
        },
        new object?[]
        {
            "trim(x)",
            new Dictionary<string, object>
            {
                ["x"] = "   a   ",
            },
            "a",
        },
        new object?[]
        {
            "trim(\"abcde\", \"ade\")",
            null,
            "bc",
        },
        new object?[]
        {
            "trim(x, y)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["y"] = "ade",
            },
            "bc",
        },
        new object?[]
        {
            "trimbody(\"abcde\", \"c\")",
            null,
            "abde",
        },
        new object?[]
        {
            "trimbody(x, z)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["z"] = "bc",
            },
            "ade",
        },
        new object?[]
        {
            "replace(\"abcde\", \"c\", \"x\")",
            null,
            "abxde",
        },
        new object?[]
        {
            "replace(x, y, z)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["y"] = "bc",
                ["z"] = "q",
            },
            "aqde",
        },
        new object?[]
        {
            "round(x, 2)=2.12",
            new Dictionary<string, object>
            {
                ["x"] = 2.1247154D,
            },
            true
        },
        new object?[]
        {
            "round(x, 3)=2.121",
            new Dictionary<string, object>
            {
                ["x"] = 2.1247154D,
            },
            false
        },
    };
}