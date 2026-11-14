using CalculatorMAUI.ViewModels;

namespace CalculatorMAUI
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel mv)
        {
            InitializeComponent();
            BindingContext = mv;
        }

       
    }
}
