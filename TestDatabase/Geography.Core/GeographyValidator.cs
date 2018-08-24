using TestDatabase.Geography.Repository;
using TestDatabase.Model;

namespace TestDatabase.Geography.Core
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
