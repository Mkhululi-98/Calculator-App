using Calculate.ViewModel;

namespace Calculate
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();


            var mainViewModel = new MainViewModel();
            mainViewModel.Displays();
            this.BindingContext = mainViewModel;
        }

       
    }

}
