using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DoctorBusiness
    {
        PoliclinicDataMapper _policlinicDataMapper;
        DoctorDataAccess _doctorDataMapper;
        public DoctorBusiness()
        {
            _doctorDataMapper = new DoctorDataAccess();
            _policlinicDataMapper = new PoliclinicDataMapper();
        }

        public List<Doctor> GetDoctor(int policlinicId)
        {
            List<Doctor> listDoctor = new List<Doctor>();
            listDoctor = _doctorDataMapper.GetAllDoctor();
            List<Doctor> yeni = new List<Doctor>();
            for (int i = 0; i < listDoctor.Count; i++)
            {
                if (policlinicId == listDoctor[i].PoliclinicId)
                {
                    yeni.Add(listDoctor[i]);
                }
            }
            return yeni;

        }
        public Doctor GetDoctorByID(int id)
        {
            Doctor doctor = new Doctor();
            doctor = _doctorDataMapper.GetDoctorById(id);
            return doctor;
        }


        public List<TimeSpan> GetDurationDoctor(int id)
        {
            int duration = 0;
            Doctor doctor = _doctorDataMapper.GetDoctorById(id);
            List<Policlinic> listPoliclinic = new List<Policlinic>();
            listPoliclinic = _policlinicDataMapper.GetAllPoliclinic();
            for (int i = 0; i < listPoliclinic.Count; i++)
            {
                if (listPoliclinic[i].Id == doctor.PoliclinicId)
                {
                    duration = listPoliclinic[i].Duration;

                }
            }
            List<TimeSpan> seanslistesi = new List<TimeSpan>();
            TimeSpan seansSaati = doctor.StartDate;
            TimeSpan saatFarkı = doctor.FinishDate - doctor.StartDate;
            int saat = saatFarkı.Hours;
            int seans= saat*60/duration;
            TimeSpan seansDuration = TimeSpan.FromMinutes(duration);

            for (int i = 0; i < seans; i++)
            {
                
                seansSaati= seansSaati+seansDuration;
                seanslistesi.Add(seansSaati);
            }

            return seanslistesi;
        }



        //}

    }
}
