<%@ Page Title="Players Reports ~ LoU Map Info" Language="C#" MasterPageFile="~/Official/OfficialMasterPage.master" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="LoUMapInfoOnline.Official.Players" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="OfficialMainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
        Player Overview:
        <asp:Button ID="btnMe" runat="server" onclick="btnMe_Click" Text="Me" />
&nbsp;&nbsp;&nbsp;&nbsp; Other:
        <asp:TextBox ID="txtPlayerName" runat="server" ></asp:TextBox>
        <asp:Button ID="btnShowPlayerReport" runat="server" 
            onclick="btnShowPlayerReport_Click" Text="Show Report" />
            <asp:AutoCompleteExtender
                ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtPlayerName" UseContextKey="True" 
            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="" 
            CompletionSetCount="20" OnClientItemSelected="SimulateClick">
            </asp:AutoCompleteExtender>
            <script type="text/javascript">
                function OnKeyUp(obj) {

                    if (obj.id == "txtPlayerName" && window.event.keyCode == 13) {

                        SimulateClick(null, null);

                    }

                }
                function SimulateClick(sender,e)
                {
                    if ($get("<%=btnShowPlayerReport.ClientID%>").dispatchEvent) {
                        var e = document.createEvent("MouseEvents");

                        e.initEvent("click", true, true);
                        $get("<%=btnShowPlayerReport.ClientID%>").dispatchEvent(e);

                    }

                    else {
                        $get("<%=btnShowPlayerReport.ClientID%>").click();

                    }
                }
            </script>
</asp:Content>
