using Java.Net;

namespace EllyInfo.ContentPages;

public partial class FreelancePositionsDetail : ContentPage
{
	public FreelancePositionsDetail()
	{
		InitializeComponent();
	}

	public string TargetUrl
	{
		set
		{
			wvDetail.Source = new UrlWebViewSource { Url = value };
		}
	}

	private void btnClose_Clicked(object sender, EventArgs e)
	{
		App.Current.MainPage.Navigation.PopModalAsync();
	}
}