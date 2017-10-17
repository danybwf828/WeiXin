<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryHrSalary.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.QueryHRsalary.QueryHrSalary" %>

<!DOCTYPE html>
<html>
 
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>薪资标准</title>
  <meta name="format-detection" content="telephone=no" />
  <meta name="apple-mobile-web-app-capable" content="yes" />
  <meta name="viewport" content="width=device-width,initial-scale=1, minimum-scale=1, maximum-scale=1,user-scalable=no" />
  <link rel="stylesheet" href="css/answerCard.css"  />
</head>
 
<body>
 
  <div >
    <div id="answer"  style="width:100%; height:100%;position:absolute;">
      <!--Q1-->
      <div class="card_cont card1">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[0]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[0]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
	  <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right;display:none">▶</a></div>
        </div>
      </div>
      <!--Q2-->
      <div class="card_cont card2">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[1]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[1]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--Q3-->
      <div class="card_cont card3">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[2]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[2]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--Q4-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[3]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[3]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--Q5-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[4]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[0]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--6-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[5]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[5]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--7-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[6]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[6]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--8-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[7]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[7]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--9-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[8]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[8]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--10-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[9]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[9]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--11-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[10]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[10]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
      <!--12-->
      <div class="card_cont">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[11]%>的薪资标准如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">工资标准项目</th>
					    <th class="listThLeft">工资标准数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">基本工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZBZ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYGZBZ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位月上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWYSFGZ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日工资标准:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRGZBZ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">岗位日上浮工资:</td>
					    <td class="listTdLeft"><%=bbSalaryGWRSFGZ[11]%>元</td>
				    </tr>				    
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left;display:none">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
    </div>
  </div> 
  <script src="js/jquery-2.1.1.min.js"></script>
  <script src="js/hovertreeanswer.js"></script>
  <script>
      $(function () {
          $("#answer").answerSheet({});
      })
  </script>
</body>
</html>

