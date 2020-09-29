using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Tools
{
    public class EmailHelper
    {
        public static void SendEmail(string emailAddr,string code)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("hlz2516", "hlz2516@sina.com"));
            message.To.Add(new MailboxAddress("whatever", emailAddr));
            message.Subject = "test";
            message.Body = new TextPart("plain") { Text = $"your code is {code}" };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.sina.com.cn", 25, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("hlz2516", "d5923a98f2d86586");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
