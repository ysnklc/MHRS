using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataAccessLayer
{
    public class ClinicDataMapper
    {
        SqlCommand _command;
        public ClinicDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public List<Clinic> GetAllClinic() {
            List<Clinic> listClinik = null;
            Clinic clinic;
            _command.CommandText = "sp_GetClinic";
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader dr = _command.ExecuteReader();
                if (dr.HasRows)
                {
                    listClinik = new List<Clinic>();
                    while (dr.Read())
                    {
                        clinic = new Clinic();
                        clinic.Id = (int)dr[0];
                        clinic.Name = dr.GetString(1);

                        listClinik.Add(clinic);
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

            return listClinik;
        
        
        
        
        }



    }
}
