using Section15_GuessingGame.Game;

namespace Section15_GuessingGame.UserInterface;

public interface IUserInterface
{
    public int ReadInputNumber();

    public void DisplayWelcome();
    public void DisplayRules(IGuessingGameOptions guessingGameOptions);
    public void DisplayRemainingAttempts(int attempts);
    public void DisplayCorrectGuessNotice();
    public void DisplayWrongGuessNotice();
    public void DisplayVictory();
    public void DisplayDefeat();
}