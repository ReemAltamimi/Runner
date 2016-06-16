<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" MasterPageFile="~/Master Page/MasterPage.master" Title="About Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" Runat="Server">
    <div>

            <asp:Label ID="lblAbout" runat="server" Text="Mysteps is a new research initiative focussing on the integration 
                and use of Information and Communication Technologies for fostering Active Lifestyles for Youths. Through this
                website you can track your levels of physical activity and screen time. " 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:fixed; left: 25vw; top:25vh" ></asp:Label>

           <asp:Label ID="lblAbout2" runat="server" Text="Physical Activity Management: " Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:fixed; left: 25vw; top:40vh" ></asp:Label>

           <asp:Label ID="lblAbout3" runat="server" Text="After login to this website and choosing the physical activity management,
               you will be redirected to the fitbit website in order to authorize our website to get your physical activity data. 
               Therefore, you will see your physical workout throughout the day which may motivate you to be more active." 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:fixed; left: 25vw; top:45vh" ></asp:Label>

           <asp:Label ID="lblAbout4" runat="server" Text="Screen Time Management: " Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:fixed; left: 25vw; top:60vh" ></asp:Label>

           <asp:Label ID="lblAbout5" runat="server" Text="After login to this website and choosing the screen time management,
               you will be asked to enter the amount of screen time your kids has spent in the day.  Therefore, it will compare
               this amount with the screen time limit that should your kid met. "
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:fixed; left: 25vw; top:65vh" ></asp:Label>

            <a href="Default.aspx" style="position:fixed; left:60vw; top:85vh">Back to home page</a>
            
            

        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>




   
       


    
