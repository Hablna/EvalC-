﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Cercle : IForme
    {
        public int? Id { get; set; }
        public Point Centre { get; private set; }
        public double Rayon { get; private set; }

        public Cercle(Point centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public Cercle(int id, double rayon, double centreX, double centreY)
        {
            Id = id;
            Rayon = rayon;
            Centre = new Point((int)centreX, (int)centreY);
        }


        public double CalculerPerimetre() => 2 * Math.PI * Rayon;

        public double CalculerAire() => Math.PI * Math.Pow(Rayon, 2);

        public DAL.Cercle_DAL ToDAL()
        {
            return new DAL.Cercle_DAL()
            {
                Id = Id,
                Rayon = Rayon,
                CentreX = Centre.X,
                CentreY = Centre.Y
            };
        }

    }
}
