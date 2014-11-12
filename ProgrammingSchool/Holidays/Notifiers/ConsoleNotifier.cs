using System;
using Holidays.Interfaces;

namespace Holidays.Notifiers
{
    public class ConsoleNotifier : INotifier
    {
        public void Notify(string sender, string receiver, string subject, string body)
        {
            Console.WriteLine("Email sent");
            Console.WriteLine("\tFrom    : {0}", sender);
            Console.WriteLine("\tTo      : {0}", receiver);
            Console.WriteLine("\tSubject : {0}", subject);
            Console.WriteLine("\tBody    : {0}", body);
            Console.WriteLine();
        }
    }
}