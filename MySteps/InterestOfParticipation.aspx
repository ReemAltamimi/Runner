<%@ Page Title="Participation Form Page" Language="C#" MasterPageFile="~/Master Page/MasterPage.master" AutoEventWireup="true" CodeFile="InterestOfParticipation.aspx.cs" Inherits="InterestOfParticipation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
    <style type="text/css">

          /*div1 style*/
        .div1 {
          width: 50vw;
          height: 70vh;
          position:absolute;
          left:0vw;
          top: 0vh;
          background:#adaaaa;
          
        }
            /*div2 style*/
        .div2 {
          width: 45vw;
            height: 70vh;
            position: absolute;
            top: 0vh;
            left: 52vw;
            background:#adaaaa;
        }
        /*Labels Div*/
        .lablDiv
        {
            text-align:center;
        }

        /*Table style*/
         .auto-style1 {
            width:50vw;
            height:30vh;
            position:absolute;
            top: 25vh;
            left:4vw;
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
            font-family: Cambria;
            width: 180px;
            color:black;
           text-align:center;
        }
         .posterFrame
         {
             vertical-align: middle;
             min-height: 100%;
             min-width: 100%;
            max-height: 100%;
            max-width: 100%;
         }
       
         </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
     
    <div class="div1">

        <div class="lablDiv">
            <asp:Label ID="lblHead" runat="server" 
            Text="Registration Form for Interest of Participation" ForeColor="White" 
            Font-Names="Cambria" Font-Size="Larger" style="display:inline-block; 
             padding-top:25px; text-align:center" Width="500px" Font-Bold="True"
              Height="50px" ></asp:Label>
         

         <asp:Label ID="lbl2" runat="server" 
            Text="Please fill out the form below if you are interested in participating in our research experiment
                       to increase your engagement in technologies that promote physical activity and facilitate healthy lifestyle" 
                      ForeColor="Black" style="text-align:justify;"
            Font-Names="Cambria" Font-Size="medium" Width="550px"></asp:Label>

        </div>

          <table class="auto-style1">

                <tr>
                    <td class="auto-style6" >Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txbUserName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUserName" ErrorMessage="* User Name is required" ForeColor="#FFCCCC" Font-Names="Comic Sans MS" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style6">Email</td>
                   <td class="auto-style3">
                        <asp:TextBox ID="txbEmail" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbEmail" ErrorMessage="* E-mail is required" ForeColor="#FFCCCC" Font-Underline="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" ErrorMessage="* You must enter a valid E-mail" ForeColor="#FFCCCC" Font-Underline="True" Width="170px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
              <tr>
                    <td class="auto-style6" >Are you a university of Newcastle </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="dnlClassification" runat="server">
                            <asp:ListItem Enabled="true" Text="" Value="0" />
                             <asp:ListItem Text="Staff" Value="1" />
                             <asp:ListItem Text="Student" Value="2" />
                             <asp:ListItem Text="Visitor" Value="3" />
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dnlClassification"
                            InitialValue="0"  ErrorMessage="*required" ForeColor="#FFCCCC" Font-Names="Comic Sans MS" Font-Underline="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="Label2" runat="server" ForeColor="#FFCCCC" Font-Bold="True" Font-Names="Comic Sans MS" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
            </table>
         <asp:Button ID="btnRegister" runat="server" Text="Register" BackColor="#AD5BFF"
                Font-Names="Cooper Black" ForeColor="white"
                style="position:absolute; left:15vw; top:60vh"  Width="140" Height="30px" OnClick="btnRegister_Click" Font-Size="Small" />

            <a href="Default.aspx" style="position:absolute; left:30vw; top:60vh">Back to home page</a>
        
    </div>

      <div class="div2">
        
         <iframe src="RecruitmentPoster.pdf" class="posterFrame" runat="server"></iframe>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
   
  

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

