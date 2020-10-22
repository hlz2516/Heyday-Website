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
            //从

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("hlz2516", "hlz2516@sina.com"));
            message.To.Add(new MailboxAddress("whatever", emailAddr));
            message.Subject = "欢迎注册heyday!";
            message.Body = new TextPart("plain") { Text = $"您的验证码是 {code}，请及时输入进行注册。" };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.sina.com.cn", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("hlz2516", "d5923a98f2d86586");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
