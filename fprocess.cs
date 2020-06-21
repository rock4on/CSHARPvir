using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPvir
{
    //abstract class parent of TextScan si PhotoScan
    abstract class fprocess
    {
        
        protected pathfinder pth;

    public fprocess()
        {
            pth = pathfinder.Instance;
        }
    public virtual void work()
        {
         
        }
    
    }

}
