using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DoctorDataAccess
    {
        SqlCommand _command;
        public DoctorDataAccess()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public List<Doctor> GetAllDoctor() {
            List<Doctor> listDoctor=null;
            Doctor doctor;
            _command.CommandText = "sp_GetDoctor";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                if (dr.HasRows)
                {
                    listDoctor = new List<Doctor>();
                    while (dr.Read())
                    {
                        doctor = new Doctor();
                        doctor.Id = (int)dr[0];
                        doctor.FirstName = dr[1].ToString();
                        doctor.LastName = dr[2].ToString();
                        doctor.PoliclinicId = (int)dr[3];
                        doctor.Title = dr[4].ToString();
                        doctor.StartDate = (TimeSpan)dr[5];
                        doctor.FinishDate = (TimeSpan)dr[6];
                        listDoctor.Add(doctor);


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
            return listDoctor;
        
        
        
        
        }
        public Doctor GetDoctorById(int doctorid) {
            _command.CommandText = "GetDoctorById";
            _command.Parameters.Clear();
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id",doctorid));
            Doctor doctor =null;
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                        doctor = new Doctor();
                        doctor.Id = (int)dr[0];
                        doctor.FirstName = dr[1].ToString();
                        doctor.LastName = dr[2].ToString();
                        doctor.PoliclinicId = (int)dr[3];
                        doctor.Title = dr[4].ToString();
                        doctor.StartDate = (TimeSpan)dr[5];
                        doctor.FinishDate = (TimeSpan)dr[6];


                  
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
            if (doctor==null)
            {
                throw new Exception("Doktor Bilgisi Getirilemedi");
            }
            else
            {

                return doctor;
            }
           
        }
    }
}
