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
        private bool mRunGame = false; // Master Game loop control
        private int mTotalDist = 413; // Total distance to drive
        private Bus Bus1; // Bus object
        private Input Input1; // Input text parser object
        private string mDest = "Las Vegas"; // String to hold Current destination
        private int mPoints = 0; // Int to hold points
        private ConsoleKeyInfo mKeypress; // Used for new game
        private bool mExit = false;
        #endregion

        #region Accessors

        // Gives Kernel access to Bus variables
        public bool aExit
        {
            get { return mExit; }
        }
        public bool aRunGame
        {
            get { return mRunGame; }
        }
        #endregion

        #region Constructor
        public Kernel()
        {
            Initialize();
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            // Welcome screen

            Console.WriteLine("Welcome to Desert Bus: The Text Adventure");
            Console.WriteLine("A text adventrue based on the Desert Bus for Hope Game Jam on Itch.io");
            Console.WriteLine("You should check out Desertbus.org");
            Console.WriteLine("Controls are printed on screen at each point");
            Console.WriteLine("Press enter key to start your adventure");
            Console.ReadKey();
            BeginGame();
        }

        public void MasterLoop()
        {
            // While bus Odometer is less than the total distance run the main loop
            if (Bus1.aOdo < mTotalDist)
            {
                
                // Draw stats at top of screen
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Road Position: {0}. Bus Temperature: {1}. Points: {2}", Bus1.aRoadpos, Bus1.aTemp, mPoints);

                // Get player input
                Input1.Listen();
                CheckCrash();
            }
            else // When bus reaches Destination, call ReachDest()
            {
                ReachDest();
            }  
        }

        private void BeginGame()
        {
            // Get player name - GNDN, just to give the player something to do
            Console.Clear();
            Console.WriteLine("What is your name?");
            Console.ReadLine();
            Console.Clear();

            // Create a bus and input parser and start the main loop
            Bus1 = new Bus(mTotalDist);
            Input1 = new Input(Bus1);
            mRunGame = true;
        }

        private void CheckCrash()
        {
            // If bus overheats cause crash, call Restart() to ask player to restart
            if (Bus1.aTemp > 10)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("The bus has over heated");
                Restart();
            }

            // If bus crashes on left or right of the road, call Restart() to ask player to restart
            if (Bus1.aRoadpos > 10 || Bus1.aRoadpos < 0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("The bus has crashed");
                Restart();
            }
        }

        private void ReachDest()
        {
            // When player reaches destination, add a point and ask to go back, if yes change destination string, if no trigger exit hook
            Console.Clear();
            mPoints++;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Congratualtions, you made it to {0}", mDest);
            Console.WriteLine("Do you want to go back? Y/N");
            mKeypress = Console.ReadKey();
            switch (mKeypress.Key)
            {
                case ConsoleKey.Y:
                    if (mDest == "Las Vegas")
                    {
                        mDest = "Tucson";
                    }
                    else
                    {
                        mDest = "Las Vegas";
                    }
                    Bus1.Reset();
                    MasterLoop();
                    break;

                case ConsoleKey.N:
                    mExit = true;
                    break;
            }
        }

        private void Restart()
        {
            // If player crashes ask to restart, if yes reset bus variables and restart master loop, if no then trigger exit hook 
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Do you want to Restart? Y/N");
            mKeypress = Console.ReadKey();
            switch (mKeypress.Key)
            {
                case ConsoleKey.Y:
                    Bus1.Reset();
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("         ");
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("                     ");
                    MasterLoop();
                    break;

                case ConsoleKey.N:
                    mExit = true;
                    break;
            }
        }
        #endregion

    }
}
