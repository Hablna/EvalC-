using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometrie.DAL;

namespace Geometrie.BLL.Depots
{
    public class Cercle_Depot : IDepot<Cercle>
    {
        private GeometrieContext context;

        public Cercle_Depot(GeometrieContext context)
        {
            this.context = context;
        }

        public Cercle Add(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_DAL = element.ToDAL();
            context.Add(cercle_DAL);
            context.SaveChanges();
            element.Id = cercle_DAL.Id;
            return element;
        }

        public IDepot<Cercle> Delete(int Id)
        {
            var cercle_DAL = context.Cercles.Find(Id);
            if (cercle_DAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(Id));

            context.Cercles.Remove(cercle_DAL);
            context.SaveChanges();
            return this;
        }

        public IDepot<Cercle> Delete(Cercle element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cercle> GetAll()
        {
            return context.Cercles.Select(c => new Cercle(c.Id.Value, c.Rayon, c.CentreX, c.CentreY));
        }

        public Cercle? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cercle Update(Cercle element)
        {
            throw new NotImplementedException();
        }

        //pou
    }
}
