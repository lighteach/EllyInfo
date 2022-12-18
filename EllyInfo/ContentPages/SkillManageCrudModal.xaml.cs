using EllyInfo.Models.ModalModes;
using System.Reflection.Metadata;

namespace EllyInfo.ContentPages;

public partial class SkillManageCrudModal : ContentPage
{
	private SkillManageModalOpen _mode = SkillManageModalOpen.Add;
	public SkillManageCrudModal()
	{
		InitializeComponent();
	}

	public SkillManageModalOpen OpenMode
	{
		set
		{
			_mode = value;
            lblTitleText.Text = $"Skill {_mode.ToString()}";
		}
	}

    private void btnClose_Clicked(object sender, EventArgs e)
	{
		App.Current.MainPage.Navigation.PopModalAsync();
	}
}