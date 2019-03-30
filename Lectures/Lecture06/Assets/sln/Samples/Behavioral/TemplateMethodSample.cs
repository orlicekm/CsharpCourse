using System;
using System.Data;

namespace Samples.Behavioral
{
    public class TemplateMethodSample
    {
        private static void Main()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();
        }
    }

    internal abstract class DataAccessObject
    {
        protected string connectionString;
        protected DataSet dataSet;

        public virtual void Connect()
        {
            // Edit connection string to available db
            connectionString =
                "provider=Microsoft.JET.OLEDB.4.0; " +
                "data source=..\\..\\..\\db1.mdb";
        }

        public abstract void Select();
        public abstract void Process();

        public virtual void Disconnect()
        {
            connectionString = "";
        }

        // The 'Template Method' 
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }

    internal class Categories : DataAccessObject
    {
        public override void Select()
        {
            var sql = "select CategoryName from Categories";
            dataSet = new DataSet();

            // Edit adapter to used database
            // var dataAdapter = new OleDbDataAdapter(sql, connectionString); create data adapter
            // dataAdapter.Fill(dataSet, "Categories");
        }

        public override void Process()
        {
            Console.WriteLine("Categories ---- ");
            var dataTable = dataSet.Tables["Categories"];
            foreach (DataRow row in dataTable.Rows) Console.WriteLine(row["CategoryName"]);
            Console.WriteLine();
        }
    }

    internal class Products : DataAccessObject
    {
        public override void Select()
        {
            var sql = "select ProductName from Products";
            dataSet = new DataSet();

            // Edit adapter to used database
            // var dataAdapter = new OleDbDataAdapter(sql, connectionString);
            // dataAdapter.Fill(dataSet, "Products");
        }

        public override void Process()
        {
            Console.WriteLine("Products ---- ");
            var dataTable = dataSet.Tables["Products"];
            foreach (DataRow row in dataTable.Rows) Console.WriteLine(row["ProductName"]);
            Console.WriteLine();
        }
    }
}