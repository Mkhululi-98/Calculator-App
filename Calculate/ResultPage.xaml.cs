using Calculate.ViewModel;

namespace Calculate;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;	
	}
}