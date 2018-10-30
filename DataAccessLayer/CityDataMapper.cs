using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CityDataMapper
    {
        SqlCommand _command;
        public CityDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public List<City> GetCity() {
            List<City> listCity=null;
            City city;
            _command.CommandText = "Select * from GetCity";
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader dr = _command.ExecuteReader();

                if (dr.HasRows)
                {
                    listCity = new List<City>();
                    while (dr.Read())
                    {
                        city = new City();
                        city.Id = (int)dr[0];
                        city.Name = dr[1].ToString();

                        listCity.Add(city);
                    }
                    dr.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                _command.Connection.Close();
            }
            return listCity;
        }



    }
}
