using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public abstract class PrinterBase
    {
        public string Model { get; set; }
        public PrintFormat Format { get; set; }
        protected IPrintTechnology PrintTechnology { get; set; }

        public void SetPrintTechnology(IPrintTechnology technology)
        {
            PrintTechnology = technology;
        }

        public abstract void GetInfo();

        public void Print()
        {
            if (PrintTechnology != null)
            {
                PrintTechnology.PrintDocument();
            }
            else
            {
                Console.WriteLine("Технология печати не установлена");
            }
        }
    }
}
