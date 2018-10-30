using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AppointmentBusiness
    {
        ClinicDataMapper _clinicDataMapper;
        AppointmentDataAccess _appoinmentDataMapper;
        CityDataMapper _cityDataMapper;
        TownDataMapper _townDataMapper;
        public AppointmentBusiness()
        {
            _clinicDataMapper = new ClinicDataMapper();
            _appoinmentDataMapper = new AppointmentDataAccess();
            _cityDataMapper = new CityDataMapper();
            _townDataMapper = new TownDataMapper();
        }
        public bool InsertAppoinment(Apointment obj)
        {
            bool result = _appoinmentDataMapper.InsertAppointment(obj);
            return result;



        }
        public List<Apointment> GetAllAppointment()
        {
            List<Apointment> appointment = _appoinmentDataMapper.GetAllAppointment();
            return appointment;

        }

        public List<City> GetAllCity()
        {
            List<City> listCity = _cityDataMapper.GetCity();
            return listCity;
        }

        public List<Town> GetAllTown(int cityId)
        {
            List<Town> cityTowns = new List<Town>();
            List<Town> listTown = _townDataMapper.GetAllTown();
            for (int i = 0; i < listTown.Count; i++)
            {
                if (listTown[i].CityId == cityId)
                {
                    cityTowns.Add(listTown[i]);
                }

            }

            return cityTowns;
        }

        public List<Clinic> GetAllClinic()
        {
            List<Clinic> listClinic =_clinicDataMapper.GetAllClinic();
            return listClinic;
        }
    }
}
