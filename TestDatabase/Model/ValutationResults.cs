using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase.Model
{
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
}
