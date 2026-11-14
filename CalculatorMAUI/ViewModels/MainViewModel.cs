using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string? text;

        [RelayCommand]
        void Tap(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                if (s == "/" || s == "*" || s == "+" || s == "-")
                {
                    if (Text[Text.Length - 1] >= '0' && 
                        Text[Text.Length - 1] <= '9') Text += $" {s} ";

                }
                else
                {
                    Text += s;
                }
            }
        }

        [RelayCommand]
        void Sum()
        {
            string[] elements = Text.Split(' ');

            if (elements.Length < 3) return;

            BigInteger bigInteger = BigInteger.Parse(elements[0]);

            for (int i = 1; i < elements.Length; i += 2)
            {
                if (elements[i] == "+")
                {
                    BigInteger n1 = BigInteger.Parse(elements[i + 1]);
                    bigInteger += n1;
                }
                else if(elements[i] == "-")
                {
                    BigInteger n1 = BigInteger.Parse(elements[i + 1]);
                    bigInteger -= n1;
                }
                else if (elements[i] == "*")
                {
                    BigInteger n1 = BigInteger.Parse(elements[i + 1]);
                    bigInteger *= n1;
                }
                else
                {
                    BigInteger n1 = BigInteger.Parse(elements[i + 1]);
                    bigInteger /= n1;
                }
            }

            Text = bigInteger.ToString();
        }

        [RelayCommand]
        void Clear() => Text = String.Empty;
    }
}
