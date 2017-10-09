<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangQun.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.ZJGroup.DangQun.DaongQun" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1, user-scalable=no">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>党群</title>
<link rel="stylesheet" href="css/demo1.css">
<link rel="stylesheet" href="css/iconfont.css">
<link rel="stylesheet prefetch" href="css/photoswipe.css">
<link rel="stylesheet prefetch" href="css/default-skin/default-skin.css">
<script type="text/javascript" src="js/iscroll.js"></script>
<script type="text/javascript">

    var myScroll,
        pullDownEl,
        pullDownOffset,
        pullUpEl,
        pullUpOffset,
        generatedCount = 0;

    function pullDownAction() {
        setTimeout(function () {	// <-- Simulate network congestion, remove setTimeout from production!
            var el, li, i;
            el = document.getElementById('thelist');

            for (i = 0; i < 5; i++) {
                li = document.createElement('li');
                li.innerText = 'Generated row ' + (++generatedCount);
                el.insertBefore(li, el.childNodes[0]);
            }
            document.getElementById("pullUp").style.display = "";
            myScroll.refresh();
        }, 1000);
    }

    function pullUpAction() {
        setTimeout(function () {
            var el, li, i;
            el = document.getElementById('thelist');

            for (i = 0; i < 1; i++) {
                li = document.createElement('li');
                li.innerText = 'Generated row ' + (++generatedCount);
                el.appendChild(li, el.childNodes[0]);
            }
            myScroll.refresh();
        }, 1000);
    }

    function loaded() {
        pullDownEl = document.getElementById('pullDown');
        pullDownOffset = pullDownEl.offsetHeight;
        pullUpEl = document.getElementById('pullUp');
        pullUpOffset = 10;
        //pullUpOffset = pullUpEl.offsetHeight;
        myScroll = new iScroll('wrapper', {
            useTransition: true,
            topOffset: pullDownOffset,
            onRefresh: function () {
                //that.maxScrollY = that.wrapperH - that.scrollerH + that.minScrollY;
                //that.minScrollY = -that.options.topOffset || 0;
                //alert(this.wrapperH);
                //alert(this.scrollerH);
                if (pullDownEl.className.match('loading')) {
                    pullDownEl.className = '';
                    pullDownEl.querySelector('.pullDownLabel').innerHTML = 'Pull down to refresh...';
                }
                if (pullUpEl.className.match('loading')) {
                    pullUpEl.className = '';
                    pullUpEl.querySelector('.pullUpLabel').innerHTML = 'Pull up to load more...';
                }

                document.getElementById("pullUp").style.display = "none";
                document.getElementById("show").innerHTML = "onRefresh: up[" + pullUpEl.className + "],down[" + pullDownEl.className + "],Y[" + this.y + "],maxScrollY[" + this.maxScrollY + "],minScrollY[" + this.minScrollY + "],scrollerH[" + this.scrollerH + "],wrapperH[" + this.wrapperH + "]";
            },
            onScrollMove: function () {
                document.getElementById("show").innerHTML = "onScrollMove: up[" + pullUpEl.className + "],down[" + pullDownEl.className + "],Y[" + this.y + "],maxScrollY[" + this.maxScrollY + "],minScrollY[" + this.minScrollY + "],scrollerH[" + this.scrollerH + "],wrapperH[" + this.wrapperH + "]";
                //if (this.y > 0) {
                //    pullDownEl.className = 'flip';
                //    pullDownEl.querySelector('.pullDownLabel').innerHTML = 'Release to refresh...';
                //    this.minScrollY = 0;
                //}
                //if (this.y < 0 && pullDownEl.className.match('flip')) {
                //    pullDownEl.className = '';
                //    pullDownEl.querySelector('.pullDownLabel').innerHTML = 'Pull down to refresh...';
                //    this.minScrollY = -pullDownOffset;
                //}

                if (this.scrollerH < this.wrapperH && this.y < (this.minScrollY - pullUpOffset) || this.scrollerH > this.wrapperH && this.y < (this.maxScrollY - pullUpOffset)) {
                    document.getElementById("pullUp").style.display = "";
                    pullUpEl.className = 'flip';
                    pullUpEl.querySelector('.pullUpLabel').innerHTML = 'Release to refresh...';
                }
                if (this.scrollerH < this.wrapperH && this.y > (this.minScrollY - pullUpOffset) && pullUpEl.className.match('flip') || this.scrollerH > this.wrapperH && this.y > (this.maxScrollY - pullUpOffset) && pullUpEl.className.match('flip')) {
                    document.getElementById("pullUp").style.display = "none";
                    pullUpEl.className = '';
                    pullUpEl.querySelector('.pullUpLabel').innerHTML = 'Pull up to load more...';
                }
            },
            onScrollEnd: function () {
                document.getElementById("show").innerHTML = "onScrollEnd: up[" + pullUpEl.className + "],down[" + pullDownEl.className + "],Y[" + this.y + "],maxScrollY[" + this.maxScrollY + "],minScrollY[" + this.minScrollY + "],scrollerH[" + this.scrollerH + "],wrapperH[" + this.wrapperH + "]";
                if (pullDownEl.className.match('flip')) {
                    pullDownEl.className = 'loading';
                    pullDownEl.querySelector('.pullDownLabel').innerHTML = 'Loading...';
                    pullDownAction();	// Execute custom function (ajax call?)
                }
                if (pullUpEl.className.match('flip')) {
                    pullUpEl.className = 'loading';
                    pullUpEl.querySelector('.pullUpLabel').innerHTML = 'Loading...';
                    pullUpAction();	// Execute custom function (ajax call?)
                }
            }
        });

        //setTimeout(function () { document.getElementById('wrapper').style.left = '0'; }, 800);
    }

    document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);

    document.addEventListener('DOMContentLoaded', function () { setTimeout(loaded, 200); }, false);
</script>

<style type="text/css" media="all">
#show{
	display:none;	
}

#wrapper {
	position:absolute; 
	z-index:1;
	height:100%;
	width:100%;
	background:#aaa;
	border:1px red solid;
}

#scroller {
	position:absolute; z-index:1;
/*	-webkit-touch-callout:none;*/
	-webkit-tap-highlight-color:rgba(0,0,0,0);
	width:100%;
	padding:0;
}

#scroller ul {
	list-style:none;
	padding:0;
	margin:0;
	width:100%;
	text-align:left;
}

#scroller li {
	padding:0 10px;
	height:40px;
	line-height:40px;
	border-bottom:1px solid #ccc;
	border-top:1px solid #fff;
	background-color:#fafafa;
	font-size:14px;
}

/**
 *
 * Pull down styles
 *
 */
#pullDown, #pullUp {
	background:#fff;
	height:40px;
	line-height:40px;
	padding:5px 10px;
	border-bottom:1px solid #ccc;
	font-weight:bold;
	font-size:14px;
	color:#888;
}

#pullDown .pullDownIcon, #pullUp .pullUpIcon  {
	display:block; float:left;
	width:40px; height:40px;
	background:url("pull-icon@2x.png") 0 0 no-repeat;
	-webkit-background-size:40px 80px; background-size:40px 80px;
	-webkit-transition-property:-webkit-transform;
	-webkit-transition-duration:250ms;	
}

#pullDown .pullDownIcon {
	-webkit-transform:rotate(0deg) translateZ(0);
}

#pullUp .pullUpIcon  {
	-webkit-transform:rotate(-180deg) translateZ(0);
}

#pullDown.flip .pullDownIcon {
	-webkit-transform:rotate(-180deg) translateZ(0);
}

#pullUp.flip .pullUpIcon {
	-webkit-transform:rotate(0deg) translateZ(0);
}

#pullDown.loading .pullDownIcon, #pullUp.loading .pullUpIcon {
	background-position:0 100%;
	-webkit-transform:rotate(0deg) translateZ(0);
	-webkit-transition-duration:0ms;

	-webkit-animation-name:loading;
	-webkit-animation-duration:2s;
	-webkit-animation-iteration-count:infinite;
	-webkit-animation-timing-function:linear;
}

@-webkit-keyframes loading {
	from { -webkit-transform:rotate(0deg) translateZ(0); }
	to { -webkit-transform:rotate(360deg) translateZ(0); }
}

</style>
</head>
<body style="background-color: #fff;">
	<div id="_contain">
		<div class="contain" style="margin:0 0 0;">
            <p id="show"></p> 
            <div id="wrapper" style="background-color: #fff;">
	            <div>
		            <div class="banner" style="position: relative;">
			            <div class="top_bg"></div>
			            <div style="width:80px; height:80px;position: absolute;background-color: #F3F3F7;right: 10px;bottom: -30px;">
				            <img src=<%=userAvatar%> style="width:96%; margin: 2%;">
			            </div>
			            <div style="position: absolute;right: 100px;bottom: 10px;color: white;"><%=userName%></div>
		            </div>
		            <div id="pullDown" style="display:none">
			            <span class="pullDownIcon"></span><span class="pullDownLabel">Pull down to refresh...</span>
		            </div>
			        <ul id="thelist">
				        <li>
					        <div class="body">
						        <div class="logo">
							        <img src="img/DQ01.png">
							        <div style="height:10%;font-size:2.2rem;font-family:YouYuan">党群</div>
						        </div>
						        <div class="text">
							        <div class="title">党群</div>
							        <div class="txt">党章，是一个政党为保证全党在政治上，思想上的一致和组织上，行动上的统一所制定的章程。一个党的党章的主要内容应该包括该党的性质、指导思想、纲领任务、组织结构、组织制度，党员的条件、权利、义务和纪律等项。
                                        <span id="p1">...</span>
                                        <span id="txt1" style="display:none;">党章是一个政党为保证全党在政治上，思想上的一致和组织上，行动上的统一所制定的章程。一个党的党章的主要内容应该包括该党的性质、指导思想、纲领任务、组织结构、组织制度，党员的条件、权利、义务和纪律等项。通常衡量一个政党是否成熟党章也是关键因素之一。党章是政党的宗旨和行为规范。中国共产党现行党章于中国共产党第十八次全国代表大会部分修改，于2012年11月14日通过。除总纲外共十一章五十三条。规定了党的纲领、组织机构、组织制度、党员的条件、党员的义务和权利、党的纪律等项。
                                        </span>
                                    </div>
							        <div style="color: #88B1C5;" onclick="more(this,'1')">全文</div>
							        <div class="my-gallery" data-pswp-uid="1">
							            <figure>
                                          <span>
							              <a href="img/m3.jpg" data-size="670x712">
							              <img style="width:80%;" src="img/th1.jpg">
							              </a>
                                          </span>
							            </figure>
							        </div>
							        <div class="tm">
								        <div class="fl">1分钟前</div>
								        <div class="fr">赞</div>
								        <div class="fr">评论</div>
							        </div>
							        <div class="cmt">
								        <div class="fav line"><i class="iconfont">&#xe616;</i>于博,唐泽</div>
								        <div><span>于博：</span>忠党爱国</div>
								        <div><span>唐泽：</span>忠党爱国</div>
							        </div>
						        </div>
					        </div>
				        </li>
				        <li>
					    <%--    <div class="body">
						        <div class="logo"><img src="img/tx3.jpg"></div>
						        <div class="text">
							        <div class="title">小清新</div>
							        <div class="txt">买了一个更帅的电饭锅，可以手机远程操制的，开心</div>
							        <!--data-pswp-uid 是每个gallery的id不能重复-->
							        <div class="my-gallery" data-pswp-uid="2">
							        <figure>
								        <div><a href="img/s5.jpg" data-size="286x220"><img style="height:100%;" src="img/s5.jpg"></a></div>
								        <figcaption style="display:none;">在这里可增加图片描述</figcaption>
							        </figure>
							        <figure>
								        <div><a href="img/sb1.jpg" data-size="640x426"><img style="height:100%;" src="img/sb1.jpg"></a></div>
								        <figcaption style="display:none;">在这里可增加图片描述2</figcaption>
							        </figure>
							        <figure>
								        <div><a href="img/sb3.jpg" data-size="768x1024"><img style="width:100%;" src="img/sb3.jpg"></a></div>
								        <figcaption style="display:none;">在这里可增加图片描述3</figcaption>
							        </figure>
							        <figure>
								        <div><a href="img/sb4.jpg" data-size="900x596"><img style="height:100%;" src="img/sb4.jpg"></a></div>
								        <figcaption style="display:none;">在这里可增加图片描述4</figcaption>
							        </figure>
							        <figure>
								        <div><a href="img/y1.jpeg" data-size="1200x1200"><img  style="height:100%;" src="img/y1.jpeg"></a></div>
								        <figcaption style="display:none;">在这里可增加图片描述5在这里可增加图片描述5在这里可增加图片描述5</figcaption>
							        </figure>
							        </div>
							        <div class="tm">
								        <div class="fl">2分钟前</div>
								        <div class="fr">评论</div>
							        </div>
							        <div class="cmt">
								        <div class="fav"><i class="iconfont">&#xe616;</i>ANTHONY,☆Sanly☆</div>
								        <div><span>ANTHONY：</span>这么先进，和我家的那台一样，打个电话，照样有饭吃，一键式，还带做菜功能，还能洗碗聊天晾衣服</div>
								        <div><span>☆Sanly☆:</span>远程？还有洗米放水功能？</div>
							        </div>
						        </div>
					        </div>--%>
				        </li>				
			        </ul>            
		            <div id="pullUp" style="display:none;" >
			            <span class="pullUpIcon"></span><span class="pullUpLabel">Pull up to refresh...</span>
		            </div>
                 </div>
            </div>
		</div>
    </div>
	
	<!-- Root element of PhotoSwipe. Must have class pswp. -->
<div class="pswp" tabindex="-1" role="dialog" aria-hidden="true">

    <!-- Background of PhotoSwipe. 
         It's a separate element as animating opacity is faster than rgba(). -->
    <div class="pswp__bg"></div>

    <!-- Slides wrapper with overflow:hidden. -->
    <div class="pswp__scroll-wrap">

        <!-- Container that holds slides. 
            PhotoSwipe keeps only 3 of them in the DOM to save memory.
            Don't modify these 3 pswp__item elements, data is added later on. -->
        <div class="pswp__container">
            <div class="pswp__item"></div>
            <div class="pswp__item"></div>
            <div class="pswp__item"></div>
        </div>

        <!-- Default (PhotoSwipeUI_Default) interface on top of sliding area. Can be changed. -->
        <div class="pswp__ui pswp__ui--hidden">

            <div class="pswp__top-bar">

                <!--  Controls are self-explanatory. Order can be changed. -->

                <div class="pswp__counter"></div>

                <button class="pswp__button pswp__button--close" title="Close (Esc)"></button>

                <button class="pswp__button pswp__button--share" title="Share"></button>

                <button class="pswp__button pswp__button--fs" title="Toggle fullscreen"></button>

                <button class="pswp__button pswp__button--zoom" title="Zoom in/out"></button>

                <!-- element will get class pswp__preloader--active when preloader is running -->
                <div class="pswp__preloader">
                    <div class="pswp__preloader__icn">
                      <div class="pswp__preloader__cut">
                        <div class="pswp__preloader__donut"></div>
                      </div>
                    </div>
                </div>
            </div>

            <div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">
                <div class="pswp__share-tooltip"></div> 
            </div>

            <button class="pswp__button pswp__button--arrow--left" title="Previous (arrow left)">
            </button>

            <button class="pswp__button pswp__button--arrow--right" title="Next (arrow right)">
            </button>

            <div class="pswp__caption">
                <div class="pswp__caption__center"></div>
            </div>

        </div>

    </div>

</div>
</body>
<script src="js/jquery.min.js"></script>
<script src="js/photoswipe.js"></script>
<script src="js/photoswipe-ui-default.min.js"></script>
<script type="text/javascript">
    function cDivLi(a) {        
        var BBul = document.getElementById("thelist");//获取li容器
        var BBli = document.createElement("li");//创建li

            var BBdivBody = document.createElement("div");
                var BBdivLogo = document.createElement("div");
                BBdivLogo.style.width = "15%";
                BBdivLogo.style.cssFloat = "left";
                    var BBimgLogo = document.createElement("img");
                    BBimgLogo.src = "<%=bbLiList[0][0]%>";
                    BBimgLogo.style.cssFloat = "left";
                    BBimgLogo.style.width = "100%";
                    var BBdivLogoUser = document.createElement("div");
                    BBdivLogoUser.style.height = "10%";
                    BBdivLogoUser.style.fontSize = "2.2rem";
                    BBdivLogoUser.style.fontFamily = "YouYuan";
                    //BBdivLogoUser.attr({ style: "height:10%;font-size:2.2rem;font-family:YouYuan" });
                    BBdivLogoUser.innerHTML = "<%=bbLiList[0][1]%>";
                BBdivLogo.appendChild(BBimgLogo);
                BBdivLogo.appendChild(BBdivLogoUser);

                var BBdivText = document.createElement("div");
                BBdivText.className = "text";
                    var BBdivTextTitle = document.createElement("div");
                    BBdivTextTitle.title = "title";
                    BBdivTextTitle.innerText = "<%=bbLiList[0][2]%>";

                    var BBdivTextTxt = document.createElement("div");
                    BBdivTextTxt.className = "txt";
                    BBdivTextTxt.innerText = "<%=bbLiList[0][3]%>";
                    var wordsHide = "<%=bbLiList[0][4]%>";
                        var BBdivTextTxtSpan1 = document.createElement("span");
                        BBdivTextTxtSpan1.id = "p" + a.toString();
                        BBdivTextTxtSpan1.innerText = "...";
                        if (wordsHide.lenth < 1) { BBdivTextTxtSpan1.style.display = "none"; }
                        var BBdivTextTxtSpan2 = document.createElement("span");
                        BBdivTextTxtSpan2.id = "txt" + a.toString();
                        BBdivTextTxtSpan2.style.display="none";
                        BBdivTextTxtSpan2.innerText = "<%=bbLiList[0][4]%>";
                    BBdivTextTxt.appendChild(BBdivTextTxtSpan1);
                    BBdivTextTxt.appendChild(BBdivTextTxtSpan2);
                
                    var BBdivTextMore = document.createElement("div");
                    BBdivTextMore.id = "TextMore";
                    BBdivTextMore.style.color = "#88B1C5";
                    BBdivTextMore.onclick = function () { more(this, a.toString()) };

                    BBdivTextMore.innerText = "全文";
                    if (wordsHide.lenth < 1) { BBdivTextMore.style.display = "none"; }

                    var imgPath = "<%=bbLiList[0][5]%>";                
                    var BBdivGallery = document.createElement("div");
                    BBdivGallery.className = "my-gallery";
                    BBdivGallery.id = "Gallery";
                    $("Gallery").attr("data-pswp-uid", "1");
                         var BBfigureGallery = document.createElement("figure");
                            var BBspanGF = document.createElement("span");
                                var BBaGFS = document.createElement("a");
                                BBaGFS.id = "aGFS";
                                BBaGFS.href = "<%=bbLiList[0][5]%>";
                                $("aGFS").attr("data-size", "670x712");
                                    var BBimgGFSA = document.createElement("img");
                                    BBimgGFSA.src = "<%=bbLiList[0][5]%>";
                                    BBimgGFSA.style = "width:80%";
                                BBaGFS.appendChild(BBimgGFSA);
                            BBspanGF.appendChild(BBaGFS);
                            BBfigureGallery.appendChild(BBspanGF);      
                    BBdivGallery.appendChild(BBfigureGallery);
                    if (imgPath.length > 0) { BBdivGallery.style.display = "none";}

                BBdivText.appendChild(BBdivTextTitle);
                BBdivText.appendChild(BBdivTextTxt);
                BBdivText.appendChild(BBdivTextMore);
                BBdivText.appendChild(BBdivGallery);
            BBdivBody.appendChild(BBdivLogo);
            BBdivBody.appendChild(BBdivText);
        BBli.appendChild(BBdivBody);
      BBul.appendChild(BBli)
    }
    cDivLi(2);

    var initPhotoSwipeFromDOM = function (gallerySelector) {

        // 解析来自DOM元素幻灯片数据（URL，标题，大小...）
        // (children of gallerySelector)
        var parseThumbnailElements = function (el) {
            var thumbElements = el.childNodes,
                numNodes = thumbElements.length,
                items = [],
                figureEl,
                linkEl,
                size,
                item,
                divEl;

            for (var i = 0; i < numNodes; i++) {

                figureEl = thumbElements[i]; // <figure> element

                // 仅包括元素节点
                if (figureEl.nodeType !== 1) {
                    continue;
                }
                divEl = figureEl.children[0];
                linkEl = divEl.children[0]; // <a> element

                size = linkEl.getAttribute('data-size').split('x');

                // 创建幻灯片对象
                item = {
                    src: linkEl.getAttribute('href'),
                    w: parseInt(size[0], 10),
                    h: parseInt(size[1], 10)
                };



                if (figureEl.children.length > 1) {
                    // <figcaption> content
                    item.title = figureEl.children[1].innerHTML;
                }

                if (linkEl.children.length > 0) {
                    // <img> 缩略图节点, 检索缩略图网址
                    item.msrc = linkEl.children[0].getAttribute('src');
                }

                item.el = figureEl; // 保存链接元素 for getThumbBoundsFn
                items.push(item);
            }

            return items;
        };

        // 查找最近的父节点
        var closest = function closest(el, fn) {
            return el && (fn(el) ? el : closest(el.parentNode, fn));
        };

        // 当用户点击缩略图触发
        var onThumbnailsClick = function (e) {
            e = e || window.event;
            e.preventDefault ? e.preventDefault() : e.returnValue = false;

            var eTarget = e.target || e.srcElement;

            // find root element of slide
            var clickedListItem = closest(eTarget, function (el) {
                return (el.tagName && el.tagName.toUpperCase() === 'FIGURE');
            });

            if (!clickedListItem) {
                return;
            }

            // find index of clicked item by looping through all child nodes
            // alternatively, you may define index via data- attribute
            var clickedGallery = clickedListItem.parentNode,
                childNodes = clickedListItem.parentNode.childNodes,
                numChildNodes = childNodes.length,
                nodeIndex = 0,
                index;

            for (var i = 0; i < numChildNodes; i++) {
                if (childNodes[i].nodeType !== 1) {
                    continue;
                }

                if (childNodes[i] === clickedListItem) {
                    index = nodeIndex;
                    break;
                }
                nodeIndex++;
            }



            if (index >= 0) {
                // open PhotoSwipe if valid index found
                openPhotoSwipe(index, clickedGallery);
            }
            return false;
        };

        // parse picture index and gallery index from URL (#&pid=1&gid=2)
        var photoswipeParseHash = function () {
            var hash = window.location.hash.substring(1),
            params = {};

            if (hash.length < 5) {
                return params;
            }

            var vars = hash.split('&');
            for (var i = 0; i < vars.length; i++) {
                if (!vars[i]) {
                    continue;
                }
                var pair = vars[i].split('=');
                if (pair.length < 2) {
                    continue;
                }
                params[pair[0]] = pair[1];
            }

            if (params.gid) {
                params.gid = parseInt(params.gid, 10);
            }

            return params;
        };

        var openPhotoSwipe = function (index, galleryElement, disableAnimation, fromURL) {
            var pswpElement = document.querySelectorAll('.pswp')[0],
                gallery,
                options,
                items;

            items = parseThumbnailElements(galleryElement);

            // 这里可以定义参数
            options = {
                barsSize: {
                    top: 100,
                    bottom: 100
                },
                fullscreenEl: false,
                shareButtons: [
                { id: 'wechat', label: '分享微信', url: '#' },
                { id: 'weibo', label: '新浪微博', url: '#' },
                { id: 'download', label: '保存图片', url: '{{raw_image_url}}', download: true }
                ],

                // define gallery index (for URL)
                galleryUID: galleryElement.getAttribute('data-pswp-uid'),

                getThumbBoundsFn: function (index) {
                    // See Options -> getThumbBoundsFn section of documentation for more info
                    var thumbnail = items[index].el.getElementsByTagName('img')[0], // find thumbnail
                        pageYScroll = window.pageYOffset || document.documentElement.scrollTop,
                        rect = thumbnail.getBoundingClientRect();

                    return { x: rect.left, y: rect.top + pageYScroll, w: rect.width };
                }

            };

            // PhotoSwipe opened from URL
            if (fromURL) {
                if (options.galleryPIDs) {
                    // parse real index when custom PIDs are used 
                    for (var j = 0; j < items.length; j++) {
                        if (items[j].pid == index) {
                            options.index = j;
                            break;
                        }
                    }
                } else {
                    // in URL indexes start from 1
                    options.index = parseInt(index, 10) - 1;
                }
            } else {
                options.index = parseInt(index, 10);
            }

            // exit if index not found
            if (isNaN(options.index)) {
                return;
            }

            if (disableAnimation) {
                options.showAnimationDuration = 0;
            }

            // Pass data to PhotoSwipe and initialize it
            gallery = new PhotoSwipe(pswpElement, PhotoSwipeUI_Default, items, options);
            gallery.init();
        };

        // loop through all gallery elements and bind events
        var galleryElements = document.querySelectorAll(gallerySelector);

        for (var i = 0, l = galleryElements.length; i < l; i++) {
            galleryElements[i].setAttribute('data-pswp-uid', i + 1);
            galleryElements[i].onclick = onThumbnailsClick;
        }

        // Parse URL and open gallery if it contains #&pid=3&gid=1
        var hashData = photoswipeParseHash();
        if (hashData.pid && hashData.gid) {
            openPhotoSwipe(hashData.pid, galleryElements[hashData.gid - 1], true, true);
        }
    };

    // execute above function
    initPhotoSwipeFromDOM('.my-gallery');

    $(".my-gallery>figure>div").each(function () {
        $(this).height($(this).width());
    });

    function more(obj, id) {
        if ($('#txt' + id).is(":hidden")) {
            $('#p' + id).hide();
            $('#txt' + id).show();
            obj.innerHTML = '收起';
        } else {
            $('#p' + id).show();
            $('#txt' + id).hide();
            obj.innerHTML = '全文';
        }
    }
</script>
</html>
