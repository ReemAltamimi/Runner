<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leaderboard.aspx.cs" Inherits="Leaderboard" MasterPageFile="~/MasterPage1.master" Title="Leaderboard Page" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style1" style="background:#FFFF80">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:4%; top:80px" />

    </div>

    <style type="text/css">
        .TableCSS
        {
            border-style:none;
            background-color:SeaGreen;
            width: 600px;
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

       <div class="style2">

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

           <asp:ListView ID="ListView1" runat="server">
               


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
                            Text='<%# Eval("UserID")%>'
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
                        <a href="Default.aspx" style="position:fixed; left:60%; top:700px">Back to home page</a>
                       
        </div>

</asp:Content> 