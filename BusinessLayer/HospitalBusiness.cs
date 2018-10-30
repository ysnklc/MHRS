using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class HospitalBusiness
    {
       HospitalDataMapper _hospitalDataMapper;
        public HospitalBusiness()
        {
            _hospitalDataMapper = new HospitalDataMapper();
        }
        public List<Hospital> GetByClinic(int clinicid, int townid) {
            List<Hospital> listHospital = new List<Hospital>();
            listHospital = _hospitalDataMapper.GetByClinicAndTown(clinicid, townid);
            return listHospital;
        
        
        }
    }
}
