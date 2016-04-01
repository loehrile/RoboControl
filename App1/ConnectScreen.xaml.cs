using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Maker.Firmata;
using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
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
    public sealed partial class ConnectScreen : Page
    {
        public ConnectScreen()
        {
            this.InitializeComponent();
            this.InitArduino();
        }

        public void InitArduino()
        {
            RetryButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            //Establish a network serial connection. change it to the right IP address and port
            App.netWorkSerial = new Microsoft.Maker.Serial.NetworkSerial(new Windows.Networking.HostName("192.168.1.133"), 3030);

            //Create Arduino Device
            App.arduino = new Microsoft.Maker.RemoteWiring.RemoteDevice(App.netWorkSerial);

            //Attach event handlers
            App.netWorkSerial.ConnectionEstablished += NetWorkSerial_ConnectionEstablished;
            App.netWorkSerial.ConnectionFailed += NetWorkSerial_ConnectionFailed;

            //Begin connection
            App.netWorkSerial.begin(9600, Microsoft.Maker.Serial.SerialConfig.SERIAL_8N1);
            ConnectText.Text = "Attempting to connect to Arduino...";
        }

        private void NetWorkSerial_ConnectionEstablished()
        {
            ConnectText.Text = "Successfully connected!";

            // Setup pin outputs on the arduino
            App.arduino.pinMode(2, Microsoft.Maker.RemoteWiring.PinMode.OUTPUT);
            App.arduino.pinMode(3, Microsoft.Maker.RemoteWiring.PinMode.OUTPUT);
            App.StartButtonEnable = true;
        }

        private void NetWorkSerial_ConnectionFailed(string message)
        {
            ConnectText.Text = ("Arduino Connection Failed: " + message);
            RetryButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            this.InitArduino();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
