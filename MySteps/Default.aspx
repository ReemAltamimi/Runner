<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physical Activity & Screen Time Management</title>
    <style type="text/css">

        /*Title banner style*/
        .style1 {
            width: 100vw;
            height: 20vh;
            position:fixed;
            background-color:#adaaaa;
        }

        /*Page style*/
        .style2 {
            background-color:#004080;
        }

        /*Middle div style*/
        .style3 {
            width: 50vw;
            height: 70vh;
            position: fixed;
            top: 22vh;
            left:24vw;   
        }

        /*Table cell style*/
        .style4 {            
            vertical-align:middle;
            text-align:center;
            border:8px outset #004080 ;
        }

        /*Table style*/
        .auto-style1 {
          
            position:fixed;
            left:24vw;
            top:23vh;
            width: 50vw;
            height:70vh;         
        }
        
        .circle {
            width:40px;
            height:40px;
            -webkit-border-radius: 15px;
            -moz-border-radius: 15px;
            border-radius: 15px; 
            border: solid outset 1px;
        }     

     </style>

</head>


<body class="style2">
    <form id="form1" runat="server">

        
    <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="True"
            style="text-align:center; position:fixed; left:20vw; top:5vh" />
       
        

        <div class="circle" style="position:fixed; top:0vh; left:0vw; background:#FFFF80"></div>
        <div class="circle" style="position:fixed; top:15vh; left:0vw; background:#AD5BFF"></div>
        <div class="circle" style="position:fixed; top:0vh; left:96vw; background:#FF8080"></div>
        <div class="circle" style="position:fixed; top:15vh; left:96vw; background:#80FF80"></div>      
     </div>


     <div style="position:fixed; top:22vh; width:20vw; height:80vh">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PA_Kids.png" Width="300px" Height="480px" />
     </div>
 
     <div class="style3">

            <table class="auto-style1">
                <tr>
                    <td style="background-color: #FFFF80" class="style4" >
                        <asp:ImageButton ID="imgBtnAbout" runat="server" ImageUrl="~/Images/infoButton.png" 
                            Height="130px" OnClick="imgBtnAbout_Click" Width="150px" />
                    
                        <br />
                        <asp:Label ID="lblAbout" runat="server" Text="Get some information about our website functions" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="#333333"></asp:Label>
                    
                    </td>
                    <td style="background-color: #FF8080" class="style4">
                        <asp:ImageButton ID="imgBtnLogin" runat="server" ImageUrl="~/Images/LoginButton.png" 
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnLogin_Click" />
                        <br />
                        <asp:Label ID="lblLogin" runat="server" Text="Login to check your physical activity and screen time" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="white"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #AD5BFF" class="style4"> 
                        
                        <asp:ImageButton ID="imgBtnAddUser" runat="server" ImageUrl="~/Images/AddUserButton.png"
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnAddUser_Click"  />
                        <br />
                        <asp:Label ID="lblAddUser" runat="server" Text="Register now to benefit our website functions" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="white"></asp:Label>
                     

                    </td>
                    <td style="background-color: #80FF80" class="style4">
                        <asp:ImageButton ID="imgBtnHelp" runat="server" ImageUrl="~/Images/HelpButton.png"
                            Height="130px" style="text-align: center" Width="150px" OnClick="imgBtnHelp_Click"/>
                        <br />
                        <asp:Label ID="lblHelp" runat="server" Text="Contact us if you have any enquiry" 
                            Width="250px" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="#333333"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>
        <div style="position:fixed; left:76vw; top:22vh;  width:20vw; height:80vh">
            <asp:Image ID="Image2" runat="server"  Width="300px" Height="480px" ImageUrl="~/Images/ScreenTime1.png" />
        </div>
    </form>
</body>
</html>
