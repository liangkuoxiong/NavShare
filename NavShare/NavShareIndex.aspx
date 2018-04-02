<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavShareIndex.aspx.cs" Inherits="NavShare.NavShareIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<%-- 微信JS接口 --%>
<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<style type="text/css">
    body {
        font-family : 微软雅黑,宋体;
font-size : 30px;
color : #f00;
width:100%;
    }
</style>

</head>
<body>    
    <h1>新一轮分享有奖活动</h1>
    <h2>活动参与方法:</h2>
    <ul>
      <li>将链接分享到朋友圈或发送给微信好友</li>
      <li>分享后奖励S币10个</li>
      <li>朋友点击分享链接超过20次奖励S币40个</li>
    </ul>
    <form id="form1" runat="server">
    <div>    
        <h1>作者信息</h1>
            班级;计算机应用技术2班
            学号：20150301241
            姓名：梁阔雄
    </div>
    </form>
</body>
</html>
<script>
    var url = location.href;
    url = 'Share.aspx?url=' + url + '&u=<%=ViewState["u"]%>' + '&s=<%=ViewState["s"]%>';
    //转发给朋友圈的回调函数，向后台传递转发记录
    function friendCirclecallback(res) {        
        //AJAX请求               
        $.ajax({
            type: "get",
            url: url + "&type=timeline",
            beforeSend: function () {
            },
            success: function () {                
            },
            complete: function () {
            },
            error: function () {                
            }
        });
    };
    //转发给朋友的回调函数，向后台传递转发记录
    function friendcallback(res) {
        //AJAX请求
        $.ajax({
            type: "get",
            url: url + "&type=friend",
            beforeSend: function () {
            },
            success: function () {                
            },
            complete: function () {
            },
            error: function () {                
            }
        });
    };
    //转发给微博的回调函数，向后台传递转发记录
    function friendCirclecallback(res) {
        //AJAX请求               
        $.ajax({
            type: "get",
            url: url + "&type=weibo",
            beforeSend: function () {
            },
            success: function () {
            },
            complete: function () {
            },
            error: function () {
            }
        });
    };
</script>
