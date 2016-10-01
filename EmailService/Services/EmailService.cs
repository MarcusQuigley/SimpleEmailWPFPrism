using EmailEntities;
using EmailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EmailService
{
   public class EmailService : IEmailService
    {
        List<EmailFolder> emailFolders;
        Timer timer = null;

        public EmailService()
        {
            CreateEmailFolders();

            timer = new Timer((o) =>
            {
                Email email = Email.Create();
                email.EnFolder(emailFolders[0]);
                 
            });
            timer.Change(0, 30000);
        }

        private void CreateEmailFolders()
        {
            emailFolders = new List<EmailFolder>() 
            {
                
                new EmailFolder(Email.Create())
                {
                Name = "Inbox"
                },
                new EmailFolder()
                {
                    Name="SentItems"
                }
            };
        }

        public List<EmailFolder> MailFolders
        {
            get
            {
                List<EmailFolder> copy;

                lock (emailFolders)
                {
                    copy = new List<EmailFolder>(emailFolders);
                }
                return copy;
            }
        }

        public void SendEmail(Email email)
        {
            email.EnFolder(MailFolders[1]);
        }

        public void DeleteEmail(Email email)
        {
            email.Delete();
        }
    }
}
