﻿using IFTransceiverDrives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimView
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
            //var controller = new PXES2590Controller(IniBind.IniFileObjectFactory<TacanModel>.CreateObject(), new JXI750xSignalController());
            var controller = new PXES2590Controller(IniBind.IniFileObjectFactory<TacanModel>.CreateObject(), new JXI750xSignalController());
            Application.Run(new ControlPanel(controller));
        }
    }
}
