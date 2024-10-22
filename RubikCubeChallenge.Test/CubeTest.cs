using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Rubik;

namespace RubikCubeChallenge.Test
{
    internal class CubeTestSut
    {
        public Cube Sut { get; set; }
        public Mock<ICubeFace> CubeFaceMock { get; set; }
    }
    internal class CubeTest
    {
        

        [Test]
        public void FinalTest()
        {
            Fixture fixture = new Fixture();
            var cubeFaceFactory = fixture.Create<CubeFaceFactory>();
            ICube expected = new Cube(cubeFaceFactory)
            {
                Up = new CubeFace()
                {
                    LeftTop = Tile.Red,
                    CenterTop = Tile.Orange,
                    RightTop = Tile.Green,
                    LeftCenter = Tile.Blue,
                    CenterCenter = Tile.White,
                    RightCenter = Tile.White,
                    LeftBottom = Tile.Blue,
                    CenterBottom = Tile.Blue,
                    RightBottom = Tile.Blue,
                },
                Left = new CubeFace()
                {
                    LeftTop = Tile.Green,
                    CenterTop = Tile.Yellow,
                    RightTop = Tile.Yellow,
                    LeftCenter = Tile.Orange,
                    CenterCenter = Tile.Orange,
                    RightCenter = Tile.Green,
                    LeftBottom = Tile.Blue,
                    CenterBottom = Tile.Green,
                    RightBottom = Tile.Orange,
                },
                Front = new CubeFace()
                {
                    LeftTop = Tile.Orange,
                    CenterTop = Tile.Red,
                    RightTop = Tile.Red,
                    LeftCenter = Tile.Orange,
                    CenterCenter = Tile.Green,
                    RightCenter = Tile.White,
                    LeftBottom = Tile.White,
                    CenterBottom = Tile.White,
                    RightBottom = Tile.White,
                },
                Right = new CubeFace()
                {
                    LeftTop = Tile.Yellow,
                    CenterTop = Tile.Blue,
                    RightTop = Tile.Orange,
                    LeftCenter = Tile.Red,
                    CenterCenter = Tile.Red,
                    RightCenter = Tile.White,
                    LeftBottom = Tile.Orange,
                    CenterBottom = Tile.Yellow,
                    RightBottom = Tile.Red,
                },
                Back = new CubeFace()
                {
                    LeftTop = Tile.Yellow,
                    CenterTop = Tile.Blue,
                    RightTop = Tile.White,
                    LeftCenter = Tile.Orange,
                    CenterCenter = Tile.Blue,
                    RightCenter = Tile.Yellow,
                    LeftBottom = Tile.Yellow,
                    CenterBottom = Tile.Yellow,
                    RightBottom = Tile.White,
                },
                Down = new CubeFace()
                {
                    LeftTop = Tile.Green,
                    CenterTop = Tile.Green,
                    RightTop = Tile.Blue,
                    LeftCenter = Tile.Red,
                    CenterCenter = Tile.Yellow,
                    RightCenter = Tile.Red,
                    LeftBottom = Tile.Red,
                    CenterBottom = Tile.Green,
                    RightBottom = Tile.Green,
                }
            };

            var cube = new Cube(cubeFaceFactory);

            cube.F();
            cube.R_();
            cube.U();
            cube.B_();
            cube.L();
            cube.D_();

            Assert.That(expected.Up, Is.EqualTo(cube.Up), "Up");
            Assert.That(expected.Left, Is.EqualTo(cube.Left), "Left");
            Assert.That(expected.Front, Is.EqualTo(cube.Front), "Front");
            Assert.That(expected.Right, Is.EqualTo(cube.Right), "Right");
            Assert.That(expected.Back, Is.EqualTo(cube.Back), "Back");
            Assert.That(expected.Down, Is.EqualTo(cube.Down), "Down");

            Assert.Pass();
        }

        private CubeTestSut setupSut()
        {
            Fixture fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization());
            var cubeFaceFactoryMock = fixture.Freeze<Mock<ICubeFaceFactory>>();
            var cubeFaceMock = fixture.Freeze<Mock<ICubeFace>>();
            cubeFaceFactoryMock.Setup(m => m.CreateCubeFace(It.IsAny<Tile>())).Returns(cubeFaceMock.Object);
            var sut = fixture.Create<Cube>();

            return new CubeTestSut()
            {
                Sut = sut,
                CubeFaceMock = cubeFaceMock
            };
        }

        [Test]
        public void B__Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.B_();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Right, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Down, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Left, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Top, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Top), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceAntiClockwise(), Times.Exactly(1));

            Assert.Pass();
        }

        [Test]
        public void D__Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.D_();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Down, It.IsAny<Tile[]>()), Times.Exactly(4));
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Down), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceAntiClockwise(), Times.Exactly(1));

            Assert.Pass();
        }

        [Test]
        public void F_Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.F();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Right, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Down, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Left, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Top, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Right), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceClockwise(), Times.Exactly(1));

            Assert.Pass();
        }

        [Test]
        public void L_Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.L();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Left, It.IsAny<Tile[]>()), Times.Exactly(3));
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Left), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceClockwise(), Times.Exactly(1));

            Assert.Pass();
        }

        [Test]
        public void R__Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.R_();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Right, It.IsAny<Tile[]>()), Times.Exactly(3));
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Left, It.IsAny<Tile[]>()), Times.Once);
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Left), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceAntiClockwise(), Times.Exactly(1));

            Assert.Pass();
        }

        [Test]
        public void U_Test()
        {
            var cubeTestSut = setupSut();

            cubeTestSut.Sut.U();
            cubeTestSut.CubeFaceMock.Verify(v => v.ReplaceEdge(AbsoluteDirection.Top, It.IsAny<Tile[]>()), Times.Exactly(4));
            cubeTestSut.CubeFaceMock.Verify(v => v.GetEdgeTiles(AbsoluteDirection.Top), Times.Exactly(1));
            cubeTestSut.CubeFaceMock.Verify(v => v.RotateFaceClockwise(), Times.Exactly(1));

            Assert.Pass();
        }
    }
}
