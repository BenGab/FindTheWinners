namespace FindTheWinners
{
    public class TestData
    {
        public TestData(int playerId, double winAmount)
        {
            PlayerId = playerId;
            WinAmount = winAmount;
        }

        public int PlayerId { get; private set; }
        public double WinAmount { get; private set; } 
    }
}
