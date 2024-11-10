namespace MinefieldGame
{
    class Program
    {
        static void Main()
        {
            const int MINE_COUNT = 15;
            const int LIFE_COUNT = 3;

            var minefield = new Minefield(MINE_COUNT);
            var gameEngine = new GameEngine(minefield, LIFE_COUNT);
            gameEngine.Start();
        }
    }
}