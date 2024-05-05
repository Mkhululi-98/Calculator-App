using Calculate.ViewModel;
using MauiPopup.Views;

namespace Calculate;

public partial class ErrorPage : BasePopupPage
{
	public ErrorPage()
	{
		var errorViewModel = new ErrorViewModel();
        InitializeComponent();
        this.BindingContext = errorViewModel;

    }
}