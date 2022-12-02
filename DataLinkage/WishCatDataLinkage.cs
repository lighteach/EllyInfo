using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataLinkage
{
    public class WishCatDataLinkage : DataLinkageBase, IJobDataLinkage
    {
        public string ScrapingTargetMainUrl => "https://www.wishket.com";
        public string ScrapingTargetUrlPath => "/project/?text_search_type=all&search_text=c%23&project_min_budget=&project_max_budget=&project_min_term=&project_max_term=&project_min_launch_date=&project_max_launch_date=&inhouse_project_min_budget=&inhouse_project_max_budget=&order_by=default&page=1";

        public List<JobDataModel> GetList()
        {
            List<JobDataModel> result = new List<JobDataModel>();

            HtmlDocument doc = base.GetHtmlDocument_V2($"{ScrapingTargetMainUrl}{ScrapingTargetUrlPath}");
            HtmlNode prjBox = doc.DocumentNode.Descendants("div").FirstOrDefault(o => o.Attributes["class"].Value.Equals("project-list-box"));
            if (prjBox != null)
            {
                IEnumerable<HtmlNode> prjList = prjBox.Descendants("div").Where(o => o.Attributes["class"].Value.Equals("project-info-box"));
                foreach (HtmlNode prj in prjList)
                {
                    HtmlNode prjTitle = prj.SelectSingleNode("//h4[@class='project-title']");
                    HtmlNode prjInfoTag = prj.Descendants("div").FirstOrDefault(o => o.Attributes["class"].Value.Equals("project-info-tag"));

                    (string title, string urlLink) tplTitle = (prjTitle.InnerText.Trim(), prjTitle.SelectSingleNode("a").Attributes["href"].Value);
                    JobDataProjectType jobType = (tplTitle.title.EndsWith("개발") ? JobDataProjectType.SI : JobDataProjectType.SM);
                    jobType = (tplTitle.title.EndsWith("운영") ? JobDataProjectType.SM : JobDataProjectType.SI);

                    result.Add(new JobDataModel
                    {
                        ProjectTitle = tplTitle.title
                        , Location = prjInfoTag.Descendants("div").FirstOrDefault(o => o.Attributes["class"].Value.Equals("client-location-tag")).InnerHtml.Trim()
                        , Price = prjInfoTag.Descendants("div").FirstOrDefault(o => o.Attributes["class"].Value.Equals("estimated-data")).InnerHtml.Trim()
                        , ProjectType = jobType
                        , CareerYearsInfo = ""
                        , AnnounceCompany = ""
                        , AnnounceCompnayImageUrl = ""
                        , IsDeskJob = false
                        , DetailViewUrl = $"{ScrapingTargetMainUrl}/{tplTitle.urlLink}"
                        , ProjectStartInfo = ""
                        , Skills = new string[] { }
                        , EtcInfos = ""
                    });
                }
            }

            #region 테스트 코드
            //foreach (int cnt in Enumerable.Range(1, 12))
            //{
            //    (string Title, string Location, string Price) tplData = ($"Title{cnt}", $"Location{cnt}", $"{760 + cnt}만원");
            //    result.Add(new JobDataModel
            //    {
            //        ProjectTitle = tplData.Title
            //            , Location = tplData.Location
            //            , Price = tplData.Price
            //            , ProjectType = JobDataProjectType.SI
            //            , CareerYearsInfo = ""
            //            , AnnounceCompany = ""
            //            , AnnounceCompnayImageUrl = ""
            //            , IsDeskJob = false
            //            , DetailViewUrl = ""
            //            , ProjectStartInfo = ""
            //            , Skills = new string[] { }
            //            , EtcInfos = ""
            //    });
            //}
            #endregion


            //// 데이터 가공(서초구, 강남구 우선)
            //if (result.Exists(jdm => jdm.Location.Contains("서초구") || jdm.Location.Contains("강남구")))
            //{
            //    result.Where(jdm => jdm.Location.Contains("서초구") || jdm.Location.Contains("강남구"))
            //        .ToList().ForEach(jdm =>
            //        {
            //            int idx = result.IndexOf(jdm);
            //            result.RemoveAt(idx);
            //            result.Insert(0, jdm);
            //        });
            //}

            return result;
        }
    }
}