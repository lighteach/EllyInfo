using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EllyInfo.Models
{
    public partial class SkillsInformation
    {
        [JsonProperty("currentPay")]
        public string CurrentPay { get; set; }

        [JsonProperty("hopedPay")]
        public string HopedPay { get; set; }

        [JsonProperty("privateInfo")]
        public PrivateInfo PrivateInfo { get; set; }

        [JsonProperty("educationInfoList")]
        public List<EducationInfoList> EducationInfoList { get; set; }

        [JsonProperty("lincenseInfoList")]
        public List<LincenseInfoList> LincenseInfoList { get; set; }

        [JsonProperty("careerList")]
        public List<CareerList> CareerList { get; set; }

        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; }
    }

    public partial class CareerList
    {
        [JsonProperty("corpName")]
        public string CorpName { get; set; }

        [JsonProperty("startYm")]
        public string StartYm { get; set; }

        [JsonProperty("endYm")]
        public string EndYm { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("works")]
        public string Works { get; set; }
    }

    public partial class EducationInfoList
    {
        [JsonProperty("schoolName")]
        public string SchoolName { get; set; }

        [JsonProperty("schoolType")]
        public string SchoolType { get; set; }

        [JsonProperty("majorType")]
        public string MajorType { get; set; }

        [JsonProperty("graduationYm")]
        public string GraduationYm { get; set; }
    }

    public partial class LincenseInfoList
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("acquisitionYmd")]
        public string AcquisitionYmd { get; set; }

        [JsonProperty("issuingAgency")]
        public string IssuingAgency { get; set; }
    }

    public partial class PrivateInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birth")]
        public string Birth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        [JsonProperty("millitaryServiceInfo")]
        public string MillitaryServiceInfo { get; set; }

        [JsonProperty("marrigeStatus")]
        public bool MarrigeStatus { get; set; }
    }

    public partial class Skill
    {
        [JsonProperty("skillName")]
        public string SkillName { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }
    }
}

