using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.ViewModels
{
    public class PageFriendViewModel
    {
        public List<FriendViewModel> Friend { get; set; }
    }
    public class FriendViewModel
    {
        public long Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
    }
}