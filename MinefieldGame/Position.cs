namespace MinefieldGame
{
    public class Position
    {
        public char Column { get; }
        public int Row { get; }
        public bool HasMine { get; private set; }
        public bool IsRevealed { get; private set; }

        public Position(char column, int row, bool hasMine = false)
        {
            Column = column;
            Row = row;
            HasMine = hasMine;
            IsRevealed = false;
        }

        public void Reveal()
        {
            IsRevealed = true;
        }

        public void PlaceMine()
        {
            HasMine = true;
        }
    }
}
