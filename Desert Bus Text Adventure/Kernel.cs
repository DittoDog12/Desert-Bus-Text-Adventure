using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desert_Bus_Text_Adventure
{
    class Kernel
    {
        #region Data Members
        private bool mRunGame = false;
        private int mTotalDist = 413;
        private Bus Bus1;
        private Input Input1;
        #endregion

        #region Constructor
        public Kernel()
        {

        }
        #endregion

        #region Methods
        public void Initialize()
        {

            Bus1 = new Bus();
            Input1 = new Input(Bus1);
            MasterLoop();
        }

        private void MasterLoop()
        {
            while (mRunGame == true)
            {
                if (Bus1.aOdo < mTotalDist)
                {
                    Input1.Listen();
                }

            }
        }
        #endregion

    }
}
