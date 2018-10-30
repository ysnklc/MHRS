using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PatientDataMapper
    {
        SqlCommand _command;
        public PatientDataMapper()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public int Insert(Patient obj)
        {
            _command.CommandText = "sp_PatientInsert";
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.Add(new SqlParameter("@identityNumber", obj.IdentityNumber));
            _command.Parameters.Add(new SqlParameter("@firstName", obj.FirstName));
            _command.Parameters.Add(new SqlParameter("@lastName", obj.LastName));
            _command.Parameters.Add(new SqlParameter("@gender", obj.Gender));
            _command.Parameters.Add(new SqlParameter("@birthDate", obj.BirthDate));
            _command.Parameters.Add(new SqlParameter("@placeOfBirth", obj.PlaceOfBirth));
            _command.Parameters.Add(new SqlParameter("@fatherName", obj.FatherName));
            _command.Parameters.Add(new SqlParameter("@motherName", obj.MotherName));
            _command.Parameters.Add(new SqlParameter("@phone", obj.Phone));
            _command.Parameters.Add(new SqlParameter("@mail", obj.Email));
            _command.Parameters.Add(new SqlParameter("@SecurityQuestion", obj.SecurityQuestion));
            _command.Parameters.Add(new SqlParameter("@password", obj.Password));
            _command.Parameters.Add(new SqlParameter("@answer", obj.Answer));
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                int result = _command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _command.Connection.Close();

            }


        }
        public List<Patient> GetAllPatient()
        {
            List<Patient> listPatient = null;
            Patient patient;

            _command.CommandText = "sp_PatientGetAll";
            _command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();

                SqlDataReader dr = _command.ExecuteReader();

                if (dr.HasRows)
                {
                    listPatient = new List<Patient>();
                    while (dr.Read())
                    {
                        patient = new Patient();
                        patient.Id = (int)dr[0];
                        patient.IdentityNumber = dr[1].ToString();
                        patient.FirstName = dr[2].ToString();
                        patient.LastName = dr[3].ToString();
                        patient.Gender = dr[4].ToString();
                        patient.BirthDate = (DateTime)dr[5];
                        patient.PlaceOfBirth = dr[6].ToString();
                        patient.FatherName = dr[7].ToString();
                        patient.MotherName = dr[8].ToString();
                        patient.Phone = dr[9].ToString();
                        patient.Email = dr[10].ToString();
                        patient.SecurityQuestion = dr[11].ToString();
                        patient.Answer = dr[12].ToString();
                        patient.Password = dr[13].ToString();

                        listPatient.Add(patient);
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

            return listPatient;
        }

    }
}
