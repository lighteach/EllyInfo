namespace DataLinkage
{
    public enum JobDataProjectType { SI, SM, Unknown }
    public class JobDataModel
    {
        /// <summary>
        ///  프로젝트 타이틀
        /// </summary>
        public string? ProjectTitle { get; set; }
        /// <summary>
        /// 위치
        /// </summary>
        public string? Location { get; set; }
        /// <summary>
        /// 단가
        /// </summary>
        public string? Price { get; set; }
        /// <summary>
        /// 프로젝트 종류(SI,SM,Unknown)
        /// </summary>
        public JobDataProjectType ProjectType { get; set; }
        /// <summary>
        /// 희망연차 정보
        /// </summary>
        public string? CareerYearsInfo { get; set; }
        /// <summary>
        /// 공고올린 회사(명)
        /// </summary>
        public string? AnnounceCompany { get; set; }
        /// <summary>
        /// 공고올린 회사 로고 이미지 URL
        /// </summary>
        public string? AnnounceCompnayImageUrl { get; set; }
        /// <summary>
        /// 재택근무 여부
        /// </summary>
        public bool IsDeskJob { get; set; }
        /// <summary>
        /// 상세내용 URL
        /// </summary>
        public string? DetailViewUrl { get; set; }
        /// <summary>
        /// 프로젝트 시작일자 및 그 외의 정보
        /// </summary>
        public string? ProjectStartInfo { get; set; }
        /// <summary>
        /// 필요 기술들
        /// </summary>
        public string[]? Skills { get; set; }
        /// <summary>
        /// 기타 참고사항
        /// </summary>
        public string? EtcInfos { get; set; }

    }
}