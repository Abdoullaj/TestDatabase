using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    public interface IBaseDbManager
    {
        int SaveChanges();
        void ShowErrors(ValutationResults validation);
    }
}
