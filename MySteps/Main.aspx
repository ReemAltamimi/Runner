<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <style type="text/css">
        /*Title banner style*/
        .style1 {
            width: 100%;
            height: 200px;
            position:fixed;
            background-color:#adaaaa;
        }
        /*Page style*/
        .style2 {
            background-color:#004080;
        }
        /*Middle div style*/
        .style3 {
             width: 600px;
            height: 480px;
            position: fixed;
            top: 220px;
            left:30%;
        }
        /*Table cell style*/
        .style4 {
            max-width:275px;
            min-width:275px;
            min-height:230px;
            max-height:230px;
            width:275px;
            height:230px;
            vertical-align:middle;
            text-align:center;
            border:8px outset #004080 ;
        }

        /*Table style*/
        .auto-style1 {
            width: 100%;
            height:480px;
        }
        /*Button text style*/
        .wrap { 
            white-space: normal;
            width: 100px;
            border:5px outset;
        }
        .style5 {
            position:fixed; top:420px; left:690px;
        }
        .style6 {
            position:fixed; top:420px; left:530px;
        }

     </style>
</head>
<body class="style2">
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:4%; top:80px" />

    </div>
 
        <div class="style3">

            <table class="auto-style1">
                <tr>
                    <td style="background-color: #FFFF80" class="style4" >
                        
                        <asp:Button ID="btnScreenTime" runat="server" Height="150" Width="150" Text="Screen Time Statistics" 
                            BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnScreenTime_Click" />
                    
                    </td>
                    <td style="background-color: #FF8080" class="style4">

                         <asp:Button ID="btnPhysicalActivity" runat="server" Height="150" Width="150" Text="Physical Activity Statistics"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPhysicalActivity_Click" />
                                               
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #AD5BFF" class="style4"> 
                        
                         <asp:Button ID="btnHistory" runat="server" Height="150" Width="150" Text="User History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnHistory_Click" />                     

                    </td>
                    <td style="background-color: #80FF80" class="style4">
                        <asp:Button ID="btnPaVsSt" runat="server" Height="150" Width="150" Text="Physical Activity Vs Screen Time"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPaVsSt_Click" />                     
                        

                    </td>
                </tr>
                <tr>
                    <td>
                          <asp:Button ID="btnGame" runat="server" OnClick="btnGame_Click" Text="Game" 
                              CssClass="style6" Height="80px" Width="100px" BackColor="#004080" ForeColor="White" />

                    </td>
                    
                    <td>
                          <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" 
                              CssClass="style5" Height="80px" Width="100px" BackColor="#004080" ForeColor="White" />

                    </td>
                </tr>
            </table>

        </div>

        <div style="position:fixed; top:220px; width:400px; height:500px; border:8px outset #004080">


            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PA_Kids.png" Width="400px" Height="500px"  />


        </div>

        <div style="position:fixed; left:71%; top:220px; width:400px; height:500px; border:8px outset #004080">


            <asp:Image ID="Image2" runat="server"  Width="400px" Height="500px" ImageUrl="~/Images/ScreenTime1.png" />


        </div>
       
    </form>
</body>
</html>
