namespace Section15_GuessingGame.Game;

internal record GuessingGameState
{
    public required GameStatus Status { get; init; }
    public required int LeftAttempts { get; init; }
    public required int TargetNumber { get; init; }
}