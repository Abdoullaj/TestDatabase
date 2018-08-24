using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
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
                // test 1°
                //db.Entry(comune).State = EntityState.Modified;

                //test 2°
                Comune temp = new Comune() { IdComune = comune.IdComune, CodIstat = comune.CodIstat };
                _db.GeographyRepository.UpdateRecord(temp);
                temp = comune;
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

        public void Search()
        {
            _db.GeographyRepository.Search(new InfoPlace() { DescComune = "Bar" });
        }
    }
}

