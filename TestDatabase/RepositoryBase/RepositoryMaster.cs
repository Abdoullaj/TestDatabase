using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestDatabase.Geography.Repository;
using TestDatabase.Model;

namespace TestDatabase.RepositoryBase
{
    abstract class RepositoryMaster<Context, TEntityDb>
        where TEntityDb : class
        where Context : DbContext

    {
        protected Context context;

        protected DbSet<TEntityDb> dbSet;
        public RepositoryMaster(Context context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntityDb>();
        }

        public virtual void UpdateRecord(TEntityDb entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void RemoveRecord(TEntityDb entityToRemove)
        {
            context.Entry(entityToRemove).State = EntityState.Deleted;
        }

        public void ShowErrors(ValutationResults validation)
        {
            var CompleteErrorMessage = "";
            foreach (var item in validation.errors)
            {
                CompleteErrorMessage = CompleteErrorMessage + "\n" + item;
            }
            MessageBox.Show(CompleteErrorMessage);
        }
        public string GetNewIdSistemTable(string entityName)
        {
            GeographyEntities context = new GeographyEntities();
            using (IDbCommand command = context.Database.Connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "sp_RG_GenerazioneNewID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = command.Connection.ConnectionTimeout;

                    command.Parameters.Add(new SqlParameter("NomeTabella", entityName));

                    SqlParameter sqlParameterOut = new SqlParameter();
                    sqlParameterOut.ParameterName = "IDNew";
                    sqlParameterOut.Direction = ParameterDirection.Output;
                    sqlParameterOut.SqlDbType = SqlDbType.VarChar;
                    sqlParameterOut.Size = -1;
                    command.Parameters.Add(sqlParameterOut);

                    if (context.Database.Connection.State != ConnectionState.Open)
                        context.Database.Connection.Open();
                    command.ExecuteScalar();

                    return sqlParameterOut.Value.ToString();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    context.Database.Connection.Close();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
