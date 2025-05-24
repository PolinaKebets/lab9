using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class PhotoPrinter : PrinterBase, IWebInterface
    {
        public override void GetInfo()
        {
            Console.WriteLine($"Фотопринтер {Model}, формат {Format}");
        }

        public void AccessWebInterface()
        {
            Console.WriteLine("Доступ к веб-интерфейсу фотопринтера");
        }
    }
}
