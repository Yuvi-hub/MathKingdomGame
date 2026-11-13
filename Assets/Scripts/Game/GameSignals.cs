using System;
public static class GameSignals
{
    public static event Action<int> ScoreChanged;
    public static event Action<string> GameFinished;
    public static void Score(int value) => ScoreChanged?.Invoke(value);
    public static void Finish(string message) => GameFinished?.Invoke(message);
}
