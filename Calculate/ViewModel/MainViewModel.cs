using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Controls.Compatibility.Platform.UWP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.ApplicationModel.Store;
//using Windows.Security.Credentials.UI;

namespace Calculate.ViewModel
{
    public partial class MainViewModel: ObservableObject
    {

        [ObservableProperty]
        int num1;

        [ObservableProperty]
        int num2;

        [ObservableProperty]
        int operator1;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        ImageSource imageSource;

        [ObservableProperty]
        int score = -1;

        [ObservableProperty]
        int count = 0;

        [ObservableProperty]
        ObservableCollection<String> results;

        int times = 0;

        
        public MainViewModel()
        {
            Results = new ObservableCollection<String>();
        }

        //Method that calls other methods in the class and links the UI components
        [RelayCommand]
        public void Displays()
        {

            Verify(Operator1, Num1, Num2);
            GetOperators();

            if (Operator1 < 2)
            {
                FirstRange();
            }
            else
            {
                SecondRange();
            }
            SetImage();

            Text = string.Empty;
            if (Count == 11)
            {
                _ = ViewResults();
            }
        }

        // method that verifies user input
        void Verify(int operate, int operand1, int operand2)
        {

            if (Count == 0)
            {
                Text = "0";
            }
            Count++;

            try
            {
                if (operate == 0)
                {
                    Results.Add(operand1 + " + " + operand2 + " = " + Int32.Parse(Text) + " | " + (operand1 + operand2));
                    if (operand1 + operand2 == Int32.Parse(Text))
                    {
                        Score++;
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new ValidationPage());
                        }
                    }
                    else
                    {
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new WrongPage());
                        }
                    }
                }
                else if (operate == 1)
                {
                    Results.Add(operand1 + " - " + operand2 + " = " + Int32.Parse(Text) + " | " + (operand1 - operand2));
                    if (operand1 - operand2 == Int32.Parse(Text))
                    {
                        Score++;
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new ValidationPage());
                        }
                    }
                    else
                    {
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new WrongPage());
                        }
                    }
                }
                else if (operate == 2)
                {
                    Results.Add(operand1 + " X " + operand2 + " = " + Int32.Parse(Text) + " | " + (operand1 * operand2));
                    if (operand1 * operand2 == Int32.Parse(Text))
                    {
                        Score++;
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new ValidationPage());
                        }
                    }
                    else
                    {
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new WrongPage());
                        }
                    }
                }
                else if (operate == 3)
                {

                    Results.Add(operand1 + " / " + operand2 + " = " + Int32.Parse(Text) + " | " + (operand1 / operand2));

                    if (operand1 / operand2 == Int32.Parse(Text))
                    {
                        Score++;
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new ValidationPage());
                        }
                    }
                    else
                    {
                        if (Count > 1)
                        {
                            MauiPopup.PopupAction.DisplayPopup(new WrongPage());
                        }
                    }
                }

            }
            catch (FormatException ex)
            {
                MauiPopup.PopupAction.DisplayPopup(new ErrorPage());
                Count--;
              //  return false;
            }
        }

        //  Method to get random operators
        void GetOperators()
        {
            Random rand = new Random();
            Operator1 = rand.Next(0, 4);
        }

  
        //Method for getting random numbers for addition and subtraction within the range 0 to 50
        void FirstRange()
        {
            Random rand = new Random();
            Num1 = rand.Next(1, 50);
            Num2 = rand.Next(1, 50);
        }
        //Method for getting numbers for multiplication and division within the range 0 to 12
        void SecondRange()
        {
            Random rand = new Random();
            Num1 = rand.Next(1, 13);
            Num2 = rand.Next(1, 13);

        }

        //Method to selects operator image 
        void SetImage()
        {
            if(Operator1 == 0)
            {
                ImageSource = ImageSource.FromFile("add.png");
            }
            else if(Operator1 == 1)
            {
                ImageSource = ImageSource.FromFile("sub.png");
            }
            else if (Operator1 == 2)
            {
                ImageSource = ImageSource.FromFile("multi.png");
            }
            else
            {
                ImageSource = ImageSource.FromFile("div.png");
            }
        }

        //method to open the page with results
        async Task ViewResults()
        {
            Count = 1;
            if (times == 0)
            {
                Results.RemoveAt(0);
            }
            times++;
            await Shell.Current.GoToAsync($"{nameof(ResultPage)}?Score={Score}",
                new Dictionary<string, object>
                {
                    {"Results", Results}
                });
            Score = 0;
        }

        //method for closing the application
        [RelayCommand]
        void ExitProg()
        {
            Application.Current.Quit();
        }

        //Method to restart the calculations and reset variables
        [RelayCommand]
        void Restart()
        {
            Count = 0;
            Score = 0;
            Results.Clear();
            Displays();
        }
    }
}
