using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailEntities
{
    public class EmailFolder
    {
        List<Email> emails;

        public event EventHandler<EmailFolderChangedEventArgs> EmailChanged;


        public EmailFolder()
            : this(new List<Email>())
        { }
 
        public EmailFolder(params Email[] emails)
            // : this((IEnumerable < Email >) emails)
            : this(emails.ToList<Email>())
        { }

        public EmailFolder(IEnumerable<Email> emails)
        {
            this.emails = new List<Email>();
            foreach (Email email in emails)
            {
                email.EnFolder(this);
            }
        }

        public string Name { get; set; }


        public IEnumerable<Email> Emails
        {
            get
            {
                IEnumerable<Email> copy;
                lock (emails)
                {
                    copy = new List<Email>(emails);
                }
                return copy;
            }
        }

        public void DeleteMail(Email email)
        {
            lock (this.emails)
            {
                this.emails.Remove(email);
            }
            OnEmailChanged(EmailFolderChangeType.Deleted, email);

         }

        public void AddMail(Email email)
        {
            lock (this.emails)
            {
                this.emails.Add(email);
            }
            OnEmailChanged(EmailFolderChangeType.Added, email);
        }

        protected void OnEmailChanged(EmailFolderChangeType changeType, Email email)
        {
            if (EmailChanged != null)
            {
                EmailChanged(this,
                    new EmailFolderChangedEventArgs(changeType, email));
            }
        }
    }
}
