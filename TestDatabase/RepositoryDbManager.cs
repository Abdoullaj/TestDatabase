using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase
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
