using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
namespace AccountManagement
{
    public class DbConnection
    {
        
        private SqlCeConnection _sqlConnection;
        private SqlCeCommand  _sqlCommand;
        public string ConnectionString;

        public DbConnection()
        {
            _sqlConnection = null;
            _sqlCommand = null;
            ConnectionString = "Data Source="+ Directory.GetCurrentDirectory () +"\\AccountManagement.sdf";

        }

        public void ConnectDatabase()
        {

            _sqlConnection = new SqlCeConnection(ConnectionString);

            try
            {
                _sqlConnection.Open();
                _sqlCommand = _sqlConnection.CreateCommand();
            }
            catch (Exception)
            {
                if (_sqlConnection.State == ConnectionState.Open)
                    _sqlConnection.Close();
                throw;
            }
        }

        public void ExecuteNonQuery(string queryString)
        {
            _sqlCommand.CommandText = queryString;

            try
            {
                _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ExecuteQuery(string queryString)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlCeDataAdapter  myAdapter = new SqlCeDataAdapter (queryString, _sqlConnection);
                myAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseDatabase()
        {
            if (_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();

            _sqlConnection = null;
            _sqlCommand = null;
        }
    }
}