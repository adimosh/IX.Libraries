using IX.Library.DataGeneration;
using IX.Math;
using Moq;

using UnitTests.Math.Helpers;

namespace UnitTests.Math;

/// <summary>
///     Tests computed expressions.
/// </summary>
public class ComputedExpressionUnitTests : IClassFixture<CachedExpressionProviderFixture>
{
    private readonly CachedExpressionProviderFixture _fixture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ComputedExpressionUnitTests" /> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public ComputedExpressionUnitTests(CachedExpressionProviderFixture fixture) => _fixture = fixture;

    /// <summary>
    ///     Provides the data for theory.
    /// </summary>
    /// <returns>Theory data.</returns>
    public static object?[][] ProvideDataForTheory() =>
    [
        [
            "3+6",
            null,
            9L
        ],
        [
            "8-9",
            null,
            -1L
        ],
        [
            "0=0",
            null,
            true
        ],
        [
            "\"some string\"=\"some string\"",
            null,
            true
        ],
        [
            "true=true",
            null,
            true
        ],
        [
            "0=1",
            null,
            false
        ],
        [
            "\"some string\"=\"spppng\"",
            null,
            false
        ],
        [
            "false=true",
            null,
            false
        ],
        [
            "0!=0",
            null,
            false
        ],
        [
            "\"some string\"!=\"skskskg\"",
            null,
            true
        ],
        [
            "false!=true",
            null,
            true
        ],
        [
            "6-2",
            null,
            4L
        ],
        [
            "3*6",
            null,
            18L
        ],
        [
            "3/6",
            null,
            0.5
        ],
        [
            "6/3",
            null,
            2L
        ],
        [
            "6^3",
            null,
            216L
        ],
        [
            @"""3""+6",
            null,
            "36"
        ],
        [
            @"""3""+""6""",
            null,
            "36"
        ],
        [
            @"""3+6""",
            null,
            "3+6"
        ],
        [
            "3+6-2*4",
            null,
            1L
        ],
        [
            "3+(6-2)*2",
            null,
            11L
        ],
        [
            "3+(6-2*2)",
            null,
            5L
        ],
        [
            "1<<2",
            null,
            4L
        ],
        [
            "3-6+1<<2",
            null,
            1L
        ],
        [
            "x&y",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 49,
            },
            1L
        ],
        [
            "x|y",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 49,
            },
            53L
        ],
        [
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 49,
            },
            52L
        ],
        [
            "x&y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            false
        ],
        [
            "x&y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = true,
            },
            true
        ],
        [
            "x|y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            true
        ],
        [
            "x|(1>2)",
            new Dictionary<string, object>
            {
                ["x"] = true,
            },
            true
        ],
        [
            "x|y",
            new Dictionary<string, object>
            {
                ["x"] = false,
                ["y"] = false,
            },
            false
        ],
        [
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = true,
            },
            false
        ],
        [
            "x#y",
            new Dictionary<string, object>
            {
                ["x"] = true,
                ["y"] = false,
            },
            true
        ],
        [
            "x<<y",
            new Dictionary<string, object>
            {
                ["x"] = 3,
                ["y"] = 2,
            },
            12L
        ],
        [
            "x>>y",
            new Dictionary<string, object>
            {
                ["x"] = 3,
                ["y"] = 1,
            },
            1L
        ],
        [
            "0x1123>>8",
            null,
            17L
        ],
        [
            "2<<2+1<<2",
            null,
            12L
        ],
        [
            "1<<1<<2",
            null,
            8L
        ],
        [
            "1<<2>>2",
            null,
            1L
        ],
        [
            "((2+3)*2-1)*2",
            null,
            18L
        ],
        [
            "  3         +        6      ",
            null,
            9L
        ],
        [
            "3=6",
            null,
            false
        ],
        [
            "((2+3)*2-1)*2 - x",
            new Dictionary<string, object>
            {
                ["x"] = 12,
            },
            6L
        ],
        [
            "x^2",
            new Dictionary<string, object>
            {
                ["x"] = 2,
            },
            4.0
        ],
        [
            "x^3",
            new Dictionary<string, object>
            {
                ["x"] = 3,
            },
            27.0
        ],
        [
            "x",
            new Dictionary<string, object>
            {
                ["x"] = 12,
            },
            12L
        ],
        [
            "2*x-7*y",
            new Dictionary<string, object>
            {
                ["x"] = 12,
                ["y"] = 2,
            },
            10L
        ],
        [
            "x-y",
            new Dictionary<string, object>
            {
                ["x"] = 12,
                ["y"] = 2,
            },
            10L
        ],
        [
            "textparam = 12",
            new Dictionary<string, object>
            {
                ["textparam"] = 13,
            },
            false
        ],
        [
            "7+14+79<3+(7*12)",
            null,
            false
        ],
        [
            "-1.00<-1",
            null,
            false
        ],
        [
            "1<<1",
            null,
            2L
        ],
        [
            "7/2",
            null,
            3.5
        ],
        [
            "1<<1 + 2 << 1",
            null,
            6L
        ],
        [
            "((1+1)-(1-1))+((1-1)-(1+1))",
            null,
            0L
        ],
        [
            "((6-3)*(3+3))-1",
            null,
            17L
        ],
        [
            "2+sqrt(4)+2",
            null,
            6D
        ],
        [
            "2.0*x-7*y",
            new Dictionary<string, object>
            {
                ["x"] = 12.5D,
                ["y"] = 2,
            },
            11.0D
        ],
        [
            "!x",
            new Dictionary<string, object>
            {
                ["x"] = 32768,
            },
            -32769L
        ],
        [
            "strlen(x)",
            new Dictionary<string, object>
            {
                ["x"] = "alabala",
            },
            7L
        ],
        [
            "21*3-17",
            null,
            46L
        ],
        [
            "(1+1)*2-3",
            null,
            1L
        ],
        [
            "sqrt(4)",
            null,
            2D
        ],
        [
            "sqrt(4.0)",
            null,
            2D
        ],
        [
            "sqrt(0.49)",
            null,
            0.7
        ],
        [
            "!4+4",
            null,
            -1L
        ],
        [
            "212",
            null,
            212L
        ],
        [
            "String is wonderful",
            null,
            "String is wonderful"
        ],
        [
            "212=String again",
            null,
            "212=String again"
        ],
        [
            "0x10+26",
            null,
            42L
        ],
        [
            "e",
            null,
            global::System.Math.E
        ],
        [
            "[pi]",
            null,
            global::System.Math.PI
        ],
        [
            "e*[pi]",
            null,
            global::System.Math.E * global::System.Math.PI
        ],
        [
            "min(2,17)",
            null,
            2L
        ],
        [
            "max(2,17)+1",
            null,
            18L
        ],
        [
            "(max(2,17)+1)/2",
            null,
            9L
        ],
        [
            "max(2,17)+max(3,1)",
            null,
            20L
        ],
        [
            "(sqrt(16)+1)*4-max(20,13)+(27*5-27*4 - sqrt(49))",
            null,
            20D
        ],
        [
            "strlen(\"This that those\")",
            null,
            15L
        ],
        [
            "5+strlen(\"This that those\")-10",
            null,
            10L
        ],
        [
            "min(max(10,5),max(25,10))",
            null,
            10L
        ],
        [
            "min(max(10,5)+40,3*max(25,10))",
            null,
            50L
        ],
        [
            "min(max(5+strlen(\"This that those\")-10,5)+40,3*max(25,10))",
            null,
            50L
        ],
        [
            "1--2",
            null,
            3L
        ],
        [
            "x+y",
            new Dictionary<string, object>
            {
                ["x"] = 1,
                ["y"] = -2,
            },
            -1L
        ],
        [
            "1*-2",
            null,
            -2L
        ],
        [
            "(x=0) & (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 1,
            },
            true
        ],
        [
            "(x=0) | (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 0,
            },
            true
        ],
        [
            "(x=0) & (y=1)",
            new Dictionary<string, object>
            {
                ["x"] = 0,
                ["y"] = 2,
            },
            false
        ],
        [
            "(x>0) & (y<1)",
            new Dictionary<string, object>
            {
                ["x"] = 1,
                ["y"] = 0,
            },
            true
        ],
        [
            "abs(x)",
            new Dictionary<string, object>
            {
                ["x"] = -1,
            },
            1L
        ],
        [
            "abs(x)",
            new Dictionary<string, object>
            {
                ["x"] = -1D,
            },
            1D
        ],
        [
            "abs(0x1)",
            null,
            1L
        ],
        [
            "sqrt(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2,
            },
            global::System.Math.Sqrt(2)
        ],
        [
            "sqrt(x)",
            new Dictionary<string, object>
            {
                ["x"] = 9,
            },
            3D
        ],
        [
            "ceil(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2.2,
            },
            3D
        ],
        [
            "floor(x)",
            new Dictionary<string, object>
            {
                ["x"] = 4.9,
            },
            4D
        ],
        [
            "round(x)",
            new Dictionary<string, object>
            {
                ["x"] = 3.5,
            },
            4D
        ],
        [
            "round(x)",
            new Dictionary<string, object>
            {
                ["x"] = 2.49,
            },
            2D
        ],
        [
            "(2*max(x,500)-y)/pow(x,2)",
            new Dictionary<string, object>
            {
                ["x"] = 217,
                ["y"] = 323,
            },
            0.014377030729045
        ],
        [
            "min(max(x,y),10)",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 3,
            },
            5D
        ],
        [
            "min(max(x,y),max(y,500)*2-min(995,pow(x,200)))",
            new Dictionary<string, object>
            {
                ["x"] = 5,
                ["y"] = 3,
            },
            5D
        ],
        [
            "max(max(x,y),max(y,500)*2-995)",
            new Dictionary<string, object>
            {
                ["x"] = 5.5,
                ["y"] = 3,
            },
            5.5
        ],
        [
            "substr(x,y)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
            },
            "bbb"
        ],
        [
            "substr(x,y,z)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
            },
            "bb"
        ],
        [
            "strlen(substr(x,y,z))",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
            },
            2L
        ],
        [
            "abs((1-17)+3) + abs(14-(1*4))",
            null,
            23L
        ],
        [
            "substr(x,y,z)+substr(q,y,z)",
            new Dictionary<string, object>
            {
                ["x"] = "aaabbb",
                ["y"] = 3,
                ["z"] = 2,
                ["q"] = "ccccddd",
            },
            "bbcd"
        ],
        [
            "\"aaa\" + \"bbb\"",
            null,
            "aaabbb"
        ],
        [
            "\"aaa\" + substr(\"bbbbbb\", 1, 1)",
            null,
            "aaab"
        ],
        [
            "\"aaa\" > \"bbb\"",
            null,
            false
        ],
        [
            "\"aaa\" > x",
            new Dictionary<string, object>
            {
                ["x"] = "z",
            },
            false
        ],
        [
            "\"aaa\" < \"bbb\"",
            null,
            true
        ],
        [
            "\"aaa\" < x",
            new Dictionary<string, object>
            {
                ["x"] = "aa",
            },
            false
        ],
        [
            "\"aaa\" >= \"bbb\"",
            null,
            false
        ],
        [
            "\"aaa\" >= x",
            new Dictionary<string, object>
            {
                ["x"] = "z",
            },
            false
        ],
        [
            "\"aaa\" <= \"bbb\"",
            null,
            true
        ],
        [
            "\"aaa\" <= x",
            new Dictionary<string, object>
            {
                ["x"] = "aa",
            },
            false
        ],
        [
            "\"aaa\" <= \"aaa\"",
            null,
            true
        ],
        [
            "\"aaa\" >= \"aaa\"",
            null,
            true
        ],
        [
            "tempVariable1=2",
            new Dictionary<string, object>
            {
                ["tempVariable1"] = 2,
            },
            true
        ],
        [
            "6/2*3",
            null,
            9L
        ],
        [
            "x=\" \"",
            new Dictionary<string, object>
            {
                ["x"] = " ",
            },
            true
        ],
        [
            "x=\"\"",
            new Dictionary<string, object>
            {
                ["x"] = string.Empty,
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101=0b1001010111010110110010000000010010101110101",
            null,
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101>0b1010111010110110010000000010010101110101",
            null,
            true
        ],
        [
            "0b1001010111010110110010000000010010101110100<0b1001010111010110110010000000010010101110101",
            null,
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101>=0b1010111010110110010000000010010101110101",
            null,
            true
        ],
        [
            "0b1001010111010110110010000000010010101110100<=0b1001010111010110110010000000010010101110101",
            null,
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101<0b1010111010110110010000000010010101110101",
            null,
            false
        ],
        [
            "0b1001010111010110110010000000010010101110100>0b1001010111010110110010000000010010101110101",
            null,
            false
        ],
        [
            "0b1001010111010110110010000000010010101110101<=0b1010111010110110010000000010010101110101",
            null,
            false
        ],
        [
            "0b1001010111010110110010000000010010101110100>=0b1001010111010110110010000000010010101110101",
            null,
            false
        ],
        [
            "0b1001010111010110110011111000010010101110101=0b1001010111010110110010000000011111101110101",
            null,
            false
        ],
        [
            "x=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101!=0b1001010111010110110010000000010010101110101",
            null,
            false
        ],
        [
            "0b1001010111010110110011111000010010101110101!=0b1001010111010110110010000000011111101110101",
            null,
            true
        ],
        [
            "x!=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "0b1001010111010110110010000000010010101110101>x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110100<x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101>=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110100<=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "0b1001010111010110110010000000010010101110101<x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "0b1001010111010110110010000000010010101110100>x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "0b1001010111010110110010000000010010101110101<=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "0b1001010111010110110010000000010010101110100>=x",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "x>0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "x<0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true
        ],
        [
            "x>=0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            true
        ],
        [
            "x<=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true
        ],
        [
            "x<0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "x>0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false
        ],
        [
            "x<=0b1010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            false
        ],
        [
            "x>=0b1001010111010110110010000000010010101110101",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false
        ],
        [
            "x>=y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true
        ],
        [
            "x<=y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            true
        ],
        [
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false
        ],
        [
            "x<y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
                ["y"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110100),
            },
            false
        ],
        [
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b11111111_11111111_11111111),
                ["y"] = BitConverter.GetBytes(0b11111111_11111111),
            },
            true
        ],
        [
            "x>y",
            new Dictionary<string, object>
            {
                ["x"] = BitConverter.GetBytes(0b11111111_11111111_00000000),
                ["y"] = BitConverter.GetBytes(0b00000000_11111111_11111111),
            },
            true
        ],
        [
            "0b11111111_11111111_00000000>0b00000000_11111111_11111111",
            null,
            true
        ],
        [
            "x*(x+1)*(x+2)",
            new Dictionary<string, object>
            {
                ["x"] = 5,
            },
            210L
        ],
        [
            "tempVar1+tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5,
            },
            10L
        ],
        [
            "tempVar1+tempVar2",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5,
                ["tempVar2"] = 5D,
            },
            10D
        ],
        [
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5D,
            },
            5D
        ],
        [
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = "aaa",
            },
            "aaa"
        ],
        [
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = 5L,
            },
            5L
        ],
        [
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = true,
            },
            true
        ],
        [
            "tempVar1",
            new Dictionary<string, object>
            {
                ["tempVar1"] = BitConverter.GetBytes(0b1001010111010110110010000000010010101110101),
            },
            BitConverter.GetBytes(0b1001010111010110110010000000010010101110101)
        ],
        [
            "2.12+6.274E+1",
            null,
            64.86D
        ],
        [
            "2.12+6.274E1",
            null,
            64.86D
        ],
        [
            "2.12+627.4E-2",
            null,
            8.394D
        ],
        [
            "2.12+6.274e+1",
            null,
            64.86D
        ],
        [
            "2.12+6.274e1",
            null,
            64.86D
        ],
        [
            "2.12+627.4e-2",
            null,
            8.394D
        ],
        [
            "trim(\"   a   \")",
            null,
            "a"
        ],
        [
            "trim(x)",
            new Dictionary<string, object>
            {
                ["x"] = "   a   ",
            },
            "a"
        ],
        [
            "trim(\"abcde\", \"ade\")",
            null,
            "bc"
        ],
        [
            "trim(x, y)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["y"] = "ade",
            },
            "bc"
        ],
        [
            "trimbody(\"abcde\", \"c\")",
            null,
            "abde"
        ],
        [
            "trimbody(x, y)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["y"] = "bc",
            },
            "ade"
        ],
        [
            "replace(\"abcde\", \"c\", \"x\")",
            null,
            "abxde"
        ],
        [
            "replace(x, y, z)",
            new Dictionary<string, object>
            {
                ["x"] = "abcde",
                ["y"] = "bc",
                ["z"] = "q",
            },
            "aqde"
        ],
        [
            "round(x, 2)=2.12",
            new Dictionary<string, object>
            {
                ["x"] = 2.1247154D,
            },
            true
        ],
        [
            "round(x, 3)=2.121",
            new Dictionary<string, object>
            {
                ["x"] = 2.1247154D,
            },
            false
        ],
        [
            "0b10010101+0b11010110",
            null,
            new byte[]
            {
                0b10010101,
                0b11010110
            }
        ],
        [
            "0b10010101+x",
            new Dictionary<string, object>
            {
                ["x"] = new byte[] { (byte)0b11010110 }
            },
            new byte[]
            {
                0b10010101,
                0b11010110
            }
        ]
    ];

    private static object GenerateFuncOutOfParameterValue(object tempParameter) =>
        tempParameter switch
        {
            byte convertedValue => new Func<byte>(() => convertedValue),
            sbyte convertedValue => new Func<sbyte>(() => convertedValue),
            short convertedValue => new Func<short>(() => convertedValue),
            ushort convertedValue => new Func<ushort>(() => convertedValue),
            int convertedValue => new Func<int>(() => convertedValue),
            uint convertedValue => new Func<uint>(() => convertedValue),
            long convertedValue => new Func<long>(() => convertedValue),
            ulong convertedValue => new Func<ulong>(() => convertedValue),
            float convertedValue => new Func<float>(() => convertedValue),
            double convertedValue => new Func<double>(() => convertedValue),
            byte[] convertedValue => new Func<byte[]>(() => convertedValue),
            string convertedValue => new Func<string>(() => convertedValue),
            bool convertedValue => new Func<bool>(() => convertedValue),
            _ => throw new InvalidOperationException(),
        };

    /// <summary>
    ///     Tests the computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        using var service = new ExpressionParsingService();

        using ComputedExpression del = service.Interpret(expression);

        object result = del.Compute(parameters?.Values.ToArray() ?? []);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        using var service = new ExpressionParsingService();

        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        using ComputedExpression del = service.Interpret(expression);

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = parameter.Value;
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

#pragma warning disable IDISP001 // Dispose created. - We specifically do not want these to be disposed

    /// <summary>
    ///     Tests the cached computed expression with parameters.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSPara")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithParameters(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        ComputedExpression del = _fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        object result = del.Compute(parameters?.Values.ToArray() ?? []);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSFindr")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = _fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                var key = parameter.Key;
                object value = parameter.Value;
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }
#pragma warning restore IDISP001 // Dispose created.

    /// <summary>
    ///     Tests a computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "EPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void ComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        using var service = new ExpressionParsingService();

        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        using ComputedExpression del = service.Interpret(expression);

        if (parameters != null)
        {
            foreach (var (key, val) in parameters)
            {
                object value = GenerateFuncOutOfParameterValue(val);
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

#pragma warning disable IDISP001 // Dispose created. - We specifically do not want these to be disposed

    /// <summary>
    ///     Tests a cached computed expression with finder.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated!.
    /// </exception>
    [Theory(DisplayName = "CEPSFindrFunc")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinder(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var finder = new Mock<IDataFinder>(MockBehavior.Loose);

        ComputedExpression del = _fixture.CachedService.Interpret(expression);
        if (del == null)
        {
            throw new InvalidOperationException("No computed expression was generated!");
        }

        if (parameters != null)
        {
            foreach (var (key, val) in parameters)
            {
                object value = GenerateFuncOutOfParameterValue(val);
                _ = finder.Setup(
                    p => p.TryGetData(
                        key,
                        out value)).Returns(true);
            }
        }

        object result = del.Compute(finder.Object);

        Assert.Equal(
            expectedResult,
            result);
    }

    /// <summary>
    ///     Tests a cached computed expression with finder returning functions repeatedly.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="expectedResult">The expected result.</param>
    /// <exception cref="InvalidOperationException">
    ///     No computed expression was generated.
    /// </exception>
    [Theory(DisplayName = "CEPSFindrFuncRepeated")]
    [MemberData(nameof(ProvideDataForTheory))]
    public void CachedComputedExpressionWithFunctionFinderRepeated(
        string expression,
        Dictionary<string, object>? parameters,
        object expectedResult)
    {
        var indexLimit = DataGenerator.RandomInteger(
            3,
            5);
        for (var index = 0; index < indexLimit; index++)
        {
            var finder = new Mock<IDataFinder>(MockBehavior.Loose);

            ComputedExpression del = _fixture.CachedService.Interpret(expression);

            if (parameters != null)
            {
                foreach (var (key, val) in parameters)
                {
                    object value = GenerateFuncOutOfParameterValue(val);
                    _ = finder.Setup(
                        p => p.TryGetData(
                            key,
                            out value)).Returns(true);
                }
            }

            object result = del.Compute(finder.Object);

            Assert.Equal(
                expectedResult,
                result);
        }
    }
#pragma warning restore IDISP001 // Dispose created.
}