namespace NumbersInWords;
public static class NumberExtensions
{

    private static Dictionary<long, string> simpleNumberLookup = new Dictionary<long, string>
    {
        { 1,"ett" },
        { 2,"två" },
        { 3,"tre" },
        { 4,"fyra" },
        { 5,"fem" },
        { 6,"sex" },
        { 7,"sju" },
        { 8,"åtta" },
        { 9,"nio" },
        { 10,"tio" },
        { 11,"elva" },
        { 12,"tolv" },
        { 13,"tretton" },
        { 14,"fjorton" },
        { 15,"femton" },
        { 16,"sexton" },
        { 17,"sjutton" },
        { 18,"arton" },
        { 19,"nitton" },
        { 20,"tjugo" },
        { 30,"trettio" },
        { 40,"förtio" },
        { 50,"femtio" },
        { 60,"sextio" },
        { 70,"sjuttio" },
        { 80,"åttio" },
        { 90,"nittio" },
    };

    public static string ToWords(this long number, bool useEn = false) => number switch
    {
        _ when number == 1 && useEn => "en",
        _ when simpleNumberLookup.ContainsKey(number) => simpleNumberLookup[number],
        _ when number < 100 => ToWordsLessThan100(number),
        _ when number < 1000 => HandleLargeNumber(number, 100, (_) => "hundra"),
        _ when number < 1_000_000 => HandleLargeNumber(number, 1_000, (_) => "tusen"),
        _ when number < 1_000_000_000 => HandleLargeNumber(number, 1_000_000, (part) => part == 1 ? "million" : "millioner", true),
        _ when number < 1_000_000_000_000_000_000 => HandleLargeNumber(number, 1_000_000_000, (part) => part == 1 ? "miljard" : "miljarder", true),
        _ => throw new ArgumentException("Number too large")
    };

    private static string HandleLargeNumber(long number, long divisor, Func<long, string> unit, bool useEn = false)
    {
        var part = number / divisor;
        var remainder = number % divisor;
        var partValue = part.ToWords(useEn) + unit(part);
        if (remainder == 0)
        {
            return partValue;
        }
        return partValue + remainder.ToWords(true);
    }

    private static string ToWordsLessThan100(long number)
    {
        var tensPart = number / 10 * 10;
        var onesPart = number % 10;
        var onesValue = onesPart > 0 ? onesPart.ToWords(true) : "";
        return tensPart.ToWords() + onesValue;
    }
}
