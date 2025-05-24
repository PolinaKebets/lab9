using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class OfficePrinter : PrinterBase, ISortFunction
    {
        public override void GetInfo()
        {
            Console.WriteLine($"Офисный принтер {Model}, формат {Format}");
        }

        public void SortDocuments()
        {
            Console.WriteLine("Сортировка документов для офисного принтера");
        }
    }
}
