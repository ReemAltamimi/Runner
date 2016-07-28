<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" MasterPageFile="~/Master Page/MasterPage.master" Title="Main Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">

        /*Table style*/
        .auto-style1 {
           position:absolute;
            left:2.5vw;
            top:0vh;
            width: 50vw;
            height:70vh;         
        }
          /*Table cell style*/
        .style2 {
          vertical-align:middle;
            text-align:center;
            border:8px outset #004080 ;
        }
        /*Button text style*/
        .wrap { 
            white-space: normal;
            width: 100px;
            border:5px outset;
        }
     </style>
      </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
      <div>

            <table class="auto-style1">
                <tr>
                    <td style="background-color: #FFFF80" class="style2" >
                        
                        <asp:Button ID="btnScreenTime" runat="server" Height="80" Width="150" Text="Screen Time Statistics" 
                            BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnScreenTime_Click" />
                    
                    </td>
                    <td style="background-color: #FF8080" class="style2">

                         <asp:Button ID="btnPhysicalActivity" runat="server" Height="80" Width="150" Text="Physical Activity Statistics"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPhysicalActivity_Click" />
                                               
                    </td>
                    <td style="background-color: #ffb366" class="style2">

                         <asp:Button ID="btnLeaderBoard" runat="server" Height="80" Width="150" OnClick="btnLeaderboard_Click" Text="Leaderboard" 
                              BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap"/>
                                               
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #AD5BFF" class="style2"> 
                        
                         <asp:Button ID="btnHistory" runat="server" Height="80" Width="150" Text="User History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnHistory_Click" />                     

                    </td>
                    <td style="background-color: #80FF80" class="style2">
                        <asp:Button ID="btnPaVsSt" runat="server" Height="80" Width="150" Text="Physical Activity Vs Screen Time"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" OnClick="btnPaVsSt_Click" />                     
                        

                    </td>
                    <td style="background-color: #4d4dff" class="style2">

                         <asp:Button ID="btnChatRoom" runat="server" OnClick="btnChatRoom_Click" Text="ChatRoom" 
                              Height="80" Width="150" BackColor="#adaaaa" Font-Bold="True" 
                             Font-Names="Aharoni" Font-Size="Medium" CssClass="wrap" />               
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #00cccc" class="style2">
                          <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" 
                              CssClass="wrap" Height="80px" Width="150px" BackColor="#adaaaa"
                               Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" />

                    </td>

                    <td style="background-color: #c68c53" class="style2">
                          <asp:Button ID="btnGame" runat="server" OnClick="btnGame_Click" Text="Game" 
                              CssClass="wrap" Height="80px" Width="150px" BackColor="#adaaaa" 
                              Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium"/>

                    </td>
                    
                    
                    <td style="background-color: #ff3377" class="style2">
                          <asp:Button ID="btnForum" runat="server" Text="Discussion Board" 
                              CssClass="wrap" Height="80px" Width="150px" BackColor="#adaaaa"
                               Font-Bold="True" Font-Names="Aharoni" Font-Size="Medium" OnClick="btnForum_Click" />

                    </td>
                </tr>
            </table>

        </div>
 </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

