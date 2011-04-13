<%@ Page Title="" Language="C#" MasterPageFile="~/Beta/BetaMasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoUMapInfoOnline.Beta.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BetaMainContent" runat="server">

    <asp:Panel ID="pnlConnexion" runat="server">
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
            World:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="lstWorlds" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnConnect" runat="server" onclick="btnConnect_Click" 
                Text="Connect" ToolTip="Connect" />
            &nbsp;</p>
</asp:Panel>
</asp:Content>
