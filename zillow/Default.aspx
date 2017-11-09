<%@ Page Title="ZillowAPI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Zillow" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div runat="server" id="divStep1">
        <table style="width: auto">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <h2>GetSearchResults API</h2>
                </td>
            </tr>
            <tr>
                <td>
                    Address
                </td>
                <td>
                    <asp:TextBox ID="tbAddress" runat="server" Width="375px" Text="1835 73rd Ave NE" style="font-size: 1.4em;" />
                </td>
            </tr>
            <tr>
                <td>
                    ZipCode OR City, State
                </td>
                <td>
                    <asp:TextBox ID="tbZipCodeORCityState" runat="server" Text="98039" Width="100px" style="font-size: 1.4em;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="GetZestimate" CssClass="button"
                        onclick="BtnSearchClick" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <br/><br/>



<div runat="server" id="divStep2Success">
    <div class="contentbox">
        Zillow Results for: <asp:Label runat="server" ID="lblQuery2"/>
        <table style="width: auto;">
            <tr>
                <td>Zestimate®</td>
                <td><asp:Label runat="server" ID="Estimate" CssClass="tblValue"/>&nbsp;<span class="lowandhigh">{<asp:Label runat="server" ID="ValueRangeLow" />
                - <asp:Label runat="server" ID="ValueRangeHigh"/>}</span></td></tr>
                            <tr><td>LastUpdated</td><td><asp:Label runat="server" ID="LastUpdated" CssClass="tblValue"/></td></tr>

            <tr><td>Street</td><td><asp:Label runat="server" ID="Street" CssClass="tblValue"/></td></tr>
            <tr><td>City</td><td><asp:Label runat="server" ID="City" CssClass="tblValue"/></td></tr>
            <tr><td>State</td><td><asp:Label runat="server" ID="State" CssClass="tblValue"/></td></tr>
            <tr><td>ZipCode</td><td><asp:Label runat="server" ID="ZipCode" CssClass="tblValue"/></td></tr>
            <tr><td>Longitude</td><td><asp:Label runat="server" ID="Longitude" CssClass="tblValue"/></td></tr>
            <tr><td>Latitude</td><td><asp:Label runat="server" ID="Latitude" CssClass="tblValue"/></td></tr>
             <tr>
                 <td>&nbsp;</td>
                 <td><asp:Button ID="Button1" runat="server" Text="GetSearchResults" CssClass="button" onclick="BtnSearchClick" /></td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td><asp:Button ID="Button2" runat="server" Text="GetChart" CssClass="button" onclick="BtnGetChartClick" /></td>

             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td><asp:Button ID="Button3" runat="server" Text="GetComps" CssClass="button" onclick="BtnSearchClick" /></td>                 
             </tr>
           <%-- <tr><td>&nbsp;</td><td><asp:HyperLink runat="server" ID="LinktoMap" Text="Map" Target="_blank" CssClass="tblValue" /></td></tr>
            <tr><td>&nbsp;</td><td><asp:HyperLink runat="server" ID="LinktoHomeDetails" Text="Home Details" Target="_blank"  CssClass="tblValue"/></td></tr>
            <tr><td>&nbsp;</td><td><asp:HyperLink runat="server" ID="LinktoGraphsAndData" Text=" Graphs And Data" Target="_blank"  CssClass="tblValue"/></td></tr>
            <tr><td>&nbsp;</td><td><asp:HyperLink runat="server" ID="LinktoComparables" Text="Comparables" Target="_blank"  CssClass="tblValue"/></td></tr>--%>
    </table>
   </div>
</div>

<div runat="server" id="divStep1Success">
    <div class="contentbox">
        Zillow Chart for: <asp:Label runat="server" ID="Address"/>       
        <tr><td>Chart</td><td><asp:Image  ID="Image1" runat="server"  /></td></tr>
       <%-- <tr><td>Graph and Data</td><td><asp:Image  ID="Image2" runat="server"  /></td></tr>--%>
   </div>
</div>


<div runat="server" id="divStep2Failure">Return Message: <asp:Label runat="server" ID="lblFailureMessage2" CssClass="tblValue"/></div>

<div runat="server" id="divStep1Failure">Return Message: <asp:Label runat="server" ID="lblFailureMessage1" CssClass="tblValue"/></div>
</asp:Content>
