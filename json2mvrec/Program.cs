using System;
using System.IO;

namespace json2mvrec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convert .json -> mvrec");
            Console.WriteLine(args[0]);
            var a = new Convert();
            var b = a.ReadRecordFile(args[0]);
            Console.WriteLine("JSON read OK");
            a.ConvertMvrec(b, Path.GetFileNameWithoutExtension(args[0]) + ".mvrec");
        }
    }
}
