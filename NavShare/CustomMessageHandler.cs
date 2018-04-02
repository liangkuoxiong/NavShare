using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.AdvancedAPIs;
using Weixin;

namespace Sample_3
{
/// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : MessageHandler<MessageContext>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="maxRecordCount"></param>
        public CustomMessageHandler(Stream inputStream, int maxRecordCount = 0)
            : base(inputStream, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 3;
        }
        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }
        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }
        protected override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            //var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            //Article a = new Article()
            //{
            //    PicUrl = "",
            //    Description = "点击链接有惊喜",
            //    Url = HttpContext.Current.Request.Url.Host + "/NavShareIndex.aspx?s=system",
            //    Title = "访问分享统计"
            //};
            //responseMessage.Articles.Add(a);
            //return responseMessage;

            var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            if (requestMessage.Content.ToUpper() == "VIEWNAV")
            {
                responseMessage.Articles.Add(new Article()
                {
                    PicUrl = "https://github.com/liangkuoxiong/NavShare/blob/master/NavShare/img/abc.png?raw=true",
                    Description = "点击图文中的链接，可打开ViewNav.aspx",
                    Url = "http://"+HttpContext.Current.Request.Url.Host+"/ViewNav.aspx",
                    Title = "ViewNav"
                });
            }
            else if (requestMessage.Content.ToUpper() == "VIEWSHARE")
            {
                responseMessage.Articles.Add(new Article()
                {
                    PicUrl = "https://github.com/liangkuoxiong/NavShare/blob/master/NavShare/img/def.jpg?raw=true",
                    Description = "点击图文中的链接，可打开ViewsShare.aspx",
                    Url = "http://" + HttpContext.Current.Request.Url.Host + "/ViewShare.aspx?s=system",
                    Title = "ViewsShare"
                });
            }
            else
            {
                responseMessage.Articles.Add(new Article()
                {
                    PicUrl = "https://github.com/liangkuoxiong/NavShare/blob/master/NavShare/img/ghi.png?raw=true",
                    Description = "点击图文中的链接，可打开NavShareIndex.aspx",
                    Url = "http://"+HttpContext.Current.Request.Url.Host+"/NavShareIndex.aspx?s=system",
                    Title = "随便"
                });
            }
            return responseMessage;
        }
        //订阅事件方法
        protected override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = @"欢迎关注!【班级：计算机应用技术二班】\n【姓名：梁阔雄】\n【学号：20150301241】\n【性别：男】";
            return responseMessage;
        }
        //没有被处理消息
        protected override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            return null;
        }
        //自定义菜单单击事件
        protected override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase rm = null;

            switch (requestMessage.EventKey)
            {
                case "gy":
                    {
                        var msg = CreateResponseMessage<ResponseMessageNews>();
                        var r = User.Info(Wx.accessToken, requestMessage.FromUserName);
                        msg.Articles.Add(new Article { Description = string.Format("{0},您好！欢迎关注!【班级：计算机应用技术二班】\n【姓名：梁阔雄】\n【学号：20150301241】\n【性别：男】", r.nickname) });
                        msg.Articles.Add(new Article
                            {
                                Title = string.Format("你的微信号是{0}", r.openid),
                                PicUrl = r.headimgurl
                            });
                        rm = msg;
                    }
                    break;
            }
            return rm;
        }

    }
}