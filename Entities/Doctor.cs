using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PoliclinicId { get; set; }
        public string Title { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan FinishDate { get; set; }
        public string FullName { get { return Title + " " + FirstName + " " + LastName; } }


    }
}
