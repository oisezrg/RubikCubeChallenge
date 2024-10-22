namespace RubikCubeChallenge.Abstraction
{
    public interface ICubeFace
    {
        public Tile LeftTop { get; set; }
        public Tile CenterTop { get; set; }
        public Tile RightTop { get; set; }
        public Tile LeftCenter { get; set; }
        public Tile CenterCenter { get; set; }
        public Tile RightCenter { get; set; }
        public Tile LeftBottom { get; set; }
        public Tile CenterBottom { get; set; }
        public Tile RightBottom { get; set; }
        public Tile[] GetTiles();

        public void RotateFaceClockwise();
        public void RotateFaceAntiClockwise();
        public Tile[] ReplaceEdge(AbsoluteDirection edgeDirection, Tile[] incomingTiles);
        public Tile[] GetEdgeTiles(AbsoluteDirection edgeDirection);
    }
}