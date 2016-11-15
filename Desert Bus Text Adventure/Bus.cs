using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desert_Bus_Text_Adventure
{
    class Bus
    {
        #region Data Members
        private int mOdo = 0;
        private int mTemp = 0;
        private int mLeft = 0;
        #endregion

        #region Accessors
        public int aOdo
        {
            get { return mOdo; }
        }

        public int aTemp
        {
            get { return mTemp; }
        }

        public int aLeft
        {
            get { return mLeft; }
        }
        
        #endregion

        #region Constructor
        public Bus()
        {

        }
        #endregion

        #region Methods
        private void Forward()
        {
            mOdo++;
        }

        private void Left()
        {

        }
        #endregion
    }
}
