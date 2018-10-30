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
    public partial class Login : Form
    {

        PatientBusiness _patientBusiness;
        public Login()
        {
            InitializeComponent();

            _patientBusiness = new PatientBusiness();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();

            patient = _patientBusiness.Login(txtTckn.Text, txtPassword.Text);
            // TODO : guvenlık kodu olayı gelecek

            if (patient != null)
            {
                if (txtRandomWrite.Text == lblRandom.Text)
                {
                    Appointment frm = new Appointment(patient);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Güvenlik kodunu yanlış girdiniz");
                }

                
            }
            else
            {
                MessageBox.Show("TC kimlik numarası ya da şifre hatalı!");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp frm = new SignUp();

            frm.Show();
            this.Hide();
        }

        private void btnRecal_Click(object sender, EventArgs e)
        {
            PasswordReminder frm = new PasswordReminder();
            frm.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();

            int sayi = rastgele.Next(1000,10000);
            lblRandom.Text = sayi.ToString();
        }
    }
}
