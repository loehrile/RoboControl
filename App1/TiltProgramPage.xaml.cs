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
    public sealed partial class TiltProgramPage : Page
    {
        String TiltProgramInput1 = "", TiltProgramInput2 = "", TiltProgramInput3 = "";

        public TiltProgramPage()
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
            App.M1TX = App.M1TY = App.M2TX = App.M2TY = 0;

            if (TiltProgramInput1 != "")
            {
                if (TiltProgramInput1 == "move motor 1")
                    App.M1TX = 1;
                if (TiltProgramInput1 == "move motor 2")
                    App.M2TX = 1;
                if (TiltProgramInput1 == "move motors 1 and 2")
                    App.M1TX = App.M2TX = 1;
            }

            if (TiltProgramInput2 != "")
            {
                if (TiltProgramInput1 == "move motor 1")
                    App.M1TY = 1;
                if (TiltProgramInput1 == "move motor 2")
                    App.M2TY = 1;
                if (TiltProgramInput1 == "move motors 1 and 2")
                    App.M1TY = App.M2TY = 1;
            }

            if (TiltProgramInput3 != "")
            {
                if (TiltProgramInput1 == "move motors 1 and 2")
                    App.M1TX = App.M2TX = App.M1TY = App.M2TY = 1;
            }
        }

        private void TiltXCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            TiltProgramInput1 = item.Content.ToString();
        }

        private void TiltYCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            TiltProgramInput2 = item.Content.ToString();
        }

        private void TiltXYCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            TiltProgramInput3 = item.Content.ToString();
        }
    }
}
