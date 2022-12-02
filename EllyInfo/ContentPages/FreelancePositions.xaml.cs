using DataLinkage;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EllyInfo.ContentPages;

public partial class FreelancePositions : ContentPage, INotifyPropertyChanged
{
    private IJobDataLinkage _currentLinkage = null;

	public FreelancePositions()
	{
		InitializeComponent();

        BindingContext = this;

        string title = Shell.Current.CurrentItem.CurrentItem.CurrentItem.Title;
        string route = Shell.Current.CurrentItem.CurrentItem.CurrentItem.Route;
        lblCurrentProvider.Text = title;

        DataDirection direction = (DataDirection)Enum.Parse(typeof(DataDirection), route, true);

        BindJobDatas(direction);
    }

    private void IndicatorShow(bool isShow)
    {
        indicator.IsRunning = isShow;
        indicator.IsVisible = isShow;
    }

    private void BindJobDatas(DataDirection direction)
    {
        IndicatorShow(true);

        if (direction == DataDirection.Okky)
        {
            // 일단 현재 포지션 제공자가 누군지 저장한다.
            _currentLinkage = new OkkyDataLinkage();
        }
        else if (direction == DataDirection.WishCat)
        {
            _currentLinkage = new WishCatDataLinkage();
        }
        else
        {
            _currentLinkage = new OkkyDataLinkage();
        }

        IJobDataLinkage linkage = _currentLinkage;
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

        IndicatorShow(false);
    }

    ObservableCollection<JobDataModel> _jobDatas = new ObservableCollection<JobDataModel>();
    public ObservableCollection<JobDataModel> JobDatas => _jobDatas;

    private async void collviewJobDatas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        JobDataModel current = (e.CurrentSelection.FirstOrDefault() as JobDataModel);
        string moveUrl = $"{_currentLinkage.ScrapingTargetMainUrl}{current.DetailViewUrl}";
        await Application.Current.MainPage.Navigation.PushModalAsync(new FreelancePositionsDetail { TargetUrl = moveUrl });
        //await Launcher.Default.OpenAsync(moveUrl);
    }
}