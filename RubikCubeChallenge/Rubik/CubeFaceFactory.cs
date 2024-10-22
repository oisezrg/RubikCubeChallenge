using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Utilities;

namespace RubikCubeChallenge.Rubik
{
    public class CubeFaceFactory : ICubeFaceFactory
    {
        public ICubeFace CreateCubeFace(Tile tile)
        {
            Require.NotNull(tile, nameof(tile));

            return new CubeFace(tile);
        }
    }
}
