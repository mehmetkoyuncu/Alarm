using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                if (i.ToString().Length == 1)
                {
                    cmbMinute.Items.Add("0" + i.ToString());
                }
                else
                {
                    cmbMinute.Items.Add(i.ToString());
                }

            }

            for (int i = 0; i < 24; i++)
            {
                if (i.ToString().Length == 1)
                {
                    cmbHour.Items.Add("0" + i.ToString());
                }
                else
                {
                    cmbHour.Items.Add(i.ToString());
                }
            }
            timer2.Enabled = true;
            timer2.Start();



        }


        private void btnAlarmKur_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbHour.Text != "" || cmbMinute.Text != "")
                {
                    if (int.Parse(cmbHour.Text) < 0 || int.Parse(cmbHour.Text) > 23)
                    {
                        MessageBox.Show("Geçersiz Saat");
                    }
                    else if (int.Parse(cmbMinute.Text) < 0 || int.Parse(cmbMinute.Text) > 59)
                    {
                        MessageBox.Show("Geçersiz Dakika");
                    }

                    else
                    {
                        listBox1.Items.Add("Alarm : " + cmbHour.Text.ToString() + " " + cmbMinute.Text.ToString());
                        timer1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Saat veya Dakika Boş Geçilemez.."); ;
                }


            }
            catch (FormatException)
            {
                MessageBox.Show("Metin Girişi Yapılamaz..");

            }







        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.Hour.ToString();
            if (hour.ToString().Length == 1)
            {
                hour = "0" + hour;
            }
            string minute = DateTime.Now.Minute.ToString();
            if (minute.ToString().Length == 1)
            {
                minute = "0" + minute;
            }

            lblClock.Text = hour + " : " + minute;


            if (cmbMinute.Text == minute && cmbHour.Text == hour)
            {
                timer1.Enabled = false;

                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sound\\sound1.mp3"));
                axWindowsMediaPlayer1.URL = path;
                MessageBox.Show("Alarm Saati !!");
                axWindowsMediaPlayer1.URL = null;
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minutE = DateTime.Now.Minute.ToString();
            if (hour.ToString().Length == 1)
            {
                hour = "0" + hour;
            }
            if (minutE.ToString().Length == 1)
            {
                minutE = "0" + minutE;
            }


            lblClock.Text = hour + " : " + minutE;
        }
    }
}
