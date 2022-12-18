using System.Reflection;
using Microsoft.Maui;
using EllyInfo.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Compatibility;
using System;
using EllyInfo.Models.ModalModes;

namespace EllyInfo.ContentPages;

public partial class SkillManage : ContentPage
{
	public SkillManage()
	{
		InitializeComponent();

        BindCareers();

        BindingContext = this;
    }

    private void BindCareers()
    {
        using (Stream strmJson = FileSystem.Current.OpenAppPackageFileAsync("SkillsInformation.json").GetAwaiter().GetResult())
        {
            if (strmJson != null)
            {
                using (StreamReader sr = new StreamReader(strmJson))
                {
                    string jsonContent = sr.ReadToEnd();
                    SkillsInformation skillInfo = skillInfo = JsonConvert.DeserializeObject<SkillsInformation>(jsonContent);

                    foreach (CareerList cl in skillInfo.CareerList)
                    {
                        _careers.Add(new CareerList
                        {
                            CorpName = cl.CorpName
                            , StartYm = cl.StartYm
                            , EndYm = cl.EndYm
                            , Position = cl.Position
                            , Works = cl.Works
                        });
                    }
                    _careers = new ObservableCollection<CareerList>(skillInfo.CareerList);
                }
            }
        }
    }

    ObservableCollection<CareerList> _careers = new ObservableCollection<CareerList>();
    public ObservableCollection<CareerList> Careers => _careers;

    

    private async void btnSkillAdd_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new SkillManageCrudModal { OpenMode = SkillManageModalOpen.Add });
        //await DisplayAlert("This is Test Alert", "ÀÌ°Å½¼ Å×½ºÆ® ¾ó·µÀÌ´Ù!!", "OK");
    }
}