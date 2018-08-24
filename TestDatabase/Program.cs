using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            GeographyServices service = new GeographyServices();
            int choose = 1;
                
                switch (choose)
                {
                    case 1:
                        service.AddRecord(new Comune() { fk_Provincia_Id = "PR89", CodComune = "asgarra2" });
                    break;
                    case 2:
                        service.UpdateRecord(new Comune() { IdComune = "C13", fk_Provincia_Id = "PR89", DescComune = "Baricella5", CodIstat = "452567" });
                    break;
                    case 3:
                        service.Search();
                    break;
                    case 4:
                        service.RemoveRecord(new Comune() { IdComune = "C15" });
                    break;
                }
            
        }
        
    }
}