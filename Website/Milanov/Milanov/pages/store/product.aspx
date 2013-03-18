<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Milanov.pages.store.product_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <!-- stylesheets -->
    <link rel="stylesheet" href="/fancybox/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="lblOutput" runat="server" Text="Helaas, dit product bestaat niet meer."></asp:Label>
    <asp:Button ID="btnAddToCart" runat="server" Text="Bestel" Visible="false" Onclick="btnAddToCart_Click" />
</asp:Content>
