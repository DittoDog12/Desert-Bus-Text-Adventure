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
        private string mDest = "Las Vegas";
        private int mPoints = 0;
        private ConsoleKeyInfo mKeypress; // Used for new game
        #endregion

        #region Constructor
        public Kernel()
        {

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
            Console.WriteLine("Press any key to start your adventure");
            Console.ReadKey();
            BeginGame();
        }

        private void MasterLoop()
        {
            while (mRunGame == true)
            {
                if (Bus1.aOdo < mTotalDist)
                {
                    // Get player input
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Road Position: {0}. Bus Temperature: {1}. Points: {2}", Bus1.aRoadpos, Bus1.aTemp, mPoints);
                    Console.SetCursorPosition(0, 22);
                    Input1.Listen();
                    CheckCrash();
                }
                else
                {
                   ReachDest();
                }
            
            }
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Visit Desertbus.org");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private void BeginGame()
        {
            // Get player name - GNDN, just to give the player something to do
            Console.Clear();
            Console.WriteLine("What is your name?");
            Console.ReadLine();
            Console.Clear();

            // Create a bus and input parser and start the main loop
            Bus1 = new Bus();
            Input1 = new Input(Bus1);
            mRunGame = true;
            MasterLoop();
        }

        private void CheckCrash()
        {
            if (Bus1.aTemp > 10)
            {
                Console.Clear();
                Console.WriteLine("The bus has over heated");
                Console.WriteLine("Do you want to Restart? Y/N");
                switch (mKeypress.Key)
                {
                    case ConsoleKey.Y:
                        mTotalDist = 0;
                        Bus1.Reset();
                        MasterLoop();
                        break;

                    case ConsoleKey.N:
                        mRunGame = false;
                        break;
                }
            }
            if (Bus1.aRoadpos > 10 || Bus1.aRoadpos < 0)
            {
                Console.Clear();
                Console.WriteLine("The bus has crashed");
                Console.WriteLine("Do you want to Restart? Y/N");
                switch (mKeypress.Key)
                {
                    case ConsoleKey.Y:
                        mTotalDist = 0;
                        Bus1.Reset();
                        MasterLoop();
                        break;

                    case ConsoleKey.N:
                        mRunGame = false;
                        break;
                }
            }
        }

        private void ReachDest()
        {
            Console.Clear();
            mPoints++;
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
                    MasterLoop();
                    break;

                case ConsoleKey.N:
                    mRunGame = false;
                    break;
            }
        }
        #endregion

    }
}
