using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmailEntities.Behaviours
{
    public static class TreeViewSelect
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
            "Command", typeof(ICommand), typeof(TreeViewSelect),
            new PropertyMetadata(OnSetCommandCallback));

        private static void OnSetCommandCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeView tv = d as TreeView;
            if (tv != null)
            {
                TreeViewSelectionChangedCommandBehaviour behaviour = GetOrCreateBehaviour(tv);
                behaviour.Command = e.NewValue as ICommand;
            }
        }

        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty = 
            DependencyProperty.RegisterAttached(
            "CommandParameter", typeof(object), typeof(TreeViewSelect), 
            new PropertyMetadata(OnSetCommandParameterCallback));

        private static void OnSetCommandParameterCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeView tv = d as TreeView;
            if (tv != null)
            {
                TreeViewSelectionChangedCommandBehaviour behaviour = GetOrCreateBehaviour(tv);
                behaviour.CommandParameter = e.NewValue;
            }

        }
 
        private static readonly DependencyProperty SelectCommandBehaviourProperty =
           DependencyProperty.RegisterAttached(
           "SelectCommandBehaviourProperty",
           typeof(object),
           typeof(TreeViewSelect),
           null);


        private static TreeViewSelectionChangedCommandBehaviour GetOrCreateBehaviour(TreeView treeView)
        {
            TreeViewSelectionChangedCommandBehaviour behaviour =
                treeView.GetValue(SelectCommandBehaviourProperty) as TreeViewSelectionChangedCommandBehaviour;
            if (behaviour == null)
            {
                behaviour = new TreeViewSelectionChangedCommandBehaviour(treeView);
                treeView.SetValue(SelectCommandBehaviourProperty, behaviour);
            }
            return behaviour;
        }
 
    }
}
