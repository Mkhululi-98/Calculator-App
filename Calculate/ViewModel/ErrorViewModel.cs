using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.ViewModel
{
    internal partial class ErrorViewModel: ObservableObject
    {
        [RelayCommand]
        async Task OkButton()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
