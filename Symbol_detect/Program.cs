using Aardvark.Base;
using System.IO.Compression;
using System.Net;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;

namespace Symbol_detect
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting the python file");
            Python_file1();

        }

        static void Python_file1()
        {
            var file = new ProcessStartInfo();

            file.FileName = @"C:\Users\Pramod_Nagaraj\Anaconda3\envs\dummy\python.exe";

            var script = @"C:\Users\Pramod_Nagaraj\source\repos\App\Opermin\Symbol_detect\script\text_detect_exe.py";
            file.Arguments = $"\"{script}\"";

            file.UseShellExecute = false;
            file.RedirectStandardOutput = true;
            file.RedirectStandardError = true;
            file.CreateNoWindow = true;

            var errors = "";
            var results = "";

            using (var process = Process.Start(file))
            {
                errors = process.StandardOutput.ReadToEnd();
                results = process.StandardError.ReadToEnd();
            }

            Console.WriteLine("ERRORS");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("RESULTS");
            Console.WriteLine(results);

        }

    }
}