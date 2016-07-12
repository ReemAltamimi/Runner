<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leaderboard.aspx.cs" Inherits="Leaderboard" MasterPageFile="~/Master Page/MasterPage.master" Title="Leaderboard Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <style type="text/css">
        .TableCSS
        {
            border-style:none;
            background-color:SeaGreen;
            width: 600px;
            align-items:center;
            position:fixed; 
            top:35vh;
            left:27vw;
            }
        .TableHeader
        {
            background-color:MediumSeaGreen;
            color:Snow;
            font-size:large;
            font-family:Verdana;
            height:45px;
            text-align:center;
            }    
        .TableData
        {
            background-color:DarkSeaGreen;
            color:Snow;
            font-family:Courier New;
            font-size:medium;
            font-weight:bold;
            height:30px;
            }  
        .TablePager
        {
            background-color:Green;
            height:45px;
            }                              
        .PagerButtonCSS
        {
            color:DarkGreen;
            height:35px;
            font-weight:bold;
            font-family:Comic Sans MS;
            }    
        .NumericButtonCSS
        {
            font-size:x-large;
            font-family:Courier New;
            color:Snow;
            font-family:Comic Sans MS;
            font-weight:bold;
            }  
        .CurrentPageLabelCSS
        {
            font-size:xx-large;
            font-family:Comic Sans MS;
            color:White;
            font-weight:bold;
            } 
        .NextPreviousButtonCSS
        {
            font-size:large;
            font-family:Courier New;
            color:LawnGreen;
            font-weight:bold;
            }                                         
    </style>

      </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

       <div>

           <asp:Label ID="lblAbout" runat="server" Text="Check the list below to see your friends and their numbers of steps today" 
                Font-Bold ="true" Font-Names="Cambria" ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:fixed; left: 25vw; top:30vh" ></asp:Label>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

           <asp:ListView ID="ListView1" runat="server">
               


              <LayoutTemplate>
                <table runat="server" class="TableCSS">
                    <tr runat="server" class="TableHeader">
                        <td runat="server">User</td>
                        <td runat="server">Steps</td>
                        <td runat="server">Game Level</td>
                    </tr>
                    <tr id="ItemPlaceholder" runat="server">
                    </tr>
                    <tr runat="server" class="TablePager">
                        <td runat="server" colspan="2">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField 
                                        ButtonType="Button" 
                                        ShowFirstPageButton="true"
                                        ShowPreviousPageButton="false"
                                        ShowNextPageButton="true"
                                        ButtonCssClass="PagerButtonCSS"
                                        />
                                    <asp:NumericPagerField 
                                        NumericButtonCssClass="NumericButtonCSS"
                                        NextPreviousButtonCssClass="NextPreviousButtonCSS"
                                        CurrentPageLabelCssClass="CurrentPageLabelCSS"
                                        />
                                    <asp:NextPreviousPagerField 
                                        ButtonType="Button"
                                        ShowNextPageButton="false"
                                        ShowLastPageButton="true"
                                        ButtonCssClass="PagerButtonCSS"
                                        />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>

               <ItemTemplate>
                <tr class="TableData">
                    <td align="center">
                        <asp:Label 
                            ID="Label1"
                            runat="server"
                            Text='<%# Eval("UserName")%>'
                            >
                        </asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label 
                            ID="Label2"
                            runat="server"
                            Text='<%# Eval("DailySteps")%>'
                            >
                        </asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label 
                            ID="Label3"
                            runat="server"
                            Text='<%# Eval("UnLockedLevel")%>'
                            >
                        </asp:Label>
                    </td>
                </tr>                
            </ItemTemplate>
           </asp:ListView>


              <asp:ListView ID="ListView2" runat="server">
               


              <LayoutTemplate>
                <table runat="server" class="TableCSS">
                    <tr runat="server" class="TableHeader">
                        <td runat="server">User</td>
                        <td runat="server">Steps</td>
                    </tr>
                    <tr id="ItemPlaceholder" runat="server">
                    </tr>
                    <tr runat="server" class="TablePager">
                        <td runat="server" colspan="2">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField 
                                        ButtonType="Button" 
                                        ShowFirstPageButton="true"
                                        ShowPreviousPageButton="false"
                                        ShowNextPageButton="true"
                                        ButtonCssClass="PagerButtonCSS"
                                        />
                                    <asp:NumericPagerField 
                                        NumericButtonCssClass="NumericButtonCSS"
                                        NextPreviousButtonCssClass="NextPreviousButtonCSS"
                                        CurrentPageLabelCssClass="CurrentPageLabelCSS"
                                        />
                                    <asp:NextPreviousPagerField 
                                        ButtonType="Button"
                                        ShowNextPageButton="false"
                                        ShowLastPageButton="true"
                                        ButtonCssClass="PagerButtonCSS"
                                        />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>

               <ItemTemplate>
                <tr class="TableData">
                    <td align="center">
                        <asp:Label 
                            ID="Label1"
                            runat="server"
                            Text='<%# Eval("UserName")%>'
                            >
                        </asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label 
                            ID="Label2"
                            runat="server"
                            Text='<%# Eval("DailySteps")%>'
                            >
                        </asp:Label>
                    </td>
                </tr>                
            </ItemTemplate>
           </asp:ListView>

                       <a href="Main.aspx" style="position:fixed; left:60vw; top:85vh">Back to Main page</a>
        </div>



    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>


