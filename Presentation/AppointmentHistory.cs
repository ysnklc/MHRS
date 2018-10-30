using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class AppointmentHistory : Form
    {
        Patient _patient;
        PatientBusiness _patientBusiness;
       
        public AppointmentHistory(Patient patient)
        {
            InitializeComponent();
            _patientBusiness = new PatientBusiness();
            _patient = patient;
            List<Apointment> listAppointment = _patientBusiness.AppointmentHistory(_patient);
            gridAppointment.DataSource = listAppointment;
            


        }
    }
}
