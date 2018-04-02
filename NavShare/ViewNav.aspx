<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNav.aspx.cs" Inherits="NavShare.ViewNav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>统计</title>
    <style type="text/css">
body
{
 font-family : 微软雅黑,宋体;
font-size : 30px;
color : #f00;
width:100%;
}

</style>
    <%-- Bootstrap --%>
    <link href="Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="row-fluid">
        <h1>作者信息</h1>
        <p>
            班级;计算机应用技术2班
            学号：20150301241
            姓名：梁阔雄
        </p>
    <div class="row-fluid">
        <div class="span12">
            <h3>访问记录</h3>
            <%-- 访问记录列表 --%>
            <div class="maincontentinner1" style="margin-left: 20px">
                    <div id="Div12" class="dataTables_wrapper">
                        <table id="page-nav-table" class="table table-bordered responsive dataTable">                           
                            <%-- 访问记录列表列名 --%>
                            <thead>
                                <tr>
                                    <th>
                                        页面地址
                                    </th>
                                    <th>
                                        访问来源
                                    </th>
                                    <th>
                                        访问者openid
                                    </th>
                                    <th>
                                        分享自openid
                                    </th>
                                    <th>
                                        访问时间
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="page-nav-table-body">
                                <%-- 一行一行生成访问记录列表 --%>
                                <% foreach (NavShare.Nav entity in (ViewState["NavList"] as List<NavShare.Nav>))
                                   { %>
                                    <tr class="gradeX odd">
                                        <td>
                                            <%= entity.Url%>
                                        </td>
                                        <td class=" ">
                                            <%= entity.NavFrom%>
                                        </td>
                                        <td class=" ">
                                            <%= entity.NavOpenId%>
                                        </td>
                                        <td class=" ">
                                            <%= entity.ShareOpenId%>
                                        </td>
                                        <td class=" ">
                                            <%= entity.VisitTime.ToString()%>
                                        </td>
                                    </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
            </div>
        </div>
    </div>
        </div>
</body>
</html>
