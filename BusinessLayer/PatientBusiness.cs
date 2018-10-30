using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer
{
    public class PatientBusiness
    {
        PatientDataMapper _patientMapper;
        AppointmentDataAccess _appointmentDataMapper;

        public PatientBusiness()
        {
            _patientMapper = new PatientDataMapper();
            _appointmentDataMapper = new AppointmentDataAccess();
        }

        public bool InsertPatient(Patient patient)
        {
            long result=0;
            bool result2 = long.TryParse(patient.IdentityNumber,out result );

            if (patient.IdentityNumber == null && result2 && patient.FirstName == null && patient.LastName == null && patient.Gender == null && patient.BirthDate == null && patient.Phone == null && patient.Email == null && patient.Password == null && patient.SecurityQuestion == null && patient.Answer == null) 
                return false;


            int affectedRows = _patientMapper.Insert(patient);

            return affectedRows > 0;
        }
        public Patient Login(string identity, string pwd)
        {

            List<Patient> listPatient = new List<Patient>();
            listPatient = _patientMapper.GetAllPatient();
            foreach (Patient item in listPatient)
            {
                if (item.IdentityNumber == identity && item.Password == pwd)
                {
                    return item;
                }
            }
            return null;

        }

        public List<Patient> Gonder(string identityNumber, string eMail)
        {
            List<Patient> _listPatient = new List<Patient>();
            _listPatient = _patientMapper.GetAllPatient();

            for (int i = 0; i < _listPatient.Count; i++)
            {
                if (identityNumber == _listPatient[i].IdentityNumber && eMail == _listPatient[i].Email)
                {
                    MailMessage ePosta = new MailMessage();
                    ePosta.From = new MailAddress("eyup.yildirim02@gmail.com");
                    ePosta.ReplyTo = new MailAddress("eyup.yildirim02@gmail.com"); ;
                    ePosta.To.Add(eMail);
                    ePosta.Subject = "Şifre hatırlatma";
                    ePosta.Body = "Sifreniz aşağıdadır başka söylemek istediğim bir şey yok iyi günler \n" + _listPatient[i].Password;
                    //
                    SmtpClient smtp = new SmtpClient();

                    smtp.Credentials = new System.Net.NetworkCredential("eyup.yildirim02@gmail.com", "Eymel.02");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = false;
                    object userState = ePosta;

                    try
                    {
                        smtp.Send(ePosta);
                        smtp.SendAsync(ePosta, (object)ePosta);
                    }
                    catch (SmtpException ex)
                    {

                        throw ex;
                    }

                }
            }

            return _listPatient;

        }

        public List<Patient> GetAll()
        {
            List<Patient> _listPatient = new List<Patient>();
            _listPatient = _patientMapper.GetAllPatient();

            return _listPatient;

        }


        public List<Apointment> AppointmentHistory(Patient patient)
        {
            List<Apointment> list = new List<Apointment>();
            List<Apointment> listApointment = _appointmentDataMapper.GetAllAppointment();
            foreach (Apointment item in listApointment)
            {
                if (item.PatientId == patient.Id)
                {
                    list.Add(item);
                }

            }
            return list;

        }
    }
}
