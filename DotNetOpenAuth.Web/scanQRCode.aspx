<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scanQRCode.aspx.cs" Inherits="DotNetOpenAuth.Web.scanQRCode" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<%--//来自：http://www.DotNetOpenAuth.com--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>扫码签到</title>
    <script type="text/javascript" src="http://apps.bdimg.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script type="text/javascript">
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
                jsApiList: ['scanQRCode', 'closeWindow']
            });
            wx.error(function (res) {
                alert("BB");
                alert(res);   
            });
            wx.ready(function () {
                var str = location.href;
                if (str.indexOf("&signState=success") >= 0) {
                    alert("签到成功!");
                    wx.closeWindow();
                }
                else if (str.indexOf("&signState=resubmit") >= 0) {
                    alert("您已签到!");
                    wx.closeWindow();
                }
                else if (str.indexOf("&signState=error") >= 0) {
                    alert("当前网络不支持,请切换网络为4g状态!");
                    wx.closeWindow();
                }
                else {
                    wx.scanQRCode({
                        desc: 'scanQRCode desc',
                        needResult: 1, // 默认为0，扫描结果由企业微信处理，1则直接返回扫描结果，
                        scanType: ["qrCode", "barCode"], // 可以指定扫二维码还是一维码，默认二者都有
                        success: function (res) {
                            // 回调
                            location.href = "scanQRCodeResult.aspx?QRcode=" + res["resultStr"];
                        },
                        error: function (res) {
                            if (res.errMsg.indexOf('function_not_exist') > 0) {
                                alert('版本过低请升级')
                            }
                        }
                    });
                }
            });
    </script>      
</head>
<body id="Body1" runat="server">
    <form id="Form" width="100%" method="post" runat="server">  
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