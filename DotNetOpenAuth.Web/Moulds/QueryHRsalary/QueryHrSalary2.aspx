<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryHrSalary2.aspx.cs" Inherits="DotNetOpenAuth.Web.Moulds.QueryHRsalary.QueryHrSalary2" %>

<!DOCTYPE html>
<html>
 
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>扣款合计</title>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[0]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed; border-collapse:separate;border-spacing:0px 0px;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[0]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[0]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[1]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[1]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[1]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[2]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[2]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[2]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[3]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[3]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[3]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[4]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[4]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[4]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[5]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[5]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[5]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[6]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[6]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[6]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[7]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[7]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[7]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[8]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[8]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[8]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[9]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[9]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[9]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[10]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[10]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[10]%>元</td>
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
          <p class="question"><span><%=userName%></span>：您<%=bbSalaryTime[11]%>的扣款如下</p>
          <div  class="table-list" style="padding-top:0rem; width:100%;height:80%;overflow:auto;">
		    <table style="table-layout: fixed;">
			    <thead>
				    <tr>
					    <th class="listThRight">扣款项目</th>
					    <th class="listThLeft">扣款数额</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td class="listTdRight">扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalaryKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">本次扣税:</td>
					    <td class="listTdLeft"><%=bbSalaryBCKS[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">养老个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYLGRKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医疗个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryYiLGRKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">失业个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySYGRKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金个人扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJGRKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">住房公积金贷款扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryZFGJJDKKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保公积金扣款合计:</td>
					    <td class="listTdLeft"><%=bbSalarySBGJJKKHJ[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位公积金自付部分:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWGJJZFBF[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣其它单位社保个人自付:</td>
					    <td class="listTdLeft"><%=bbSalaryDKQTDWSBGRZF[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额说明:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJESM[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">扣罚款:</td>
					    <td class="listTdLeft"><%=bbSalaryKFK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣捐款:</td>
					    <td class="listTdLeft"><%=bbSalaryDKJK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">水电费扣款:</td>
					    <td class="listTdLeft"><%=bbSalarySDFKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">工会会费代扣:</td>
					    <td class="listTdLeft"><%=bbSalaryGHHFDK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">多发工资扣回:</td>
					    <td class="listTdLeft"><%=bbSalaryDFGZKH[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">个税清算当年:</td>
					    <td class="listTdLeft"><%=bbSalaryGSQSDN[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">代扣上年个税清算:</td>
					    <td class="listTdLeft"><%=bbSalaryDKSNGSQS[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">医保清算:</td>
					    <td class="listTdLeft"><%=bbSalaryYBQS[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">社保清算:</td>
					    <td class="listTdLeft"><%=bbSalarySBQS[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">缺勤扣款:</td>
					    <td class="listTdLeft"><%=bbSalaryQQKK[11]%>元</td>
				    </tr>
				    <tr>
					    <td class="listTdRight">其他扣款金额:</td>
					    <td class="listTdLeft"><%=bbSalaryQTKKJE[11]%>元</td>
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

