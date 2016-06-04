<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
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
        /*Button text style*/
        .wrap { 
            white-space: normal;
            width: 100px;
            border:5px outset;
        }
     </style>
</head>
<body class="style2">
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:20vw; top:5vh" />

    </div>
 
        <div class="style3">

            <table class="auto-style1">
                <tr>
                    <td style="background-color: #FFFF80" class="style4" >
                        
                        <asp:Button ID="btnScreenTime" runat="server" Height="100" Width="150" Text="Screen Time Statistics" 
                            BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnScreenTime_Click" />
                    
                    </td>
                    <td style="background-color: #FF8080" class="style4">

                         <asp:Button ID="btnPhysicalActivity" runat="server" Height="100" Width="150" Text="Physical Activity Statistics"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPhysicalActivity_Click" />
                                               
                    </td>
                    <td style="background-color: #ffb366" class="style4">

                         <asp:Button ID="btnLeaderBoard" runat="server" Height="100" Width="150" OnClick="btnLeaderboard_Click" Text="Leaderboard" 
                              BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap"/>
                                               
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #AD5BFF" class="style4"> 
                        
                         <asp:Button ID="btnHistory" runat="server" Height="100" Width="150" Text="User History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnHistory_Click" />                     

                    </td>
                    <td style="background-color: #80FF80" class="style4">
                        <asp:Button ID="btnPaVsSt" runat="server" Height="100" Width="150" Text="Physical Activity Vs Screen Time"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPaVsSt_Click" />                     
                        

                    </td>
                    <td style="background-color: #99ccff" class="style4">

                         <asp:Button ID="btnChatRoom" runat="server" OnClick="btnChatRoom_Click" Text="ChatRoom" 
                              Height="100" Width="150" BackColor="#adaaaa" Font-Bold="True" 
                             Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" />               
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #ff3377" class="style4">
                          <asp:Button ID="btnGame" runat="server" OnClick="btnGame_Click" Text="Game" 
                              CssClass="wrap" Height="50px" Width="150px" BackColor="#adaaaa" 
                              Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium"/>

                    </td>
                    
                    <td style="background-color: #ff3377" class="style4">
                          <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" 
                              CssClass="wrap" Height="50px" Width="150px" BackColor="#adaaaa"
                               Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" />

                    </td>
                    <td style="background-color: #ff3377" class="style4">
                          <asp:Button ID="btnHome" runat="server" Text="Home" 
                              CssClass="wrap" Height="50px" Width="150px" BackColor="#adaaaa"
                               Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" OnClick="btnHome_Click" />

                    </td>
                </tr>
            </table>

        </div>

        <div style="position:fixed; top:22vh; width:20vw; height:80vh">


            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PA_Kids.png" Width="300px" Height="480px" />


        </div>

        <div style="position:fixed; left:76vw; top:22vh;  width:20vw; height:80vh">


            <asp:Image ID="Image2" runat="server"   Width="300px" Height="480px" ImageUrl="~/Images/ScreenTime1.png" />


        </div>
       
    </form>
</body>
</html>
