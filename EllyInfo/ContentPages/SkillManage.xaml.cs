namespace EllyInfo.ContentPages;

public partial class SkillManage : ContentPage
{
	public SkillManage()
	{
		InitializeComponent();
	}

    private async void btnAlertTest_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("This is Test Alert", "�̰Ž� �׽�Ʈ ���̴�!!", "OK");
    }
}