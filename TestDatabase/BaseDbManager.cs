using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestDatabase.FakeModels;

namespace TestDatabase
{
    public class BaseDbManager<Context> :  IBaseDbManager where Context : DbContext, new()
    {
        protected readonly Context context;

        protected BaseDbManager(Context context)
        {
            this.context = context;
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
           
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ShowErrors(ValutationResults validation)
        {
            var CompleteErrorMessage = "";
            foreach (var item in validation.errors)
            {
                CompleteErrorMessage = CompleteErrorMessage + "\n" + item;
            }
            //MessageBox.Show(CompleteErrorMessage);
        }
    }
}
