<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registeration.aspx.cs" Inherits="Registeration" MasterPageFile="~/MasterPage1.master" Title="Registeration Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="style1" style="background:#AD5BFF">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="white" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:20vw; top:5vh" />
    </div>
        <div class="style2">

            <asp:Label ID="Label1" runat="server" Text="Please enter your details below to be a member:" Font-Bold ="False"
                 Font-Names="Cooper Black" style ="position:fixed; left: 25vw; top:25vh" ForeColor="#FFFF99"></asp:Label>
            
            <table class="auto-style10">
                <tr>
                    <td class="auto-style6">User Name</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txbUserName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUserName" ErrorMessage="* User Name is required" ForeColor="#FF99CC" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Email</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txbEmail" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbEmail" ErrorMessage="* E-mail is required" ForeColor="#FF99CC" Font-Underline="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" ErrorMessage="* You must enter a valid E-mail" ForeColor="#FF99CC" Font-Underline="True" Width="170px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Password</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txbPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbPassword" ErrorMessage="* Password is required" ForeColor="#FF99CC" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Confirm Password</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txbConfPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbConfPassword" ErrorMessage="* Password confirmation is required" ForeColor="#FF99CC" Font-Underline="True" Width="170px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbPassword" ControlToValidate="txbConfPassword" ErrorMessage="* Both password must be the same" ForeColor="#FF99CC" Font-Underline="True" Width="170px"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Band Code</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txbCodeBand" runat="server" Width="200px"></asp:TextBox>
                    </td>
                     <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbCodeBand" ErrorMessage="* Band Code is required" ForeColor="#FF99CC" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="3">
                        <asp:Label ID="Label2" runat="server" ForeColor="#FFCCCC" Font-Underline="True" Font-Bold="true"></asp:Label>
                      
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnRegister" runat="server" Text="Register" BackColor="#AD5BFF"
                Font-Names="Cooper Black" ForeColor="white"
                style="position:fixed; left:38vw; top:82vh"  Width="140" Height="50px" OnClick="btnRegister_Click" Font-Size="Medium" />

            <a href="Default.aspx" style="position:fixed; left:60vw; top:85vh">Back to home page</a>
        </div>
    </asp:Content>
 
    <asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style6 {
            font-family: Cooper Black;
            width: 142px;
            height: 50px;
            color: #FFFF99;
            font-size:small;
            text-align:center;
        }
        .auto-style7 {
            width: 211px;
            height: 50px;
        }
        .auto-style8 {
            text-align: left;
            height: 50px;
        }
        .auto-style9 {
            font-family:'Comic Sans MS';
            font-size:medium;
            height: 40px;
        }
        .auto-style10{
             width: 40vw;
            height: 30vh;
            position:fixed;
            top: 30vh;
            left:25vw;
        }
    </style>
</asp:Content>

 
