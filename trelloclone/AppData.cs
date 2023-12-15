using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trelloclone
{
    internal class AppData
    {
        private string describeContent;
        private string activityContent;
        private string memberAccessID;

        public string DescribeContent { get => describeContent; set => describeContent = value; }
        public string ActivityContent { get => activityContent; set => activityContent = value; }
        public string MemberAccessID { get => memberAccessID; set => memberAccessID = value; }

        public AppData(string describeContent, string activityContent, string memberAccessID)
        {
            DescribeContent = describeContent;
            ActivityContent = activityContent;
            MemberAccessID = memberAccessID;
        }


    }
}
