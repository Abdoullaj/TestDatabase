
using TestDatabase.Geography.Repository;
using  TestDatabase.Model;

namespace TestDatabase.Geography.Core
{
    public class GeographyServices
    {
        RepositoryDbManager _db;
        GeographyValidator _validator = new GeographyValidator();

        public GeographyServices()
        {
            _db = new RepositoryDbManager(new GeographyEntities());
        }
        
        public void AddRecord(Comune comune)
        {
            ValutationResults validation = _db.GeographyRepository.AddRecord(comune);
            if (validation.valutationResult == true)
            {
                _db.SaveChanges();
            }
            else
            {
                _db.ShowErrors(validation);
            }
        }

        public void UpdateRecord(Comune comune)
        {
            ValutationResults validation = _validator.ValidateEntity(comune, Operation.Update);

            if (validation.valutationResult == true)
            {
                // update 1°
                //db.Attach(comune) ecc...

                //update 2°
                _db.GeographyRepository.UpdateRecord(comune);
                _db.SaveChanges();
            }
            else
            {
                _db.ShowErrors(validation);
            }
        }

        public void RemoveRecord(Comune comune)
        {
            ValutationResults validation = _validator.ValidateEntity( comune, Operation.Delete);

            if (validation.valutationResult == true)
            {
                _db.GeographyRepository.RemoveRecord(comune);
                _db.SaveChanges();
            }
            else
            {
                _db.GeographyRepository.ShowErrors(validation);
            }
        }

        public void Search(InfoPlace filter)
        {
            _db.GeographyRepository.Search(filter);
        }
    }
}

