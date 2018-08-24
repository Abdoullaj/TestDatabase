using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    public interface IGeographyRepository
    {

        ValutationResults AddRecord(Comune newEntity);
        void UpdateRecord(Comune newEntity);
        void RemoveRecord(Comune newEntity);
        void Search(InfoPlace filter);
        string GetNewIdSistemTable(string entityName);
        void ShowErrors(ValutationResults validation);

    }
}
