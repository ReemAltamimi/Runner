<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA_Vs_ST.aspx.cs" Inherits="PA_Vs_ST" MasterPageFile="~/Master Page/MasterPage.master" Title="Physical Activity Vs Screen Time" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


      <style type="text/css">
      
        /*Chart Div Style*/
        .style5 {
            position:fixed;
            top:28vh;
            left:24vw;
        }
       
     </style>
          </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

    
 
        <div>

            <asp:Label ID="Label1" runat="server" Text="Physical Activity Versus Screen Time" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 24vw; top:23vh" Font-Underline="True" ForeColor="#FFFF99"></asp:Label>


            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
                SelectCommand="SELECT CAST(PhysicalActivityData.DateAndTime AS DATE) as DateAndTime, 
                ROUND(cast(DailySteps as decimal(10,1))/1000,2) as DailySteps,
                ROUND(cast(RecomSteps as decimal(10,1))/1000,2) as RecomSteps,
                ScreenTimeData.UserScreenDailyAmnt, ScreenTimeData.ScreenDailyLimit
                From PhysicalActivityData
                INNER JOIN ScreenTimeData ON PhysicalActivityData.UserID = ScreenTimeData.UserID
                Where (PhysicalActivityData.UserID = @UserID) AND (CAST(PhysicalActivityData.DateAndTime AS DATE) = @dt) AND (CAST(ScreenTimeData.Date AS DATE) = @dt)">
                <SelectParameters>
                    <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                    <asp:SessionParameter Name="dt" SessionField="LastTime" Type="DateTime" />
                    </SelectParameters>
            </asp:SqlDataSource>

            <asp:Label ID="Label2" runat="server" Text="" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Smaller" style ="position:fixed; left: 23vw; top:83vh" ForeColor="#990000"></asp:Label>


        </div>

        <div class="style5">

        <asp:Chart ID="PA_Versus_ST" runat="server" DataSourceID="SqlDataSource1" Width="700px" Height="350px" BackColor="255, 255, 153">
                <Series>
                    <asp:Series Name="UserScreenAmount" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="UserScreenDailyAmnt" XValueType="DateTime" YValueType="Int32"
                        Color="#cc0000" Legend="Legend1" LegendText="Your Screen Time Amount" IsValueShownAsLabel="True" Label="#VAL hours" Font="Andalus, 8.25pt, style=Bold">
                    </asp:Series>
                    <asp:Series Name="RecommendedScreenAmount" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="ScreenDailyLimit" XValueType="DateTime" YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Screen Time" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL hours" >
                         </asp:Series>
                    <asp:Series Name="UserPhysicalSteps" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="DailySteps" XValueType="DateTime" YValueType="Int32"
                        Color="#ff0000" Legend="Legend1" LegendText="Your Physical Steps" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL thousand Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedSteps" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="RecomSteps" YValueType="Int32" Color="#66ff33" 
                        Legend="Legend1" LegendText="Recommended Steps for Adults" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL thousand Steps" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>

            <a href="Main.aspx" style="position:fixed; left:66vw; top:88vh">Back to Main page</a>
            </div>

      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

