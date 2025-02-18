using EXAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using EXAPI;

using System.Drawing;

namespace MMREAPER
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        

        static void Main()
        {
            AllocConsole();
            PrintArt();
            Thread.Sleep(3000);
            Console.Clear();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        private static void PrintArt()
        {
            string grim = @"                           ...
                         ;::::;
                       ;::::; :;
                     ;:::::'   :;
                    ;:::::;     ;.
                   ,:::::'       ;           OOO\
                   ::::::;       ;          OOOOO\
                   ;:::::;       ;         OOOOOOOO
                  ,;::::::;     ;'         / OOOOOOO
                ;:::::::::`. ,,,;.        /  / DOOOOOO
              .';:::::::::::::::::;,     /  /     DOOOO
             ,::::::;::::::;;;;::::;,   /  /        DOOO
            ;`::::::`'::::::;;;::::: ,#/  /          DOOO
            :`:::::::`;::::::;;::: ;::#  /            DOOO
            ::`:::::::`;:::::::: ;::::# /              DOO
            `:`:::::::`;:::::: ;::::::#/               DOO
             :::`:::::::`;; ;:::::::::##                OO
             ::::`:::::::`;::::::::;:::#                OO
             `:::::`::::::::::::;'`:;::#                O
              `:::::`::::::::;' /  / `:#
               ::::::`:::::;'  /  /   `#";
            string text = @"
 ▄▀▀▄▀▀▀▄  ▄▀▀█▄▄▄▄  ▄▀▀█▄   ▄▀▀▄▀▀▀▄  ▄▀▀█▄▄▄▄  ▄▀▀▄▀▀▀▄ 
█   █   █ ▐  ▄▀   ▐ ▐ ▄▀ ▀▄ █   █   █ ▐  ▄▀   ▐ █   █   █ 
▐  █▀▀█▀    █▄▄▄▄▄    █▄▄▄█ ▐  █▀▀▀▀    █▄▄▄▄▄  ▐  █▀▀█▀  
 ▄▀    █    █    ▌   ▄▀   █    █        █    ▌   ▄▀    █  
█     █    ▄▀▄▄▄▄   █   ▄▀   ▄▀        ▄▀▄▄▄▄   █     █   
▐     ▐    █    ▐   ▐   ▐   █          █    ▐   ▐     ▐   
           ▐                ▐          ▐                  ";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(grim);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
