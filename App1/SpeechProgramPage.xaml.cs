using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// Create a list of strings from user input for commands and actions, can convert to an array. Also have parallel action list

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpeechProgramPage : Page
    {
        String action5 = "", action4 = "", action3 = "", action2 = "", action1 = "";
        List<String> Actionlist = new List<String>();
        List<String> Commandlist = new List<String>();

        public SpeechProgramPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Actionlist.Clear();
            Commandlist.Clear();

            if (CommandBox1.Text != "" && action1 != "")
            {
                Actionlist.Add(CommandBox1.Text);
                Commandlist.Add(action1);
            }
            if (CommandBox2.Text != "" && action2 != "")
            {
                Actionlist.Add(CommandBox2.Text);
                Commandlist.Add(action2);
            }
            if (CommandBox3.Text != "" && action3 != "")
            {
                Actionlist.Add(CommandBox3.Text);
                Commandlist.Add(action3);
            }
            if (CommandBox4.Text != "" && action4 != "")
            {
                Actionlist.Add(CommandBox4.Text);
                Commandlist.Add(action4);
            }
            if (CommandBox5.Text != "" && action5 != "")
            {
                Actionlist.Add(CommandBox5.Text);
                Commandlist.Add(action5);
            }

            App.commands = Commandlist.ToArray();
            App.actions = Actionlist.ToArray();
        }

        private void ActionCombo5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            action5 = item.Content.ToString();
        }

        private void ActionCombo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            action4 = item.Content.ToString();
        }

        private void ActionCombo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            action3 = item.Content.ToString();
        }

        private void ActionCombo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            action2 = item.Content.ToString();
        }

        private void ActionCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            action1 = item.Content.ToString();
        }
    }
}
