using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trelloclone
{
    public class AppData
    {
        private string title;
        private string describeContent;
        private string activityContent;
        private string label;
        private List<string> listOfMember = new List<string>();
        private List<string> listOfToDoList = new List<string>();
        private bool existed;

        public string Title { get => title; set => title = value; }
        public string DescribeContent { get => describeContent; set => describeContent = value; }
        public string ActivityContent { get => activityContent; set => activityContent = value; }
        public string Label { get => label; set => label = value; }
        public List<string> ListOfMember { get => listOfMember; set => listOfMember = value; }
        public List<string> ListOfToDoList { get => listOfToDoList; set => listOfToDoList = value; }
        public bool Existed { get => existed; set => existed = value; }

        public AppData()
        {
            title = "Tiêu đề";
            describeContent = "";
            activityContent = "";
            label = "none";
            Existed = true;
        }

        public AppData(string describeContent, string activityContent, string memberAccessID)
        {
            DescribeContent = describeContent;
            ActivityContent = activityContent;
            listOfMember.Add(memberAccessID);
        }
        ~AppData()
        {


        }


    }
}
