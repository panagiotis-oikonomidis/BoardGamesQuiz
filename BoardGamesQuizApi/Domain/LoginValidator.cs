namespace BoardGamesQuizApi.Domain;
public static class LoginValidator
{
    private static readonly int[] Numbers =
        {10,20,30,40,50,60,70,80,90,100,110,120,130,140,150};

    public static bool IsValid(UserName u, Password p)
    {
        int threshold = Numbers.Take(u.Length).Sum();
        return p.Value < threshold;
    }
}