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
using Windows.Media.SpeechRecognition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.Devices.Sensors;

namespace App1
{
    public sealed partial class ControlPage : Page
    {
        // Setup accelerometer and bool to check wake state
        private Accelerometer _accelerometer;
        Boolean TiltWake = false, SpeechWake = false;

        // setup speechrecognizer
       // private SpeechRecognizer SpRec;

        // when accelerometer detects a change
        private async void ReadingChanged(object sender, AccelerometerReadingChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = e.Reading;

                //convert accelerometer values to pwm values
                double x = reading.AccelerationX * 127 / 2;
                double y = reading.AccelerationY * 127 / 2;

                //set limits
                if (x > 127) x = 127;
                if (x < -127) x = -127;
                if (y > 127) y = 127;
                if (y < -127) y = -127;

                //set motor speeds
                MoveMotor1((ushort)(127 + App.M1TX * x + App.M1TY * y));
                MoveMotor2((ushort)(127 + App.M2TX * x + App.M2TY * y));

            });
        }

        public ControlPage()
        {
            this.InitializeComponent();

           // InitializeSpeechRecognizer();

            _accelerometer = Accelerometer.GetDefault();

            if (_accelerometer != null)
            {
                if (TiltWake)
                {
                    // Establish the report interval
                    uint minReportInterval = _accelerometer.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _accelerometer.ReportInterval = reportInterval;

                    // Assign an event handler for the reading-changed event
                    _accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }



      /*  private async void InitializeSpeechRecognizer()
        {
            SpRec = new SpeechRecognizer();

            //create event handler
            SpRec.ContinuousRecognitionSession.ResultGenerated += SpRec_ResultGenerated;

            //set grammar constraints
            if (App.actions != null)
            {
                var listConstraint = new Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint(App.commands);
                SpRec.Constraints.Add(listConstraint);
            }
            else return;

            SpeechRecognitionCompilationResult CompilationResult = await SpRec.CompileConstraintsAsync();

            if (CompilationResult.Status == SpeechRecognitionResultStatus.Success)
            {
                await SpRec.ContinuousRecognitionSession.StartAsync();
            }
        }

        private void SpRec_ResultGenerated(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionResultGeneratedEventArgs args)
        {
            if (SpeechWake)
            {
                //check to see if result is valid and performs coordinating action
                int ind = Array.IndexOf(App.commands, args.Result.Text);
                if ( ind != -1)
                {
                    switch (App.actions[ind])
                    {
                        case "move motor 1 forward":
                            MoveMotor1(127 + 65);
                            break;
                        case "move motor 1 backward":
                            MoveMotor1(127 - 65);
                            break;
                        case "move motor 2 forward":
                            MoveMotor2(127 + 65);
                            break;
                        case "move motor 2 backward":
                            MoveMotor2(127 - 65);
                            break;
                        case "move motors 1 and 2 forward":
                            MoveMotor1(127 + 65);
                            MoveMotor2(127 + 65);
                            break;
                        case "move motors 1 and 2 backward":
                            MoveMotor1(127 - 65);
                            MoveMotor2(127 - 65);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        */
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        // Use analogWrite to set PWM value of motors 0-255, 127=stop
        private void MoveMotor1(ushort val)
        {
            //App.arduino.analogWrite(2, val);
        }

        private void MoveMotor2(ushort val)
        {
            //App.arduino.analogWrite(3, val);
        }

        // If the button is pressed, the motor will move if programmed to do so
        private void UpButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127+App.M1U*65));
            MoveMotor2((ushort)(127+App.M2U*65));
        }

        // If the button is programmed as a while statement, then the motor will be turned off when the button is released
        private void UpButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127+App.UW*App.M1U*65));
            MoveMotor2((ushort)(127+App.UW*App.M2U*65));
        }

        // Stop all motors
        private void StopButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1(127);
            MoveMotor2(127);
        }

        private void LeftButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 - App.M1L * 65));
            MoveMotor2((ushort)(127 - App.M2L * 65));
        }

        private void LeftButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 - App.LW * App.M1L * 65));
            MoveMotor2((ushort)(127 - App.LW * App.M2L * 65));
        }

        private void RightButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 + App.M1R * 65));
            MoveMotor2((ushort)(127 + App.M2R * 65));
        }

        private void RightButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 + App.RW * App.M1R * 65));
            MoveMotor2((ushort)(127 + App.RW * App.M2R * 65));
        }

        private void DownButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 - App.M1D * 65));
            MoveMotor2((ushort)(127 - App.M2D * 65));
        }

        private void DownButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MoveMotor1((ushort)(127 - App.DW * App.M1D * 65));
            MoveMotor2((ushort)(127 - App.DW * App.M2D * 65));
        }

        //check if user wants to use tilt control
        private void TiltSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (TiltSwitch.IsOn)
                TiltWake = true;
            else
                TiltWake = false;
        }

        //check if user wants to use speech control
       private void SpeechSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (SpeechSwitch.IsOn)
                SpeechWake = true;
            else
                SpeechWake = false;
        }
        
    }
}
