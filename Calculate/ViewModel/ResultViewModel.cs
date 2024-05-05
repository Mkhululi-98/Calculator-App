
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.Collections.ObjectModel;


namespace Calculate.ViewModel
{
    [QueryProperty("Results","Results")]
    [QueryProperty("Score", "Score")]

    public partial class ResultViewModel: ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<String> results;

        [ObservableProperty]
        int score;

        [RelayCommand]
        async Task Return()
        {
            results.Clear();
            Score = 0;
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        void ExitProg()
        {
            Application.Current.Quit();
        }

    }
}
