namespace Section15_GuessingGame.Game;

public interface IGuessingGameOptions
{
    public int MaxDiceNumber { get; }
    public int MinDiceNumber { get; }
    public int MaxAllowedTurns { get; }
}