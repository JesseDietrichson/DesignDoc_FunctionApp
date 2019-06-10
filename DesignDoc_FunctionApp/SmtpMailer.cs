using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public class SmtpMailer
    {
        public bool Send(SmtpSettings settings, string from, string to, string subject, string body,string fileName)
        {
            // TODO: Validate arguments
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.ReplyToList.Add(new MailAddress(from));
                    mail.Attachments.Add(new Attachment(fileName));

                    var smtp = new SmtpClient(settings.Host, settings.Port);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(settings.Username, settings.Password);
                    smtp.Timeout = 60000; // 60 seconds
                    smtp.EnableSsl = true; // Outlook.com and Gmail require SSL
                    smtp.Send(mail);

                    // email was accepted by the SMTP server
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: Log the exception message
                return false;
            }
        }
    }
}
