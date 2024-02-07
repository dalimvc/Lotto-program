using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        string errorMessage;
        int rounds;
        int fives = 0;
        int sixes = 0;
        int sevens = 0;

        Random randomNumber = new Random();

        List<int> enteredLottoNumbers = new List<int>();

        List<List<int>> generatedLottoSeries = new List<List<int>>();   

        public void GetNumbers()
        {
            errorMessage= string.Empty;
            enteredLottoNumbers.Clear();

            try
            {
                int.TryParse(number1.Text, out int value1);
                int.TryParse(number2.Text, out int value2);
                int.TryParse(number3.Text, out int value3);
                int.TryParse(number4.Text, out int value4);
                int.TryParse(number5.Text, out int value5);
                int.TryParse(number6.Text, out int value6);
                int.TryParse(number7.Text, out int value7);

                enteredLottoNumbers.Add(value1);
                enteredLottoNumbers.Add(value2);
                enteredLottoNumbers.Add(value3);
                enteredLottoNumbers.Add(value4);
                enteredLottoNumbers.Add(value5);
                enteredLottoNumbers.Add(value6);
                enteredLottoNumbers.Add(value7);
            }
            catch{
                errorMessage = "All fields are required and you can enter only numbers between 1-35!";
            }
            ErrorMessageTextBlock.Text = errorMessage;
        }

        public void GetNrOfRounds()
        {   
            try
            {
                rounds = int.Parse(nrDraws.Text);
            }
            catch
            {
                errorMessage = "Number of rounds must be a positive number!";
            }
            ErrorMessageTextBlock.Text = errorMessage;
        }

        public void CheckNumberValidity()
        {
            for (int i = 0; i< enteredLottoNumbers.Count -1; i++)
            {
                if (enteredLottoNumbers[i] < 1 || enteredLottoNumbers[i] > 35)
                {
                    errorMessage = "Numbers must be between 1 and 35! Wrong entry.";
                }
                else if (enteredLottoNumbers[i] == enteredLottoNumbers[i + 1])
                {
                    errorMessage = "You can't enter same number more than once! Wrong entry.";
                } 
                else if (rounds < 0)
                {
                    errorMessage = "Number of rounds must be a positive number! Wrong entry.";
                }     
            }
            ErrorMessageTextBlock.Text = errorMessage;
        }

        public List<int> generateLottoNumbers()
        {
            List<int> generatedLottoNumbers = new List<int>();
            generatedLottoNumbers.Add(randomNumber.Next(1, 35));
            int counter = 0;
            while (counter < 6)
            {
                int lottoNumber = randomNumber.Next(1, 35);
                if (!generatedLottoNumbers.Contains(lottoNumber))
                {
                    generatedLottoNumbers.Add(lottoNumber);
                    counter++;
                }
            }
            return generatedLottoNumbers;
        }



        public List<List<int>> generateLottoSeriers()
        {
            generatedLottoSeries.Clear();
            int counter = 0;
            while (rounds > counter)
            {
                generatedLottoSeries.Add(generateLottoNumbers());
                counter++;
            }








            Debug.WriteLine(generatedLottoSeries.Count);
            return generatedLottoSeries;
        }

        public int CountOccurrences()
        {
            sevens= 0;
            sixes= 0;
            fives= 0;
            int counterMatches = 0;
            foreach (List<int> lottoCombination in generatedLottoSeries)
            {
                counterMatches = 0;
                foreach (int number in enteredLottoNumbers)
                {
                    if (lottoCombination.Contains(number))
                    {
                        counterMatches++;
                        if (counterMatches == 7)
                        {
                            sevens++;
                        } else if(counterMatches == 6)
                        {
                            sixes++;
                        } else if(counterMatches == 5)
                        {
                            fives++;
                        }
                    }
                }
            }
            return counterMatches;
        }

        public void updateTextresult()
        {
            fiveMatches.Text = fives.ToString();
            sixMatches.Text = sixes.ToString();
            SevenMatches.Text = sevens.ToString();
        }




        private void RunLotto(object sender, RoutedEventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            updateTextresult();
            GetNumbers();
            GetNrOfRounds();
            CheckNumberValidity();
            generateLottoSeriers();
            CountOccurrences();
            updateTextresult();


            stopwatch.Stop();
            Debug.WriteLine($"Time taken to generate {rounds} rounds: {stopwatch.Elapsed.TotalSeconds} seconds");
            Debug.WriteLine("Fives: " + fives);
            Debug.WriteLine("Sixes: " + sixes);
            Debug.WriteLine("Sevens: " + sevens);
        }


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
