using NumberAutomaton;

namespace NumberAutomaton.Tests;

public class NumberRecognitionTests
{
    private readonly Dfa _dfa = NumberDfa.Build();

    [Theory]
    [InlineData("0")]
    [InlineData("123")]
    [InlineData("-45")]
    [InlineData("+7")]
    [InlineData("000")]
    [InlineData("3.14")]
    [InlineData("-0.5")]
    [InlineData(".75")]
    [InlineData("12.")]
    [InlineData("+.5")]
    [InlineData("9.0")]
    public void ValidNumbers_AreAccepted(string input)
    {
        Assert.True(_dfa.Accepts(input));
    }

    [Theory]
    [InlineData("")]
    [InlineData("+")]
    [InlineData("-")]
    [InlineData(".")]
    [InlineData("+.")]
    [InlineData("-.")]
    [InlineData("1.2.3")]
    [InlineData("1..2")]
    [InlineData("1-2")]
    [InlineData("12a")]
    [InlineData(" 12")]
    [InlineData("1 2")]
    [InlineData("--5")]
    public void InvalidNumbers_AreRejected(string input)
    {
        Assert.False(_dfa.Accepts(input));
    }

}
