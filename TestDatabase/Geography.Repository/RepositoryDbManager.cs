
using TestDatabase.RepositoryBase;

namespace TestDatabase.Geography.Repository
{
    public class RepositoryDbManager : BaseDbManager<GeographyEntities>
    {
        GeographyRepository _geographyRepository;

        public RepositoryDbManager(GeographyEntities context) : base(context)
        {
        }

        public IGeographyRepository GeographyRepository
        {
            get
            {
                if( _geographyRepository == null)
                {
                    _geographyRepository = new GeographyRepository(context);
                }
                return _geographyRepository;
            }
        }
    }
}
