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
        private Bus mBus; // Reference for Bus
        private string mInput; // String to hold player input
        #endregion

        #region Accessors
        
        
        #endregion

        #region Constructor
        public Input(Bus pBus)
        {
            mBus = pBus; // Reference to Bus object
        }
        #endregion

        #region Methods
        public void Listen()
        {
            // Main player entry
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Enter a command: forward, backward, left, right, pause");
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
            // Check player entry, call approperiate method in the bus object
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
                case "pause":
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("                       ");
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("The horn beeps");
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
