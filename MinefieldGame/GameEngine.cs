namespace MinefieldGame
{
    public class GameEngine
    {
        private readonly Minefield _minefield;
        private Position _currentPosition;
        private int _moveCount = 0;
        private int _lifeCount;

        public Position CurrentPosition => _currentPosition;
        public int MoveCount => _moveCount;
        public int LifeCount => _lifeCount;

        public GameEngine(Minefield minefield, int lifeCount)
        {
            _minefield = minefield;
            _currentPosition = minefield.StartPosition;
            _currentPosition.Reveal();
            _lifeCount = lifeCount;
        }

        public void Start()
        {
            Console.WriteLine("New game started!");
            Console.WriteLine("Use arrow keys to move up, down, left or right.\n");

            Console.WriteLine($"Current position: {_currentPosition.Column}{_currentPosition.Row}, Lives: {_lifeCount}, Moves taken: {_moveCount}");

            while (_lifeCount > 0)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Move(0, 1);
                        break;
                    case ConsoleKey.DownArrow:
                        Move(0, -1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(1, 0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid input! Please use arrow keys to move up, down, left or right.");
                        break;
                }

                if (_currentPosition.Row == 8)
                {
                    Console.WriteLine($"\nCongratulations! You crossed the board and won the game!\nFinal score: {_moveCount}");
                    return;
                }
            }

            Console.WriteLine("\nGame over! You've lost all lives.");
        }

        public void Move(int columnDelta, int rowDelta)
        {
            var newColumn = (char)(_currentPosition.Column + columnDelta);
            var newRow = _currentPosition.Row + rowDelta;

            var newPosition = _minefield.GetPosition(newColumn, newRow);

            if (newPosition == null)
            {
                Console.WriteLine("Move is out of bounds!");
                return;
            }

            _currentPosition = newPosition;
            _moveCount++;

            if (!_currentPosition.IsRevealed)
            {
                if (_currentPosition.HasMine)
                {
                    _lifeCount--;
                    Console.WriteLine("Mine hit! You lost a life.");
                }

                _currentPosition.Reveal();
            }

            Console.WriteLine($"Current position: {_currentPosition.Column}{_currentPosition.Row}, Lives: {_lifeCount}, Moves taken: {_moveCount}");
        }
    }
}
