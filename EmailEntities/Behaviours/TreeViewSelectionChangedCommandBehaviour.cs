using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EmailEntities.Behaviours
{
    public class TreeViewSelectionChangedCommandBehaviour : CommandBehaviorBase<TreeView>
    {
        public TreeViewSelectionChangedCommandBehaviour(TreeView treeView)
            : base(treeView)
        {
            treeView.SelectedItemChanged += SelectedItemChangedHandler;
        }

        void SelectedItemChangedHandler(object sender,  RoutedPropertyChangedEventArgs<object> e)
        {
             base.ExecuteCommand();
        }
    }
}
