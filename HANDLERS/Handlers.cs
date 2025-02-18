using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANDLERS
{
    public class Handlers
    {
        private void BBO_Handler(dynamic response, bool ack)
        {
            if (!ack)
            {
                if (response.Code != 0 || response.Code == 21002)
                {
                    string msg = "BBO Subscribe Error: " + response.Message;
                    Print(msg, ConsoleColor.Red);
                    return;
                }
                Print("BBO Subscribe Successful", ConsoleColor.Green);
                return;
            }
            else if (ack)
            {
                Console.WriteLine("uhh" + response.Data);
            }
        }

        private void Auth_Handler(dynamic response, bool ack)
        {
            if (response.Code != 0 || response.Code == 21002)
            {
                string msg = "Authentication Error: " + response.Message;
                Print(msg, ConsoleColor.Red);
                return;
            }
            Print("Authentication Successful", ConsoleColor.Green);
            return;
        }

        public void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
}
