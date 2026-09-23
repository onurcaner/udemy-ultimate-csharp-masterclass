using Section15_GuessingGame.RandomNumberGenerator;
using Section15_GuessingGame.UserInterface;

namespace Section15_GuessingGame.Game;

public class GuessingGame
{
    private readonly IGuessingGameOptions _guessingGameOptions;
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly IUserInterface _userInterface;

    public GuessingGame(
        IGuessingGameOptions guessingGameOptions,
        IRandomNumberGenerator randomNumberGenerator,
        IUserInterface userInterface
    )
    {
        this._guessingGameOptions = guessingGameOptions;
        this._randomNumberGenerator = randomNumberGenerator;
        this._userInterface = userInterface;
    }

    public bool Play()
    {
        this._userInterface.DisplayWelcome();
        this._userInterface.DisplayRules(this._guessingGameOptions);

        GuessingGameState guessingGameState = new()
        {
            Status = GameStatus.Playing,
            LeftAttempts = this._guessingGameOptions.MaxAllowedTurns,
            TargetNumber =
                this._randomNumberGenerator.Roll(this._guessingGameOptions.MinDiceNumber,
                    this._guessingGameOptions.MaxDiceNumber)
        };

        while (guessingGameState.Status == GameStatus.Playing)
        {
            guessingGameState = this.GuessOnce(guessingGameState);
        }

        if (guessingGameState.Status == GameStatus.Victory)
        {
            this._userInterface.DisplayVictory();
        }
        else
        {
            this._userInterface.DisplayDefeat();
        }

        return guessingGameState.Status == GameStatus.Victory;
    }

    private GuessingGameState GuessOnce(GuessingGameState guessingGameState)
    {
        this._userInterface.DisplayRemainingAttempts(guessingGameState.LeftAttempts);
        int guessedNumber = this._userInterface.ReadInputNumber();
        bool wasLastTurn = guessingGameState.LeftAttempts == 1;

        if (guessedNumber == guessingGameState.TargetNumber)
        {
            this._userInterface.DisplayCorrectGuessNotice();
            return guessingGameState with
            {
                Status = GameStatus.Victory,
                LeftAttempts = guessingGameState.LeftAttempts - 1
            };
        }

        this._userInterface.DisplayWrongGuessNotice();
        return guessingGameState with
        {
            Status = wasLastTurn ? GameStatus.Defeat : GameStatus.Playing,
            LeftAttempts = guessingGameState.LeftAttempts - 1
        };
    }
}