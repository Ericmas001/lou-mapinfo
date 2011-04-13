<%@ Page Title="LoU Map Info" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %>
    </h2>
    <p>
        This could be the future of <a href="http://code.google.com/p/lou-mapinfo/" title="LoU Map Info Google Code Website">LoU Map Info</a>.
    </p>
</asp:Content>
