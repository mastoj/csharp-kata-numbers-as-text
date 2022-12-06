namespace NumbersInWords.Tests;

public class ToWordsTests
{
    [Theory]
    [InlineData(1, "ett")]
    [InlineData(2, "två")]
    [InlineData(3, "tre")]
    [InlineData(4, "fyra")]
    [InlineData(5, "fem")]
    [InlineData(6, "sex")]
    [InlineData(7, "sju")]
    [InlineData(8, "åtta")]
    [InlineData(9, "nio")]
    [InlineData(10, "tio")]
    [InlineData(11, "elva")]
    [InlineData(12, "tolv")]
    [InlineData(13, "tretton")]
    [InlineData(14, "fjorton")]
    [InlineData(15, "femton")]
    [InlineData(16, "sexton")]
    [InlineData(17, "sjutton")]
    [InlineData(18, "arton")]
    [InlineData(19, "nitton")]
    public void ShouldTranslateAllNumbersTo19(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }

    [Theory]
    [InlineData(21, "tjugoen")]
    [InlineData(32, "trettiotvå")]
    [InlineData(43, "förtiotre")]
    [InlineData(54, "femtiofyra")]
    [InlineData(65, "sextiofem")]
    [InlineData(76, "sjuttiosex")]
    [InlineData(87, "åttiosju")]
    [InlineData(98, "nittioåtta")]
    public void ShouldTranslateAllNumbersLessThan100(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }

    [Theory]
    [InlineData(100, "etthundra")]
    [InlineData(201, "tvåhundraen")]
    [InlineData(313, "trehundratretton")]
    [InlineData(424, "fyrahundratjugofyra")]
    [InlineData(535, "femhundratrettiofem")]
    [InlineData(998, "niohundranittioåtta")]
    public void ShouldTranslateAllNumbersLessThan1000(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }

    [Theory]
    [InlineData(20001, "tjugotusenen")]
    [InlineData(10121, "tiotusenetthundratjugoen")]
    [InlineData(300001, "trehundratusenen")]
    [InlineData(770354, "sjuhundrasjuttiotusentrehundrafemtiofyra")]
    [InlineData(999999, "niohundranittioniotusenniohundranittionio")]
    public void ShouldTranslateNumbersLessThan1000000(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }

    [Theory]
    [InlineData(1000000, "enmillion")]
    [InlineData(1000001, "enmillionen")]
    [InlineData(2345678, "tvåmillionertrehundraförtiofemtusensexhundrasjuttioåtta")]
    public void ShouldTranslateNumbersInTheMillions(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }

    [Theory]
    [InlineData(1000000000, "enmiljard")]
    [InlineData(520000000032, "femhundratjugomiljardertrettiotvå")]
    public void ShouldTranslateNumbersInTheBillions(long value, string expected)
    {
        Assert.Equal(expected, value.ToWords());
    }
}