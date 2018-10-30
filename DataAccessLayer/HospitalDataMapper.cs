using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HospitalDataMapper
    {
        SqlCommand _command;
        public HospitalDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public List<Hospital> GetByClinicAndTown(int clinicId,int townId)
        {
            List<Hospital> listHospital = null;
            Hospital hospital;
            _command.CommandText = "sp_GetClinicHospital";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add(new SqlParameter("@id", clinicId));
            _command.Parameters.Add(new SqlParameter("@townId", townId));

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader dr = _command.ExecuteReader();

                if (dr.HasRows)
                {
                    listHospital = new List<Hospital>();
                    while (dr.Read())
                    {
                        hospital = new Hospital();
                        hospital.Id = (int)dr[0];
                        hospital.HospitalName = dr.GetString(1);

                        listHospital.Add(hospital);
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
            return listHospital;
        }

    }
}
