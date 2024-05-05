using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Calculate.ViewModel
{
    internal partial class WrongViewModel: ObservableObject
    {
        [RelayCommand]
        async Task Return()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
