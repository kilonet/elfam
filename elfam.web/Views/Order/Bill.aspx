<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<elfam.web.ViewModels.Order.BillViewModel>" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml"><head>
<title>Elfam.ru - Банковский перевод</title>
<style>
html
{
	font-size: 100.1%;
}
body
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 0.75em;
	font-weight: normal;
	letter-spacing: normal;
	text-transform: none;
	word-spacing: normal;
	width: 100%;
	height: auto !important;
	height: 100%;
	min-height: 100%;
	background-color: white;
}
p
{
	margin: 0.5em 0px 1em 0px;
}
.clear
{
	clear: both;
	font-size: 0;
	line-height: 0;
	height: 0;
	border: none;
	float: none;
}
.notShow
{
	visibility: hidden;
}
div.wrapper
{
	width: 100%;
}
div.wrapper1000
{
	min-width: 1000px; /* Opera & FireFox & Internet Explorer 7.0 */
}
div.wrapper600
{
	min-width: 600px; /* Opera & FireFox & Internet Explorer 7.0 */
}
div.pageCenter
{
	padding: 0px 0px 0px 200px;
}
div.pageContainer
{
	float: left;
	width: 100%;
	border-left: solid 200px transparent;
	margin-left: -200px;
	display: inline; /* So IE plays nice */
}
* html div.pageContainer
{
	border-left: solid 200px #fff;
}
div.pageCenterNoLeft
{
	padding: 0px 0px 0px 20px;
}
div.pageCenterNoLeft div.pageContainer
{
	border-left: 0px;
	margin-left: 0px;
}
div.pageLeft
{
	float: left;
	width: 200px;
	margin-left: -200px;
	position: relative;
	overflow: hidden; /* This chops off any overhanging divs */
}
div.pageContent
{
	float: left;
	width: 100%;
	margin-right: -100%;
	position: relative;
	overflow: hidden; /* This chops off any overhanging divs */
}
div.pageContent div.pageRight
{
	float:right;
	width:0;
	padding-top: 15px;
}
div.pageHeader, div.pageFooter
{
	clear: both;
}
div.adminBlock
{
	padding: 5px;
	position: absolute;
	top: 0px;
	left: 0px;
}

table.PageRow
{
	width: 100%;
	margin: 0px;
	border: 0px;
	padding: 0px;
}
table.PageRow td.LeftCell
{
	width: 200px;
	width: expression(this.clientWidth < 200?        '200px' : '' ); /* Internet Explorer <= 6.0 */
	min-width: 200px;
}
td.Width20
{
	width: 20%;
}
td.Width25
{
	width: 25%;
}
td.Width33
{
	width: 33%;
}
td.Width40
{
	width: 40%;
}
td.Width50
{
	width: 50%;
}
td.Width60
{
	width: 60%;
}
td.Width67
{
	width: 67%;
}
td.Width75
{
	width: 75%;
}
td.Width80
{
	width: 80%;
}

.box
{
	margin-right: 10px;
}
div.pageContent .PageModule
{
	margin: 2px 10px 6px 0px;
}
div.pageLeft .PageModule
{
	margin: 0px 20px;
}
.PageModule div.breadcrumbs, .PageModule div.detail
{
	margin-right: -10px;
}
table.detail
{
	width: 100%;
	margin: 0px;
	padding: 0px;
	border: 0px;
}

select.width96
{
	width: 96%;
}
table.saleblock_list
{
	float: right;
	margin-left: 5px;
	margin-right: 3px;
	background-color: #ffffff;
}

form
{
	margin: 0px;
}
table
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1em; /*     border-collapse: collapse;     border-top-style: none;     border-right-style: none;     border-left-style: none;     border-bottom-style: none; */
}
th, thead, tfoot
{
	color: #006699;
}
h1
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1.5em;
	font-weight: 500;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
h2
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1.2em;
	font-weight: 500;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
h3
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1.1em;
	font-weight: 500;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
h4
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1em;
	font-weight: 700;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
h5
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 0.9em;
	font-weight: 700;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
h6
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 0.8em;
	font-weight: 700;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	margin-bottom: 0px;
}
thead, tfoot
{
	font-size: 1em;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	font-family: Arial, Helvetica, sans-serif;
}
th
{
	vertical-align: baseline;
	font-size: 1em;
	font-weight: bold;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	font-family: Arial, Helvetica, sans-serif;
}
a
{
	color: #000000;
	text-decoration: underline;
}
a:hover
{
	text-decoration: none;
}
img
{
	border: solid 0px #1a5fa1;
}
img.border
{
	border: solid 1px #1a5fa1;
}
img.help_big
{
	margin-right: 4px;
	vertical-align: text-top;
}
img.left
{
	float: left;
	margin-bottom: 3px;
	margin-right: 5px;
}
input, select, option, textarea
{
	font-size: 100.1%;
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
}
input.button
{
	font-size: 0.9em;
	font-weight: 700;
}
input.maxWidth, textarea.maxWidth
{
	width: 95%;
}
select.maxWidth
{
	width: 99%;
}
select.maxText
{
	width: 100%;
}
input.maxText
{
	width: 99.9%;
	_width: 98.5%; *width:98.5%;
}
textarea.maxText
{
	width: 100%;
	_width: 98.5%; *width:98.5%;
}
html:root input.maxText, html:root textarea.maxText
{
	width: 98.5%;
}

.fixed
{
	font-size: 8pt;
}
.micro
{
	font-size: 0.85em;
}
small
{
	font-size: 0.9em;
}
.microsberblank
{
	font-size: 0.8em;
	font-family: Times New Roman;
}
.smallsberblank
{
	font-size: 0.9em;
	font-family: Times New Roman;
}
.middlesberblank
{
	font-size: 1em;
	font-family: Times New Roman;
}
small.sbBlankLine, 
small.microsberblank,
small.middlesberblank,
small.smallsberblank,
small.sbBlankBlock,
div.sbBlankBlock
{
	display:block; float:left;
}
.sbBlankLine
{
	border-bottom-color:Black; border-bottom-style:solid; border-bottom-width: 1px;
}
.small
{
	font-size: 0.9em;
}
.smallBold
{
	font-size: 0.9em;
	font-weight: 700;
}
.smaller
{
	font-size: 0.95em;
}
.bigger
{
	font-size: 1.05em;
}
big
{
	font-size: 1.1em;
	font-weight: 700;
}
.big1
{
	font-size: 1.2em;
	font-weight: 700;
}
.big2
{
	font-size: 1.5em;
	font-weight: 500;
}
.big3
{
	font-size: 2.5em;
	font-weight: 500;
}
a.help_big
{
	font-family: Verdana;
	font-size: 12px;
	font-weight: normal;
	color: #000000;
	text-decoration: none;
	border-bottom: 1px dashed #000000;
}

.detail h1
{
	font-size: 1.8em;
}

.label0
{
	font-size: 0.8em;
}
.label1
{
	font-size: 1.0em;
}
.label2
{
	font-size: 1.2em;
}
.lablel3
{
	font-size: 1.4em;
}
.label4
{
	font-size: 1.6em;
}
.label5
{
	font-size: 1.8em;
}
.label6
{
	font-size: 2.0em;
}
.label7
{
	font-size: 2.2em;
}
.label8
{
	font-size: 2.4em;
}
.label9
{
	font-size: 2.6em;
}
.label10
{
	font-size: 2.8em;
}
.label11
{
	font-size: 3.0em;
}
.label12
{
	font-size: 3.2em;
}
.label13
{
	font-size: 3.4em;
}
.label14
{
	font-size: 3.6em;
}
.label15
{
	font-size: 3.8em;
}
.label16
{
	font-size: 4.0em;
}
.label17
{
	font-size: 4.2em;
}
.label18
{
	font-size: 4.4em;
}
.label19
{
	font-size: 4.6em;
}
.label20
{
	font-size: 4.8em;
}


.padd
{
	padding-left: 5px;
	padding-right: 5px;
}
.padd_left
{
	padding-left: 5px;
}
.padd_right
{
	padding-right: 5px;
}
.vertpadd
{
	padding-top: 5px;
	padding-bottom: 5px;
}
.vertpaddText
{
	padding-top: 5px;
	padding-bottom: 5px;
	text-align: justify;
	text-indent: 15px;
}
.vertpaddTextWithoutIndent
{
	padding-top: 5px;
	padding-bottom: 5px;
	text-align: justify;
}
.padd15
{
	padding-left: 15px;
	padding-right: 15px;
}
.padd15_5
{
	padding-left: 15px;
	padding-right: 15px;
	padding-top: 5px;
	padding-bottom: 5px;
}
.padd10_5
{
	padding-left: 10px;
	padding-right: 10px;
	padding-top: 5px;
	padding-bottom: 5px;
}
.padd5_2
{
	padding-left: 5px;
	padding-right: 5px;
	padding-top: 2px;
	padding-bottom: 2px;
}
.padd0_2
{
	padding-top: 2px;
	padding-bottom: 2px;
}
.padd20
{
	padding-left: 20px;
	padding-right: 20px;
}
.padd20_5
{
	padding-left: 20px;
	padding-right: 20px;
	padding-top: 5px;
	padding-bottom: 5px;
}
.detail_leftpadd
{
	padding-left: 10px;
	padding-right: 5px;
}
.detail_picture
{
	width: 1%;
	padding-right: 5px;
	text-align: center;
}
.detail_leftcell
{
	padding-left: 10px;
	padding-right: 5px;
}
.detail_centralcell
{
	padding-right: 10px;
}
.detail_2cell
{
	padding-right: 10px;
}
.detail_leftcol
{
	padding-right: 5px;
	padding-top: 5px;
	padding-bottom: 5px;
}
.detail_rightcol
{
	padding-top: 5px;
	padding-bottom: 5px;
}
.description_vertpadd
{
	padding-top: 5px;
	padding-bottom: 15px;
}
.sale
{
	background-color: #F6C646;
}
.nowrap
{
	white-space: nowrap;
}
.maxWidth
{
	width: 100%;
}
.minWidth
{
	width: 1%;
}
a.nolink
{
	text-decoration: none;
}
a.nolink:hover
{
	text-decoration: underline;
}
a.nolinkb
{
	text-decoration: none;
	font-weight: bold;
}
a.nolinkb:hover
{
	text-decoration: underline;
}
ol
{
	margin: 5px 0px 5px 20px;
	padding: 0px 0px 0px 10px;
}
ol li
{
	margin: 4px 0px;
	padding: 0px;
}
ul
{
	margin: 5px 0px;
	padding: 0px;
	list-style-type: none;
}
ul li
{
	margin: 4px 0px;
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/common/bullet_filled_small.gif) no-repeat 0.3em 0.6em;
}
ul.circle li
{
	background: url(/graphics/ozon/skin/common/bullet_empty.gif) no-repeat 0.1em 0.6em;
}
ul.filled li
{
	background: url(/graphics/ozon/skin/common/bullet_filled.gif) no-repeat 0.1em 0.6em;
}
ul.circle2 li
{
	background: url(/graphics/ozon/skin/common/bullet2_empty.gif) no-repeat 0.1em 0.6em;
}
ul.none li
{
	background: none;
}
span.section_new
{
	display: block;
	padding: 1px 26px 1px 0px;
	line-height: 14px;
	background: url(/graphics/ozon/icon_new.gif) no-repeat 100px top;
}
span.section_new1
{
	padding: 1px 28px 1px 0px; *padding-right:25px;
line-height:14px;
background:url(/graphics/ozon/icon_new.gif)no-repeatrighttop;
}
span.section_sale
{
	padding: 1px 29px 1px 0px;
	line-height: 14px;
	background: url(/graphics/ozon/icon_sale.gif) no-repeat right top;
}
span.section_gift
{
	padding: 0px 25px 0px 0px;
	line-height: 17px;
	background: url(/graphics/action/ny/gift.gif) no-repeat right top;
}
span.section_heart
{
	padding: 0px 25px 0px 0px;
	line-height: 14px;
	background: url(/graphics/action/heart/heart.gif) no-repeat right 0.1em;
}
span.section_orientalmkt
{
	padding: 0px 25px 0px 0px;
	line-height: 14px;
	background: url(/graphics/action/orientalmkt/menu_icon.gif) no-repeat right 0.1em;
}
span.section_ny
{
	padding: 0px 14px 0px 0px;
	line-height: 12px;
	background: url(/graphics/action/ny/ic1_ny.gif) no-repeat right top;
}
span.section_salon
{
	padding: 1px 25px 1px 0px;
	line-height: 13px;
	background: url(/graphics/action/salon/icon.gif) no-repeat right top;
}
span.section_travel
{
	padding: 1px 35px 1px 0px;
	line-height: 13px;
	background: url(/graphics/travel/menu_travel.gif) no-repeat right 0.1em;
}
span.section_travel_beta
{
	padding: 0px 55px 0px 0px;
	line-height: 12px;
	background: url(/graphics/travel/menu_travel_beta.gif) no-repeat right 0.1em;
}
span.section_sa
{
	padding: 1px 26px 1px 0px;
	line-height: 14px;
	background: url(/graphics/action/stella/icon_sa.gif) no-repeat right top;
}
.gray
{
	color: #686868;
}
.searchText
{
	color: #000000;
}
.highlight
{
	background-color: #BDE3FF;
	color: #000000;
	white-space: nowrap;
}
.searchResult_block
{
	margin-bottom: 10px;
}
.searchResult_block a
{
	text-decoration: none;
}
.searchResult_block a.skin_link
{
	text-decoration: underline;
}
.searchResult_block a:hover
{
	text-decoration: underline;
}
.searchResult_block .highlight
{
	background-color: Transparent;
	font-weight: 700;
}
div.searchResult_ingroup ul.circle2 li
{
	margin-bottom: 7px;
}
table.searchResult_table
{
	width: auto;
	padding: 0px;
	margin: 0px;
	border: none;
}
table.searchResult_table td.searchResult_cell
{
	width: 33%;
}
div.searchResult_moreperson
{
	float: right;
	font-size: 0.95em;
	white-space: nowrap;
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/2D83C2/bullet_filled.gif) no-repeat 0.2em 0.4em;
	margin-top: 2px;
}
div.searchResult_moreperson a
{
	text-decoration: underline;
}
div.searchResult_moreperson a:hover
{
	text-decoration: none;
}
big.saleblock_price
{
	font-size: 1.8em;
	font-weight: 500;
}
span.asterisk
{
	font-size: 0.9em;
}
div.comment
{
	font-size: 0.8em;
	color: #666666;
}


















div#header td.leftcell
{
	width: 200px;
	min-width: 200px;
	padding: 0px;
}
td.leftcell
{
	width: 160px;
	padding: 0px 20px 0px 20px;
}
td.rightcell
{
	width: 20%;
	padding-right: 10px;
}
table.central
{
	width: 100%;
	min-width: 800px;
	padding: 0px;
}
td.central_4cell
{
	width: 80%;
	min-width: 640px;
}
td.central_leftcell
{
	width: 40%;
	min-width: 310px;
	padding-right: 10px;
}
td.central_rightcell
{
	width: 40%;
	min-width: 310px;
	padding-left: 10px;
}
table.header_line
{
	width: 100%;
	margin: 0px 0px 5px 0px;
	padding: 0px;
	border: 0px;
}
div.header_line_left
{
	margin-top: 1px;
	width: 100%;
	height: 7px;
	line-height: 7px;
	background: #2D83C2 url(/graphics/ozon/skin/2D83C2/header_line_left.gif) no-repeat left top;
}
div.header_line_right
{
	margin-top: 1px;
	width: 100%;
	height: 7px;
	line-height: 7px;
	background: #2D83C2 url(/graphics/ozon/skin/2D83C2/header_line_right.gif) no-repeat right top;
}
.root_text
{
	color: #2D83C2;
}
a.root_link
{
	color: #2D83C2;
}
.skin_text
{
	color: #2D83C2;
}
a.skin_link
{
	color: #2D83C2;
}

.frame
{
	position: relative;
}
div.frame_tl
{
	position: absolute;
	width: 8px;
	height: 8px;
}
div.frame_tr
{
	position: absolute;
	width: 8px;
	height: 8px;
}
div.frame_bl
{
	position: absolute;
	width: 8px;
	height: 8px;
}
div.frame_br
{
	position: absolute;
	width: 8px;
	height: 8px;
}
* html div.frame_br
{
	display: none;
}

.frame_dashed
{
	border: dashed 1px #b2b2b2;
}
.frame_dashed div.frame_tl
{
	left: -1px;
	top: -1px;
	background: url(/graphics/ozon/skin/common/frame_dashed_tl.gif) no-repeat left top;
}
* html div.frame_dashed div.frame_tl
{
	top: 0px;
}
.frame_dashed div.frame_tr
{
	right: -1px;
	top: -1px;
	background: url(/graphics/ozon/skin/common/frame_dashed_tr.gif) no-repeat right top;
}
.frame_dashed div.frame_bl
{
	left: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/skin/common/frame_dashed_bl.gif) no-repeat left bottom;
}
.frame_dashed div.frame_br
{
	right: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/skin/common/frame_dashed_br.gif) no-repeat right bottom;
}
.frame_dashed div.frame_content15
{
	padding: 15px 15px 15px 15px;
	font-size: 1em;
	height: 400px;
}

.frame_dashed_blue
{
	border: dashed 1px #2D83C2;
}
.frame_dashed_blue div.frame_tl
{
	left: -1px;
	top: -1px;
	background: url(/graphics/ozon/skin/2D83C2/frame_dashed_tl.gif) no-repeat left top;
}
* html div.frame_dashed_blue div.frame_tl
{
	top: 0px;
}
.frame_dashed_blue div.frame_br
{
	right: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/skin/2D83C2/frame_dashed_br.gif) no-repeat right bottom;
}

.frame_dashed_orange
{
	border: dashed 1px #FF6600;
}
.frame_dashed_orange div.frame_tl
{
	left: -1px;
	top: -1px;
	background: url(/graphics/ozon/skin/FF6600/frame_dashed_tl.gif) no-repeat left top;
}
* html div.frame_dashed_orange div.frame_tl
{
	top: 0px;
}
.frame_dashed_orange div.frame_br
{
	right: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/skin/FF6600/frame_dashed_br.gif) no-repeat right bottom;
}

.frame_solid
{
	border: solid 1px #2D83C2;
}
.frame_solid div.frame_tl
{
	left: -1px;
	top: -1px;
	background: url(/graphics/ozon/skin/2D83C2/frame_solid_tl.gif) no-repeat left top;
}
* html div.frame_solid div.frame_tl
{
	top: 0px;
}
.frame_solid div.frame_br
{
	right: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/skin/2D83C2/frame_solid_br.gif) no-repeat right bottom;
}
.frame_solid_grey
{
	border: solid 1px #b7b7b7;
}
.frame_solid_grey div.frame_tl
{
	left: -1px;
	top: -1px;
	background: url(/graphics/ozon/ticket/corner_left.gif) no-repeat left top;
}
* html div.frame_solid_grey div.frame_tl
{
	top: 0px;
}
.frame_solid_grey div.frame_br
{
	right: -1px;
	bottom: -1px;
	background: url(/graphics/ozon/ticket/corner_right.gif) no-repeat right bottom;
}
.frame_filled
{
	background-color: #2D83C2;
}
.frame_filled div.frame_tl
{
	top: 0px;
	left: 0px;
	background: url(/graphics/ozon/skin/2D83C2/frame_filled_tl.gif) no-repeat left top;
}
.frame_filled div.frame_bl
{
	bottom: 0px;
	left: 0px;
	background: url(/graphics/ozon/skin/2D83C2/frame_filled_bl.gif) no-repeat left bottom;
}
.frame_filled div.frame_br
{
	bottom: 0px;
	right: 0px;
	background: url(/graphics/ozon/skin/2D83C2/frame_filled_br.gif) no-repeat right bottom;
}

.frame_invert_filled
{
	background-color: #FFFFFF;
}
.frame_invert_filled div.frame_tl
{
	left: 0px;
	top: 0px;
	background: url(/graphics/ozon/skin/2D83C2/frame_invert_filled_tl.gif) no-repeat left top;
}
.frame_invert_filled div.frame_br
{
	bottom: 0px;
	right: 0px;
	background: url(/graphics/ozon/skin/2D83C2/frame_invert_filled_br.gif) no-repeat right bottom;
}

div.frame_content
{
	padding: 5px 9px 7px 9px;
}
div.frame_leftcell
{
	padding: 5px 9px 7px 9px;
}
div.frame_tagcloud
{
	padding: 5px 5px 7px 9px;
}

.page_cell
{
	padding-top: 2px;
	padding-bottom: 6px;
}
.page_block
{
	margin-bottom: 18px;
}

#menu
{
	padding-top: 1px;
}
#menu a
{
	text-decoration: none;
}
#menu a:hover
{
	text-decoration: underline;
}
#menu div.returnToShop
{
	margin: 7px 0px;
	font-size: 1em;
	padding: 0px 0px 0px 15px;
	background: url(/graphics/ozon/c2c/icon_menu.gif) no-repeat 3px center;
}
#menu div.returnToShop a
{
	color: #000000;
	text-decoration: underline;
}
#menu div.returnToShop a:hover
{
	text-decoration: none;
}
div.group
{
	margin: 7px 0px;
	font-size: 0.9em;
	font-weight: 700;
}
div.group a
{
	color: #2D83C2;
}
div.group_sections
{
	margin: 2px 0px;
}
div.section
{
	margin: 5px 0px;
	font-size: 0.9em;
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/common/bullet_empty.gif) no-repeat 0.1em 0.4em;
}
div.section_item_active div.section
{
	font-weight: 700;
	background: url(/graphics/ozon/skin/common/bullet_filled.gif) no-repeat 0.1em 0.4em;
}
div.section_childs
{
	margin: 1px 0px;
	margin-left: 10px;
}
div.child
{
	margin: 3px 0px;
}
div.child_item_active div.child
{
	font-weight: 700;
}
div.child_catalogs
{
	margin-left: 5px;
}
div.child_catalogs div.line
{
	height: 1px;
	line-height: 1px;
	background-color: #000000;
}
div.catalog
{
	margin: 3px 0px;
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/common/bullet_empty_small.gif) no-repeat 0.3em 0.6em;
}
div.catalog_item_active div.catalog
{
	font-weight: 700;
	background: url(/graphics/ozon/skin/2D83C2/bullet_filled_small.gif) no-repeat 0.3em 0.6em;
}
div.catalog_item_active div.catalog a
{
	color: #2D83C2;
}
div.group_magazin
{
	margin: 15px 0px 7px 0px;
	font-size: 0.9em;
	font-weight: 700;
}
div.group_magazin a
{
	color: #2D83C2;
}

#minicart a
{
	color: #FFFFFF;
}
div.frame_minicart
{
	width: auto;
	height: auto;
	padding: 0px 5px 2px 5px;
}
table.minicart
{
	color: #FFFFFF;
}

div.news_block a
{
	text-decoration: none;
}
div.news_block a:hover
{
	text-decoration: underline;
}

#mynavigator div.addpage
{
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/common/addpage.gif) no-repeat 0.1em 0.4em;
}

#search a
{
	color: #FFFFFF;
}
div.frame_search
{
	padding: 5px 0px 7px 0px;
}
table.search_table td.search_cell
{
	height: 80px;
}
div.searchForm
{
	padding-left: 10px;
	padding-right: 10px;
}
div.searchForm input 
{
	margin: 0px;
}
div.searchForm td.searchGroup input 
{
	margin-right: 4px;
}
td.searchButton
{
	width: 80px;
	padding-left: 10px;
}
td.searchGroup
{
	color: #FFFFFF;
	font-size: 0.9em;
	line-height: 20px;
	height: 20px;
}
td.searchKeyboard
{
	padding-right: 1px;
}
td.search_help_cell
{
	width: 160px;
	text-align: right;
	padding-right: 10px;
}
table.search_table table.search_help_block
{
	font-size: 0.9em;
	float: right;
	height: 100%;
	margin: 0px;
	padding: 0px;
	border: 0px;
	text-align: left;
}
table.search_table table.search_my_block
{
	font-size: 0.75em;
	font-weight: bold;
	height: 60px;
	margin: 0px;
	padding: 0px;
	border: 0px;
	width: 100%;
}
#search div.frame_invert_filled div.frame_content
{
	padding: 5px 4px 7px 9px;
}
#search table.search_my_block a
{
	color: #2D83C2;
	text-decoration: none;
}
#search table.search_my_block a:hover
{
	text-decoration: underline;
}
table.search_my_block td
{
	vertical-align: middle;
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/2D83C2/bullet_filled.gif) no-repeat left center;
	height: 30px;
}
table.search_my_block td.myCart
{
	vertical-align: middle;
	padding: 0px 0px 0px 27px;
	background: url(/graphics/ozon/skin/2D83C2/3.gif) no-repeat 0px center;
}
table.search_my_block td.myOrder
{
	vertical-align: middle;
	padding: 0px 0px 0px 32px;
	background: url(/graphics/ozon/skin/2D83C2/2.gif) no-repeat 5px center;
}
table.search_my_block td.myOzon
{
	vertical-align: middle;
	padding: 0px 0px 0px 32px;
	background: url(/graphics/ozon/skin/2D83C2/1.gif) no-repeat 5px center;
}
table.search_my_block td.myPoints
{
	vertical-align: middle;
	padding: 0px 0px 0px 27px;
	background: url(/graphics/ozon/skin/myPointsIcon.gif) no-repeat 0px center;
}
.page_subheading
{
	font-size: 0.9em;
	color: #666666;
}
div.searchLogo
{
	height: 36px;
	max-height: 36px;
	overflow: hidden;
	padding-top: 6px;
}

table.itemrow
{
	width: 100%;
	margin: 0px;
	padding: 0px;
	border: 0px;
}
table.itemrow td.itemcell
{
	border-bottom: 0px;
}
table.itemrow td.itemfooter
{
	border-right: 0px;
	border-bottom: 0px;
	border-left: 0px;
}
table.itemrow div.itemfooter
{
	position: relative;
}
div.itemfooter div.frame_br
{
	right: 0px;
	bottom: 1px;
}
html:first-child div.itemfooter div.frame_br
{
	right: -1px;
	bottom: 1px;
}

td.itemcell div.item_pict
{
	position: relative;
}
.item_pict div.item_look
{
	position: relative;
	bottom: 8px;
}
div.item_pict div.specialprice_splash
{
	position: absolute;
	top: 50%;
	left: 50%;
	margin-top: -21px;
	margin-left: -69px;
}
div.item_pict div.specialprice_splash2
{
	position: absolute;
	top: 50%;
	left: 50%;
	margin-top: -7px;
	margin-left: -69px;
}
table.itemrow td div.item_detail
{
	padding: 2px 0px 5px 0px;
}
table.itemrow td div.specialprice_tips
{
	position: relative;
	width: 100%;
	left: 0px;
	bottom: 0px;
}
table.itemrow td div.specialprice_tips div
{
	background-color: #FF6600;
	margin: 1px;
	padding: 3px 9px 3px 9px;
	text-align: center;
	color: #ffffff;
	font-size: 0.8em;
	font-weight: 700;
}
table.itemrow td div.item_title
{
	margin-bottom: 10px;
}

div.maincatalog_block a
{
	color: #2F2F2F;
	text-decoration: none;
}
div.maincatalog_block a:hover
{
	text-decoration: underline;
}
div.maincatalog_block .title
{
	color: #2F2F2F;
	font-size: 1.1em;
	font-weight: 700;
}
div.maincatalog_block table.subcatalog_block, div.maincatalog_block table.othercatalog_block
{
	width: auto;
}
div.maincatalog_block table.subcatalog_block td.subcatalog
{
	padding: 0px 0px 5px 0px;
}
div.maincatalog_block table.subcatalog_block td.spacer
{
	padding-left: 15px;
}
table.subcatalog_block td.spacer img
{
	width: 5px;
}
table.subcatalog_block td.subcatalog div.subcatalog
{
	padding: 0px 0px 0px 10px;
	background: url(/graphics/ozon/skin/common/bullet2_empty.gif) no-repeat 0.1em 0.6em;
}
table.subcatalog_block div.subcatalog div.name
{
	font-size: 1.1em;
	font-weight: bold;
	color: #2f2f2f;
	padding-bottom: 1px;
}
table.subcatalog_block div.subcatalog div.childs
{
	font-size: 0.9em;
}
div.maincatalog_block table.othercatalog_block
{
	margin-top: 5px;
}
div.maincatalog_block table.othercatalog_block td.title
{
	padding: 0px 0px 5px 0px;
}
div.maincatalog_block table.othercatalog_block td.section
{
	font-size: 1.1em;
}
div.maincatalog_block table.othercatalog_block td.spacer
{
	padding: 0px 5px;
}
div.maincatalog_block table.othercatalog_block td.links
{
	width: 99%;
	font-size: 0.9em;
}
td.detail_delim
{
	padding-top: 10px;
	border-bottom: solid 1px #2D83C2;
}
div.detail_delim
{
	padding-top: 10px;
	border-bottom: solid 1px #2D83C2;
}
div.magazine_otherreview_left
{
	width: 45%;
	clear: left;
}
div.magazine_otherreview_right
{
	width: 45%;
	clear: right;
}
table.minidetail
{
	width: 100%;
	margin: 0px;
	padding: 0px;
	border: 0px;
	text-align: left;
}
table.minidetail td.minidetail_body
{
	width: 100%;
}
.textForPersonalRecomendation
{
	color: black;
	text-decoration: underline;
}
.textForPersonalRecomendationBlue
{
	color: #2D83C2;
	text-decoration: underline;
}

/* Скин FF6600 */
.skin_FF6600 .skin_text
{
	color: #FF6600;
}
.skin_FF6600 a.skin_link:link
{
	color: #FF6600;
}
.skin_FF6600 a.skin_link:visited
{
	color: #FF6600;
}
.skin_FF6600 a.skin_link:hover
{
	color: #FF6600;
}
.skin_FF6600 div.catalog_item_active div.catalog a
{
	color: #FF6600;
}
/* Скин 2D83C2 */
.skin_2D83C2 div.header_line_left
{
	background: #2D83C2 url(/graphics/ozon/skin/2D83C2/header_line_left.gif) no-repeat left top;
}
.skin_2D83C2 div.header_line_right
{
	background: #2D83C2 url(/graphics/ozon/skin/2D83C2/header_line_right.gif) no-repeat right top;
}
.skin_2D83C2 .skin_text
{
	color: #2D83C2;
}
.skin_2D83C2 a.skin_link:link
{
	color: #2D83C2;
}
.skin_2D83C2 a.skin_link:visited
{
	color: #2D83C2;
}
.skin_2D83C2 a.skin_link:hover
{
	color: #2D83C2;
}
.skin_2D83C2 div.frame_solid
{
	border: solid 1px #2D83C2;
}
.skin_2D83C2 div.frame_solid div.frame_tl
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_solid_tl.gif);
}
.skin_2D83C2 div.frame_solid div.frame_br
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_solid_br.gif);
}
.skin_2D83C2 div.frame_filled
{
	background-color: #2D83C2;
}
.skin_2D83C2 div.frame_filled div.frame_tl
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_filled_tl.gif);
}
.skin_2D83C2 div.frame_filled div.frame_br
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_filled_br.gif);
}
.skin_2D83C2 div.frame_filled div.frame_bl
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_filled_bl.gif);
}
.skin_2D83C2 div.frame_invert_filled div.frame_tl
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_invert_filled_tl.gif);
}
.skin_2D83C2 div.frame_invert_filled div.frame_br
{
	background-image: url(/graphics/ozon/skin/2D83C2/frame_invert_filled_br.gif);
}
.skin_2D83C2 div.group_item_active div.group a
{
	color: #2D83C2;
}
.skin_2D83C2 div.catalog_item_active div.catalog
{
	background-image: url(/graphics/ozon/skin/2D83C2/bullet_filled_small.gif);
}
.skin_2D83C2 div.catalog_item_active div.catalog a
{
	color: #2D83C2;
}
.skin_2D83C2 td.detail_delim
{
	border-bottom: solid 1px #2D83C2;
}
.skin_2D83C2 div.detail_delim
{
	border-bottom: solid 1px #2D83C2;
}
.skin_2D83C2 #search .search_my_block a
{
	color: #2D83C2;
}
.skin_2D83C2 .search_my_block td
{
	background-image: url(/graphics/ozon/skin/2D83C2/bullet_filled.gif);
}
.skin_2D83C2 table.search_my_block td.myCart
{
	background: url(/graphics/ozon/skin/2D83C2/3.gif) no-repeat 0px center;
}
.skin_2D83C2 table.search_my_block td.myOrder
{
	background: url(/graphics/ozon/skin/2D83C2/2.gif) no-repeat 5px center;
}
.skin_2D83C2 table.search_my_block td.myOzon
{
	background: url(/graphics/ozon/skin/2D83C2/1.gif) no-repeat 5px center;
}
.skin_2D83C2 #mynavigator div.addpage
{
	background-image: url(/graphics/ozon/skin/2D83C2/addpage.gif);
}

#keyboardInputMaster
{
	position: absolute;
	background-color: #e3e3e7;
	z-index: 1000000;
}
#keyboardInputMaster thead tr td.header
{
	width: 313px;
	padding: 5px 0px 5px 7px;
	font: bold 11px Verdana, Tahoma, Arial, Helvetica, sans-serif;
	text-align: left;
	border: 0px none;
	color: Black;
}
#keyboardInputMaster thead tr td.rightCorner
{
	width: 20px;
	padding: 5px 0px 5px 0px;
	border: 0px none;
}
#keyboardInputMaster thead tr td span
{
	cursor: default;
	cursor: pointer;
}
#keyboardInputMaster thead tr td span.pressed
{
	background-color: #bbbbbb;
}
#keyboardInputMaster tbody tr td.background
{
	width: 327px;
	padding: 0px 7px 7px 7px;
	background-image: url(/graphics/ozon/keybord/keys_back.gif);
	background-position: 7px 0px;
	background-repeat: no-repeat;
}
#keyboardInputMaster tbody tr td
{
	margin: 0px;
	text-align: center;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout
{
	height: 100px;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table
{
	height: 20px;
	width: auto;
	white-space: nowrap;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td
{
	vertical-align: middle;
	font: normal 11px Verdana, Tahoma, Arial, Helvetica, sans-serif;
	cursor: default;
	cursor: pointer;
	width: 20px;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.alive
{
	background-color: #ccccdd;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.target
{
	background-color: #ddddcc;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.hover
{
	background-color: #cccccc;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.pressed, #keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.dead
{
	background-color: #cccccc;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.last
{
	width: 66px;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.lastNotLong
{
	width: 46px;
}
#keyboardInputMaster tbody tr td div#keyboardInputLayout table tbody tr td.CapsLong
{
	width: 40px;
}
.keyboardInputInitiator
{
	vertical-align: middle;
	cursor: default;
	cursor: pointer;
}
.color_Brown
{
	color: #770b3e;
}
table.calendarParter a
{
	text-decoration: none;
}
table.calendarParter a:hover
{
	text-decoration: underline;
}
.calendarParterHeader
{
	background-position: left bottom;
	background-image: url(/graphics/ozon/ticket/calendar_header.gif);
	height: 35px;
	background-repeat: no-repeat;
}

.calendarParterHeader td
{
	vertical-align: top;
}

.calendarParter td.Arrow
{
	vertical-align: top;
	padding-top: 5px;
}
ul.blueMerchant li
{
	margin: 2px 0px;
	background: url(/graphics/ozon/skin/2D83C2/bullet_filled.gif) no-repeat 0.3em 0.6em;
}
ul.blueMerchant li a
{
	color: #3183bd;
}
img.merchant_info_logo
{
	border: 0px;
	margin: 0px;
	padding: 0px;
}
.merchant_info_frame
{
	padding-bottom: 5px;
	background: url(/graphics/ozon/c2c/bg_bottom_left.jpg) no-repeat right bottom;
}
.merchant_info_box
{
	width: 138px;
	min-width: 138px;
	border-left: solid 1px #c8c8c8;
	border-right: solid 1px #c8c8c8;
	padding: 15px 10px 5px 10px;
}
.merchant_info_block
{
	margin-top: 5px;
	margin-bottom: 10px;
}

.merchant_comment_frame
{
	padding-bottom: 0px;
	background: url(/graphics/ozon/c2c/bg_gradient_bottom.jpg) repeat-x bottom;
}
.merchant_comment_box
{
	border: solid 1px #c8c8c8;
	padding: 10px 10px 5px 10px;
}

.padLeftRight10Bottom10
{
	padding-left: 10px;
	padding-right: 10px;
	padding-bottom: 10px;
}
.padBottom15Left10
{
	padding-bottom: 15px;
	padding-left: 10px;
}
.skin_7b7b7b
{
	color: #7b7b7b;
}
.backGround_2D83C2
{
	background-color: #2D83C2;
}
.backGround_7b7b7b
{
	background-color: #7b7b7b;
}
.tableRatingMerchant
{
	width: 50px;
	height: 9px;
}
td.merchant_rating
{
	width: 65px;
	padding: 0px 3px;
}
td.merchant_rating div
{
	background-color: #c8c8c8;
	line-height: 9px;
}
td.merchant_rating div img
{
	background-color: #2d83c2;
}
td.merchant_rating div img.Rating1
{
	background-color: #C27E18;
}
td.merchant_rating div img.Rating0
{
	background-color: #838383;
}
td.merchant_rating div img.RatingMinus1
{
	background-color: #CC0000;
}
td.merchant_rating1
{
	color: #C27E18;
}
td.merchant_rating0
{
	color: #838383;
}
td.merchant_ratingMinus1
{
	color: #CC0000;
}

td.merchant_top_rating_border
{
	border-right-color: #e0e0e0;
	border-right-width: 1px;
	border-right-style: solid;
	text-align: right;
}
tr.merchant_top_rating_background
{
	background-image: url(/graphics/ozon/c2c/grad_bg_controls.jpg);
	background-repeat: repeat-x;
}

.ifP p
{
	text-align: justify;
}
.ifP .red
{
	color: red;
}
.ifP .blue
{
	color: blue;
}
.ifP strong, .ifP em
{
	font-weight: bold;
	font-style: normal;
}
.ifP a.none
{
	text-decoration: none;
}

div.floatLeft5
{
	float: left;
	padding-right: 5px;
	padding-bottom: 5px;
	width: 425px;
	height: 350px;
}
div.mainText
{
	color: #2D83C2;
	font-weight: bold;
	font-size: 1.17em;
	padding-bottom: 15px;
	font-family: Verdana;
	vertical-align: top;
	text-align: left;
}
div.paddingBottomGoogle
{
	padding-bottom: 10px;
}
div.TopUp8
{
	position: relative;
	top: -8px;
}
td.GrayDown
{
	border-bottom: solid 1px;
}
.fadein
{
	display: none;
}
.fadeinFld
{
	display: none;
}
.labelpr
{
	width: 80px;
	padding-left: 5px;
}
.fieldpr
{
	width: 220px;
}
hr.thinGreyLine
{
	width: 100%;
	height: 1px;
	color: #EDEDED;
	background-color: #EDEDED;
	border-width: 0px;
}


.help_img
{
	width: 215px;
	float: left;
	margin-top: 2px;
}
.help_img a img
{
	width: 205px;
	height: 110px;
	border: 0px;
}
.help_img a div
{
	text-align: left;
	margin: 2px 0 0 5px;
}
.help_img a div img
{
	width: 200px;
	height: 10px;
	border: 0px;
}
.help_img1
{
	width: 215px;
	float: left;
	margin-top: 2px;
}
.help_img1 a img
{
	width: 205px;
	border: 0px;
}
.help_img1 a div
{
	width: 200px;
	text-align: right;
	margin: 0 0 0 5px;
}
.help_img1 a div span
{
	font-size: 0.9em;
	cursor: hand;
	text-decoration: underline;
}
.help_img1 a div span:hover
{
	text-decoration: none;
}
.help_img1 a div img
{
	vertical-align: bottom;
}

.help_text
{
	margin-left: 215px;
}
.help_text table.startab
{
	width: 300px;
	background-color: #666666;
	text-align: left;
}
.help_text table.startab th, .help_text table.startab td
{
	width: 150px;
	background-color: #ffffff;
	color: black;
}
.help_text table.startab td img
{
	width: 10px;
	height: 9px;
	border: 0;
}
.help_text_noimg p .icon_open, .help_text li .icon_open, .help_text p .icon_open, .help_img1 a div img
{
	width: 9px;
	height: 9px;
	margin-left: 3px;
	border: 0px;
	cursor: hand;
}
.help_text ul, .help_text ol
{
	padding-left: 30px;
}

div.DateForHH
{
	color: #000000;
	font-size: 0.8em;
}
div.CompanyNameForHH
{
	color: #000000;
}
span.PngFix
{
	vertical-align: middle;
}
div.AuctionPricesDiv
{
	border-top-width: 1px;
	border-top-style: dashed;
	border-top-color: #686868;
	border-left-width: 1px;
	border-left-style: dashed;
	border-left-color: #686868;
	border-right-width: 1px;
	border-right-style: dashed;
	border-right-color: #686868;
	margin-left: 5px;
}
div.AuctionDelimeter
{
	border-bottom-width: 1px;
	border-bottom-style: dashed;
	border-bottom-color: #686868;
	height: 1px;
	margin-left: 5px;
}
div.AuctionBlitzPricesDiv
{
	border-bottom-width: 1px;
	border-bottom-style: dashed;
	border-bottom-color: #686868;
	border-left-width: 1px;
	border-left-style: dashed;
	border-left-color: #686868;
	border-right-width: 1px;
	border-right-style: dashed;
	border-right-color: #686868;
	margin-left: 5px;
}
div.AuctionPricesDiv div.CurrentStartPrice
{
	margin: 1px 1px 1px 1px;
	color: White;
	background-color: #2d83c2;
	font-size: 0.9em;
	padding: 5px 5px 5px 5px;
}
div.AuctionPricesDiv div.BlitzPrice, div.AuctionBlitzPricesDiv div.BlitzPrice
{
	margin: 0px 1px 0px 1px;
	color: Red;
	background-color: #c8c9ce;
	font-size: 0.9em;
	padding: 5px 5px 5px 5px;
}
div.AuctionPricesDiv div.BlitzPrice div, div.AuctionPricesDiv div.CurrentStartPrice div, div.AuctionBlitzPricesDiv div.BlitzPrice div
{
	text-align: right;
}
div.AuctionPricesDiv div.BlitzPrice div span, div.AuctionPricesDiv div.CurrentStartPrice div span, div.AuctionBlitzPricesDiv div.BlitzPrice div span
{
	font-size: 1.67em;
}
div.YourAuctionPrice
{
	margin: 10px 5px 5px 5px;
	font-size: 0.9em;
}
div.YourAuctionPrice span
{
	font-weight: bold;
	margin-right: 5px;
}
div.NotifyAuctionSpam
{
	margin: 5px 5px 5px 5px;
	font-size: 0.9em;
}
div.NotifyAuctionSpam div
{
	float: left;
	margin-top: -3px;
}
div.AuctionButton
{
	text-align: center;
	margin: 0px 5px 5px 5px;
}
div.AuctionButtonBlitzPrice
{
	text-align: center;
	margin: 5px 5px 5px 5px;
}
.HHVacancyHeader
{
	font-weight: bold;
	float: left;
	font-size: 0.8em;
}
#ForImagesInHH
{
}
#ForImagesInHH img
{
	float: right;
}
.LeaderAuction
{
	margin: 5px 5px 5px 5px;
}
div.AuctionErrors
{
	margin: 5px 5px 5px 5px;
	font-size: 0.8em;
}
div.ErrorLabel
{
	margin: 5px 5px 5px 5px;
	color: Red;
}
div.MainDivChangePassword
{
	width: 30%;
	float: left;
	margin-right: 10px;
}
div.ChangePasswordInternalDiv
{
	width: 100%;
}
div.ChangePasswordInternalDiv input
{
	width: 99%;
}
div.ChangePasswordInternalDiv input.button
{
	font-size: 1em;
	font-weight: 700;
	width: 150px;
}
div.ChangePasswordInternalDiv div.ChangePasswordButtonClass
{
	text-align: center;
}
div.ChangePasswordInternalDiv div
{
	font-size: 0.9em;
	padding: 5px 0px 0px 0px;
}
div.ForgotPasswordDescription
{
	color: red;
	font-weight: bold;
}
div.ForgotPasswordEMail
{
	width: 291px;
	margin: 5px 0px 5px 0px;
}
div.ForgotPasswordEMail input
{
	width: 99%;
}
div.ForgotPasswordEMail input.button
{
	width: 150px;
	margin-top: 5px;
}
div.ForgotPasswordEMail div.textCenter, div.ForgotPasswordCard div.textCenter
{
	text-align: center;
}
div.ForgotPasswordCard
{
	width: 291px;
	margin: 5px 0px 5px 0px;
	float: left;
	height: 116px;
}
div.ForgotPasswordCard input.Input60
{
	width: 60px;
}
div.ForgotPasswordCard input.Input30
{
	width: 30px;
}
div.ForgotPasswordCard input.button
{
	margin-top: 5px;
}
div.ForgotPasswordCard div.small
{
	font-size: 0.9em;
	margin: 5px 0px 0px 0px;
}
img.CardImage
{
	margin: 5px 0px 5px 10px;
}
div.MyPersonalMain
{
	float: left;
	width: 40%;
	margin-right: 10px;
}
div.MyPersonalMain div div
{
	font-size: 0.9em;
	margin-top: 5px;
}
div.MyPersonalMain input
{
	width: 98%;
}
div.MyPersonalMain table.Input100 tbody tr td input, div.MyPersonalMain span input, div.MyPersonalMain div table tbody tr td input, div.MyPersonalMain input.CheckBox
{
	width: auto;
}
div.MyPersonalMain div.textCenter
{
	margin-top: 5px;
	text-align: center;
}
div.MyPersonalMain input.button
{
	width: auto;
	font-size: 1.1em;
}
div.MyPersonalMain span.BigText
{
	font-size: 1.24em;
	padding: 10px 0px 10px 0px;
}
div.PanelMyAccountAdd
{
	margin-top: 10px;
}
div.ValidationSummary
{
	margin-top: -10px;
}
div.RegistrationMain
{
	width: 610px;
	margin-bottom: 10px;
}
div.Login
{
	width: 300px;
	margin-right: 10px;
}
div.Login div.Bold, div.Registration div.Bold
{
	font-weight: bold;
}
div.Login div.frame div.frame_content div, div.Registration div.frame div.frame_content div
{
	margin: 3px;
}
div.Login div.frame div.frame_content div.Button, div.Registration div.frame div.frame_content div.Button
{
	margin: 6px 3px 6px 3px;
	text-align: center;
}
div.Login div.frame div.frame_content div.Border, div.Registration div.frame div.frame_content div.Border
{
	margin-top: 10px;
	height: 1px;
	background-color: #C8C9CE;
}
div.Registration
{
	width: 300px;
	float: right;
}
div.Login div.frame div.frame_content input, div.Registration div.frame div.frame_content input
{
	width: 98%;
	font-size: 1.1em;
}
div.Login div.frame div.frame_content input.NoWidth, div.Registration div.frame div.frame_content span.NoWidth input, div.Registration div.frame div.frame_content input.NoWidth, div.Login div.frame div.frame_content span.NoWidth input
{
	width: auto;
}
div.Login div.frame div.frame_content div.Button input, div.Registration div.frame div.frame_content div.Button input, div.Login div.frame div.frame_content span.NoWidth label
{
	font-size: 0.9em;
}
div.NameRegistraion
{
	font-size: 1.5em;
	font-weight: 500;
	margin-bottom: 10px;
}
div.RegistrationLE
{
	float: left;
	margin-right: 10px;
	margin-top: 10px;
}
div.MySubscribe
{
	float: left;
	margin-right: 10px;
	width: 50%;
}
div.RegistarionLEInner
{
	width: 280px;
}
div.RegistarionLEInner div.small input
{
	font-size: 1.1em;
}
div.RegistarionLEInner div, div.MySubscribeInner div
{
	margin: 6px;
}
div.RegistarionLEInner div.bold, div.MySubscribeInner div.bold
{
	font-weight: bold;
}
div.RegistarionLEInner div.Button, div.MySubscribeInner div.Button
{
	text-align: right;
}
div.RegistarionLEInner div.border, div.MySubscribeInner div.border
{
	height: 1px;
	line-height: 1px;
	background-color: #c8c9ce;
	margin-right: 9px;
}
.ErrorMessageSearch
{
	color: #fff69a;
}
div.FloatLeftImage
{
	float: left;
	padding-top: 1px;
}
div.MainDiv div.UpperDiv div.RightDiv
{
	float: right;
}
span.ErrorMessageText
{
	color: Red;
	padding: 10px 0px 10px 0px;
}
span.MoneySpan span
{
	font-weight: bold;
}
div.notVisible, span.notVisible
{
	display: none;
}
div.DescribeTitleService
{
	font-size: 1.2em;
	font-weight: 700;
	color: #2D83C2;
	margin: 10px 0px 5px 0px;
}
div.MainDiv
{
	margin-left: 17px;
}
div.MainDiv div.LeftDiv div.Title
{
	font-size: 1.2em;
	font-weight: 700;
}
div.MainDiv div.LeftDiv div.Description
{
	font-size: 0.9em;
	margin: 5px 0px 5px 0px;
}
div.MainDiv div.LeftDiv div.Price
{
	font-size: 1.2em;
	font-weight: 700;
	color: #2D83C2;
}
div.MainDiv div.RightDiv div.LinkButtonAddPeriod
{
	margin: 20px 20px 20px 20px;
}
div.MainDiv div.RightDiv div.LinkButtonAddPeriod img
{
	vertical-align: middle;
}
div.MainDiv div.RightDiv div.LinkButtonAddPeriod a
{
	color: #2D83C2;
	font-size: 0.9em;
	padding-bottom: 5px;
}
hr.HRSeparator
{
	color: #e0e0e0;
	height: 1px;
	margin-top: 10px;
	margin-bottom: 5px;
}
div.DownDiv
{
	margin-left: 17px;
}
table.MerchantSearch tbody tr td
{
	padding-bottom: 10px;
}
table.MerchantSearch tbody tr.Header td
{
	padding-top: 5px;
}
table.MerchantSearch tbody tr.Footer td
{
	padding-bottom: 5px;
	height: 23px;
}
table.OfferList tbody tr td
{
	padding-top: 6px;
	padding-bottom: 6px;
}
table.OfferList tbody tr.Header td
{
	height: 20px;
	background-image: url(/graphics/ozon/skin/common/bg_grey.jpg);
	padding: 0px;
}
table.OfferList tbody tr.Separator td
{
	height: 1px;
	padding: 0px;
}
table.gradientTable tr td.t1em
{
	font-size: 1em;
}
table.gradientTable small
{
	font-size: 0.9em;
}
table.gradientTable div.frame_round_tl
{
	width: 8px;
	height: 10px;
	background: url(/graphics/ozon/checkout/bg_grey_ugol2.jpg) no-repeat left top;
	float: left;
}
table.gradientTable
{
	margin-top: 10px;
	background: url(/graphics/ozon/checkout/bg_grey_2.jpg) repeat-x left top;
}
table.gradientTable tr.trnum_6 td
{
	padding: 6px 0 7px 10px;
}
table.gradientTable tr.bg1px
{
	background: url(/graphics/ozon/checkout/tr_bg_1px_ededed.gif) repeat-x left bottom;
}
table.gradientTable tr.htop td
{
	vertical-align: top;
}
table.gradientTable tr.htop td span
{
	display: block;
	padding: 7px 0 8px 10px;
	font-size: 0.9em;
}
table.gradientTable td.none
{
	padding: 0px;
}
table.gradientTable td em
{
	white-space: nowrap;
	font-style: normal;
	float: left;
	padding-right: 5px;
}
table.gradientTable tr.TotalBlueLineBlueBack td
{
	background-color: #eaf2f9;
	border-top-color: #2d83c2;
	border-top-width: 1px;
	border-top-style: solid;
	padding: 6px 0 7px 10px;
	vertical-align: middle;
}
table.gradientTable tr.TotalBlueLineBlueBack td div
{
	text-align: center;
	margin: auto 70px;
}
div.PriceDoubleItemBlock span
{
	font-size: 1.05em;
	margin-top: 5px;
	font-weight: bold;
}
span.bold
{
	font-weight: bold;
}
tr.paddingTop15
{
	padding-top: 15px;
}
span.BigBlueAddtionalPossibility
{
	font-family: Verdana, Tahoma, Arial, Helvetica, sans-serif;
	font-size: 1.2em;
	font-style: normal;
	text-decoration: none;
	word-spacing: normal;
	letter-spacing: normal;
	text-transform: none;
	margin-top: 0px;
	color: #2D83C2;
	font-weight: bold;
}
.paddingCartPointWillBe
{
	padding-left: 15px;
	padding-right: 28px;
}
td.ScoreTDDetail
{
	border-top: 1px dashed #B2B2B2;
	padding: 1px 0px 1px 0px;
}

td.ScoreTDDetail div
{
	padding: 6px 3px 5px 0px;
	background: #E5F2FF;
	color: #4280A9;
	text-align: center;
	font-weight: bold;
	vertical-align: bottom;
}

img.verticalAlignBottomImg
{
	margin-bottom: -2px;
}
.ImageButton
{
	width: 99px;
	height: 53px;
	margin-top: 8px;
	margin-bottom: 8px;
}
div.TakeIntoAccountPersonalRecomendationDIV
{
	font-size: 0.9em;
	margin-top: 10px;
}
.HiddenButton
{
	visibility: hidden;
	display: none;
}
div.AdviceControlDIV
{
}
div.AdviceControlDIV div
{
	float: left;
	background-color: #E1E2E5;
}
div.AdviceControlDIV div span input, div.AdviceControlDIV div input
{
	height: auto;
	width: auto;
	font-weight: normal;
}
div.AdviceControlDIV div span label, div.AdviceControlDIV div label
{
	font-size: 0.9em;
}
div.AdviceControlDIV input
{
	font-size: 10px;
	font-weight: bold;
	height: 18px;
	width: 70px;
	margin-left: 5px;
}
div.DetailCommentDIVRegistation
{
	margin-top: 5px;
	margin-bottom: 5px;
	margin-left: 10px;
	margin-right: 5px;
}
input.DisabledInput
{
	background-color: #D3D3D3;
}
div.SignatureDIV
{
	margin-top: 5px;
	float: right;
	color: Gray;
}
div.RateLiteralDIV
{
	margin: 5px 5px 5px 72px;
}
div.CommentSignatureDIV
{
	margin: 5px 10px 5px 0px;
}
input.BuyElectroItemLoadCatalogINPUT
{
	width: 105px;
	height: 55px;
	margin: 8px 0px 8px 0px;
}
input.BuyElectroItemDownloadCatalogINPUT
{
	width: 71px;
	height: 53px;
	margin: 8px 0px 8px 0px;
}
div.ClientListAnotherLinkControl
{
	margin: 10px 0px 5px 5px;
}
div.ClientListAnotherLinkControl img
{
	margin-left: 5px;
	height: 5px;
	width: 100%;
}
div.ClientListAnotherLinkControl div
{
	margin-left: 16px;
	color: #666666;
	font-size: 0.9em;
}
div.ClientListAnotherLinkControl span img
{
	margin-left: 0px;
	height: 12px;
	width: 12px;
}
div.ClientListAnotherLinkControl span a
{
	margin-left: 4px;
	font-weight: bold;
}
div.MainPanelFormAddLists span.RadioImage input
{
	display: none;
}
div.MainPanelFormAddLists span.RadioImage label
{
	vertical-align: middle;
}
div.MainPanelFormAddLists div.big2
{
	font-size: 1.5em;
	font-weight: 500;
	color: #FF6600;
	padding-left: 20px;
}
div.MainPanelFormAddLists table tbody tr td label
{
	font-size: 0.9em;
}
div.MainPanelFormAddLists input.maxWidth
{
	font-size: 0.9em;
	margin-left: 21px;
}
div.MainPanelFormAddLists div.ButtonToAddClientListDiv div
{
	background-color: #ff6600;
	margin: 4px 0px 4px 21px;
	height: 5px;
}
div.MainPanelFormAddLists div.ButtonToAddClientListDiv input
{
	float: right;
}
div.MainPanelFormAddLists span.RadioImage label img
{
	height: 18px;
	width: 19px;
	margin-right: 2px;
	margin-left: 0px;
}
div.MainPanelFormAddLists img
{
	margin-left: 5px;
	height: 5px;
	width: 100%;
}
div.ResultOfAddClientListDIV div.big
{
	margin: 0px 0px 0px 30px;
	font-size: 1.2em;
	font-weight: 700;
}
div.ResultOfAddClientListDIV div
{
	margin: 5px 15px 5px 15px;
}
div.ResultOfAddClientListDIV div div
{
	font-size: 0.9em;
	margin: 2px 0px 2px -8px;
}
div.ResultOfAddClientListDIV div div a, div.ResultOfAddClientListDIV div div img
{
	vertical-align: middle;
}
div.ResultOfAddClientListDIV div div img.Margin
{
	margin-left: 16px;
}
img.LongGreyDelimiter
{
	width: 100%;
	height: 5px;
	margin-left: 5px;
}
input.VerticalAlignMiddle
{
	vertical-align: middle;
}
div.SetVotePanelDIV div
{
	margin-left: 15px;
	margin-top: 5px;
	font-size: 0.9em;
}
div.SetVotePanelDIV div a
{
	color: #2D83C2;
	background-image: url(/graphics/ozon/c2c/but_accept_deal.png);
	background-position: left center;
	background-repeat: no-repeat;
	padding-left: 25px;
	height: 21px;
}
input.Margin88
{
	margin-top: 8px;
	margin-bottom: 8px;
}
div.MarginBottom15
{
	margin-bottom: 15px;
}
input.LittleMarginImageButton
{
	margin-top: 4px;
}
.greyFrameTopLine div.frame_contentAll15 span.text_formASPCHECKBOX input
{
	margin: 0;
	float: left;
}
.greyFrameTopLine div.frame_contentAll15 span.text_formASPCHECKBOX label
{
	display: block;
	margin-left: 17px;
	font-size: 0.9em;
	margin-top: 1px;
}
.searchBoxSuggestions, .CompletionListCssClass
{
	background: #fff none;
	z-index: 10000;
	margin: 0px;
	padding: 0px;
	border: solid 1px black;
}
.searchBoxSuggestions li.ui-menu-item a.ui-corner-all 
{
	font-family: inherit !important;
	-moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px;	
	border: none;
	line-height: 1;
}
.searchBoxSuggestions li.ui-menu-item
{
	margin: 0px;
	padding: 0px;
	overflow: visible; 
	background-image: none;
}
.CompletionListItemCssClass
{
	margin: 5px 0px 5px 2px;
	padding: 0px;
	overflow: visible; 
	background-image: none;
}
.searchBoxSuggestions div.CountOfSearchedResult
{
	float: right;
	font-size: 0.9em;
	color: Green;
	display:inline;
	position:absolute;
	right:0px;
	padding-right: 5px;
}
.searchBoxSuggestions .ui-menu-item a.ui-state-hover, .searchBoxSuggestions .ui-menu-item a.ui-state-highlight
{
	-moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px;
	border: none; 
	background: none; 
	background-color: yellow; 
	font-weight: normal; 
	color: inherit !important;	
	margin: 0px;
}

.CompletionListHighlightedItemCssClass
{
	background-color: Yellow;
	background-image: none;
	margin: 5px 0px 5px 2px;
	padding: 0px;	
}
.CompletionListHighlightedItemCssClass div.CountOfSearchedResult, .CompletionListItemCssClass div.CountOfSearchedResult
{
	float: right;
	font-size: 0.9em;
	color: Green;
	display:inline;
	position:absolute;
	right:0px;
	padding-right: 3px;
}
.bigBold
{
	font-size: 1.1em;
	font-weight: 700;
}

table.#vkpay0
{
	width:100% !important;
}

.merchant_seller
{
    width: 100%;
    }
    
table.merchant_seller tbody tr td     
{
    padding-bottom:0px;
    padding-top:0px;
}
</style>
</head>

<body>
	
<div>
    <b><small>&nbsp;БАНКОВСКИЙ ПЕРЕВОД&nbsp;</small></b></div>
<div>
    <table style="background-color: rgb(255, 255, 255); border-color: rgb(0, 0, 0);" border="1" cellspacing="0" width="670px">
        <tbody><tr valign="top">

            <td class="nowrap" style="width: 155px; height: 194px;" align="center">
                <div class="center"><b><small>Извещение</small></b></div><br>
                <div style="width: 185px; height: 210px;">&nbsp;</div>
                <div class="center"><b><small>Кассир</small></b></div>
            </td>
            <td style="height: 194px;">
            <br>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 100%;">ПОКРЕВСКАЯ СВЕТЛАНА ДМИТРИЕВНА</small>

              <small class="microsberblank" style="text-align: center; width: 100%;">(наименование получателя платежа)</small> 
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 200px;">7728168971</small>
              <small class="sbBlankBlock">&nbsp;</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 270px;">40817810806000010867</small>
              <small class="microsberblank" style="text-align: center; width: 200px;">(ИНН получателя платежа)</small>
              <small class="sbBlankBlock">&nbsp;</small>
              <small class="microsberblank" style="text-align: center; width: 270px;">(номер счета получателя платежа)</small>

              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 366px;">ОАО «Альфа-Банк»</small>
              <small class="smallsberblank">БИК</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 87px;">044525593</small>
              <small class="microsberblank" style="text-align: center; width: 330px;">(наименование банка получателя платежа)</small>
              <small class="sbBlankBlock" style="text-align: center; width: 86px;">&nbsp;</small>
              <small class="smallsberblank" style="text-align: left; width: 206px;">Номер кор./сч. банка получателя платежа</small>

              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 256px;">30101810200000000593</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 205px;">оплата заказа № <%= ViewData["uid"] %></small>
              <small class="smallsberblank sbBlankBlock">&nbsp;</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 264px;">&nbsp;</small>
              <small class="microsberblank" style="text-align: center; width: 226px;">(наименование платежа)</small>
              <small class="microsberblank" style="text-align: center; width: 248px;">(номер лицевого счета (код) плательщика)</small>
              <small class="middlesberblank">Ф.И.О. плательщика &nbsp;</small>
              
              <%
                  decimal price = Model.Price;
                  int rubles = (int)price;
                  int cops = (int) ((price - Math.Truncate(price))*100);
              %>
              
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 360px;"><%= Model.UserName %></small>
              <small class="middlesberblank">Адрес плательщика &nbsp;</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 364px;"><%= Model.Address %></small>
              <small class="middlesberblank">Сумма платежа:</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 52px;"><%= rubles %></small> 
              <small class="middlesberblank">руб.</small>

              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 15px;"><%= cops %></small> 
              <small class="middlesberblank"> коп. &nbsp;&nbsp;Сумма платы за услуги:</small>
              <small class="sbBlankLine" style="text-align: center; width: 32px;">&nbsp;</small> 
              <small class="middlesberblank">руб.</small>
              <small class="sbBlankLine" style="text-align: center; width: 15px;">&nbsp;</small> 
              <small class="middlesberblank" style="width: 50px;">коп.</small>
              <div class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</div>

              <small class="middlesberblank">Итого</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 52px;"><%= rubles %></small> 
              <small class="middlesberblank">руб.</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 15px;"><%= cops %></small> 
              <small class="middlesberblank">коп.</small>
              <small class="middlesberblank" style="width: 40px;">&nbsp;</small>

              <small class="middlesberblank">"</small>
              <small class="sbBlankLine" style="text-align: center; width: 42px;">&nbsp;</small> 
              <small class="middlesberblank">"</small>
              <small class="sbBlankLine" style="text-align: center; width: 140px;">&nbsp;</small> 
              <small class="middlesberblank">201__г.</small>
              <div class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</div>
              <small class="microsberblank">С условиями приема указанной в платежном документе суммы, в т.ч с суммой взимаемой платы за услуги<br> банка ознакомлен и согласен.</small>

							<div class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</div>
              <small class="sbBlankBlock" style="width: 188px;">&nbsp;</small> 
              <small class="microsberblank"><b>Подпись плательщика</b></small>
              </td>
        </tr>
         <tr valign="top">
            <td class="nowrap" align="center">
								<div style="width: 155px; height: 250px;">&nbsp;</div>
                <div class="center"><b><small>Квитанция</small></b></div>

                <div style="width: 155px; height: 20px;">&nbsp;</div>
                <div class="center"><b><small>Кассир</small></b></div>
            </td>
            <td style="height: 304px;">
            <br>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 100%;">ПОКРЕВСКАЯ СВЕТЛАНА ДМИТРИЕВНА</small>
              <small class="microsberblank" style="text-align: center; width: 100%;">(наименование получателя платежа)</small> 
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 200px;">7728168971</small>

              <small class="sbBlankBlock">&nbsp;</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 270px;">40817810806000010867</small>
              <small class="microsberblank" style="text-align: center; width: 200px;">(ИНН получателя платежа)</small>
              <small class="sbBlankBlock">&nbsp;</small>
              <small class="microsberblank" style="text-align: center; width: 270px;">(номер счета получателя платежа)</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 366px;">ОАО «Альфа-Банк»</small>
              <small class="smallsberblank">БИК</small>

              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 87px;">044525593</small>
              <small class="microsberblank" style="text-align: center; width: 330px;">(наименование банка получателя платежа)</small>
              <small class="sbBlankBlock" style="text-align: center; width: 86px;">&nbsp;</small>
              <small class="smallsberblank" style="text-align: left; width: 206px;">Номер кор./сч. банка получателя платежа</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 256px;">30101810200000000593</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 205px;">оплата заказа № <%= ViewData["uid"] %></small>

              <small class="smallsberblank sbBlankBlock">&nbsp;</small>
              <small class="smallsberblank sbBlankLine" style="text-align: center; width: 264px;">&nbsp;</small>
              <small class="microsberblank" style="text-align: center; width: 226px;">(наименование платежа)</small>
              <small class="microsberblank" style="text-align: center; width: 248px;">(номер лицевого счета (код) плательщика)</small>
              <small class="middlesberblank">Ф.И.О. плательщика &nbsp;</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 360px;"><%= Model.UserName %></small>
              <small class="middlesberblank">Адрес плательщика &nbsp;</small>

              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 364px;"><%= Model.Address %></small>
              <small class="middlesberblank">Сумма платежа:</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 52px;"> <%= rubles %></small> 
              <small class="middlesberblank">руб.</small>

              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 15px;"><%= cops %></small> 
              <small class="middlesberblank"> коп. &nbsp;&nbsp;Сумма платы за услуги:</small>

              <small class="sbBlankLine" style="text-align: center; width: 32px;">&nbsp;</small> 
              <small class="middlesberblank">руб.</small>
              <small class="sbBlankLine" style="text-align: center; width: 15px;">&nbsp;</small> 
              <small class="middlesberblank" style="width: 50px;">коп.</small>
              <small class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</small>
              <small class="middlesberblank">Итого</small>
              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 52px;"><%= rubles %></small> 
              <small class="middlesberblank">руб.</small>

              <small class="middlesberblank sbBlankLine" style="text-align: center; width: 15px;"><%= cops %></small> 
              <small class="middlesberblank">коп.</small>
              <small class="middlesberblank" style="width: 40px;">&nbsp;</small>
              <small class="middlesberblank">"</small>
              <small class="sbBlankLine" style="text-align: center; width: 42px;">&nbsp;</small> 
              <small class="middlesberblank">"</small>
              <small class="sbBlankLine" style="text-align: center; width: 140px;">&nbsp;</small> 
              <small class="middlesberblank">201__г.</small>

              <small class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</small>
              <small class="microsberblank">С условиями приема указанной в платежном документе суммы, в т.ч с суммой взимаемой платы за услуги<br> банка ознакомлен и согласен.</small>
							<small class="sbBlankBlock" style="width: 100%; font-size: 1px;">&nbsp;</small>
              <small class="sbBlankBlock" style="width: 188px;">&nbsp;</small> 
              <small class="microsberblank"><b>Подпись плательщика</b></small>
              </td>
        </tr>

    </tbody></table>
    <!-- Печать -->
</div>
	
</body></html>
