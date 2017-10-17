<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryHrSalary1.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.QueryHRsalary.QueryHrSalary1" %>

<!DOCTYPE html>
<html> 
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>总薪资查询</title>
  <meta name="format-detection" content="telephone=no" />
  <meta name="apple-mobile-web-app-capable" content="yes" />
  <meta name="viewport" content="width=device-width,initial-scale=1, minimum-scale=1, maximum-scale=1,user-scalable=no" />
  <link rel="stylesheet" href="css/answerCard.css"  />
  <style>
      table {
          border: 0;
          border-collapse: collapse;
      }
      td {
          font: normal 12px/17px Arial;
          padding: 2px;
          width: 100px;
      }
      th {
          font: bold 12px/17px Arial;
          text-align: left;
          padding: 4px;
          border- bottom:1px solid #333;
          width: 100px;
      }

      .parent {
          background: #FFF38F;
          cursor: pointer;
      }
      .odd {
          background: #FFFFEE;
      }
      .selected {
          background: #FFC125;
          color: #fff;
      }
  </style>
  <script src="js/jquery-2.1.1.min.js"></script>
  <script src="js/hovertreeanswer.js"></script>
  <script>
      $(function () {
          $("#answer").answerSheet({});
      })
      $(function () {
          $('tr.parent').click(function () {   // 获取所谓的父行
              $(this)
                  //.toggleClass("selected")   // 添加/删除高亮
                  .siblings('.child_' + this.id).toggle();  // 隐藏/显示所谓的子行
          }).click();
      })
  </script>
</head> 
<body> 
  <div >
    <div id="answer"  style="width:100%; height:100%;position:absolute;">
      <!--Q1-->
      <div class="card_cont card1">
        <div class="card"">
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[0]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[0]%>元</td>
				    </tr>
				    <tr class="parent" id="row_00">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[0]%>元</td>
				    </tr>
				    <tr class="child_row_00" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[0]%>元</td></tr>
				    <tr class="child_row_00" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[0]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[0]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[0]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[0]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[1]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[1]%>元</td>
				    </tr>
				    <tr class="parent" id="row_01">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[1]%>元</td>
				    </tr>
				    <tr class="child_row_01" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[1]%>元</td></tr>
				    <tr class="child_row_01" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[1]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[1]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[1]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[1]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[2]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[2]%>元</td>
				    </tr>
				    <tr class="parent" id="row_02">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[2]%>元</td>
				    </tr>
				    <tr class="child_row_02" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[2]%>元</td></tr>
				    <tr class="child_row_02" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[2]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[2]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[2]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[2]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[3]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[3]%>元</td>
				    </tr>
				    <tr class="parent" id="row_03">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[3]%>元</td>
				    </tr>
				    <tr class="child_row_03" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[3]%>元</td></tr>
				    <tr class="child_row_03" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[3]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[3]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[3]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[3]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[4]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[4]%>元</td>
				    </tr>
				    <tr class="parent" id="row_04">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[4]%>元</td>
				    </tr>
				    <tr class="child_row_04" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[4]%>元</td></tr>
				    <tr class="child_row_04" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[4]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[4]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[4]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[4]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[5]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[5]%>元</td>
				    </tr>
				    <tr class="parent" id="row_05">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[5]%>元</td>
				    </tr>
				    <tr class="child_row_05" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[5]%>元</td></tr>
				    <tr class="child_row_05" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[5]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[5]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[5]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[5]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[6]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[6]%>元</td>
				    </tr>
				    <tr class="parent" id="row_06">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[6]%>元</td>
				    </tr>
				    <tr class="child_row_06" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[6]%>元</td></tr>
				    <tr class="child_row_06" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[6]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[6]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[6]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[6]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[7]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[7]%>元</td>
				    </tr>
				    <tr class="parent" id="row_07">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[7]%>元</td>
				    </tr>
				    <tr class="child_row_07" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[7]%>元</td></tr>
				    <tr class="child_row_07" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[7]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[7]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[7]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[7]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[8]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[8]%>元</td>
				    </tr>
				    <tr class="parent" id="row_08">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[8]%>元</td>
				    </tr>
				    <tr class="child_row_08" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[8]%>元</td></tr>
				    <tr class="child_row_08" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[8]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[8]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[8]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[8]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[9]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[9]%>元</td>
				    </tr>
				    <tr class="parent" id="row_09">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[9]%>元</td>
				    </tr>
				    <tr class="child_row_09" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[9]%>元</td></tr>
				    <tr class="child_row_09" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[9]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[9]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[9]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[9]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[10]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[10]%>元</td>
				    </tr>
				    <tr class="parent" id="row_10">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[10]%>元</td>
				    </tr>
				    <tr class="child_row_10" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[10]%>元</td></tr>
				    <tr class="child_row_10" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[10]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[10]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[10]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[10]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[11]%>的总薪资如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">薪资项目</th>
					    <th class="listThLeft">薪资数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">应发合计:</td>
					    <td class="listTdLeft"><%=bbSalaryYF[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">实发合计:</td>
					    <td class="listTdLeft"><%=bbSalarySF[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight" style="color:red">各类小计如下:</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryGZ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">假期工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJQGZ[11]%>元</td>
				    </tr>
				    <tr class="parent" id="row_11">
					    <td class="listTdRight">津贴小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJT[11]%>元</td>
				    </tr>
				    <tr class="child_row_11" style="background:#E0FFFF;"><td class="listTdRight">-岗位津贴</td><td class="listTdLeft"><%=bbSalaryGWJT[11]%>元</td></tr>
				    <tr class="child_row_11" style="background:#E0FFFF;"><td class="listTdRight">-异地津贴</td><td class="listTdLeft"><%=bbSalaryYDJT[11]%>元</td></tr>
				    <tr>
					    <td class="listTdRight">加班工资小计:</td>
					    <td class="listTdLeft"><%=bbSalaryJBGZ[11]%>元</td>
				    </tr>
<%--				    <tr>
					    <td class="listTdRight">考核额度:</td>
					    <td class="listTdLeft"><%=bbSalaryKHED[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">考核工资:</td>
					    <td class="listTdLeft"><%=bbSalaryKHGZ[11]%>元</td>
				    </tr>--%>
				    <tr>
					    <td class="listTdRight">奖金性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryJJXSR[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">福利性收入合计:</td>
					    <td class="listTdLeft"><%=bbSalaryFLXSR[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他人工成本小计:</td>
					    <td class="listTdLeft"><%=bbSalaryQTRGCB[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(本年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLBND[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">上级单位奖励(上年度):</td>
					    <td class="listTdLeft"><%=bbSalarySJDWJLSND[11]%>元</td>
				    </tr>
			    </tbody>
		    </table>
    	  </div>
          <div class="card_bottom"><a class="forward" style="float:left;display:none">◀</a><a class="prev" style="float:right">▶</a></div>
        </div>
      </div>
    </div>
  </div> 
</body>
</html>

