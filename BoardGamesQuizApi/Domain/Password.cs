namespace BoardGamesQuizApi.Domain;
public class Password
{
    public int Value { get; }
    private Password(int v) => Value = v;

    public static bool TryParse(string raw, out Password? p)
    {
        p = null;
        return int.TryParse(raw, out int n) &&
               n is >= 100 and <= 999 &&
               (p = new Password(n)) is not null;
    }
}