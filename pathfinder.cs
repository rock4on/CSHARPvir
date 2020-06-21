using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSHARPvir
{
    //singleton class used to navigate paths
    public sealed class pathfinder
    {
        private static pathfinder instance = null;
        private static readonly object padlock = new object();
        //files
        public String[] fisiere;
        //folders
        public String[] foldere;
        //parent directory
        public String parent;





        

        //fuction to change path
        public void Work(String path)
        {
            fisiere=Directory.GetFiles(path);
            foldere = Directory.GetDirectories(path);
            parent = Directory.GetParent(path).FullName;
        }
        
        pathfinder()
        {
            fisiere=Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            foldere = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            parent = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).FullName;
        }

        public static pathfinder Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new pathfinder();
                    }
                    return instance;
                }
            }
        }
    }

}
