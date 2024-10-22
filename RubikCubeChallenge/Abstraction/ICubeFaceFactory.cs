namespace RubikCubeChallenge.Abstraction
{
    public interface ICubeFaceFactory
    {
        ICubeFace CreateCubeFace(Tile tile);
    }
}
