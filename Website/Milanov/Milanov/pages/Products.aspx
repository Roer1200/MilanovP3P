<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Milanov.pages.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Shop</title>
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
    <p>
        Select by category: 
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="sds_category" DataTextField="category" DataValueField="category">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sds_category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            SelectCommand="SELECT DISTINCT [cat_id] FROM [picture] ORDER BY [category]">
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>