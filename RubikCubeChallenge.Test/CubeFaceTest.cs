using AutoFixture;
using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Rubik;

namespace RubikCubeChallenge.Test
{
    internal class CubeFaceTest
    {
        [Test]
        public void DummyTest()
        {
            var cubeFace = new CubeFace(Tile.Blue);
            cubeFace.RotateFaceClockwise();

            var expected = new CubeFace(Tile.Blue).GetTiles();

            Assert.That(expected, Is.EqualTo(cubeFace.GetTiles()));

            Assert.Pass();
        }

        [Test]
        public void RotateClockwiseTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new CubeFace()
            {
                CenterCenter = cubeFace.CenterCenter,
                LeftTop = cubeFace.LeftBottom,
                CenterTop = cubeFace.LeftCenter,
                RightTop = cubeFace.LeftTop,
                RightCenter = cubeFace.CenterTop,
                RightBottom = cubeFace.RightTop,
                CenterBottom = cubeFace.RightCenter,
                LeftBottom = cubeFace.RightBottom,
                LeftCenter = cubeFace.CenterBottom,
            }.GetTiles();

            cubeFace.RotateFaceClockwise();
            var actual = cubeFace.GetTiles();
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }

        [Test]
        public void RotateAntiClockwiseTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new CubeFace()
            {
                CenterCenter = cubeFace.CenterCenter,
                LeftTop = cubeFace.RightTop,
                CenterTop = cubeFace.RightCenter,
                RightTop = cubeFace.RightBottom,
                RightCenter = cubeFace.CenterBottom,
                RightBottom = cubeFace.LeftBottom,
                CenterBottom = cubeFace.LeftCenter,
                LeftBottom = cubeFace.LeftTop,
                LeftCenter = cubeFace.CenterTop,
            }.GetTiles();

            cubeFace.RotateFaceAntiClockwise();
            var actual = cubeFace.GetTiles();
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }

        [Test]
        public void GetLeftEdgeTilesTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new[] { cubeFace.LeftTop, cubeFace.LeftCenter, cubeFace.LeftBottom };
            var actual = cubeFace.GetEdgeTiles(AbsoluteDirection.Left);
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }

        [Test]
        public void GetRightEdgeTilesTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new[] { cubeFace.RightTop, cubeFace.RightCenter, cubeFace.RightBottom };
            var actual = cubeFace.GetEdgeTiles(AbsoluteDirection.Right);
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }

        [Test]
        public void GetTopEdgeTilesTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new[] { cubeFace.RightTop, cubeFace.CenterTop, cubeFace.LeftTop };
            var actual = cubeFace.GetEdgeTiles(AbsoluteDirection.Top);
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }

        [Test]
        public void GetDownEdgeTilesTest()
        {
            Fixture fixture = new Fixture();
            var cubeFace = fixture.Create<CubeFace>();

            var expected = new[] { cubeFace.LeftBottom, cubeFace.CenterBottom, cubeFace.RightBottom };
            var actual = cubeFace.GetEdgeTiles(AbsoluteDirection.Down);
            Assert.That(expected, Is.EqualTo(actual));

            Assert.Pass();
        }
    }
}
