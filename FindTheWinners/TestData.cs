namespace FindTheWinners
{
    public class TestData
    {
        public TestData(int playerId, decimal winAmount)
        {
            PlayerId = playerId;
            WinAmount = winAmount;
        }

        public int PlayerId { get; private set; }
        public decimal WinAmount { get; private set; } 
    }
}
