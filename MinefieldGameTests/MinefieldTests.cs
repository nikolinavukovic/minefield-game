using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinefieldGame;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MinefieldTests
{
    [TestClass] // Marking the class as containing unit tests
    public class PositionTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            char column = 'A';
            int row = 1;

            // Act
            Position position = new Position(column, row);

            // Assert
            Assert.AreEqual(column, position.Column);
            Assert.AreEqual(row, position.Row);
            Assert.IsFalse(position.HasMine); // Default is false
            Assert.IsFalse(position.IsRevealed); // Default is false
        }

        [TestMethod]
        public void PlaceMine_ShouldSetHasMineToTrue()
        {
            // Arrange
            Position position = new Position('B', 2);

            // Act
            position.PlaceMine();

            // Assert
            Assert.IsTrue(position.HasMine); // After calling PlaceMine(), HasMine should be true
        }

        [TestMethod]
        public void Reveal_ShouldSetIsRevealedToTrue()
        {
            // Arrange
            Position position = new Position('C', 3);

            // Act
            position.Reveal();

            // Assert
            Assert.IsTrue(position.IsRevealed); // After calling Reveal(), IsRevealed should be true
        }

        [TestMethod]
        public void PlaceMine_AfterReveal_ShouldNotChangeHasMine()
        {
            // Arrange
            Position position = new Position('E', 5);
            position.Reveal();

            // Act
            position.PlaceMine();

            // Assert
            Assert.IsTrue(position.HasMine); // Mine should still be placed after Reveal
            Assert.IsTrue(position.IsRevealed); // Reveal status remains true
        }

        [TestMethod]
        public void MultiplePositions_ShouldBeIndependent()
        {
            // Arrange
            Position position1 = new Position('F', 6);
            Position position2 = new Position('F', 6); // Same coordinates, different instance

            // Act
            position1.Reveal();
            position2.PlaceMine();

            // Assert
            Assert.IsTrue(position1.IsRevealed); // position1 should be revealed
            Assert.IsTrue(position2.HasMine); // position2 should have a mine
            Assert.IsFalse(position1.HasMine); // position1 should not have a mine
            Assert.IsFalse(position2.IsRevealed); // position2 should not be revealed
        }

        [TestMethod]
        public void Constructor_ShouldHandleEdgeCaseCoordinates()
        {
            // Arrange
            Position position1 = new Position('A', 1);
            Position position2 = new Position('Z', 100);

            // Act & Assert
            Assert.AreEqual('A', position1.Column);
            Assert.AreEqual(1, position1.Row);
            Assert.AreEqual('Z', position2.Column);
            Assert.AreEqual(100, position2.Row);
        }

        [TestMethod]
        public void Reveal_ShouldNotAffectHasMine()
        {
            // Arrange
            Position position = new Position('G', 7, true); // Position with mine

            // Act
            position.Reveal();

            // Assert
            Assert.IsTrue(position.HasMine); // The position should still have a mine after revealing
            Assert.IsTrue(position.IsRevealed); // The position should now be revealed
        }

        [TestMethod]
        public void Reveal_ShouldNotAllowMultipleReveals()
        {
            // Arrange
            Position position = new Position('H', 8);

            // Act
            position.Reveal();
            position.Reveal(); // Second reveal, should have no effect

            // Assert
            Assert.IsTrue(position.IsRevealed); // Should still be revealed after second call
        }
    }
}
