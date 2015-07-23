using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.ViewModels
{
    public class MyPageViewModel
    {
        public long Id { get; set; }
        public long IdUserInSystem { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public List<PostViewModel> Posts { get; set; }                 
    }
}