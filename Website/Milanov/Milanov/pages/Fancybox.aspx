﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Fancybox.aspx.cs" Inherits="Milanov.pages.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Test</title>

    <!-- scripts -->  
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $("a[rel=fancybox]").fancybox({
	            'transitionIn': 'none',
	            'transitionOut': 'none',
	            'titlePosition': 'over',
	            'titleFormat': function (title, currentArray, currentIndex, currentOpts) {
	                return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
	            }
	        });
	    });
	</script>

    <!--stylesheets-->
    <link rel="stylesheet" href="/fancybox/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <center>
        <table>
	        <tr>
		        <td><a rel="fancybox" href="../images/pictures/1.jpg" title="test"><img src="../images/pictures/1.jpg" alt="1" height="100px" width="100px"/></a></td>
                <td><a rel="fancybox" href="../images/pictures/2.jpg" title="test"><img src="../images/pictures/2.jpg" alt="2" height="100px" width="100px"/></a></td>
                <td><a rel="fancybox" href="../images/pictures/3.jpg" title="test"><img src="../images/pictures/3.jpg" alt="3" height="100px" width="100px"/></a></td>
	        </tr>
	        <tr>
		        <td><a rel="fancybox" href="../images/pictures/4.jpg" title="test"><img src="../images/pictures/4.jpg" alt="4" height="100px" width="100px"/></a></td>
                <td><a rel="fancybox" href="../images/pictures/5.jpg" title="test"><img src="../images/pictures/5.jpg" alt="5" height="100px" width="100px"/></a></td>
                <td><a rel="fancybox" href="../images/pictures/6.jpg" title="test"><img src="../images/pictures/6.jpg" alt="6" height="100px" width="100px"/></a></td>
	        </tr>
	        <tr>
		        <td><a rel="fancybox" href="../images/pictures/7.jpg" title="test"><img src="../images/pictures/7.jpg" alt="7" height="100px" width="100px"/></a></td>
                <td><a rel="fancybox" href="../images/pictures/8.jpg" title="test"><img src="../images/pictures/8.jpg" alt="8" height="100px" width="100px"/></a></td>        
	        </tr>
        </table>
    </center>
</asp:Content>
