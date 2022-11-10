namespace EllyInfo.ContentPages;

public partial class SkillManage : ContentPage
{
	public SkillManage()
	{
		InitializeComponent();
	}

    private async void btnAlertTest_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("This is Test Alert", "이거슨 테스트 얼럿이다!!", "OK");
    }
}