using System;
using System.IO;

namespace json2mvrec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convert .json -> mvrec");
            var convert = new Convert();
            foreach (var path in args)
            {
                Console.WriteLine(path);
                var json = convert.ReadRecordFile(path);
                if (json == null)
                {
                    Console.WriteLine("JSON read ERR!");
                    continue;
                }
                Console.WriteLine("JSON read OK");
                var savePath = Path.GetFileNameWithoutExtension(Path.GetFullPath(path)) + ".mvrec";
                Console.WriteLine(savePath);
                convert.ConvertMvrec(json, savePath);
            }
            if (args.Length == 0)
                Console.WriteLine("Paste the MovementRecorder recording file (*.json) into json2mvrec.exe by drag & drop");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
