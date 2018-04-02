using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.GroupMessage;
using Weixin;

namespace NavShare
{
    public partial class sendnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string accessToken = Wx.accessToken;
                List<NewsModel> News = new List<NewsModel>();
                int count;
                int.TryParse(Request.Form["lineCount"], out count);
                string Author = "【个人信息】";
                string AuthorID = Request.Form["AuthorID"];
                for (int i = 0; i < count; ++i)
                {
                    var file = Request.Files["Img" + i.ToString()];
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        var r = Media2.UploadForeverMedia(Wx.accessToken, file);
                        News.Add(new NewsModel
                        {
                            title = Request.Form["Title" + i.ToString()],
                            content = Request.Form["Content" + i.ToString()],
                            content_source_url = Request.Form["Url" + i.ToString()],
                            author = Author,
                            thumb_media_id = r.media_id
                        });

                    }
                }

                if (News.Count > 0)
                {
                    var r1 = MediaApi.UploadNews(Wx.accessToken, News.ToArray());
                    var r2 = GroupMessageApi.SendGroupMessagePreview(Wx.accessToken, GroupMessageType.mpnews, r1.media_id, AuthorID);
                    ClientScript.RegisterStartupScript(GetType(), "1", "alert('成功发送消息');", true);
                }
            }
        }
    }
}