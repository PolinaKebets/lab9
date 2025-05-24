using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public abstract class PrinterBuilder
    {
        protected string model = "Default";
        protected PrintFormat format = PrintFormat.A4;
        protected IPrintTechnology technology = null;

        public PrinterBuilder SetModel(string model)
        {
            this.model = model;
            return this;
        }

        public PrinterBuilder SetFormat(PrintFormat format)
        {
            this.format = format;
            return this;
        }

        public PrinterBuilder SetPrintTechnology(IPrintTechnology technology)
        {
            this.technology = technology;
            return this;
        }

        public abstract PrinterBase Build();
    }
}
