<%@ Page Title="Holyday Request" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="EmployeeWebApp.ManageAccount" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
    <asp:TextBox ID="txtbxHolidayStart" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
    <asp:TextBox ID="txtbxHolidayEnd" runat="server"></asp:TextBox>
    <asp:ImageButton ID="btnCalender" runat="server" Height="22px" ImageUrl="~/icons/calendar_icon.png" OnClick="btnCalender_Click" Width="31px" />

    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="SUBMIT" />

    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="350px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>


    <asp:Literal ID="Ltrl" runat="server"></asp:Literal>


</asp:Content>
