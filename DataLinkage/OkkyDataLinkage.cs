using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataLinkage
{
    public class OkkyDataLinkage : DataLinkageBase, IJobDataLinkage
    {
        public string ScrapingTargetMainUrl => "https://okky.kr";
        public string ScrapingTargetUrlPath => "/jobs/contract?keyword=c%23&page=1";

        public List<JobDataModel> GetList()
        {
            HtmlDocument doc = base.GetHtmlDocument($"{ScrapingTargetMainUrl}{ScrapingTargetUrlPath}");
            HtmlNode nextData = doc.DocumentNode.SelectSingleNode("//script[@id='__NEXT_DATA__']");
            string jsonData = nextData.InnerText;


            JObject json = JObject.Parse(jsonData);
            List<JToken> datas = new List<JToken>(json["props"]["pageProps"]["result"]["content"].ToArray());

            List<JobDataModel> result = datas.Select(tk => new JobDataModel
            {
                ProjectTitle = tk["title"]?.ToString()
                , Location = $"{tk["recruitResponse"]?["city"]?.ToString()} {tk["recruitResponse"]?["district"]?.ToString()} {tk["recruitResponse"]?["town"]?.ToString()}"
                , Price = $"{tk["recruitResponse"]?["minPay"]?.ToString()} ~ {tk["recruitResponse"]?["maxPay"]?.ToString()} 만원"
                , ProjectType = (tk["recruitResponse"]?["workType"]?.ToString().ToUpper() == "SI" ? JobDataProjectType.SI :
                                                                    tk["recruitResponse"]?["workType"]?.ToString().ToUpper() == "SM" ? JobDataProjectType.SM : JobDataProjectType.Unknown)
                , CareerYearsInfo = $"{tk["recruitResponse"]?["minCareer"]?.ToString()}년 이상 ~ {(tk["recruitResponse"]?["maxCareer"]?.ToString() == "99" ? "무관" : tk["recruitResponse"]?["maxCareer"]?.ToString())}"
                , AnnounceCompany = tk["recruitResponse"]?["company"]?["name"]?.ToString()
                , AnnounceCompnayImageUrl = tk["recruitResponse"]?["company"]?["logo"]?.ToString()
                , IsDeskJob = (tk["recruitResponse"]?["workingCondition"]?.ToString().ToUpper() == "INHOUSE")
                , DetailViewUrl = $"/recruits/{tk["id"]?.ToString()}"
                , ProjectStartInfo = $"{tk["recruitResponse"]?["startDate"]?.ToString()} ({tk["recruitResponse"]?["workingMonth"]?.ToString()}개월)"
                , Skills = tk["recruitResponse"]?["tags"]?.Select(t => t["name"]?.ToString()).ToArray()
                , EtcInfos = $"급여일:{tk["recruitResponse"]?["payDay"]?.ToString()}"
            }).ToList();

            // 데이터 가공(서초구, 강남구 우선)
            if (result.Exists(jdm => jdm.Location.Contains("서초구") || jdm.Location.Contains("강남구")))
            {
                result.Where(jdm => jdm.Location.Contains("서초구") || jdm.Location.Contains("강남구"))
                    .ToList().ForEach(jdm =>
                    {
                        int idx = result.IndexOf(jdm);
                        result.RemoveAt(idx);
                        result.Insert(0, jdm);
                    });
            }

            return result;
        }
    }
}