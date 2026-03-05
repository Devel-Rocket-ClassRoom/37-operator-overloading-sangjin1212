using System;
GameCurrency wallet1 = new GameCurrency(3, 50);
GameCurrency wallet2 = new GameCurrency(1, 80);

Console.WriteLine($"지갑1: {wallet1}");
Console.WriteLine($"지갑2: {wallet2}");
GameCurrency sum = wallet1 + wallet2;
Console.WriteLine($"합계: {sum}");
GameCurrency diff = wallet2 - wallet1;
Console.WriteLine($"차액: {diff}");
Console.WriteLine($"지갑1 == 지갑2: {wallet1 == wallet2}");
Console.WriteLine($"지갑1 != 지갑2: {wallet1 != wallet2}");
Console.WriteLine($"지갑1 > 지갑2: {wallet1 > wallet2}");
Console.WriteLine($"지갑1 < 지갑2: {wallet1 < wallet2}");
GameCurrency wallet3 = new GameCurrency(0, 250);
Console.WriteLine($"250S 정규화: {wallet3}");
Console.WriteLine($"지갑1 총 Silver: {wallet1.GetTotalSilver()}");

public struct GameCurrency
{
    public int Gold;
    public int Silver;
    public GameCurrency(int gold, int silver)
    { 
        Gold = gold;
        Silver = silver;
        while (Silver >= 100)
        {
            Gold += 1;
            Silver -= 100;
        }
        while (Silver < 0)
        {
            Gold -= 1;
            Silver += 100;
        }
    }
    public static GameCurrency operator +(GameCurrency a, GameCurrency b)
    {
        return new GameCurrency(a.Gold + b.Gold, a.Silver + b.Silver);
    }
    public static GameCurrency operator -(GameCurrency a, GameCurrency b)
    {

        int sum1 = a.Gold * 100 + a.Silver;
        int sum2 = b.Gold * 100 + b.Silver;
        int result = sum1 - sum2;
        if (result < 0)
        {
            return new GameCurrency(0, 0);
        }
        return new GameCurrency(0, result);
    }
    public static bool operator ==(GameCurrency a, GameCurrency b)
    { 
        return a.Gold == b.Gold && a.Silver == b.Silver;
    }
    public static bool operator !=(GameCurrency a, GameCurrency b)
    { 
        return !(a == b);
    }
    public static bool operator <(GameCurrency a, GameCurrency b)
    {
        return a.Gold < b.Gold && a.Silver < b.Silver;
    }
    public static bool operator >(GameCurrency a, GameCurrency b)
    {
        return a.Gold > b.Gold && a.Silver < b.Silver;

    }

    public int GetTotalSilver()
    {
        return Gold * 100 + Silver;
    }
    public override bool Equals(object obj)
    {
        if (!(obj is GameCurrency))
            return false;

        GameCurrency other = (GameCurrency)obj;
        return Gold == other.Gold && Silver == other.Silver;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Gold, Silver);
    }

    public override string ToString()
    {
        return $"{Gold}G {Silver}S";
    }
}