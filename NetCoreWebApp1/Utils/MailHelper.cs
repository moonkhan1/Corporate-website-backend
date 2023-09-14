using Entities;
using System.Net;
using System.Net.Mail;

namespace NetCoreWebApp1.Utils
{
    public class MailHelper
    {
        public static bool SendMail(Contact contact)
        {
			try
			{
				SmtpClient smtpClient = new SmtpClient("mail.sitename.com", 587);
                smtpClient.Credentials = new NetworkCredential("email user name", "email password");
                //smtpClient.EnableSsl = true;  // Əgər mail də Ssl olacaqsa
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ayxanhesenov3105@gmail.com");
                message.To.Add(contact.Email);
                message.Subject = "Message from site";
                message.Body = $"<p>Message Info; <hr/> Name: {contact.Name} <hr/> Email: {contact.Email} <hr/> Phone: {contact.Phone} " +
                    $"<hr/> Message: {contact.Message} <hr/> Date: {contact.CreationDate} </p>";
                message.IsBodyHtml = true;
                smtpClient.Send(message);


                return true;

            }
			catch (Exception)
			{
                return false;
			}
        }
    }
}
