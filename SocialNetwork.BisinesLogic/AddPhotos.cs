using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.BisinesLogic
{
    public class AddPhotos
    {
        public string AddImage(HttpPostedFileBase upload, string serverPath, string imgPath)
        {
            string path = null;
            string pathPic = null;
            if (upload != null && upload.ContentLength > 0)
            {
                var generator = RandomNumberGenerator.Create();
                byte[] num = new byte[8];
                generator.GetBytes(num);
                var name = Convert.ToBase64String(num);

                var time = Convert.ToString(DateTime.Now.Millisecond);
                var pic = Path.GetExtension(upload.FileName);
                path = serverPath + name + time + pic;
                pathPic = imgPath + name + time + pic;
                upload.SaveAs(Path.GetFullPath(path));
            }
            return pathPic;
        }
    }
}
