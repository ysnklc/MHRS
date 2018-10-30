using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Policlinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClinicId { get; set; }
        public int HospitalId { get; set; }
        public int Duration { get; set; }
    }
}
