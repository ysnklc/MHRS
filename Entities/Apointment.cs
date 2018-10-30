using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Apointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int  DoktorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Session { get; set; }
        public string Status { get; set; }

    }
}
