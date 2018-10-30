using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PoliclinicDataMapper
    {
        SqlCommand _command;

        public PoliclinicDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public List<Policlinic> GetHospitalPoliclinic(int hospitalId)
        {
            List<Policlinic> listPoliclinic = null;
            Policlinic policlinic;

            _command.CommandText = "sp_GetPoliclinic";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add(new SqlParameter("@id", hospitalId));

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader rd = _command.ExecuteReader();

                if (rd.HasRows)
                {
                    listPoliclinic = new List<Policlinic>();
                    while (rd.Read())
                    {
                        policlinic = new Policlinic();
                        policlinic.Id = (int)rd[0];
                        policlinic.Name = rd.GetString(1);
                       
                        listPoliclinic.Add(policlinic);
                    }

                    rd.Close();
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

            return listPoliclinic;
        }
        public List<Policlinic> GetAllPoliclinic() {
            List<Policlinic> listPoliclinic = null;
            Policlinic policlinic;

            _command.CommandText = "sp_GetAllPoliclinic";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
   

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader rd = _command.ExecuteReader();

                if (rd.HasRows)
                {
                    listPoliclinic = new List<Policlinic>();
                    while (rd.Read())
                    {
                        policlinic = new Policlinic();
                        policlinic.Id = (int)rd[0];
                        policlinic.Name = rd.GetString(1);
                        policlinic.HospitalId = rd.GetInt32(2);
                        policlinic.ClinicId = rd.GetInt32(3);
                        policlinic.Duration = rd.GetInt32(4);
                        listPoliclinic.Add(policlinic);
                    }

                    rd.Close();
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

            return listPoliclinic;
        
        
        }
    }
}
