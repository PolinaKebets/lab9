using System;
using System.Collections.Generic;

// Перечисление для форматов печати
public enum PrintFormat
{
    A4,
    A3,
    LargeFormat44
}

// Интерфейс для основной функции печати (шаблон "Мост")
public interface IPrintTechnology
{
    void PrintDocument();
}

// Реализации технологий печати
public class LaserPrint : IPrintTechnology
{
    public void PrintDocument()
    {
        Console.WriteLine("Печатает с использованием лазерной технологии");
    }
}

public class InkjetPrint : IPrintTechnology
{
    public void PrintDocument()
    {
        Console.WriteLine("Печатает с использованием струйной технологии");
    }
}

public class SublimationPrint : IPrintTechnology
{
    public void PrintDocument()
    {
        Console.WriteLine("Печатает с использованием сублимационной технологии");
    }
}

// Базовый абстрактный класс принтера
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

// Интерфейсы дополнительных функций
public interface IRollPrint
{
    void PrintFromRoll();
}

public interface ISortFunction
{
    void SortDocuments();
}

public interface IWebInterface
{
    void AccessWebInterface();
}

// Конкретные классы принтеров
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

// Строитель для создания принтеров (шаблон "Строитель")
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

public class OfficePrinterBuilder : PrinterBuilder
{
    public override PrinterBase Build()
    {
        var printer = new OfficePrinter { Model = model, Format = format };
        if (technology != null)
        {
            printer.SetPrintTechnology(technology);
        }
        return printer;
    }
}

public class LargeFormatPrinterBuilder : PrinterBuilder
{
    public override PrinterBase Build()
    {
        var printer = new LargeFormatPrinter { Model = model, Format = format };
        if (technology != null)
        {
            printer.SetPrintTechnology(technology);
        }
        return printer;
    }
}

public class PhotoPrinterBuilder : PrinterBuilder
{
    public override PrinterBase Build()
    {
        var printer = new PhotoPrinter { Model = model, Format = format };
        if (technology != null)
        {
            printer.SetPrintTechnology(technology);
        }
        return printer;
    }
}

// Директор для создания стандартных конфигураций
public static class PrinterDirector
{
    public static PrinterBase GetStandardOfficePrinter(string model, PrinterBuilder builder)
    {
        return builder.SetModel(model)
                      .SetFormat(PrintFormat.A4)
                      .SetPrintTechnology(new LaserPrint())
                      .Build();
    }

    public static PrinterBase GetPhotoPrinter(string model, PrinterBuilder builder)
    {
        return builder.SetModel(model)
                      .SetFormat(PrintFormat.A3)
                      .SetPrintTechnology(new SublimationPrint())
                      .Build();
    }

    public static PrinterBase GetLargeFormatPrinter(string model, PrinterBuilder builder)
    {
        return builder.SetModel(model)
                      .SetFormat(PrintFormat.LargeFormat44)
                      .SetPrintTechnology(new InkjetPrint())
                      .Build();
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        var printers = new List<PrinterBase>();
        var officeBuilder = new OfficePrinterBuilder();
        var largeFormatBuilder = new LargeFormatPrinterBuilder();
        var photoBuilder = new PhotoPrinterBuilder();

        printers.AddRange(new PrinterBase[] {
            PrinterDirector.GetStandardOfficePrinter("HP LaserJet", officeBuilder),
            PrinterDirector.GetPhotoPrinter("Canon Pixma", photoBuilder),
            PrinterDirector.GetLargeFormatPrinter("Epson SureColor", largeFormatBuilder)
        });

        foreach (var printer in printers)
        {
            printer.GetInfo();
            printer.Print();

            // Вызов дополнительных функций в зависимости от типа принтера
            if (printer is ISortFunction sortPrinter)
            {
                sortPrinter.SortDocuments();
            }

            if (printer is IRollPrint rollPrinter)
            {
                rollPrinter.PrintFromRoll();
            }

            if (printer is IWebInterface webPrinter)
            {
                webPrinter.AccessWebInterface();
            }

            Console.WriteLine("---");
        }
    }
}