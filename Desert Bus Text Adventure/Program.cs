using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desert_Bus_Text_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Kernel Kernel1 = new Kernel();
            while (Console.ReadKey(true).Key != ConsoleKey.Escape || Kernel1.aExit == false)
            {
                if (Kernel1.aRunGame == true)
                {
                    Kernel1.MasterLoop();
                }
            }
            // Exit hook
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Visit Desertbus.org");
            Console.WriteLine("Press enter key to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
