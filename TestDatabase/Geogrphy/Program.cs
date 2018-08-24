
using TestDatabase.Geography.Core;
using TestDatabase.Geography.Repository;
using TestDatabase.Model;

namespace TestDatabase.Geography
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            GeographyServices service = new GeographyServices();
            int choose = 4;
                
                switch (choose)
                {
                    case 1:
                        service.AddRecord(new Comune() { fk_Provincia_Id = "PR89", CodComune = "asgarra3" });
                    break;
                    case 2:
                        service.UpdateRecord(new Comune() { IdComune = "C13", fk_Provincia_Id = "PR89", DescComune = "Baricella5", CodIstat = "452567" });
                    break;
                    case 3:
                        service.Search(new InfoPlace() { DescProvincia = "Bologna", DescComune = "B" });
                    break;
                    case 4:
                        service.RemoveRecord(new Comune() { IdComune = "C18" });
                    break;
                }
            
        }
        
    }
}