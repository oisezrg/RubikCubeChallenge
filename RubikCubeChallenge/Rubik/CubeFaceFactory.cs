using RubikCubeChallenge.Abstraction;

namespace RubikCubeChallenge.Rubik
{
    public class CubeFaceFactory : ICubeFaceFactory
    {
        public ICubeFace CreateCubeFace(Tile tile)
        {
            ArgumentNullException.ThrowIfNull(tile, nameof(tile));
            return new CubeFace(tile);
        }
    }
}
