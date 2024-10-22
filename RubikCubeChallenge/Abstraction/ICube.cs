namespace RubikCubeChallenge.Abstraction
{
    public interface ICube
    {
        public void Print();
        public void F();
        public void R_();
        public void U();
        public void B_();
        public void L();
        public void D_();
        public ICubeFace Front { get; set; }
        public ICubeFace Back { get; set; }
        public ICubeFace Up { get; set; }
        public ICubeFace Down { get; set; }
        public ICubeFace Left { get; set; }
        public ICubeFace Right { get; set; }
    }
}