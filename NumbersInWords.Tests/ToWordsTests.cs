namespace NumbersInWords.Tests;

public class ToWordsTests
{
    [Fact]
    public void ShouldTranslateOne()
    {
        Assert.Equal("ett", 1L.ToWords());
    }

    [Fact]
    public void ShouldTranslateAllNumbersTo19()
    {
        var expected = new[]{
            "ett", "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio", "elva", "tolv", "tretton", "fjorton", "femton", "sexton", "sjutton", "arton", "nitton"
        };
        for (long i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], (i + 1).ToWords());
        }
    }

    [Fact]
    public void ShouldTranslateAllNumbersLessThan100()
    {
        var expected = new Dictionary<long, string>{
            { 21, "tjugoen" },
            { 32, "trettiotvå" },
            { 43, "förtiotre" },
            { 54, "femtiofyra" },
            { 65, "sextiofem" },
            { 76, "sjuttiosex" },
            { 87, "åttiosju" },
            { 98, "nittioåtta" },
        };
        foreach (var item in expected)
        {
            Assert.Equal(item.Value, item.Key.ToWords());
        }
    }

    [Fact]
    public void ShouldTranslateAllNumbersLessThan1000()
    {
        var expected = new Dictionary<long, string>{
            { 100, "etthundra" },
            { 201, "tvåhundraen" },
            { 313, "trehundratretton" },
            { 424, "fyrahundratjugofyra" },
            { 535, "femhundratrettiofem" },
            { 998, "niohundranittioåtta" },
        };
        foreach (var item in expected)
        {
            Assert.Equal(item.Value, item.Key.ToWords());
        }
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