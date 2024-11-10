namespace MinefieldGame
{
    public class Minefield
    {
        private readonly List<Position> _positions;
        public Position StartPosition => GetPosition('A', 1)!;

        public Minefield(int mineCount)
        {
            _positions = GeneratePositions(mineCount);
        }

        private static List<Position> GeneratePositions(int mineCount)
        {
            var positions = new List<Position>();
            var random = new Random();

            for (char col = 'A'; col <= 'H'; col++)
            {
                for (int row = 1; row <= 8; row++)
                {
                    positions.Add(new Position(col, row));
                }
            }

            var shuffledPositions = positions.Skip(1).OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < mineCount; i++)
            {
                shuffledPositions[i].PlaceMine();
            }

            return positions;
        }

        public Position? GetPosition(char column, int row)
        {
            return _positions.Find(p => p.Column == column && p.Row == row);
        }

        public int GetPositionCount() => _positions.Count;

        public List<Position> GetAllPositions() => _positions;
    }
}
