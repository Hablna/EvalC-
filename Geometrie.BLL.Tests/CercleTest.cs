using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL.Tests
{
    public class CercleTest
    {
        [Fact]

        public void test_perimetre()
        {
            var centre = new Point(0, 0);
            var rayon = 5.0;
            var cercle = new Cercle(centre, rayon);

            // Act
            var perimetre = cercle.CalculerPerimetre();

            // Assert
            Assert.Equal(2 * Math.PI * rayon, perimetre);
        }

        [Fact]
        public void Constructeur_AvecId_RetourneCercleCorrect()
        {
            // Arrange
            var id = 1;
            var rayon = 5.0;
            var centreX = 2.0;
            var centreY = 3.0;

            // Act
            var cercle = new Cercle(id, rayon, centreX, centreY);

            // Assert
            Assert.Equal(id, cercle.Id);
            Assert.Equal(rayon, cercle.Rayon);
            Assert.Equal((int)centreX, cercle.Centre.X);
            Assert.Equal((int)centreY, cercle.Centre.Y);
        }

        [Fact]
        public void ToDAL_RetourneCercleDALCorrect()
        {
            // Arrange
            var centre = new Point(0, 0);
            var rayon = 5.0;
            var cercle = new Cercle(centre, rayon);

            // Act
            var cercleDAL = cercle.ToDAL();

            // Assert
            Assert.Equal(cercle.Id, cercleDAL.Id);
            Assert.Equal(cercle.Rayon, cercleDAL.Rayon);
            Assert.Equal(cercle.Centre.X, cercleDAL.CentreX);
            Assert.Equal(cercle.Centre.Y, cercleDAL.CentreY);
        }

    }
}
