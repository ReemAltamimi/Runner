﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" MasterPageFile="MasterPage1.master" Title="Contact Us"  %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style1" style="background: #80FF80">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:4%; top:80px" />

    </div>
    <div class="style2">

            <asp:Label ID="lblAbout" runat="server" Text="If you experience any technical issue or have 
                any enquiries regarding this website please contact us via email by filling the boxes below:" 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:500px; text-align:justify; 
                position:fixed; left: 32%; top:250px" ></asp:Label>

       

            <table class="auto-style6">
                <tr>
                    <td class="auto-style7">Name</td>
                    <td class="auto-style8"> <asp:TextBox ID="txbUserName" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style7">Email Address</td>
                    <td class="auto-style8"><asp:TextBox ID="txbEmail" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style7">Subject</td>
                    <td class="auto-style8"><asp:TextBox ID="txbSubject" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style7">Your enquiry</td>
                    <td class="auto-style8"><asp:TextBox ID="txbText" runat="server" Width="200px" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style9" colspan="3">
                        <asp:Label ID="lblError" runat="server" ForeColor="#FFCCCC" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style10"> 
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#80FF80" Font-Bold="true"
                Font-Names="Cambria" ForeColor="white" Width="140" Height="40px" Font-Size="Medium" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>

       

           <a href="Default.aspx" style="position:fixed; left:60%; top:700px">Back to home page</a>
            
            

        </div>

</asp:Content> 
    

<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style6 {
            position:fixed; 
            left: 32%; 
            top:350px;
            width:500px;
        }
        .auto-style7 {
           font-family: Comic Sans MS;
            width: 142px;
            height: 50px;
            color: #FFFF99;
            font-size:small;
            text-align:center;
        }
        .auto-style8 {
             width: 211px;
            height: 50px;
        }
         .auto-style9 {
            font-family:'Comic Sans MS';
            font-size:medium;
            height: 40px;
        }
        .auto-style10 {
            text-align:center;
            position:fixed;
            left:48%;
            top:640px;
        }
 
    </style>
</asp:Content>
 
    

