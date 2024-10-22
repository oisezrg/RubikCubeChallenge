using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Utilities;

namespace RubikCubeChallenge.Rubik
{
    public class CubeFace : ICubeFace
    {
        public CubeFace() { }
        public CubeFace(Tile tile)
        {
            Require.NotNull(tile, nameof(tile));

            LeftTop = CenterTop = RightTop = LeftCenter = CenterCenter = RightCenter = LeftBottom = CenterBottom = RightBottom = tile;
        }
        public Tile LeftTop { get; set; }
        public Tile CenterTop { get; set; }
        public Tile RightTop { get; set; }
        public Tile LeftCenter { get; set; }
        public Tile CenterCenter { get; set; }
        public Tile RightCenter { get; set; }
        public Tile LeftBottom { get; set; }
        public Tile CenterBottom { get; set; }
        public Tile RightBottom { get; set; }

        public Tile[] GetTiles()
        {
            return new[] { LeftTop, CenterTop, RightTop, LeftCenter, CenterCenter, RightCenter, LeftBottom, CenterBottom, RightBottom };
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            return GetTiles().SequenceEqual(((CubeFace)obj).GetTiles());
        }

        public void RotateFaceClockwise()
        {
            var clone = (CubeFace)MemberwiseClone();
            LeftTop = clone.LeftBottom;
            CenterTop = clone.LeftCenter;
            RightTop = clone.LeftTop;
            LeftCenter = clone.CenterBottom;
            RightCenter = clone.CenterTop;
            LeftBottom = clone.RightBottom;
            CenterBottom = clone.RightCenter;
            RightBottom = clone.RightTop;
        }

        public void RotateFaceAntiClockwise()
        {
            var clone = (CubeFace)MemberwiseClone();
            LeftTop = clone.RightTop;
            CenterTop = clone.RightCenter;
            RightTop = clone.RightBottom;
            LeftCenter = clone.CenterTop;
            LeftBottom = clone.LeftTop;
            CenterBottom = clone.LeftCenter;
            RightBottom = clone.LeftBottom;
            RightCenter = clone.CenterBottom;
        }

        public Tile[] ReplaceEdge(AbsoluteDirection edgeDirection, Tile[] incomingTiles)
        {
            Require.NotNull(edgeDirection, nameof(edgeDirection));
            Require.NotNull(incomingTiles, nameof(incomingTiles));
            Require.Equals(incomingTiles.Length, 3, nameof(incomingTiles));


            Tile[] result = GetEdgeTiles(edgeDirection);
            switch (edgeDirection)
            {
                case AbsoluteDirection.Top:
                    LeftTop = incomingTiles[2];
                    CenterTop = incomingTiles[1];
                    RightTop = incomingTiles[0];
                    break;
                case AbsoluteDirection.Down:
                    LeftBottom = incomingTiles[0];
                    CenterBottom = incomingTiles[1];
                    RightBottom = incomingTiles[2];
                    break;
                case AbsoluteDirection.Left:
                    LeftTop = incomingTiles[0];
                    LeftCenter = incomingTiles[1];
                    LeftBottom = incomingTiles[2];
                    break;
                case AbsoluteDirection.Right:
                    RightTop = incomingTiles[2];
                    RightCenter = incomingTiles[1];
                    RightBottom = incomingTiles[0];
                    break;
            }
            return result;
        }

        public Tile[] GetEdgeTiles(AbsoluteDirection edgeDirection)
        {
            Require.NotNull(edgeDirection, nameof(edgeDirection));

            Tile[] result = new Tile[3];
            switch (edgeDirection)
            {
                case AbsoluteDirection.Top:
                    result = [RightTop, CenterTop, LeftTop];
                    break;
                case AbsoluteDirection.Down:
                    result = [LeftBottom, CenterBottom, RightBottom];
                    break;
                case AbsoluteDirection.Left:
                    result = [LeftTop, LeftCenter, LeftBottom];
                    break;
                case AbsoluteDirection.Right:
                    result = [RightBottom, RightCenter, RightTop];
                    break;
            }
            return result;
        }
    }
}
