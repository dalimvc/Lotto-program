using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lottoprogram
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        int value1;
        int value2;
        int value3;
        int value4;
        int value5;
        int value6;
        int value7;

        public void GetNumbers()
        {
                value1 = int.Parse(number1.Text);
                value2 = int.Parse(number2.Text);
                value3 = int.Parse(number3.Text);
                value4 = int.Parse(number4.Text);
                value5 = int.Parse(number5.Text);
                value6 = int.Parse(number6.Text);
                value7 = int.Parse(number7.Text);     

        }

        public void CheckNumberValidity()
        {

        }

        private void RunLotto(object sender, RoutedEventArgs e)
        {
            try
            {
                GetNumbers();
            }
            catch
            {
                Debug.WriteLine(e);
            }
            

            Debug.WriteLine("lallaa");
            Debug.WriteLine(value1);
        }


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
