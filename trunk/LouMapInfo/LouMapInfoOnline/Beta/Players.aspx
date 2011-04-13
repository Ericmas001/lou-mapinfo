<%@ Page Title="Players Reports ~ LoU Map Info" Language="C#" MasterPageFile="~/Beta/BetaMasterPage.master" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="LoUMapInfoOnline.Beta.Players" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BetaMainContent" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
    <p>
        Player Overview:
        <asp:Button ID="btnMe" runat="server" onclick="btnMe_Click" Text="Me" />
&nbsp;&nbsp;&nbsp;&nbsp; Other:
        <asp:TextBox ID="txtPlayerName" runat="server" AutoCompleteType="Search"></asp:TextBox>
        <asp:Button ID="btnShowPlayerReport" runat="server" 
            onclick="btnShowPlayerReport_Click" Text="Show Report" />
            <asp:AutoCompleteExtender
                ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtPlayerName" UseContextKey="True" 
            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="">
            </asp:AutoCompleteExtender>
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BetaReportContent" runat="server">
    <asp:Literal ID="ReportLiteral" runat="server"></asp:Literal>
</asp:Content>
