namespace MinefieldGame.Tests
{
    public class GameEngineTests
    {
        [Fact]
        public void Constructor_InitializesGameEngineCorrectly()
        {
            var minefield = new Minefield(10);
            var gameEngine = new GameEngine(minefield, 3);

            Assert.Equal('A', minefield.StartPosition.Column);
            Assert.Equal(1, minefield.StartPosition.Row);
            Assert.False(minefield.StartPosition.HasMine);
            Assert.Equal(3, gameEngine.LifeCount);
            Assert.Equal(0, gameEngine.MoveCount);  // No moves made yet
        }

        [Fact]
        public void Move_ChangesPositionCorrectly_WhenValidMove()
        {
            var minefield = new Minefield(10);
            var gameEngine = new GameEngine(minefield, 3);

            // Move right from A1 to B1
            gameEngine.Move(1, 0);

            Assert.Equal('B', gameEngine.CurrentPosition.Column);
            Assert.Equal(1, gameEngine.CurrentPosition.Row);
            Assert.Equal(1, gameEngine.MoveCount);  // Move count should increase by 1
        }

        [Fact]
        public void Move_ShouldDecreaseLives_WhenMineIsHit()
        {
            var minefield = new Minefield(1);
            var gameEngine = new GameEngine(minefield, 3);

            // Place mine on B1 and move right to hit it
            minefield.GetPosition('B', 1)!.PlaceMine();
            gameEngine.Move(1, 0);

            Assert.True(gameEngine.CurrentPosition.HasMine);  // Current position should have a mine
            Assert.Equal(2, gameEngine.LifeCount);  // Should lose 1 life
        }

        [Fact]
        public void Move_HandlesInvalidMove_OutOfBounds()
        {
            var minefield = new Minefield(10);
            var gameEngine = new GameEngine(minefield, 3);

            // Try to move out of bounds (e.g., left of A1)
            gameEngine.Move(-1, 0);

            // Position should not change, and move count should not increase
            Assert.Equal('A', gameEngine.CurrentPosition.Column);
            Assert.Equal(1, gameEngine.CurrentPosition.Row);
            Assert.Equal(0, gameEngine.MoveCount);
        }

        [Fact]
        public void GameWon_ShouldEndGame_WhenPlayerReachesRow8()
        {
            var minefield = new Minefield(1);
            var gameEngine = new GameEngine(minefield, 3);

            // Move up to row 8
            for (int i = 0; i < 7; i++)
            {
                gameEngine.Move(0, 1);
            }

            Assert.Equal(8, gameEngine.CurrentPosition.Row);  // Should be in row 8
            Assert.True(gameEngine.LifeCount > 0);  // Game should be won
        }

        [Fact]
        public void Move_ShouldNotDecreaseLives_WhenPositionIsAlreadyRevealed()
        {
            var minefield = new Minefield(1);
            var gameEngine = new GameEngine(minefield, 3);

            // Place mine on B1 and move right to hit it
            minefield.GetPosition('B', 1)!.PlaceMine();
            gameEngine.Move(1, 0);

            var initialLifeCount = gameEngine.LifeCount;

            gameEngine.Move(-1, 0);
            gameEngine.Move(1, 0);  // Move back to B1

            Assert.Equal(initialLifeCount, gameEngine.LifeCount);  // Additional life should not be lost

        }
    }
}