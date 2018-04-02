<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendnews.aspx.cs" Inherits="NavShare.sendnews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>    
        <h1>作者信息</h1>
        <p>班级;计算机应用技术 班
            学号：
            姓名：
        </p>
    </div>
    <div>
    <input type="text" id="AuthorID" name="AuthorID" value="" />
    <input type="submit" value="发送" />
    </div>
    </form>
</body>
</html>
