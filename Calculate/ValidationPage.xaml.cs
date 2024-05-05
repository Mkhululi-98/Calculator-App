using Calculate.ViewModel;
using MauiPopup.Views;

namespace Calculate;

public partial class ValidationPage : BasePopupPage
{
	public ValidationPage()
	{
        var correctViewModel = new CorrectViewModel();
        InitializeComponent();
        this.BindingContext = correctViewModel;
    }
}