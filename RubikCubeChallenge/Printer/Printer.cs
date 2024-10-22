using RubikCubeChallenge.Abstraction;

namespace RubikCubeChallenge.Printer
{
    internal class Printer : IPrinter
    {
        private void writeAt(Tile tile, int x, int y, int startCol, int startRow)
        {
            try
            {
                Console.SetCursorPosition(startCol + x, startRow + y);
                Console.BackgroundColor = Console.ForegroundColor = getColorFromTile(tile);
                Console.Write("X");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private ConsoleColor getColorFromTile(Tile tile)
        {
            switch(tile)
            {
                case Tile.Orange:
                    return ConsoleColor.Magenta;
                case Tile.Red:
                    return ConsoleColor.Red;
                case Tile.Green:
                    return ConsoleColor.Green;
                case Tile.Blue:
                    return ConsoleColor.Blue;
                case Tile.Yellow:
                    return ConsoleColor.Yellow;
                case Tile.White:
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.Black;
            }
        }

        void printCubeFace(ICubeFace cubeFace, int startCol, int startRow)
        {
            var tilesToPrint = cubeFace.GetTiles();
            for(int y = 0, i = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++, i++)
                {
                    writeAt(tilesToPrint[i], x, y, startCol, startRow);
                }
            }
        }

        void IPrinter.Print(ICube cube)
        {
            Console.Clear();

            printCubeFace(cube.Up, 3, 0);
            printCubeFace(cube.Left, 0, 3);
            printCubeFace(cube.Front, 3, 3);
            printCubeFace(cube.Right, 6, 3);
            printCubeFace(cube.Back, 9, 3);
            printCubeFace(cube.Down, 3, 6);

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
