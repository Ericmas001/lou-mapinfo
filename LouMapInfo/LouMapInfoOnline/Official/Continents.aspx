<%@ Page Title="Alliances Reports ~ LoU Map Info" Language="C#" MasterPageFile="~/Official/OfficialMasterPage.master" AutoEventWireup="true" CodeBehind="Continents.aspx.cs" Inherits="LoUMapInfoOnline.Official.Continent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="OfficialMainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
        <b>Continent Overview:</b><asp:Panel ID="pnlActiveContinent" runat="server">
    
        <asp:Button ID="btnChooseContinent" runat="server" Text="Choose Continent" OnClientClick="return false;" />
      </asp:Panel>          <asp:Panel ID="pnlChooseContinent" runat="server" CssClass="popupControl">
                    <asp:Button ID="btnC00" runat="server" visible="false" onclick="btnContinent_Click" Text="00" />
                    <asp:Button ID="btnC01" runat="server" visible="false" onclick="btnContinent_Click" Text="01" />
                    <asp:Button ID="btnC02" runat="server" visible="false" onclick="btnContinent_Click" Text="02" />
                    <asp:Button ID="btnC03" runat="server" visible="false" onclick="btnContinent_Click" Text="03" />
                    <asp:Button ID="btnC04" runat="server" visible="false" onclick="btnContinent_Click" Text="04" />
                    <asp:Button ID="btnC05" runat="server" visible="false" onclick="btnContinent_Click" Text="05" />
                    <asp:Button ID="btnC06" runat="server" visible="false" onclick="btnContinent_Click" Text="06" />
                    <asp:Button ID="btnC07" runat="server" visible="false" onclick="btnContinent_Click" Text="07" />
                    <asp:Button ID="btnC08" runat="server" visible="false" onclick="btnContinent_Click" Text="08" />
                    <asp:Button ID="btnC09" runat="server" visible="false" onclick="btnContinent_Click" Text="09" />
                    <br />
                    <asp:Button ID="btnC10" runat="server" visible="false" onclick="btnContinent_Click" Text="10" />
                    <asp:Button ID="btnC11" runat="server" visible="false" onclick="btnContinent_Click" Text="11" />
                    <asp:Button ID="btnC12" runat="server" visible="false" onclick="btnContinent_Click" Text="12" />
                    <asp:Button ID="btnC13" runat="server" visible="false" onclick="btnContinent_Click" Text="13" />
                    <asp:Button ID="btnC14" runat="server" visible="false" onclick="btnContinent_Click" Text="14" />
                    <asp:Button ID="btnC15" runat="server" visible="false" onclick="btnContinent_Click" Text="15" />
                    <asp:Button ID="btnC16" runat="server" visible="false" onclick="btnContinent_Click" Text="16" />
                    <asp:Button ID="btnC17" runat="server" visible="false" onclick="btnContinent_Click" Text="17" />
                    <asp:Button ID="btnC18" runat="server" visible="false" onclick="btnContinent_Click" Text="18" />
                    <asp:Button ID="btnC19" runat="server" visible="false" onclick="btnContinent_Click" Text="19" />
                    <br />
                    <asp:Button ID="btnC20" runat="server" visible="false" onclick="btnContinent_Click" Text="20" />
                    <asp:Button ID="btnC21" runat="server" visible="false" onclick="btnContinent_Click" Text="21" />
                    <asp:Button ID="btnC22" runat="server" visible="false" onclick="btnContinent_Click" Text="22" />
                    <asp:Button ID="btnC23" runat="server" visible="false" onclick="btnContinent_Click" Text="23" />
                    <asp:Button ID="btnC24" runat="server" visible="false" onclick="btnContinent_Click" Text="24" />
                    <asp:Button ID="btnC25" runat="server" visible="false" onclick="btnContinent_Click" Text="25" />
                    <asp:Button ID="btnC26" runat="server" visible="false" onclick="btnContinent_Click" Text="26" />
                    <asp:Button ID="btnC27" runat="server" visible="false" onclick="btnContinent_Click" Text="27" />
                    <asp:Button ID="btnC28" runat="server" visible="false" onclick="btnContinent_Click" Text="28" />
                    <asp:Button ID="btnC29" runat="server" visible="false" onclick="btnContinent_Click" Text="29" />
                    <br />
                    <asp:Button ID="btnC30" runat="server" visible="false" onclick="btnContinent_Click" Text="30" />
                    <asp:Button ID="btnC31" runat="server" visible="false" onclick="btnContinent_Click" Text="31" />
                    <asp:Button ID="btnC32" runat="server" visible="false" onclick="btnContinent_Click" Text="32" />
                    <asp:Button ID="btnC33" runat="server" visible="false" onclick="btnContinent_Click" Text="33" />
                    <asp:Button ID="btnC34" runat="server" visible="false" onclick="btnContinent_Click" Text="34" />
                    <asp:Button ID="btnC35" runat="server" visible="false" onclick="btnContinent_Click" Text="35" />
                    <asp:Button ID="btnC36" runat="server" visible="false" onclick="btnContinent_Click" Text="36" />
                    <asp:Button ID="btnC37" runat="server" visible="false" onclick="btnContinent_Click" Text="37" />
                    <asp:Button ID="btnC38" runat="server" visible="false" onclick="btnContinent_Click" Text="38" />
                    <asp:Button ID="btnC39" runat="server" visible="false" onclick="btnContinent_Click" Text="39" />
                    <br />
                    <asp:Button ID="btnC40" runat="server" visible="false" onclick="btnContinent_Click" Text="40" />
                    <asp:Button ID="btnC41" runat="server" visible="false" onclick="btnContinent_Click" Text="41" />
                    <asp:Button ID="btnC42" runat="server" visible="false" onclick="btnContinent_Click" Text="42" />
                    <asp:Button ID="btnC43" runat="server" visible="false" onclick="btnContinent_Click" Text="43" />
                    <asp:Button ID="btnC44" runat="server" visible="false" onclick="btnContinent_Click" Text="44" />
                    <asp:Button ID="btnC45" runat="server" visible="false" onclick="btnContinent_Click" Text="45" />
                    <asp:Button ID="btnC46" runat="server" visible="false" onclick="btnContinent_Click" Text="46" />
                    <asp:Button ID="btnC47" runat="server" visible="false" onclick="btnContinent_Click" Text="47" />
                    <asp:Button ID="btnC48" runat="server" visible="false" onclick="btnContinent_Click" Text="48" />
                    <asp:Button ID="btnC49" runat="server" visible="false" onclick="btnContinent_Click" Text="49" />
                    <br />
                    <asp:Button ID="btnC50" runat="server" visible="false" onclick="btnContinent_Click" Text="50" />
                    <asp:Button ID="btnC51" runat="server" visible="false" onclick="btnContinent_Click" Text="51" />
                    <asp:Button ID="btnC52" runat="server" visible="false" onclick="btnContinent_Click" Text="52" />
                    <asp:Button ID="btnC53" runat="server" visible="false" onclick="btnContinent_Click" Text="53" />
                    <asp:Button ID="btnC54" runat="server" visible="false" onclick="btnContinent_Click" Text="54" />
                    <asp:Button ID="btnC55" runat="server" visible="false" onclick="btnContinent_Click" Text="55" />
                    <asp:Button ID="btnC56" runat="server" visible="false" onclick="btnContinent_Click" Text="56" />
                    <asp:Button ID="btnC57" runat="server" visible="false" onclick="btnContinent_Click" Text="57" />
                    <asp:Button ID="btnC58" runat="server" visible="false" onclick="btnContinent_Click" Text="58" />
                    <asp:Button ID="btnC59" runat="server" visible="false" onclick="btnContinent_Click" Text="59" />
                    <br />
                    <asp:Button ID="btnC60" runat="server" visible="false" onclick="btnContinent_Click" Text="60" />
                    <asp:Button ID="btnC61" runat="server" visible="false" onclick="btnContinent_Click" Text="61" />
                    <asp:Button ID="btnC62" runat="server" visible="false" onclick="btnContinent_Click" Text="62" />
                    <asp:Button ID="btnC63" runat="server" visible="false" onclick="btnContinent_Click" Text="63" />
                    <asp:Button ID="btnC64" runat="server" visible="false" onclick="btnContinent_Click" Text="64" />
                    <asp:Button ID="btnC65" runat="server" visible="false" onclick="btnContinent_Click" Text="65" />
                    <asp:Button ID="btnC66" runat="server" visible="false" onclick="btnContinent_Click" Text="66" />
                    <asp:Button ID="btnC67" runat="server" visible="false" onclick="btnContinent_Click" Text="67" />
                    <asp:Button ID="btnC68" runat="server" visible="false" onclick="btnContinent_Click" Text="68" />
                    <asp:Button ID="btnC69" runat="server" visible="false" onclick="btnContinent_Click" Text="69" />
                    <br />
                    <asp:Button ID="btnC70" runat="server" visible="false" onclick="btnContinent_Click" Text="70" />
                    <asp:Button ID="btnC71" runat="server" visible="false" onclick="btnContinent_Click" Text="71" />
                    <asp:Button ID="btnC72" runat="server" visible="false" onclick="btnContinent_Click" Text="72" />
                    <asp:Button ID="btnC73" runat="server" visible="false" onclick="btnContinent_Click" Text="73" />
                    <asp:Button ID="btnC74" runat="server" visible="false" onclick="btnContinent_Click" Text="74" />
                    <asp:Button ID="btnC75" runat="server" visible="false" onclick="btnContinent_Click" Text="75" />
                    <asp:Button ID="btnC76" runat="server" visible="false" onclick="btnContinent_Click" Text="76" />
                    <asp:Button ID="btnC77" runat="server" visible="false" onclick="btnContinent_Click" Text="77" />
                    <asp:Button ID="btnC78" runat="server" visible="false" onclick="btnContinent_Click" Text="78" />
                    <asp:Button ID="btnC79" runat="server" visible="false" onclick="btnContinent_Click" Text="79" />
                    <br />
                    <asp:Button ID="btnC80" runat="server" visible="false" onclick="btnContinent_Click" Text="80" />
                    <asp:Button ID="btnC81" runat="server" visible="false" onclick="btnContinent_Click" Text="81" />
                    <asp:Button ID="btnC82" runat="server" visible="false" onclick="btnContinent_Click" Text="82" />
                    <asp:Button ID="btnC83" runat="server" visible="false" onclick="btnContinent_Click" Text="83" />
                    <asp:Button ID="btnC84" runat="server" visible="false" onclick="btnContinent_Click" Text="84" />
                    <asp:Button ID="btnC85" runat="server" visible="false" onclick="btnContinent_Click" Text="85" />
                    <asp:Button ID="btnC86" runat="server" visible="false" onclick="btnContinent_Click" Text="86" />
                    <asp:Button ID="btnC87" runat="server" visible="false" onclick="btnContinent_Click" Text="87" />
                    <asp:Button ID="btnC88" runat="server" visible="false" onclick="btnContinent_Click" Text="88" />
                    <asp:Button ID="btnC89" runat="server" visible="false" onclick="btnContinent_Click" Text="89" />
                    <br />
                    <asp:Button ID="btnC90" runat="server" visible="false" onclick="btnContinent_Click" Text="90" />
                    <asp:Button ID="btnC91" runat="server" visible="false" onclick="btnContinent_Click" Text="91" />
                    <asp:Button ID="btnC92" runat="server" visible="false" onclick="btnContinent_Click" Text="92" />
                    <asp:Button ID="btnC93" runat="server" visible="false" onclick="btnContinent_Click" Text="93" />
                    <asp:Button ID="btnC94" runat="server" visible="false" onclick="btnContinent_Click" Text="94" />
                    <asp:Button ID="btnC95" runat="server" visible="false" onclick="btnContinent_Click" Text="95" />
                    <asp:Button ID="btnC96" runat="server" visible="false" onclick="btnContinent_Click" Text="96" />
                    <asp:Button ID="btnC97" runat="server" visible="false" onclick="btnContinent_Click" Text="97" />
                    <asp:Button ID="btnC98" runat="server" visible="false" onclick="btnContinent_Click" Text="98" />
                    <asp:Button ID="btnC99" runat="server" visible="false" onclick="btnContinent_Click" Text="99" />
                </asp:Panel>
    <asp:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="btnChooseContinent" PopupControlID="pnlChooseContinent" Position="Bottom">
    </asp:PopupControlExtender>
</asp:Content>
