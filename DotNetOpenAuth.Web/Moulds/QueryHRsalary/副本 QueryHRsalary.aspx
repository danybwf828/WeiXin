<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryHRsalary.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.QueryHRsalary.QueryHRsalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<title>工资查询</title>

<link rel="stylesheet" type="text/css" href="css/default.css"/>
<link rel="stylesheet" type="text/css" href="css/styles.css"/>
</head>

<body runat="server">
<article class="htmleaf-container">
	<div class="demo">
	  <header class="demo__header"></header>
	  <div class="demo__content">
		<div class="demo__card-cont" id="DCC01">
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-12">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[11]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[11]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[11]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[11]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-9">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[10]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[10]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[10]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[10]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-8">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[9]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[9]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[9]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[9]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-11">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[8]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[8]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[8]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[8]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-7">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[7]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[7]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[7]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[7]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top bgcolor-6 ">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[6]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[6]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[6]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[6]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top blue">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[5]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[5]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[5]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[5]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top lime">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[4]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[4]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[4]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[4]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top brown">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[3]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[3]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[3]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[3]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top indigo">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[2]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[2]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[2]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[2]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top cyan">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[1]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[1]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[1]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[1]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		  <div class="demo__card">
			<div class="demo__card__top purple">
			  <div class="demo__card__img"></div>
			  <p class="demo__card__name">'<%=bbSalaryTime[0]%>'</p>
			</div>
			<div class="demo__card__btm">
               <br />
			  <p style="font-size:20px;"> 应发：<%=bbSalaryYF[0]%>元</p>
               <br />
			  <p style="font-size:20px;"> 扣款：<%=bbSalaryKK[0]%>元</p>
               <br />
			  <p style="font-size:20px;"> 实发：<%=bbSalarySF[0]%>元</p>
			</div>
			<div class="demo__card__choice m--reject"></div>
			<div class="demo__card__choice m--like"></div>
			<div class="demo__card__drag"></div>
		  </div>
		</div>
		<p class="demo__tip">Swipe left or right</p>
	  </div>
	</div>
</article>
<script src='js/stopExecutionOnTimeout.js?t=1'></script>
<script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<script>
    function cDiv(){
        var bb = document.getElementById("DCC01");
        var div = document.createElement("div");
        div.id = "DC07";
        div.className = "demo__card";
        div.innerHTML = "";
            var div_1 = document.createElement("div");
            div_1.id = "DCTB07";
            div_1.className = "demo__card__top brown";
                var div_11 = document.createElement("div");
                div_11.id = "DCI0711";
                div_11.className = "demo__card__img";              
                div_1.appendChild(div_11)       
                var div_12 = document.createElement("p");
                div_12.id = "DCN0712";
                div_12.className = "demo__card__name";
                div_12.innerHTML = "白白笨笨";             
                div_1.appendChild(div_12)          
            div.appendChild(div_1)
            var div_2 = document.createElement("div");
            div_2.id = "DCB07";
            div_2.className = "demo__card__btm";
                var div_21 = document.createElement("p");
                div_21.id = "DCN0721";
                div_21.className = "demo__card__name";
                div_21.innerHTML = "白白笨笨2";             
                div_2.appendChild(div_21)  
            div.appendChild(div_2)
            var div_3 = document.createElement("div");
            div_3.id = "DCCMR07";
            div_3.className = "demo__card__choice m--reject";
            div.appendChild(div_3)
            var div_4 = document.createElement("div");
            div_4.id = "DCCML07";
            div_4.className = "demo__card__choice m--like";
            div.appendChild(div_4)
            var div_5 = document.createElement("div");
            div_5.id = "DCTB07";
            div_5.className = "demo__card__drag";
            div.appendChild(div_5)
        bb.appendChild(div);
    }
    //cDiv();
    $(document).ready(function () {
        var animating = false;
        var cardsCounter = 0;
        var numOfCards = 12;
        var decisionVal = 80;
        var pullDeltaX = 0;
        var deg = 0;
        var $card, $cardReject, $cardLike;
        function pullChange() {
            animating = true;
            deg = pullDeltaX / 10;
            $card.css('transform', 'translateX(' + pullDeltaX + 'px) rotate(' + deg + 'deg)');
            var opacity = pullDeltaX / 100;
            var rejectOpacity = opacity >= 0 ? 0 : Math.abs(opacity);
            var likeOpacity = opacity <= 0 ? 0 : opacity;
            $cardReject.css('opacity', rejectOpacity);
            $cardLike.css('opacity', likeOpacity);
        }
        ;
        function release() {
            if (pullDeltaX >= decisionVal) {
                $card.addClass('to-right');
            } else if (pullDeltaX <= -decisionVal) {
                $card.addClass('to-left');
            }
            if (Math.abs(pullDeltaX) >= decisionVal) {
                $card.addClass('inactive');
                setTimeout(function () {
                    $card.addClass('below').removeClass('inactive to-left to-right');
                    cardsCounter++;
                    if (cardsCounter === numOfCards) {
                        cardsCounter = 0;
                        $('.demo__card').removeClass('below');
                    }
                }, 300);
            }
            if (Math.abs(pullDeltaX) < decisionVal) {
                $card.addClass('reset');
            }
            setTimeout(function () {
                $card.attr('style', '').removeClass('reset').find('.demo__card__choice').attr('style', '');
                pullDeltaX = 0;
                animating = false;
            }, 300);
        };
        $(document).on('mousedown touchstart', '.demo__card:not(.inactive)', function (e) {
            if (animating)
                return;
            $card = $(this);
            $cardReject = $('.demo__card__choice.m--reject', $card);
            $cardLike = $('.demo__card__choice.m--like', $card);
            var startX = e.pageX || e.originalEvent.touches[0].pageX;
            $(document).on('mousemove touchmove', function (e) {
                var x = e.pageX || e.originalEvent.touches[0].pageX;
                pullDeltaX = x - startX;
                if (!pullDeltaX)
                    return;
                pullChange();
            });
            $(document).on('mouseup touchend', function () {
                $(document).off('mousemove touchmove mouseup touchend');
                if (!pullDeltaX)
                    return;
                release();
            });
        });
    });
</script>

<script type="text/javascript">
            $(function(){
                var userid='<%=userID%>';
            //$("#msgDiv").html(userid);
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
                        //$("#msgDiv").html(userid+" 您好！<br>当前位置：<br>纬度："+res.latitude+"<br>经度："+res.longitude+"<br>速度："+res.speed+"<br>精度："+res.accuracy+"<br>");
                        //var htmlobj=$.ajax({url:"/PlanFill.aspx?state=Sign&userid="+userid+"&deviceId="+userid+"&deviceId="+deviceId+"&lat="+res.latitude+"&lng="+res.longitude,async:false});
                        //$("#rstDiv").html(htmlobj.responseText);
                    },
                    fail:function(){
                        //$("#msgDiv").html(userid+" 您好！<br>获取位置信息失败");
                    }
                });                
            });
            wx.error(function(res){
                //$("#msgDiv").html(res);                
            });
        });
    </script>
<div style="text-align:center;margin:-50px 0; font:normal 14px/24px 'MicroSoft YaHei';">
<p>适用浏览器：360、FireFox、Chrome、Safari、Opera、傲游、搜狗、世界之窗. 不支持IE8及以下浏览器。</p>
<p>来源：<a href="http://172.22.23.104/" target="_blank">ZIJIN-HR</a></p>
</div>
</body>
</html>
