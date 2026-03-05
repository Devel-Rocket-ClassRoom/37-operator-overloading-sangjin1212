using System;
GameTime t1 = new GameTime(1, 30, 45);
GameTime t2 = new GameTime(0, 45, 30);

Console.WriteLine($"시간1: {t1}");
Console.WriteLine($"시간2: {t2}");

GameTime sum = t1 + t2;
Console.WriteLine($"합계: {sum}");

GameTime diff = t2 - t1;
Console.WriteLine($"차이: {diff}");
struct GameTime
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    public GameTime(int hours, int minutes, int seconds)
    { 
        Hours = hours; Minutes = minutes; Seconds = seconds;

        if (seconds >= 60)
        {
            Minutes += 1;
            Seconds -= 60;
        }
        if (minutes >= 60)
        {
            Hours += 1;
            Minutes -= 60;
        }
    }
    public static GameTime operator +(GameTime a, GameTime b)
    {
        return new GameTime(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);
    }
    public static GameTime operator -(GameTime a, GameTime b)
    {

        return new GameTime(a.Hours - b.Hours, a.Minutes - b.Minutes, a.Seconds - b.Seconds);

    }

    public override string ToString()
    {
        return $"{Hours}h {Minutes}m {Seconds}s";
    }
}