<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DQdispatch.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.ZJGroup.DangQun.DQdispatch" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta http-equiv="Content-Type" content="text/html" charset="UTF-8">
	<meta name="apple-mobile-web-app-capable" content="yes">	
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
<%--	<script type="text/javascript">
	    if (/Android (\d+\.\d+)/.test(navigator.userAgent)) {
	        var version = parseFloat(RegExp.$1);
	        if (version > 2.3) {
	            var phoneScale = parseInt(window.screen.width) / 640;
	            document.write('<meta name="viewport" content="width=640, minimum-scale = ' + phoneScale + ', maximum-scale = ' + phoneScale + ', target-densitydpi=device-dpi">');
	        } else {
	            document.write('<meta name="viewport" content="width=640, target-densitydpi=device-dpi">');
	        }
	    } else {
	        document.write('<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi">');
	    }
	</script>--%>
	<title></title>
	<link rel="stylesheet" href="css/animate.css">
	<link rel="stylesheet" href="css/style2.css">
    <script type="text/javascript">
    function formSubmit(){
    if(confirm('是否确定？')){
        document.getElementById("myForm").submit();
    }
    }
	</script>
</head>
<body>
  <form action="DQdispatch.aspx" name="form" id="myForm" method="POST" enctype="multipart/form-data">
	<div class="wrap">
		<div class="album-old">
			<div class="upload-btn btn-old"><input type="file" name="" id="File0"></div>
			<div class="upload-img "></div>	
		</div>
		<div class="album-new">
			<div class="upload-btn btn-new"><input type="file" name="" id="File1"></div>
			<div class="upload-img "></div>
		</div>
		<div class="wan"></div>
		<div class="textarea">
			<textarea Name="issTitle" placeholder="填写标题"></textarea>
		</div>
		<div class="textarea2">
			<textarea Name="issWords" placeholder="填写内容，字数不超过x字"></textarea>
		</div>
		<div ><input class="submit" type="button" value="" onclick="formSubmit()"  /></div>
	</div>
	</form>
	<script type="text/javascript" src="js/zepto.min.js"></script>
	<script type="text/javascript" src="js/iscroll-zoom.js"></script>
	<script type="text/javascript" src="js/script.js"></script>
</body>
</html>

