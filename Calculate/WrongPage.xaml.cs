using Calculate.ViewModel;
using MauiPopup.Views;

namespace Calculate;

public partial class WrongPage : BasePopupPage
{
	public WrongPage()
	{
		var wrongViewModel  = new WrongViewModel();
		InitializeComponent();
		this.BindingContext = wrongViewModel;
	}
}