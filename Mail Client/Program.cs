using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Mail_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать программу для отправки электронного письма.  Пользователь сам указывает логин/ пароль и получателя.
            Console.WriteLine("Введите почту:\n");
            string a = Console.ReadLine();
            Console.WriteLine("Введите пароль:\n");
            Console.ReadLine();
            Console.WriteLine("Пользователь авторизован.\n");
            Console.ReadKey();
            method1(a);


        }
        static void method1(string a)
        {
            Console.Clear();
            MailAddress from = new MailAddress(a);
            Console.WriteLine("Укажите получателя письма:");
            string b = Console.ReadLine();
            MailAddress to = new MailAddress(b);

            MailMessage objectMail =new MailMessage(from, to);
            Console.WriteLine("Введите тему письма:\n");
            string c = Console.ReadLine();
            objectMail.Subject = c;
            Console.WriteLine("Введите текст письма");
            string d = Console.ReadLine();
            objectMail.Body = $"<h2>{d}<h2>";
            objectMail.IsBodyHtml = true;

            Console.WriteLine("Введите адрес smtp сервера, с которого будете отправлять письмо:");
            string e = Console.ReadLine();
            Console.WriteLine("Введите порт smtp сервера, с которого будете отправлять письмо:");
            int g = Convert.ToInt32(Console.ReadLine());
            SmtpClient smtp = new SmtpClient(e, g);

            Console.WriteLine("Введите логин от smtp сервера:");
            string h = Console.ReadLine();
            Console.WriteLine("Введите пароль от smtp сервера:");
            string i = Console.ReadLine();
            smtp.Credentials = new NetworkCredential(h, i);
            smtp.EnableSsl = true;
            smtp.Send(objectMail);
            Console.Read();


        }
    }
}
