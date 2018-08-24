using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    class GeographyRepository : RepositoryMaster<GeographyEntities,Comune> , IGeographyRepository
    {
        
        public GeographyRepository(GeographyEntities context) : base (context)
        {

        }


        public ValutationResults AddRecord(Comune newEntity)
        {
            ValutationResults validation = ValidateEntity(newEntity, Operation.New);
            
            if (validation.valutationResult == true)
            {
                newEntity.IdComune = GetNewIdSistemTable("Comune");
                dbSet.Add(newEntity);
                return validation;
            }
            else
            {
                return validation;
            }
        }
        


        public void Search(InfoPlace filter)
        {
            IQueryable<InfoPlace> query1 = dbSet.Select(x =>
                            new InfoPlace()
                            {
                                IdComune = x.IdComune,
                                DescComune = x.DescComune,
                                IdProvincia = x.Provincia.IdProvincia,
                                DescProvincia = x.Provincia.DescProvincia,
                                IdRegione = x.Provincia.Regione.IdRegione,
                                DescRegione = x.Provincia.Regione.DescRegione,
                                IdNazione = x.Provincia.Regione.Nazione.IdNazione,
                                DescNazione = x.Provincia.Regione.Nazione.DescNazione
                            });
            query1 = BuildFiltredQuery(query1, new InfoPlace() { DescProvincia = "Bologna" , DescComune = "B" });
            var result = query1.ToList();

        }

        public IQueryable<InfoPlace> BuildFiltredQuery(IQueryable<InfoPlace> query, InfoPlace filter)
        {
            if (filter != null)
            {

                if (filter.IdComune != null)
                {
                    query = query.Where(x => x.IdComune == filter.IdComune);
                }

                if (filter.IdNazione != null)
                {
                    query = query.Where(x => x.IdNazione == filter.IdNazione);
                }

                if (filter.IdProvincia != null)
                {
                    query = query.Where(x => x.IdProvincia == filter.IdProvincia);
                }

                if (filter.IdRegione != null)
                {
                    query = query.Where(x => x.IdRegione == filter.IdRegione);
                }

                if (filter.DescComune != null)
                {
                    query = query.Where(x => x.DescComune.StartsWith(filter.DescComune));
                }

                if (filter.DescProvincia != null)
                {
                    query = query.Where(x => x.DescProvincia.StartsWith(filter.DescProvincia));
                }

                if (filter.DescRegione != null)
                {
                    query = query.Where(x => x.DescRegione.StartsWith(filter.DescRegione));
                }
            }
            return query;
        }
        

        public ValutationResults ValidateEntity(Comune comune, Operation operation)
        {
            IQueryable<Comune> query = dbSet;
            ValutationResults result = new ValutationResults();

            switch (operation)
            {
                case Operation.New:
                    // required parameter 
                    if (string.IsNullOrWhiteSpace(comune.fk_Provincia_Id))
                    {
                        result.addErrors("Province is required.");
                    }

                    //Univocal CodComune
                    if (!string.IsNullOrWhiteSpace(comune.CodComune))
                    {
                        if (query.Where(x => x.CodComune == comune.CodComune).Count() > 0)
                        {
                            result.addErrors("CodComune is univocal ");
                        }
                    }
                    break;

                case Operation.Update:
                    if (string.IsNullOrWhiteSpace(comune.IdComune) || string.IsNullOrWhiteSpace(comune.fk_Provincia_Id))
                    {
                        result.addErrors("Id and province are required ");
                        break;
                    }


                    if (!string.IsNullOrWhiteSpace(comune.CodComune))
                    {
                        if (query.Where(x => x.CodComune == comune.CodComune).Count() > 0)
                        {
                            result.addErrors("CodComune is univocal ");
                        }
                    }
                    break;

                case Operation.Delete:
                    if (string.IsNullOrWhiteSpace(comune.IdComune))
                    {
                        result.addErrors("Id is required .");
                        break;
                    }

                    if (!(query.Where(x => x.IdComune == comune.IdComune).Count() > 0))
                    {
                        result.addErrors("A Comune with that ID doesn't exist ");

                    }

                    break;

            }
            return result;
        }


    }
}
