

using System;
using System.Data.Entity;
using TestDatabase.Model;

namespace TestDatabase.RepositoryBase
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
