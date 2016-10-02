using MailSelection.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MailSelection.Views
{
    /// <summary>
    /// Interaction logic for MailSelectionView.xaml
    /// </summary>
    public partial class MailSelectionView : UserControl
    {
        public MailSelectionView(MailSelectionViewModel vm)
        {
            InitializeComponent();
            this.Loaded += ((o,g) =>
            {
                this.DataContext = vm;
            });
         }
    }
}
