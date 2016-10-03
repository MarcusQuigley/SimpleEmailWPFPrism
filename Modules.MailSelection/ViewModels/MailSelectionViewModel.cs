using EmailEntities;
using EmailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace MailSelection.ViewModels
{
    public class MailSelectionViewModel : ViewModelBase
    {
        IEmailService emailService;
        EmailFolder selectedFolder;
        ICommand selectFolderCommand;

        public MailSelectionViewModel(IEmailService emailService, IEventAggregator eventAggregator)
        {
            this.emailService = emailService;
         //   this.eventAggregator = eventAggregator;

            SetUpCommands();
        }
 
        public IEnumerable<EmailFolder> Folders
        {
            get { return emailService.MailFolders; }
        }
 
        public EmailFolder SelectedFolder
        {
            get { return selectedFolder; }
            set {
                selectedFolder = value;
                this.OnPropertyChanged("SelectedFolder");
            }
        }

        public ICommand SelectFolderCommand
        {
            get { return selectFolderCommand; }
           // set { selectFolderCommand = value; }
        }

        private void SetUpCommands()
        {
            selectFolderCommand = new DelegateCommand<EmailFolder> (FolderSelected,CanSelectFolder);
        }



        private bool CanSelectFolder(EmailFolder folder)
        {
            return true;// SelectedFolder != null;
        }

        private void FolderSelected(EmailFolder folder)
        {
         //    SelectedFolder = ?
        }
    }
}
