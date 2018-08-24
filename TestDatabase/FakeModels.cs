﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase
{
    public class FakeModels
    {
        public class TicketProva
        {
            public string IdTicket { get; set; }
        }

        public class ValutationResults
        {
            public List<string> errors { get; set; }
            public bool valutationResult = true;

            public ValutationResults()
            {
                errors = new List<string>();
            }
            public void addErrors(string error)
            {
                valutationResult = false;
                errors.Add(error);
            }
        }

        public class InfoPlace
        {
            public string IdComune { get; set; }
            public string IdNazione { get; set; }
            public string IdProvincia { get; set; }
            public string IdRegione { get; set; }
            public string DescComune { get; set; }
            public string DescNazione { get; set; }
            public string DescProvincia { get; set; }
            public string DescRegione { get; set; }
        }
    }
}
