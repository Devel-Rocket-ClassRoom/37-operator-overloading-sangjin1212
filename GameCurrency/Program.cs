using System;
GameCurrency wallet1 = new GameCurrency(3, 50);
GameCurrency wallet2 = new GameCurrency(1, 80);

Console.WriteLine($"지갑1: {wallet1}");
Console.WriteLine($"지갑2: {wallet2}");
GameCurrency sum = wallet1 + wallet2;
Console.WriteLine($"합계: {sum}");
GameCurrency diff = wallet2 - wallet1;
Console.WriteLine($"차액: {diff}");
public struct GameCurrency
{
    public int Gold;
    public int Silver;
    public GameCurrency(int gold, int silver)
    { 
        Gold = gold;
        Silver = silver;
        if (Silver >= 100)
        {
            Gold += 1;
            Silver -= 100;
        }
    }
    public static GameCurrency operator +(GameCurrency a, GameCurrency b)
    {
        return new GameCurrency(a.Gold + b.Gold, a.Silver + b.Silver);
    }
    public static GameCurrency operator -(GameCurrency a, GameCurrency b)
    {
        
        return new GameCurrency(a.Gold - b.Gold, a.Silver - b.Silver);
        
    }


    public override string ToString()
    {
        return $"{Gold}G {Silver}S";
    }
}