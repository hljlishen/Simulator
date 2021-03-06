﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var controller = new PXES2590Controller(IniBind.IniFileObjectFactory<TacanModel>.CreateObject());
            var form = new Form1(controller);
            Application.Run(new Form2());
        }
    }
}
