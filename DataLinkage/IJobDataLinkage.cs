using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkage
{
    public interface IJobDataLinkage
    {
        string ScrapingTargetMainUrl { get; }
        string ScrapingTargetUrlPath { get; }
        List<JobDataModel> GetList();
    }
}
