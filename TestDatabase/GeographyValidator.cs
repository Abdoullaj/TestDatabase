using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    public class GeographyValidator
    {

        GeographyRepository db = new GeographyRepository(new GeographyEntities());

        public ValutationResults ValidateEntity(Comune comune, Operation operation)
        {
            ValutationResults result = db.ValidateEntity(comune, operation);
            return result;
        }
    }
}
