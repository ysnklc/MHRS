using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class PoliclinicBusiness
    {
        PoliclinicDataMapper _policlinicMapper;

        public PoliclinicBusiness()
        {
            _policlinicMapper = new PoliclinicDataMapper();
        }

        public List<Policlinic> GetAllPoliclinic(int id)
        {
            List<Policlinic> policlinic = new List<Policlinic>();

            policlinic = _policlinicMapper.GetHospitalPoliclinic(id);

            return policlinic;

        }

    }
}
