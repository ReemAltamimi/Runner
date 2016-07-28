<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" MasterPageFile="~/Master Page/MasterPage.master" Title="About Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" Runat="Server">
    <div>

            <asp:Label ID="lblAbout" runat="server" Text="Mysteps is a new research initiative focussing on the integration 
                and use of Information and Communication Technologies for fostering Active Lifestyles. Through this
                website you can track your levels of physical activity and screen time. " 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                line-height: 1.5; position:absolute; left: 2vw; top:4vh" ></asp:Label>

         <asp:Label ID="lblAbout2" runat="server" Text="Click the button below to learn more about website pages" Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:absolute; left: 2vw; top:18vh" ></asp:Label>

        <asp:Button ID="btnChart" runat="server" Width="150" Text="About MySteps"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:absolute; left: 3vw; top:28vh" OnClick="btnChart_Click" />        

           <asp:Label ID="lblAbout4" runat="server" Text="Click the button below to view the Fitbit Charge Manual " Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:absolute; left: 2vw; top:40vh" ></asp:Label>

         <asp:Button ID="btnManul" runat="server" Width="150" Text="Fitbit Manual"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:absolute; left: 3vw; top:50vh" OnClick="btnManul_Click" />

            <a href="Default.aspx" style="position:absolute; left:40vw; top:60vh">Back to home page</a>
            
        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>




   
       


    
