<%@ Page Title="Alliances Reports ~ LoU Map Info" Language="C#" MasterPageFile="~/Beta/BetaMasterPage.master" AutoEventWireup="true" CodeBehind="Alliances.aspx.cs" Inherits="LoUMapInfoOnline.Beta.Alliance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BetaMainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
        Alliance Overview:
        <asp:Button ID="btnMe" runat="server" onclick="btnMe_Click" Text="Me" />
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
</asp:Content>
