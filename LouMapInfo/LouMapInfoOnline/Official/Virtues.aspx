<%@ Page Title="Alliances Reports ~ LoU Map Info" Language="C#" MasterPageFile="~/Official/OfficialMasterPage.master" AutoEventWireup="true" CodeBehind="Virtues.aspx.cs" Inherits="LoUMapInfoOnline.Official.Virtue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="OfficialMainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
        <b>By Alliance Report:</b>
        <asp:Button ID="btnMe" runat="server" onclick="btnMe_Click" Text="Me" 
    style="height: 26px" />
    <asp:Label ID="lblOther" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp; Other:"></asp:Label>
        <asp:TextBox ID="txtAllianceName" runat="server" ></asp:TextBox>
        <asp:Button ID="btnShowAllianceReport" runat="server" 
            onclick="btnShowAllianceReport_Click" Text="Show Report" />
            <asp:AutoCompleteExtender
                ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtAllianceName" UseContextKey="True" 
            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="" 
            CompletionSetCount="20" OnClientItemSelected="SimulateClick">
            </asp:AutoCompleteExtender>
            <script type="text/javascript">
                function OnKeyUp(obj) {

                    if (obj.id == "txtAllianceName" && window.event.keyCode == 13) {

                        SimulateClick(null, null);

                    }

                }
                function SimulateClick(sender,e)
                {
                    if ($get("<%=btnShowAllianceReport.ClientID%>").dispatchEvent) {
                        var e = document.createEvent("MouseEvents");

                        e.initEvent("click", true, true);
                        $get("<%=btnShowAllianceReport.ClientID%>").dispatchEvent(e);

                    }

                    else {
                        $get("<%=btnShowAllianceReport.ClientID%>").click();

                    }
                }
            </script>

            <br />
            <b>By Virtue Report:</b>
    <asp:Button ID="btnAll" runat="server" Text="All" onclick="btnAll_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btnCompassion" runat="server" Text="Compassion" 
    onclick="btnCompassion_Click" />
    <asp:Button ID="btnHonesty" runat="server" Text="Honesty" 
    onclick="btnHonesty_Click" />
    <asp:Button ID="btnHonor" runat="server" Text="Honor" 
    onclick="btnHonor_Click" />
    <asp:Button ID="btnHumility" runat="server" Text="Humility" 
    onclick="btnHumility_Click" />
    <asp:Button ID="btnJustice" runat="server" Text="Justice" 
    onclick="btnJustice_Click" />
    <asp:Button ID="btnSacrifice" runat="server" Text="Sacrifice" 
    onclick="btnSacrifice_Click" />
    <asp:Button ID="btnSpirituality" runat="server" Text="Spirituality" 
    onclick="btnSpirituality_Click" />
    <asp:Button ID="btnValor" runat="server" Text="Valor" 
    onclick="btnValor_Click" />
    
            <br />
            <b>Alliances Battle:</b>
<asp:Button ID="btnHighestLevel"
        runat="server" Text="Highest Level Palace" onclick="btnHighestLevel_Click" />
            <br />
            <b>Shrine Radius:</b> Shrine Location: 
    <asp:TextBox ID="txtShrineLocation" runat="server"></asp:TextBox>
    <asp:Button ID="btnShrineRadius"
        runat="server" Text="Get cities in the 20 tiles radius" onclick="btnShrineRadius_Click" />
</asp:Content>
