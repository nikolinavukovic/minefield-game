namespace MinefieldGame.Tests
{
    public class MinefieldTests
    {
        [Fact]
        public void Constructor_CreatesExpectedNumberOfPositions()
        {
            var minefield = new Minefield(10);

            // Check that there are 64 positions in an 8x8 grid
            Assert.Equal(64, minefield.GetPositionCount());
        }

        [Fact]
        public void StartPosition_IsInBottomLeftCornerAndDoesNotHaveMine()
        {
            var minefield = new Minefield(10);

            Assert.Equal('A', minefield.StartPosition.Column);
            Assert.Equal(1, minefield.StartPosition.Row);
            Assert.False(minefield.StartPosition.HasMine);
        }

        [Fact]
        public void MineCount_IsCorrectAfterInitialization()
        {
            int mineCount = 10;
            var minefield = new Minefield(mineCount);

            int actualMineCount = minefield.GetAllPositions().Count(p => p.HasMine);

            Assert.Equal(mineCount, actualMineCount);
        }
    }
}
