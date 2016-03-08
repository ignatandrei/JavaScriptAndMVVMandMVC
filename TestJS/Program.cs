using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJS
{
    class Program
    {
        static void Main(string[] args)
        {
            //karma start D:\github\JavaScriptAndMVVMandMVC\TestJS\my.conf.js
            var karmaPath = @"C:\Users\admin\AppData\Roaming\npm\karma.cmd";
            var file = Path.Combine(Directory.GetCurrentDirectory(), "my.conf.js");
            var ps=new ProcessStartInfo(karmaPath, "start " + file );
            ps.WorkingDirectory = @"C:\Users\admin";
            ps.UseShellExecute = false;
            ps.CreateNoWindow = true;
            ps.RedirectStandardOutput = true;
            ps.RedirectStandardError = true;
            var p=Process.Start(ps);
            p.WaitForExit();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            Console.WriteLine(p.StandardError.ReadToEnd());
            Console.Read();

        }
    }
}
