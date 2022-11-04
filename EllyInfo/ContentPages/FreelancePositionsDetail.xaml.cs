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
}