<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scanQRCode.aspx.cs" Inherits="DotNetOpenAuth.Web.scanQRCode" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<%--//来自：http://www.DotNetOpenAuth.com--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>计划填报</title>
    <script type="text/javascript" src="http://apps.bdimg.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script src="../mobiscroll/mobiscroll.custom-2.17.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../mobiscroll/mobiscroll.custom-2.17.0.min.css"/>
               
    <script type="text/javascript">
        function a(obj) {
            var aa = document.getElementById("Date1").value;
            var bb = document.getElementById("Date2").value;
            if (aa > bb) {
                alert("开始时间必须小于结束时间!");
            }
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
                dateFormat: 'yy-mm-dd',
                lang: 'zh',
                showNow: true,
                nowText: "今天",
                startYear: currYear - 50, //开始年份
                endYear: currYear + 10 //结束年份
            };

            $("#Date1").mobiscroll($.extend(opt['date'], opt['default']));
            $("#Date2").mobiscroll($.extend(opt['date'], opt['default']));
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
        #Date2 {height: auto;width: 80%;
        }
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
        .hidden { display:none;}
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 75%;
            height: 33px;
        }
        .auto-style5 {
            height: 33px;
        }
        .auto-style6 {
            height: 28px;
        }
    </style>

</head>
<body id="Body1" runat="server">
    <form id="Form" width="100%" method="post" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var appId = '<%=appId%>', nonceStr = '<%=nonceStr%>', signature = '<%=signature%>';
            var timestamp = 0;
            timestamp = '<%=timestamp%>';
            //$("#msgDiv").html(userid);   
            wx.config({
                debug: false,
                appId: appId,
                timestamp: timestamp,
                nonceStr: nonceStr,
                signature: signature,
                jsApiList: ['scanQRCode']
            });
            wx.error(function (res) {
                alert("BB");
                alert(res);
                //$("#msgDiv").html(res);                
            });
            //alert("BB");
            //alert(appId + "-" + signature + "-" + timestamp + "-" + nonceStr + "-" + signature);
            wx.ready(function () {
                wx.scanQRCode({
                    desc: 'scanQRCode desc',
                    needResult: 1, // 默认为0，扫描结果由企业微信处理，1则直接返回扫描结果，
                    scanType: ["qrCode", "barCode"], // 可以指定扫二维码还是一维码，默认二者都有
                    success: function (res) {
                        // 回调
                        alert(JSON.stringify(res));
                    },
                    error: function (res) {
                        if (res.errMsg.indexOf('function_not_exist') > 0) {
                            alert('版本过低请升级')
                        }
                    }
                });
            });
        });
    </script>
        <table class="auto-style1">
            <tr>
                <td align="right" class="auto-style5">        
        <asp:Label ID="Label4" runat="server" Text="考勤类别:" BorderStyle="None"></asp:Label>
                </td>
                <td class="auto-style4">
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" Text="出勤" GroupName="1" Width="30%" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="出差" GroupName="1" Width="30%" />
        <asp:RadioButton ID="RadioButton3" runat="server" Text="休假" GroupName="1" Width="30%" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style5">        
        <asp:Label ID="Label8" runat="server" Text="考勤地点:" BorderStyle="None"></asp:Label>
                </td>
                <td class="auto-style4">
        <asp:RadioButton ID="RadioButton4" runat="server" Checked="True" Text="国内" GroupName="2" Width="30%" />
        <asp:RadioButton ID="RadioButton5" runat="server" Text="国外" GroupName="2" Width="30%" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">        
        <asp:Label ID="Label9" runat="server" Text="具体地点:" BorderStyle="None"></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="TBplaceInfo" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">
        <asp:Label ID="Label5" runat="server" Text="考勤区间:" BorderStyle="None"></asp:Label>
                </td>
                <td class="auto-style6">
                   <input id="Date1" runat="server" type="text" placeholder="Start Date" onchange="a(this);"/></td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">
                    <asp:Label ID="Label1" runat="server" Text="至:"></asp:Label>
                </td>
                <td class="auto-style6">
                    <input id="Date2" runat="server" type="text" placeholder="End Date" onchange="a(this);"/></td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">
        <asp:Label ID="Label6" runat="server" Text="考勤人员:" BorderStyle="None"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TBuserName" runat="server" Width="50%" ReadOnly="True" BorderStyle="None" Font-Size="Medium"></asp:TextBox>
        <asp:TextBox ID="TBmobile" runat="server" Width="50%" ReadOnly="True" BorderStyle="None" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">
        <asp:Label ID="Label2" runat="server" Text="所属组织:" BorderStyle="None"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TBupDp" runat="server" Width="100%" ReadOnly="True" BorderStyle="None" Font-Size="Medium"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">
        <asp:Label ID="Label7" runat="server" Text="计划内容:" BorderStyle="None"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style6" colspan="2">
        <asp:TextBox ID="TextBox2" runat="server" Width="99%" Font-Size="Medium" Height="90px" TextMode="MultiLine" style="margin-left: 2px"></asp:TextBox>
                </td>
            </tr>
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