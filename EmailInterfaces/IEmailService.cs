using EmailEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailInterfaces
{
   public interface IEmailService
    {
       List<EmailFolder> MailFolders { get; }
       void SendEmail(Email email);
       void DeleteEmail(Email email);
    }
}
