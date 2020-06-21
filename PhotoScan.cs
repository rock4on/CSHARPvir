using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSHARPvir
{
    //class used to get photos
    class PhotoScan : fprocess
    {
        int nof = 0;
        String Format = "";
        List<String> ftch;
        public PhotoScan(String format)
        {
            Format = format;
        }


        public override void work()
        {
            base.work();
            ftch = new List<string>();
            foreach (var s in pth.fisiere)
            {
                ftch.Add(s);
            }

            List<int> to_rem = new List<int>();

            
            for (int i = 0; i < ftch.Count; i++)
            {
                if (!Format.Contains(Path.GetExtension(ftch[i]).ToLower()))
                {
                   // MessageBox.Show(Path.GetExtension(ftch[i]));
                    to_rem.Add(i);
                }
            }

            for (int i = 0; i < to_rem.Count; i++)
            {
                ftch.RemoveAt(to_rem[i] - i);
            }

            to_rem.Clear();



            nof = ftch.Count;
            //creates vir directory in MyMusic
            var f_path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/vir";
            System.IO.Directory.CreateDirectory(f_path);
            
            //copies chosen files in the vir directory
            foreach (string s in ftch)

            {
                System.IO.File.Copy(s, f_path + "/" + Path.GetFileName(s), true);
            }
            //writes a report file
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(f_path + "/raport_photo.txt", true))
            {
                try
                {
                    file.WriteLine("number of photos: " + ftch[0] + "   " + nof.ToString());
                }
                catch { }
            }

        }


    }


    }

