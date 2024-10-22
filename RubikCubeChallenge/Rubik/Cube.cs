using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Printer;

namespace RubikCubeChallenge.Rubik
{
    public class Cube : ICube
    {
        private readonly IPrinter? printer;
        private readonly ICubeFaceFactory cubeFaceFactory;

        public Cube(ICubeFaceFactory cubeFaceFactory)
        {
            ArgumentNullException.ThrowIfNull(cubeFaceFactory, nameof(cubeFaceFactory)); 
            this.cubeFaceFactory = cubeFaceFactory;

            Reset();
            ArgumentNullException.ThrowIfNull(Front, nameof(Front));
            ArgumentNullException.ThrowIfNull(Left, nameof(Left));
            ArgumentNullException.ThrowIfNull(Right, nameof(Right));
            ArgumentNullException.ThrowIfNull(Down, nameof(Down));
            ArgumentNullException.ThrowIfNull(Back, nameof(Back));
            ArgumentNullException.ThrowIfNull(Up, nameof(Up));
        }

        public Cube(IPrinter printer, ICubeFaceFactory cubeFaceFactory) : this(cubeFaceFactory)
        {
            ArgumentNullException.ThrowIfNull(printer, nameof(printer));

            this.printer = printer;
        }

        public void Reset()
        {
            Front = cubeFaceFactory.CreateCubeFace(Tile.Green);
            Left = cubeFaceFactory.CreateCubeFace(Tile.Orange);
            Right = cubeFaceFactory.CreateCubeFace(Tile.Red);
            Up = cubeFaceFactory.CreateCubeFace(Tile.White);
            Down = cubeFaceFactory.CreateCubeFace(Tile.Yellow);
            Back = cubeFaceFactory.CreateCubeFace(Tile.Blue);
        }

        public void Print()
        {
            ArgumentNullException.ThrowIfNull(printer, nameof(printer));

            printer.Print(this);
        }

        public ICubeFace Front { get; set; }
        public ICubeFace Back { get; set; }
        public ICubeFace Up { get; set; }
        public ICubeFace Down { get; set; }
        public ICubeFace Left { get; set; }
        public ICubeFace Right { get; set; }

        public void B_()
        {
            // back face anticlockwise

            Back.RotateFaceAntiClockwise();
            var replacedTiles = Up.GetEdgeTiles(AbsoluteDirection.Top);
            replacedTiles = Right.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
            replacedTiles = Down.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
            replacedTiles = Left.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
            replacedTiles = Up.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
        }

        public void D_()
        {
            // down face anticlockwise

            Down.RotateFaceAntiClockwise();
            var replacedTiles = Front.GetEdgeTiles(AbsoluteDirection.Down);
            replacedTiles = Left.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
            replacedTiles = Back.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
            replacedTiles = Right.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
            replacedTiles = Front.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
        }

        public void F()
        {
            // front rotate clockwise 

            Front.RotateFaceClockwise();
            var replacedTiles = Left.GetEdgeTiles(AbsoluteDirection.Right);
            replacedTiles = Up.ReplaceEdge(AbsoluteDirection.Down, replacedTiles);
            replacedTiles = Right.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
            replacedTiles = Down.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
            replacedTiles = Left.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
        }

        public void L()
        {
            // left rotate clockwise 

            Left.RotateFaceClockwise();
            var replacedTiles = Up.GetEdgeTiles(AbsoluteDirection.Left);
            replacedTiles = Front.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
            replacedTiles = Down.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
            replacedTiles = Back.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
            replacedTiles = Up.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
        }

        public void R_()
        {
            // right face anticlockwise

            Right.RotateFaceAntiClockwise();
            var replacedTiles = Back.GetEdgeTiles(AbsoluteDirection.Left);
            replacedTiles = Up.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
            replacedTiles = Front.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
            replacedTiles = Down.ReplaceEdge(AbsoluteDirection.Right, replacedTiles);
            replacedTiles = Back.ReplaceEdge(AbsoluteDirection.Left, replacedTiles);
        }

        public void U()
        {
            // up face clockwise

            Up.RotateFaceClockwise();
            var replacedTiles = Left.GetEdgeTiles(AbsoluteDirection.Top);
            replacedTiles = Back.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
            replacedTiles = Right.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
            replacedTiles = Front.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
            replacedTiles = Left.ReplaceEdge(AbsoluteDirection.Top, replacedTiles);
        }
    }
}
