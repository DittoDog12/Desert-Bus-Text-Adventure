using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desert_Bus_Text_Adventure
{
    class Input
    {
        #region Data Members
        private Bus mBus;
        private string mInput;
        #endregion

        #region Accessors
        
        
        #endregion

        #region Constructor
        public Input(Bus pBus)
        {
            mBus = pBus;
        }
        #endregion

        #region Methods
        public void Listen()
        {
            Console.WriteLine("Enter a command: forward, backward, left, right, exit");
            Console.WriteLine("           ");
            Console.SetCursorPosition(0, 23);
            mInput = Console.ReadLine();
            if(mInput != null)
            {
                InputParser();
            }
        }

        public void InputParser()
        {
            switch (mInput)
            {
                case "forward":
                    mBus.Forward();
                    break;
                case "backward":
                    mBus.Backward();
                    break;
                case "left":
                    mBus.Left();
                    break;
                case "right":
                    mBus.Right();
                    break;
                case "exit":
                    Console.Clear();
                    Console.WriteLine("Thanks for playing");
                    Console.WriteLine("Visit Desertbus.org");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Command not recognised");
                    break;
            }
        }
        
        #endregion
    }
}
