<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scanQRQuery.aspx.cs" Inherits="DotNetOpenAuth.Web.scanQRQuery" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<%--//来自：http://www.DotNetOpenAuth.com--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>会议签到查询</title>
    <script type="text/javascript" src="http://apps.bdimg.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="mobiscroll/mobiscroll.custom-2.17.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="mobiscroll/mobiscroll.custom-2.17.0.min.css"/>
               
    <script type="text/javascript">
        function clickQuary() {
            var btn = document.getElementById("Button6"); btn.click();
        }
        function a(obj){
        }
        function getNowFormatDate() {
            var date = new Date();
            var seperator1 = "-";
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = year + seperator1 + month + seperator1 + strDate;
            return currentdate;
        }
        function GridViewItemKeyDownEvent(d) {
            showWin(d); 
            //window.alert("参数公式:" + d);
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
                dateFormat: 'yy-mm',
                dateOrder:"yy",//只显示年
                lang: 'zh',
                showNow: true,
                nowText: "今天",
                startYear: currYear - 50, //开始年份
                endYear: currYear + 10 //结束年份
            };

            $("#Date1").mobiscroll($.extend(opt['date'], opt['default']));

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
        #Date1 {height: auto;width: 80%;
        }
        #win{
        /*边框*/
        /*border:1px red solid;*/
        /*窗口的高度和宽度*/
        width : 320px;
        height: 250px;
        /*窗口的位置*/
        position : absolute;
        top : 100px;
        left: 40px;
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
            margin-left: 208px;
            /*当鼠标移动到X上时，出现小手的效果*/
            cursor: pointer;
        }
        .hidden { display:none;}
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 30%;
            height: 21px;
        }
        .auto-style4 {
            width: 70%;
            height: 26px;
        }
    </style>

</head>
<body>
    <form id="Form" width="100%" method="post" runat="server">
        <div id="win">
        <div id="title">计划详情:<span id="close" onclick="hide()">X</span></div>
        <div id="content" style="height:225px;overflow-y:auto"></div>
        </div>
        <table class="auto-style1">
            <tr style="height:40px">
                <td align="right" td class="auto-style3">
        <asp:Label ID="Label5" runat="server" Text="时期选择:" BorderStyle="None"></asp:Label>
                </td>
                <td>
        <input  style="height:90%;font-size:larger" id="Date1" runat="server" type="text" placeholder="Start Date" onchange="a(this);"/></td>
            </tr>
            </table>
        <asp:Button ID="Button1" runat="server" Text="查询" Width="50%" Height="30px" BorderWidth="2px" BorderStyle="Solid" OnClick="Button1_Click" BackColor="#FFFF66" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Large" ForeColor="#9900CC" type="button"/>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" title="参数信息">
            <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="id" CellPadding="4" AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#9900CC" BorderStyle="Groove" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BorderWidth="2px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="app" HeaderText="扫描应用" ></asp:BoundField>
                    <asp:BoundField DataField="id" HeaderText="id" >
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sing" HeaderText="姓名" ></asp:BoundField>
                    <asp:BoundField DataField="meettitle" ReadOnly="True" HeaderText="会议名称"></asp:BoundField>
                    <asp:BoundField DataField="singtime" HeaderText="扫描时间" ></asp:BoundField>
                    <asp:BoundField DataField="qcode" ReadOnly="True" HeaderText="qcode">
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="belongs" ReadOnly="True" HeaderText="部门">
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" /></asp:BoundField>
                    <asp:BoundField DataField="userid" HeaderText="userid(wx)">
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" /></asp:BoundField>
                </Columns>
                <RowStyle HorizontalAlign="Center" BackColor="White" />
                <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />
            </asp:GridView>
        </table>
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
            <webdiyer:aspnetpager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged"
                ShowCustomInfoSection="Left" Width="100%" meta:resourcekey="AspNetPager1" Style="font-size: 14px" InputBoxStyle="width:19px"
                CustomInfoHTML="共<b><font color='red'>%RecordCount%</font></b>条 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="30" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px">
            </webdiyer:aspnetpager>
        </table>
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