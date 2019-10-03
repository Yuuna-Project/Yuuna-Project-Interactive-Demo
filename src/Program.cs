
namespace Yuuna.InteractiveDemo
{
    using NetDimension.NanUI;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             
            var result = Bootstrap.Load();

            var nginxes = Process.GetProcessesByName("nginx.exe");
            if(nginxes.Length == 0)
            {
                foreach (var item in new DirectoryInfo("./nginx").GetFiles())
                {
                    if(item.Name.Contains("nginx"))
                    {
                        Process.Start(item.FullName);
                    }
                }
                nginxes = Process.GetProcessesByName("nginx.exe");
            }

            if (result)
            { 
                Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly());

                Application.Run(new Live2dDemo()); 
                Application.Exit();
            }

            foreach (var nginx in nginxes)
            {
                nginx.Kill();
            }
        }
    }
     
}

