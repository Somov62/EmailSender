using System;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender sender = new EmailSender();
            sender.SimpleSend("misha2003980@gmail.com", "aboba", "aboba");
            Console.ReadKey();
        }
    }
}
