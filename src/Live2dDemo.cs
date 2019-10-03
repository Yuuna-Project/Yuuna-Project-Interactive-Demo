using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public partial class Live2dDemo : WinFormium
    {
        public Live2dDemo() : base("http://localhost/live2d/demo.html")
        {
            InitializeComponent();

            var screens = new List<Screen>( Screen.AllScreens);
            if(screens.Count > 0)
            {
                //最右下的螢幕
                var targetScreen = screens[0];
                screens.RemoveAt(0);

                foreach (var scr in screens)
                {
                    if(scr.Bounds.X> targetScreen.Bounds.X || scr.Bounds.Height > targetScreen.Bounds.Height)
                    {
                        targetScreen = scr;
                    }
                }

                // 400 為估算值，實際上應為 this.Width
                this.Location = new Point(targetScreen.WorkingArea.Right-400, targetScreen.WorkingArea.Bottom-this.Height);
            } 

        }
    }
}
