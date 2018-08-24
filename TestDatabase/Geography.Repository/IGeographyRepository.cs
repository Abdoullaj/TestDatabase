using TestDatabase.Model;

namespace TestDatabase.Geography.Repository
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
