<%@ Page Title="Beta ~ LoU Map Info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Beta.aspx.cs" Inherits="LoUMapInfoOnline.Beta" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Try LoU Map Info Online as a Beta Tester.
    </h2>
    <p>
        Anything could happen :p
    </p>
    <p>
        <asp:Label ID="lblErrors" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="LoU Mail: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="LoU Password: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        World:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="lstWorlds" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnConnect" runat="server" Text="Connect" ToolTip="Connect" 
            onclick="btnConnect_Click" />
&nbsp;</p>
    <p>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </p>
</asp:Content>
