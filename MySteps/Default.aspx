﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Master Page/MasterPage.master" Title="Home Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        /*Table style*/
        .auto-style1 {     
            position:absolute;
            left:2.5vw;
            top: 0vh;
            width: 50vw;
            height:70vh;         
        }
          /*Table cell style*/
        .style2 {            
            vertical-align:middle;
            text-align:center;
            border:8px outset #004080 ;
        }      
     </style>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server" >

       <div>

            <table class="auto-style1">
                <tr>
                    <td style="background-color: #FFFF80" class="style2" >
                        <asp:ImageButton ID="imgBtnAbout" runat="server" ImageUrl="~/Images/infoButton.png" 
                            Height="130px" OnClick="imgBtnAbout_Click" Width="150px" />
                    
                        <br />
                        <asp:Label ID="lblAbout" runat="server" Text="Get some information about our website functions" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="#333333"></asp:Label>
                    
                    </td>
                    <td style="background-color: #FF8080" class="style2">
                        <asp:ImageButton ID="imgBtnLogin" runat="server" ImageUrl="~/Images/LoginButton.png" 
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnLogin_Click" />
                        <br />
                        <asp:Label ID="lblLogin" runat="server" Text="Login to check your physical activity and screen time" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="white"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #AD5BFF" class="style2"> 
                        
                        <asp:ImageButton ID="imgBtnAddUser" runat="server" ImageUrl="~/Images/AddUserButton.png"
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnAddUser_Click"  />
                        <br />
                        <asp:Label ID="lblAddUser" runat="server" Text="Register now to benefit our website functions" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="white"></asp:Label>
                     

                    </td>
                    <td style="background-color: #80FF80" class="style2">
                        <asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="~/Images/HelpButton.png"
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnHelp_Click"/>
                        <br />
                        <asp:Label ID="lblHelp" runat="server" Text="Contact us if you have any enquiry" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="#333333"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>

  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>
