﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class LaserPrint : IPrintTechnology
    {
        public void PrintDocument()
        {
            Console.WriteLine("Печатает с использованием лазерной технологии");
        }
    }

}
