using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Application.Helpers;
using WebMVCComDDD.Application.Interfaces;

namespace WebMVCComDDD.Application.Applications
{
    public class EmailApplication : IEmailApplication
    {
        private readonly EmailSettings _mailsettings;
        private EmailSettings? mailSettings;
        private object mailRequest;

        public EmailApplication(IOption<EmailSettings> emailSettings)
        {
            _mailsettings = mailSettings;

        }

        public Task SendEmailAsync(EmailRequest emailRequest)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmailAsyncc(EmailRequest _mailSettings)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(_mailsettings.Mail, _mailsettings.DisplayName);
            message.To.Add(new MailAddress(_mailSettings.ToEmail));
            message.Subject = _mailSettings.Subject;

            if (_mailSettings.Attachments != null)
            {
                foreach (var file in _mailSettings.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }

            message.IsBodyHtml = true;
            message.Body = mailRequest.Body;
            smtp.Port = _mailsettings.Port;
            smtp.Host = _mailsettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        Task IEmailApplication.SendEmailAsyncc(EmailRequest emailRequest)
        {
            throw new NotImplementedException();
        }

        Task IEmailApplication.SendEmailAsyncc()
        {
            throw new NotImplementedException();
        }
    }
}
