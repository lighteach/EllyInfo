using System.Reflection;
using Microsoft.Maui;
using EllyInfo.Models;
using Newtonsoft.Json;

namespace EllyInfo.ContentPages;

public partial class SkillManage : ContentPage
{
	public SkillManage()
	{
		InitializeComponent();

        BindCareers();
	}

    private async void BindCareers()
    {
        await Task.Run(async () =>
        {

            using (Stream strmJson = await FileSystem.Current.OpenAppPackageFileAsync("SkillsInformation.json"))
            {
                if (strmJson != null)
                {
                    using (StreamReader sr = new StreamReader(strmJson))
                    {
                        string jsonContent = sr.ReadToEnd();
                        SkillsInformation skillInfo = skillInfo = JsonConvert.DeserializeObject<SkillsInformation>(jsonContent);

                        TableView tmp = this.tvCareers;

                        TableSection tbSection = tvCareers.Root.First();
                        // [2022-11-20] �� �κп��� �������� ��� �����丮�� �߰���Ű�� ���� �ϱ��..
                        //foreach (CareerList cl in skillInfo.CareerList)
                        //{
                        //    tbSection.Add(new TextCell
                        //    {
                        //        Text = cl.CorpName
                        //        , Detail = cl.Works
                        //    });
                        //}
                    }
                }
            }



        });

    }

    private async void btnAlertTest_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("This is Test Alert", "�̰Ž� �׽�Ʈ ���̴�!!", "OK");
    }
}