using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppointmentDataAccess
    {
        SqlCommand _command;
        public AppointmentDataAccess()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public List<Apointment> GetAllAppointment() {
            List<Apointment> listAppointment=null;
            Apointment appointment;
            _command.CommandText = "sp_GetAllAppointmet";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                if (dr.HasRows)
                {
                    listAppointment = new List<Apointment>();
                    while (dr.Read())
                    {
                        appointment = new Apointment();
                        appointment.Id = (int)dr[0];
                        appointment.PatientId = (int)dr[1];
                        appointment.DoktorId = (int)dr[2];
                        appointment.Date = (DateTime)dr[3];
                        appointment.Session = (TimeSpan)dr[4];
                        appointment.Status = dr[5].ToString();
                        listAppointment.Add(appointment);
                      

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
            return listAppointment;
        




        }
        public bool InsertAppointment(Apointment obj) {
            _command.CommandText = "sp_InsertAppointment";
            _command.Parameters.Clear();
        _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@date", obj.Date));
            _command.Parameters.Add(new SqlParameter("@doctorId", obj.DoktorId));
            _command.Parameters.Add(new SqlParameter("@status", obj.Status));
            _command.Parameters.Add(new SqlParameter("@patientId", obj.PatientId));
            _command.Parameters.Add(new SqlParameter("@session", obj.Session));

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed) _command.Connection.Open();
                int result = _command.ExecuteNonQuery();
                return result > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { _command.Connection.Close(); }
        }



    }
}
