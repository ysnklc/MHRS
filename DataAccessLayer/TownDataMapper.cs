using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TownDataMapper
    {
        SqlCommand _command;
        public TownDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        

        public List<Town> GetAllTown()
        {
            List<Town> listTown = null;
            Town town;
            _command.CommandText = "sp_GetAllTown";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader dr = _command.ExecuteReader();

                if (dr.HasRows)
                {
                    listTown = new List<Town>();
                    while (dr.Read())
                    {
                        town = new Town();
                        town.Id = (int)dr[0];
                        town.CityId = (int)dr[1];
                        town.Name = dr[2].ToString();

                        listTown.Add(town);
                    }
                    dr.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _command.Connection.Close();
            }
            return listTown;
        }
    }
}
