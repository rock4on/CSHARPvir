using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace projEmil
{

    //singleton class used for sending mails with files
    class MailSender
    {
        private static MailSender instance = null;
        private static readonly object padlock = new object();

        //parola si user-ul gmail
        const string user = "";
        const string parola = "";
        const string primire = "exemplu@gmail.com";
        MailSender()
        {
        }
       





        public void send(string pth)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(primire);
            mail.To.Add("to_address");
            mail.Subject = "vir";
            mail.Body = "fisiere vir";
            var fisiere = Directory.GetFiles(pth);

            foreach(string str in fisiere)
            {
                mail.Attachments.Add(new Attachment(str));
            }


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(user, parola);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }



        public static MailSender Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MailSender();
                    }
                    return instance;
                }
            }
        }
    }
}
