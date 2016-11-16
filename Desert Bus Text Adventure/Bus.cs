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
        private int mOdo = 0; // Bus Odometer
        private int mTemp = 0; // Bus temperature
        private int mRoadPos = 6; // 5 is central, 0 is crash on left, 10 is crash on right
        private Random rand = new Random(); // Random number for Bug Splat
        private int mBugSplat; // Int for bug splat timing
        private string mDriver; // Driver name - GNDN
        #endregion

        #region Accessors

        // Gives Kernel access to Bus variables
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
        public Bus(int pTotalDist)
        {
            // Create Bugsplat time
            mBugSplat = rand.Next(0, pTotalDist);
        }
        #endregion

        #region Methods
        public void Forward()
        {
             // Add to Odo and Road Pos, bus drifts to the right
            mOdo++;
            mRoadPos++;
            // Decrease Temerature, bus over heats if you slow down
            if (mTemp >= 1)
            {
                mTemp--;
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                                       ");
            Console.SetCursorPosition(0, 21);

            // Trigger bug splat at random interval created in Constructor
            if (mOdo == mBugSplat)
            {
                Console.WriteLine("A bug splats on the windscreen");
            }
            else
            {
                Console.WriteLine("You see desert");
            }
           

        }

        public void Left()
        {
            // Correct for bus drift
            //mTemp++; Not sure if needed
            mRoadPos--;
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Backward()
        {
            // Bus overheats if you slow
            mTemp = mTemp + 5;
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Right()
        {
            // WHY? Why would you go right?
            mRoadPos++;
            //mTemp++; Not sure if needed
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("You see desert");
        }

        public void Reset()
        {
            // resets bus variables in case of crash and restart
            mOdo = 0;
            mTemp = 0; 
            mRoadPos = 6; 
        }
        #endregion
    }
}
