using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DTO;

namespace Geometrie.Service
{
    public class Cercle_Service : ICercle_Service
    {
        private IDepot<Cercle> cercle_depot;

        public Cercle_Service(IDepot<Cercle> unDepotDeCercle)
        {
            ArgumentNullException.ThrowIfNull(unDepotDeCercle);
            cercle_depot = unDepotDeCercle;
        }

        public Cercle_DTO Add(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var centre = new Point((int)element.CentreX, (int)element.CentreY);
            var cercle_BLL = new Cercle(centre, element.Rayon);
            cercle_BLL = cercle_depot.Add(cercle_BLL);
            element.Id = cercle_BLL.Id;

            return element;
        }

        public Cercle_DTO Update(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var centre = new Point((int)element.CentreX, (int)element.CentreY);
            var cercle_BLL = new Cercle(element.Id.Value, element.Rayon, element.CentreX, element.CentreY);
            cercle_depot.Update(cercle_BLL);

            return element;
        }

        public IService<Cercle_DTO> Delete(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IService<Cercle_DTO> Delete(int Id)
        {
            cercle_depot.Delete(Id);
            return this;
        }

        public IEnumerable<Cercle_DTO> GetAll()
        {
            return cercle_depot.GetAll().Select(c => new Cercle_DTO() { Id = c.Id, Rayon = c.Rayon, CentreX = c.Centre.X, CentreY = c.Centre.Y });
        }

        public double CalculerPerimetre()
        {
            throw new NotImplementedException();
        }

        public double CalculerAire()
        {
            throw new NotImplementedException();
        }

        //je n'ai pas fait cette methode

        public Cercle_DTO? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}