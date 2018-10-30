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
    public partial class SignUp : Form
    {
        PatientBusiness _patientBusiness;
        public SignUp()
        {
            InitializeComponent();
            _patientBusiness = new PatientBusiness();
        }

        Patient patient;
        private void button4_Click(object sender, EventArgs e)
        {
            patient = new Patient();

            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
            patient.Answer = txtReply.Text;
            patient.IdentityNumber = txtTckn.Text;
            patient.MotherName = txtMotherName.Text;
            patient.FatherName = txtFatherName.Text;
            patient.Email = txtMail.Text;
            patient.BirthDate = DateTime.Parse(dtpBirthDate.Text);
            if (cmbGender.SelectedItem != null)
                patient.Gender = cmbGender.SelectedItem.ToString();
            else MessageBox.Show("Cinsiyet seçiniz.");
            patient.PlaceOfBirth = txtPlaceOfBirth.Text;
            patient.Phone = txtPhone.Text;
            patient.Password = txtPassword.Text;
            if (cmbSecurity.SelectedItem != null)
                patient.SecurityQuestion = cmbSecurity.SelectedItem.ToString();
            else MessageBox.Show("Güvenlik sorusu boş geçilemez!");
            if (txtReply.Text != null)
                patient.Answer = txtReply.Text;
            else MessageBox.Show("Cevap kısmı boş geçilemez");

            List<Patient> _listPatient = new List<Patient>();
            _listPatient = _patientBusiness.GetAll();

            for (int i = 0; i < _listPatient.Count; i++)
            {
                if (_listPatient[i].IdentityNumber == patient.IdentityNumber)
                {
                    MessageBox.Show("Girmiş olduğunuz kimlik numarası sistemde kayıtlı bulunmaktadır.");

                }
                if (_listPatient[i].Email == patient.Email)
                {
                    MessageBox.Show("Girmiş olduğunuz E-Posta adresi sistemde kayıtlıdır.Lütfen başka bir E-Posta adresi giriniz.");

                }
            }

            if(patient.Password == txtPasswordAgain.Text)
            {

                bool result = _patientBusiness.InsertPatient(patient);

                if (result)
                {
                    MessageBox.Show("Başarılı");

                    Login frm = new Login();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Başarısız");
                }
            }
            else
            {
                MessageBox.Show("Parola uyuşmuyor");
            }

            


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gbContactInformation_Enter(object sender, EventArgs e)
        {

        }
    }
}
