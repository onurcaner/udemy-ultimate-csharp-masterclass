namespace Section15_GuessingGame.RandomNumberGenerator;

internal class BasicRandomNumberGenerator : IRandomNumberGenerator
{
    public int Roll(int min, int max)
    {
        return new Random().Next(min, max + 1);
    }
}