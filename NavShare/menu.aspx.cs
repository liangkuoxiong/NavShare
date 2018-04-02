using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using Weixin;

namespace NavShare
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonGroup bg = new ButtonGroup();
            bg.button.Add(new SingleClickButton { name = "关于", key = "gy", type = "click" });
            bg.button.Add(new SingleViewButton { name = "NavShareIndex", url = "http://" + HttpContext.Current.Request.Url.Host + "/NavShareIndex.aspx?s=system" });
            var bg2 = new SubButton() { name = "网站" };
            bg2.sub_button.Add(new SingleViewButton { name = "百度", url = "http://www.baidu.com/" });
            bg2.sub_button.Add(new SingleViewButton { name = "微博", url = "https://www.weibo.com" });
            bg.button.Add(bg2);
            var r = Meun.CreateMenu(Wx.accessToken, bg);
            if (r.errcode == 0)
                Response.Write("创建菜单成功");
            else
                Response.Write("创建菜单失败");
        }
    }
}