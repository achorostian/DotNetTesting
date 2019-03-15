using System;
using System.Collections.Generic;
using GeometryLib;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PointUnitTest
    {
        Point2D testPoint1;
        Point2D testPoint2;
        Point2D testPoint3;
        [TestInitialize]
        public void Setup()
        {
            testPoint1 = new Point2D(11.0, 20.0);
            testPoint2 = new Point2D(11.0, 20.0);
            testPoint3 = new Point2D(10.0, 20.0);
        }
        [TestMethod]
        public void TestPointComparatorPositive()
        {
            // Arrange:

            // Act:
            bool result = testPoint1.Compare(testPoint2);

            // Assert:
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestPointComparatorNegtive()
        {
            // Arrange:
            Point2D testPoint2 = new Point2D(13, 20);

            // Act:
            bool result = testPoint1.Compare(testPoint2);

            // Assert:
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMovingByVector()
        {
            // Arrange:
            double[] expected = { 15.0, 23.0 };

            IVector vector =
             new GeometryLib.Fakes.StubIVector()
             {
                 GetVector = () => { return new double[] { 4, 3 }; }
             };

            // Act:
            testPoint1.MoveByVector(vector, 1);
            // Assert:
            CollectionAssert.AreEqual(expected,
                (new[] { testPoint1.X, testPoint1.Y }));
        }
        [TestMethod]
        public void TestPointTranspose()
        {
            // Arrange:
            double[] expected = { 13.0, 21.0 };

            // Act:
            testPoint1.Transpose(2, 1);
            // Assert:
            CollectionAssert.AreEqual(expected,
                (new[] { testPoint1.X, testPoint1.Y }));
        }
        [TestMethod]
        public void TestPointScale()
        {
            // Arrange:
            double[] expected = { 5.5, 10.0 };

            // Act:
            testPoint1.Scale(0.5);
            // Assert:
            CollectionAssert.AreEqual(expected,
                (new[] { testPoint1.X, testPoint1.Y }));
        }
        [TestMethod]
        public void TestReadPointsFromFile()
        {
            // Arrange:
            double[] expected = { 5.5, 10.0 };

            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllLinesString =
                    s => new string[] { "10 10", "12 32", "1 4" };

            // Act
            Point2D[] output = Point2D.ReadPointsFromFile("test.txt");
            //
            Assert.AreEqual(3, output.Length);
            }
        }
        [TestMethod]
        public void TestPrintPointAsAtring()
        {
            //Arrange:
            String output;
            //Act:
            output = testPoint1.Print();
            //Assert:
            StringAssert.Equals(output, "11 20");
        }
    }

    [TestClass]
    public class VectorUnitTest
    {
        Vector2D vector1;
        Vector2D vector2;

        [TestInitialize]
        public void Setup()
        {
            vector1 = new Vector2D(-3, 4);
            vector2 = new Vector2D(2, 3);
        }

        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            Vector2D outVector;
            double[] expcted = { -1, 7 };
        
            //Act
            outVector = vector1.Add(vector2);
            //Assert
            CollectionAssert.Equals(expcted, outVector);
        }
        [TestMethod]
        public void TestGetLength()
        {
            //Arrange
            double expectedLen = 5;
            double calculatedLen;
            //Act
            calculatedLen = vector1.GetLength();
            //Assert
            Assert.AreEqual(expectedLen, calculatedLen);
        }
        [TestMethod]
        public void MultiplyByNumber()
        {
            //Arrange
            double multipler = 0.28;
            double[] expected = { 0.28 * -3, 0.28 * 4 };
            double[] actual;
            //Act
            vector1.MultiplyByNumber(multipler);
            actual = new double[] { vector1.GetX(), vector1.GetY()};
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetVector()
        {
            //Arrange
            double[] expected = new double[] { 2, 3 };
            double[] actual;
            //Act
            actual = vector2.GetVector();
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPointConstructor()
        {
            //Arrange
            Point2D p1 = new Point2D(1, 2);
            Point2D p2 = new Point2D(2, 3);
            double[] expected = new double[] { 1, 1 };
            double[] actual;
            //Act
            Vector2D createdVector = new Vector2D(p1, p2);
            actual = createdVector.GetVector();
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }



    [TestClass]
    public class PolygonUnitTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        Polygon testPolygon;
        [TestInitialize]
        public void Setup()
        {
            Point2D[] points = {
                new Point2D(1, 1),
                new Point2D(1, 2),
                new Point2D(2, 2),
                new Point2D(2, 1)
            };
            testPolygon = new Polygon(points);
            //TODO: data driven test with points
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "test_data.csv", 
            "test_data#csv",
            DataAccessMethod.Sequential),
            DeploymentItem("test_data.csv")]
        [TestMethod]
        public void TestCountArea_FromDataSource()
        {
            // Access the data  
            String[] rawPoints = Convert.ToString(TestContext.DataRow["PointPosition"]).Split(';');
            List<Point2D> points = new List<Point2D>();
            foreach(String point in rawPoints)
            {
                String[] position = point.Split('|');
                int x = Convert.ToInt32(position[0]);
                int y = Convert.ToInt32(position[1]);
                points.Add(new Point2D(x, y));
            }
            double expectedArea = Convert.ToDouble(TestContext.DataRow["ExpectedArea"]);
            Polygon p = new Polygon(points.ToArray());
            double actual = p.Area();
            Assert.AreEqual(expectedArea, actual, 0.001);

        }
        [TestMethod]
        public void TestCircutCounting()
        {
            //Arrange
            double expected = 4;
            //Act
            double actual = testPolygon.Circut();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        private bool PointListComparator(Point2D[] a, Point2D[] b)
        {
            if (a.Length != b.Length) return false;
            for(int i = 0; i < a.Length; i++)
            {
                Point2D p1 = a[0];
                Point2D p2 = b[0];
                if (p1.X != p2.X || p1.Y != p2.Y) return false;
            }
            return true;
        }
        [TestMethod]
        public void TestMoveAlongVector()
        {
            //Arrange
            Point2D[] actual;
            Point2D[] expected = {
                new Point2D(2,2),
                new Point2D(3,2),
                new Point2D(3,3),
                new Point2D(2,3)
            };
            IVector vector =
            new GeometryLib.Fakes.StubIVector()
            {
                GetVector = () => { return new double[] { 1, 1 }; },
                GetLength = () => { return 2; }
            };
            //Act
            testPolygon.MoveAlongVector(vector);
            actual = testPolygon.GetPoints();
            //Assert
            Console.WriteLine("{0}--{1}", actual[0].Print(), expected[0].Print());
            Assert.IsTrue(PointListComparator(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestErrorMovingAlongVector()
        {
            //Arrange
            IVector vector =
            new GeometryLib.Fakes.StubIVector()
            {
                GetLength = () => { return 3; }
            };
            //Act
            testPolygon.MoveAlongVector(vector);
        }

        [TestMethod]
        public void TestScalingPolygon()
        {
            //Arrange
            double beforeScale = testPolygon.Circut();
            double scale = 0.5;
            double expected = beforeScale * scale;
            //Act
            testPolygon.Scale(scale);
            //Arrange
            Assert.AreEqual(expected, testPolygon.Circut());
        }

    }
}
