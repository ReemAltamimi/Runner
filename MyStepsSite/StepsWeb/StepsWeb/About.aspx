<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" MasterPageFile="MasterPage1.master" Title="About Page" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style1" style="background:#FFFF80">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:4%; top:80px" />

    </div>
       <div class="style2">

            <asp:Label ID="lblAbout" runat="server" Text="Mysteps is a new research initiative focussing on the integration 
                and use of Information and Communication Technologies for fostering Active Lifestyles for Youths. Through this
                website parents and caregivers can track the levels of physical activity and screen time of their kids. " 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:500px; text-align:justify; 
                position:fixed; left: 32%; top:250px" ></asp:Label>

           <asp:Label ID="lblAbout2" runat="server" Text="Physical Activity Management: " Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:fixed; left: 32%; top:380px" ></asp:Label>

           <asp:Label ID="lblAbout3" runat="server" Text="After login to this website and choosing the physical activity management,
               you will be redirected to the fitbit website in order to authorize our website to get your physical activity data. 
               Therefore, you will see your kid's physical workout throughout the day which will help you know the levels of his/her
               physical activity and motivate him/her to be active." 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:500px; text-align:justify; 
                position:fixed; left: 32%; top:410px" ></asp:Label>

           <asp:Label ID="lblAbout4" runat="server" Text="Screen Time Management: " Font-Bold ="true" 
               ForeColor="#FFFF80" Font-Underline="true" Font-Names="Cambria" Font-Size="Large" style ="text-align:justify; 
                position:fixed; left: 32%; top:560px" ></asp:Label>

           <asp:Label ID="lblAbout5" runat="server" Text="After login to this website and choosing the screen time management,
               you will be asked to enter the amount of screen time your kids has spent in the day.  Therefore, it will compare
               this amount with the screen time limit that should your kid met. "
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:500px; text-align:justify; 
                position:fixed; left: 32%; top:590px" ></asp:Label>

                        <a href="Default.aspx" style="position:fixed; left:60%; top:700px">Back to home page</a>
            
            

        </div>

</asp:Content> 
    
