<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style =" border:1px solid #4b7854;box-shadow:0px 2px 5px #4b7854">
        <h1>Login </h1>
        <br>
        <br>
        <p> Employee ID</p>
&nbsp;<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br>
        <br>
        <p> Password</p>
        &nbsp;<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br>
        <br>
        &nbsp;<asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
               
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
