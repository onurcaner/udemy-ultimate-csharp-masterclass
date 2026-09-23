namespace Section15_GuessingGame.Game;

public record GuessingGuessingGameOptions : IGuessingGameOptions
{
    public required int MaxDiceNumber { get; init; }
    public required int MinDiceNumber { get; init; }
    public required int MaxAllowedTurns { get; init; }
}