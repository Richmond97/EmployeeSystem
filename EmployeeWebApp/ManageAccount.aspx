<%@ Page Title="Holyday Request" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="EmployeeWebApp.ManageAccount" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Holiday Booking" ForeColor="Blue" Height="136px" Width="1215px" Font-Size="55pt"></asp:Label>
    </p>
    <p>

    <asp:Label ID="Label1" runat="server" Text="   From      "></asp:Label>
    <asp:TextBox ID="txtbxHolidayStart" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="To    "></asp:Label>
    <asp:ImageButton ID="btnCalenderGo" runat="server" Height="28px" ImageUrl="~/icons/calendar_icon.png" Width="39px" OnClick="calenderGo_Click" />
    <asp:TextBox ID="txtbxHolidayEnd" runat="server"></asp:TextBox>
    <asp:ImageButton ID="btnReturn" runat="server" Height="28px" ImageUrl="~/icons/calendar_icon.png" OnClick="btnReturn_Click" Width="39px" />

    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="SUBMIT" BackColor="#4A30DE" BorderStyle="None" ForeColor="White" />

    
  

        <br />
    </p>
    <table class="nav-justified">
        <tr>
            <td style="width: 307px"> 
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="220px" NextPrevFormat="ShortMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="282px" BorderStyle="Solid" CellSpacing="1">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
        
            </td>
            <td style="width: 314px">
    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="220px" NextPrevFormat="ShortMonth" Width="292px" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>
                <asp:Button ID="btnPersonalDet" runat="server" BackColor="#2616E9" BorderColor="White" BorderStyle="None" ForeColor="White" OnClick="btnPersonalDet_Click" Text="VIEW MY PERSONAL DETAILS " Width="386px" />
                <asp:Button ID="btnViewReq" runat="server" BackColor="#2616E9" BorderColor="White" BorderStyle="None" ForeColor="White" OnClick="btnViewReq_Click" Text="VIEW MY REQUEST" Width="386px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GridViewrRequest" runat="server" BorderStyle="Double" CaptionAlign="Top" Height="179px" Width="660px" AutoGenerateColumns ="true">
    </asp:GridView>
        <div runat="server" id="AlertBox" class="alertBox" Visible="false">
    <div runat="server" id="AlertBoxMessage"></div>
    <button onclick="closeAlert.call(this, event)">Ok</button>
</div>

    
</asp:Content>
