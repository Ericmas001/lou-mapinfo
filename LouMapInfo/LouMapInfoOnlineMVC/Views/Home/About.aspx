<%@ Page  Title="About ~ LoU Map Info Online" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Header"] %>
    </h2>
    <p>
        Please visit <a href="http://code.google.com/p/lou-mapinfo/" title="LoU Map Info Google Code Website">LoU Map Info on Google Code</a>.
    </p>
</asp:Content>
