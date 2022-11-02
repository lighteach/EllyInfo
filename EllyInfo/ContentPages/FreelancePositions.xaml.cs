using DataLinkage;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EllyInfo.ContentPages;

public partial class FreelancePositions : ContentPage, INotifyPropertyChanged
{
	public FreelancePositions()
	{
		InitializeComponent();

        BindJobDatas();

        BindingContext = this;
    }

    private void BindJobDatas()
    {
        IJobDataLinkage linkage = new OkkyDataLinkage();
        List<JobDataModel> list = linkage.GetList();
        foreach (JobDataModel jdm in list)
        {
            _jobDatas.Add(new JobDataModel
            {
                ProjectTitle = jdm.ProjectTitle
                , Location = jdm.Location
                , Price = jdm.Price
                , ProjectType = jdm.ProjectType
                , CareerYearsInfo = jdm.CareerYearsInfo
                , AnnounceCompany = jdm.AnnounceCompany
                , AnnounceCompnayImageUrl = jdm.AnnounceCompnayImageUrl
                , IsDeskJob = jdm.IsDeskJob
                , DetailViewUrl = jdm.DetailViewUrl
                , ProjectStartInfo = jdm.ProjectStartInfo
                , Skills = jdm.Skills
                , EtcInfos = jdm.EtcInfos
            });
        }
    }

    ObservableCollection<JobDataModel> _jobDatas = new ObservableCollection<JobDataModel>();
    public ObservableCollection<JobDataModel> JobDatas => _jobDatas;
}