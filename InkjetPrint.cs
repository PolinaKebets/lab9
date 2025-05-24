using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class InkjetPrint : IPrintTechnology
    {
        public void PrintDocument()
        {
            Console.WriteLine("Печатает с использованием струйной технологии");
        }
    }
}
