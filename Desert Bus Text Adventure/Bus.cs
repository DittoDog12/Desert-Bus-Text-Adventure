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
        private int mTemp = 0; // 
        private int mRoadPos = 6; // 5 is central, 0 is crash on left, 10 is crash on right
        private string mDriver;
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

        public int aRoadpos
        {
            get { return mRoadPos; }
        }

        public string aDriver
        {
            set { mDriver = value; }
        }
        
        #endregion

        #region Constructor
        public Bus()
        {

        }
        #endregion

        #region Methods
        public void Forward()
        {
            mOdo++;
            mRoadPos++;
            if (mTemp >= 1)
            {
                mTemp--;
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Left()
        {
            mTemp++;
            mRoadPos--;
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Backward()
        {
            mTemp = mTemp + 5;
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Right()
        {
            mRoadPos++;
            mTemp++;
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Reset()
        {
            mOdo = 0;
            mTemp = 0; // 
            mRoadPos = 6; // 5 is central, 0 is crash on left, 10 is crash on right
        }
        #endregion
    }
}
