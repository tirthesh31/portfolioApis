using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Utilities
{

    class Credentials
    {
        public string company_mail { get; set; }
        public string company_mail_password { get; set; }
    }
    public class Mailer
    {

        private Credentials credentials;

        public Mailer()
        {
            string json_data = File.ReadAllText(@"C:\Users\Rishit.Selia.SSMLEC_10\Desktop\EndeavoursAPI\EndeavoursAPI\EndeavoursAPI\Credentials.json");
            credentials = JsonSerializer.Deserialize<Credentials>(json_data);
        }

        public void SendMail(string subject,string HtmlBody, string ReciepentIDs, string CC = null, string BCC = null)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(credentials.company_mail, credentials.company_mail_password);

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(credentials.company_mail);

                        foreach (string ids in ReciepentIDs.Split(","))
                            mailMessage.To.Add(ids);

                        if(CC != null)
                            foreach (string CCs in CC.Split(","))
                                mailMessage.CC.Add(CCs);
                        if(BCC != null)
                            foreach (string BCCs in BCC.Split(","))
                                mailMessage.Bcc.Add(BCCs);

                        mailMessage.Subject = subject;
                        mailMessage.Body = HtmlBody;

                        mailMessage.IsBodyHtml = true;
                       
                        smtpClient.Send(mailMessage);
                    }
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }

        public void SendMail(string subject, string HtmlBody, string ReciepentIDs,List<Attachment> attachments, string CC = null, string BCC = null)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.example.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(credentials.company_mail, credentials.company_mail_password);

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(credentials.company_mail);

                        foreach (string ids in ReciepentIDs.Split(","))
                            mailMessage.To.Add(ids);

                        foreach (string CCs in CC.Split(","))
                            mailMessage.CC.Add(CCs);

                        foreach (string BCCs in BCC.Split(","))
                            mailMessage.Bcc.Add(BCCs);

                        foreach(Attachment attachment in attachments)
                            mailMessage.Attachments.Add(attachment);

                        mailMessage.Subject = subject;
                        mailMessage.Body = HtmlBody;

                        mailMessage.IsBodyHtml = true;

                        smtpClient.Send(mailMessage);
                    }
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }

    }
}
