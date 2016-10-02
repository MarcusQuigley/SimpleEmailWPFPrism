using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using MailSelection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSelection.ModuleDefinitions
{
    public class Module : IModule
    {
        IRegionManager regionManager;

        public Module(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("FolderSelectionRegion", typeof(MailSelectionView));
        }
    }
}
