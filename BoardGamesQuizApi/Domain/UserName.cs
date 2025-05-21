using System.Text.RegularExpressions;

namespace BoardGamesQuizApi.Domain;
public class UserName
{
    private static readonly Regex Rx = new("^[a-z]{1,15}$", RegexOptions.Compiled);
    public string Value { get; }
    public int Length => Value.Length;
    private UserName(string v) => Value = v;

    public static bool TryParse(string raw, out UserName? u)
    {
        bool ok = Rx.IsMatch(raw) && raw.Count("aeiou".Contains) >= 2;
        u = ok ? new UserName(raw) : null;
        return ok;
    }
}
