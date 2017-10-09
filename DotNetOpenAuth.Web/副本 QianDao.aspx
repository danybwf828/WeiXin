<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QianDao.aspx.cs" Inherits="DotNetOpenAuth.Web.QianDao" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<%--//来自：http://www.DotNetOpenAuth.com--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>微信项目-签到</title>
    <script type="text/javascript" src="http://apps.bdimg.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="../mobiscroll/mobiscroll.custom-2.17.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../mobiscroll/mobiscroll.custom-2.17.0.min.css"/>
               
    <script type="text/javascript">
        function clickQuary() {
            var btn = document.getElementById("Button6"); btn.click();
        }
        function GridViewItemKeyDownEvent(d) {
            showWin(d); window.alert("参数公式:" + d);
        }
        function showWin(d) {
            /*找到div节点并返回*/
            var winNode = $("#win");
            //方法一：利用js修改css的值，实现显示效果
            //winNode.css("display", "block");
            //方法二：利用jquery的show方法，实现显示效果
            // winNode.show("slow");
            //方法三：利用jquery的fadeIn方法实现淡入
            winNode.fadeIn("slow"); document.getElementById("content").innerText = d;
        }
        function hide() {
            var winNode = $("#win");
            //方法一：修改css的值
            //winNode.css("display", "none");
            //方法二：jquery的fadeOut方式
            winNode.fadeOut("slow");
            //方法三：jquery的hide方法
            winNode.hide("slow");
        }

        $(function () {

            var currYear = (new Date()).getFullYear();
            var opt = {};
            opt.date = { preset: 'date' };
            opt.datetime = { preset: 'datetime' };
            opt.time = { preset: 'time' };
            opt.default = {
                theme: 'mobiscroll', //皮肤样式
                display: 'modal', //显示方式 
                mode: 'scroller', //日期选择模式
                dateFormat: 'yyyy-MM-dd',
                lang: 'zh',
                showNow: true,
                nowText: "今天",
                startYear: currYear - 50, //开始年份
                endYear: currYear + 10 //结束年份
            };

            $("#Date1").mobiscroll($.extend(opt['date'], opt['default']));
            $("#Date2").mobiscroll($.extend(opt['date'], opt['default']));

            //$('#demo').mobiscroll().date({
            //    theme: 'mobiscroll',
            //    display: 'modal',
            //    dateFormat: 'yyyy-mm-dd',
            //    lang: 'zh',
            //    showNow: true,
            //    nowText: "今天",
            //    startYear: currYear - 50,
            //    endYear: currYear + 10
            //});

            $('#show').click(function () {
                $('#Date1').mobiscroll('show');
                return false;
            });

            $('#clear').click(function () {
                $('#Date1').mobiscroll('clear');
                return false;
            });


        });

            </script>

    <style type="text/css">
        #Date1 {height: 27px;width: 78px;}
        #Date2 {height: 27px;width: 78px;}
        #win{
        /*边框*/
        /*border:1px red solid;*/
        /*窗口的高度和宽度*/
        width : 300px;
        height: 200px;
        /*窗口的位置*/
        position : absolute;
        top : 100px;
        left: 100px;
        /*开始时窗口不可见*/
        display : none;
        background-color:#d0def0; 
        padding:2px; 
        margin:5px; 
}
        /*控制背景色的样式*/
        #title{
            background-color : #FFF;
            color : red;
            /*控制标题栏的左内边距*/
            /*padding-left: 3px;*/
           padding:2px;  
         font-size:15px; 
        }
        #cotent{
            padding-left : 3px;
            padding-top :  5px; 
           height:150px; 
        background-color:#FFF; 
        font-size:14px; 
         overflow:auto; 
        }
        /*控制关闭按钮的位置*/
        #close{
            margin-left: 188px;
            /*当鼠标移动到X上时，出现小手的效果*/
            cursor: pointer;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="msgDiv"></div>
    <div id="rstDiv" style="font-size:40px"></div>
    <script type="text/javascript">
        $(function(){
            var userid='<%=userID%>',deviceId='<%=deviceId%>',userinfo2='<%=userInfo2%>';
            $("#msgDiv").html(userid);

            wx.config({
                debug: false, 
                appId: '<%=appId%>', 
                timestamp: <%=timestamp%>, 
                nonceStr: '<%=nonceStr%>', 
                signature: '<%=signature%>',
                jsApiList: ['getLocation'] 
            });

            wx.ready(function () {

                wx.getLocation({
                    success: function (res) {
                        var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                        var longitude = res.longitude ; // 经度，浮点数，范围为180 ~ -180。
                        var speed = res.speed; // 速度，以米/每秒计
                        var accuracy = res.accuracy; // 位置精度

                        $("#msgDiv").html(userid+" 您好！<br>当前位置：<br>纬度："+res.latitude+"<br>经度："+res.longitude+"<br>速度："+res.speed+"<br>精度："+res.accuracy+"<br>");

                        var htmlobj=$.ajax({url:"/QianDao.aspx?state=Sign&userid="+userid+"&deviceId="+userid+"&deviceId="+deviceId+"&lat="+res.latitude+"&lng="+res.longitude,async:false});
                        $("#rstDiv").html(htmlobj.responseText);
                    },
                    fail:function(){
                        $("#msgDiv").html(userid+" 您好！<br>获取位置信息失败");
                    }
                });

                
            });

            wx.error(function(res){
                $("#msgDiv").html(res);                
            });


        });
    </script>
        
    <form id="Form2" width="100%" method="post" runat="server">
        <img width="100%" alt="Liwap" border="0" style="height: 69px" />
        <br /> 
        <asp:Button ID="Button1" runat="server" Text="计划填报" Width="50%" Height="78px" Visible="True" BorderWidth="2px" BorderStyle="Solid" OnClick="Button1_Click" BackColor="#FFFF66" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Large" ForeColor="#9900CC" />
        <asp:Button ID="Button5" runat="server" Text="计划查询" Width="49%" Height="78px" Visible="True" BorderWidth="2px" BorderStyle="Solid" BackColor="#FFFF66" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Large" ForeColor="#9900CC" OnClick="Button5_Click" />
        <br />   
        <asp:Label ID="Label1" runat="server" Font-Size="X-Small"></asp:Label>
        <div id="win">
        <div id="title">参数公式:<span id="close" onclick="hide()">X</span></div>
        <div id="content"></div>
        </div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="分管部门"></asp:Label>
        <asp:DropDownList ID="UserDp" runat="server" Width="20%" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="UserDp_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="公司名称"></asp:Label>
        <asp:DropDownList ID="UserCp" runat="server" Width="20%" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="UserCp_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="考勤类别"></asp:Label>
        <asp:DropDownList ID="KQmode" runat="server" Width="20%" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="UserCp_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Selected="True">出勤</asp:ListItem>
            <asp:ListItem>出差</asp:ListItem>
            <asp:ListItem>休假</asp:ListItem></asp:DropDownList>
        <br />
        <input id="Date1" runat="server" type="text" placeholder="Start Date" />  
        <input id="Date2" runat="server" type="text" placeholder="End Date" /> 
        <asp:Button ID="Button6" runat="server" Text="查询" OnClick="Button1_Click" />
        <asp:Button ID="Button8" runat="server" Text="保存" Enabled="False" Visible="False" OnClick="Button2_Click" />
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" title="参数信息">
            <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="ID" CellPadding="4" AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#9900CC" BorderStyle="Groove" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BorderWidth="2px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" ReadOnly="True" HeaderText="分管部门" ></asp:BoundField>
                    <asp:BoundField DataField="参数名" ReadOnly="True" HeaderText="公司名称"></asp:BoundField>
                    <asp:BoundField DataField="参数模式" ReadOnly="True" HeaderText="姓名"></asp:BoundField>
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" ><ControlStyle Width="32px" /></asp:CommandField>
                </Columns>
                <RowStyle HorizontalAlign="Center" BackColor="White" />
                <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />
            </asp:GridView>
        </table>
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
            <webdiyer:aspnetpager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged"
                ShowCustomInfoSection="Left" Width="100%" meta:resourcekey="AspNetPager1" Style="font-size: 14px" InputBoxStyle="width:19px"
                CustomInfoHTML="共<b><font color='red'>%RecordCount%</font></b>条 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="20" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px">
            </webdiyer:aspnetpager>
        </table>
    </form>
        <asp:TextBox ID="TextBox1" runat="server" Width="100%" Font-Size="Medium" Height="105px" TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>
 <%--wx.config({
                debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: '', // 必填，企业号的唯一标识，此处填写企业号corpid
                timestamp: , // 必填，生成签名的时间戳
                nonceStr: '', // 必填，生成签名的随机串
                signature: '',// 必填，签名，见附录1
                jsApiList: [] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
            });

 接口调用说明

所有接口通过wx对象(也可使用jWeixin对象)来调用，参数是一个对象，除了每个接口本身需要传的参数之外，还有以下通用参数： 
1.success：接口调用成功时执行的回调函数。 
2.fail：接口调用失败时执行的回调函数。 
3.complete：接口调用完成时执行的回调函数，无论成功或失败都会执行。 
4.cancel：用户点击取消时的回调函数，仅部分有用户取消操作的api才会用到。 
5.trigger: 监听Menu中的按钮点击时触发的方法，该方法仅支持Menu中的相关接口。 


注意：不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回。 


 以上几个函数都带有一个参数，类型为对象，其中除了每个接口本身返回的数据之外，还有一个通用属性errMsg，其值格式如下： 
1. 调用成功时："xxx:ok" ，其中xxx为调用的接口名 
2. 用户取消时："xxx:cancel"，其中xxx为调用的接口名 
3.调用失败时：其值为具体错误信息 
    
     
     
     
     
     --%>