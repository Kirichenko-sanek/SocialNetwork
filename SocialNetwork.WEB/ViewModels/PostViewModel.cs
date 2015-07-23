using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.ViewModels
{
    public class PostViewModel
    {
        public long Id { get; set; }
        public string PhotoPost { get; set; }
        public string DescriptionPost { get; set; }
        public string DatePost { get; set; }
        public string NameUser { get; set; }
    }
}