<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" MasterPageFile="~/Master Page/MasterPage.master" Title="Login Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
       
         /*table style in login page style*/
         .auto-style1 {
            width: 40vw;
            height: 30vh;
            position:fixed;
            top: 40vh;
            left:25vw;
        }
          .auto-style2 {
            font-family:Cambria;
        }
          .auto-style3 {
            width: 211px;
        }
        .auto-style4 {
            text-align: left;
        }
         .auto-style6 {
            font-family: Comic Sans MS;
            width: 127px;
            color:#ffccff;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

       <div>

            <asp:Label ID="Label1" runat="server" Text="Please enter your login details below :" Font-Bold ="True"
                 Font-Names="Comic Sans MS" ForeColor="#ffccff" Font-Underline="true" style ="position:fixed; left: 25vw; top:30vh"></asp:Label>
            
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6" >User Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txbUserName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUserName" ErrorMessage="* User Name is required" ForeColor="#FFCCCC" Font-Names="Comic Sans MS" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style6">Password</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txbPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbPassword" ErrorMessage="* Password is required" ForeColor="#FFCCCC" Font-Names="Comic Sans MS" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="Label2" runat="server" ForeColor="#FFCCCC" Font-Bold="True" Font-Names="Comic Sans MS" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="#FF8080"
                Font-Names="Comic Sans MS" Font-Bold="True" ForeColor="White"
                style="position:fixed; left:45vw; top:75vh"  Width="140" Height="50px" 
                OnClick="btnLogin_Click" BorderStyle="Outset" Font-Size="Large" />

           <a href="Default.aspx" style="position:fixed; left:60vw; top:85vh">Back to home page</a>

        </div>

    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

     