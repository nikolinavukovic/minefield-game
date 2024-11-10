namespace MinefieldGame.Tests
{
    public class PositionTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var position = new Position('A', 1);

            Assert.Equal('A', position.Column);
            Assert.Equal(1, position.Row);
            Assert.False(position.HasMine);
            Assert.False(position.IsRevealed);
        }

        [Fact]
        public void Reveal_SetsIsRevealedToTrue()
        {
            var position = new Position('A', 1);

            position.Reveal();

            Assert.True(position.IsRevealed);
        }

        [Fact]
        public void PlaceMine_SetsHasMineToTrue()
        {
            var position = new Position('A', 1);

            position.PlaceMine();

            Assert.True(position.HasMine);
        }
    }
}