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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ButtonProgramPage : Page
    {
        String ButtonProgInput1a = "", ButtonProgInput1b = "", ButtonProgInput2a = "", ButtonProgInput2b = "",
            ButtonProgInput3a = "", ButtonProgInput3b = "", ButtonProgInput4a = "", ButtonProgInput4b = "";

        public ButtonProgramPage()
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

        private void LogicCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput1a = item.Content.ToString();
        }

        private void MotorCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput1b = item.Content.ToString();
        }

        private void LogicCombo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput2a = item.Content.ToString();
        }

        private void MotorCombo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput2b = item.Content.ToString();
        }

        private void LogicCombo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput3a = item.Content.ToString();
        }

        private void MotorCombo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput3b = item.Content.ToString();
        }

        private void LogicCombo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput4a = item.Content.ToString();
        }

        private void MotorCombo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ButtonProgInput4b = item.Content.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            App.UW = App.DW = App.LW = App.RW = 0;
            App.M1U = App.M2U = App.M1D = App.M2D = App.M1L = App.M2L = App.M1R = App.M2R = 0;

            if (ButtonProgInput1a == "While")
                App.UW = 1;
            if (ButtonProgInput2a == "While")
                App.DW = 1;
            if (ButtonProgInput3a == "While")
                App.LW = 1;
            if (ButtonProgInput4a == "While")
                App.RW = 1;

            if(ButtonProgInput1b != "")
            {
                if (ButtonProgInput1b == "move motor 1")
                    App.M1U = 1;
                if (ButtonProgInput1b == "move motor 2")
                    App.M2U = 1;
                if (ButtonProgInput1b == "move motors 1 and 2")
                    App.M1U = App.M2U = 1;
            }

            if (ButtonProgInput2b != "")
            {
                if (ButtonProgInput2b == "move motor 1")
                    App.M1D = 1;
                if (ButtonProgInput2b == "move motor 2")
                    App.M2D = 1;
                if (ButtonProgInput2b == "move motors 1 and 2")
                    App.M1D = App.M2D = 1;
            }

            if (ButtonProgInput3b != "")
            {
                if (ButtonProgInput3b == "move motor 1")
                    App.M1L = 1;
                if (ButtonProgInput3b == "move motor 2")
                    App.M2L = 1;
                if (ButtonProgInput3b == "move motors 1 and 2")
                    App.M1L = App.M2L = 1;
            }
            
            if (ButtonProgInput4b != "")
            {
                if (ButtonProgInput4b == "move motor 1")
                    App.M1R = 1;
                if (ButtonProgInput4b == "move motor 2")
                    App.M2R = 1;
                if (ButtonProgInput4b == "move motors 1 and 2")
                    App.M1R = App.M2R = 1;
            }
        }
    }
}
