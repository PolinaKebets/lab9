using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class LargeFormatPrinter : PrinterBase, IRollPrint
    {
        public override void GetInfo()
        {
            Console.WriteLine($"Широкоформатный принтер {Model}, формат {Format}");
        }

        public void PrintFromRoll()
        {
            Console.WriteLine("Печать с рулона на широкоформатном принтере");
        }
    }
}
