using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class PasswordReminder : Form
    {
        PatientBusiness _patientBusiness;
        public PasswordReminder()
        {
            InitializeComponent();

            _patientBusiness = new PatientBusiness();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Patient patient;
        private void btnSend_Click(object sender, EventArgs e)
        {
            //patient = new Patient();

            

            _patientBusiness.Gonder(textBox1.Text, textBox2.Text);
        }
        
 
    }
}
