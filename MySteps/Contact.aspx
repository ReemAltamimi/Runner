<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" MasterPageFile="~/Master Page/MasterPage.master" Title="Contact Us"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
          /*Table style*/
        .auto-style1 {
             width: 40vw;
            height: 30vh;
            position:fixed;
            top: 40vh;
            left:25vw;
        }
        .auto-style2 {
           font-family: Comic Sans MS;
            width: 142px;
            height: 50px;
            color: #FFFF99;
            font-size:small;
            text-align:center;
        }
        .auto-style3 {
             width: 211px;
            height: 50px;
        }
         .auto-style4 {
            font-family:'Comic Sans MS';
            font-size:medium;
            height: 40px;
        }
   
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

    <div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">

            <asp:Label ID="lblAbout" runat="server" Text="If you experience any technical issue or have 
                any enquiries regarding this website please contact us via email by filling the boxes below:" 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:fixed; left: 25vw; top:30vh" ></asp:Label>

       

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Name</td>
                    <td class="auto-style3"> <asp:TextBox ID="txbUserName" runat="server" Width="200px"></asp:TextBox></td>
                    <td>  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
            ControlToValidate="txbUserName" ValidationGroup="save" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">Email Address</td>
                    <td class="auto-style3"><asp:TextBox ID="txbEmail" runat="server" Width="200px"></asp:TextBox></td>
                    <td>  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
            ControlToValidate="txbEmail" ValidationGroup="save" /></td>
                    <td>  <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator23"
            SetFocusOnError="true" Text="Example: username@gmail.com" ControlToValidate="txbEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
            ValidationGroup="save" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">Subject</td>
                    <td class="auto-style3"><asp:TextBox ID="txbSubject" runat="server" Width="200px"></asp:TextBox></td>
                    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
            ControlToValidate="txbSubject" ValidationGroup="save" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">Your enquiry</td>
                    <td class="auto-style3"><asp:TextBox ID="txbText" runat="server" Width="200px" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
            ControlToValidate="txbText" ValidationGroup="save" /></td>
                </tr>
            </table>

             <asp:Label ID="lblError" runat="server" ForeColor="#FFCCCC" Font-Underline="True"
                style="position:fixed; left:25vw; top:85vh" ></asp:Label>
                   

       <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#80FF80" Font-Bold="true"
           style="position:fixed; left:55vw; top:83vh" Font-Names="Cambria" ForeColor="#004080" 
           Width="140" Height="40px" Font-Size="Medium" OnClick="btnSubmit_Click" ValidationGroup="save" />
                    

           <a href="Default.aspx" style="position:fixed; left:68vw; top:85vh">Back to home page</a>
            </asp:Panel>

        </div>
    
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

