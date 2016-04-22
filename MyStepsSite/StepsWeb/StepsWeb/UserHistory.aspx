<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHistory.aspx.cs" Inherits="UserHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User History</title>
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
            height: 100%;
            position: fixed;
            top: 220px;
            left:30%;
            background:#adaaaa;
        }
        /*Chart1 Div Style*/
        .style5 {
            position:fixed;
            top:220px;
        }
         /*Chart2 Div Style*/
        .style6 {
            position:fixed;
            top:220px;
            left:1050px;
        }
         /*label1 Style*/
        .style7 {
            position:fixed;
            top:270px;
            left:33%;

        }
          /*label2 Style*/
        .style8{
            position:fixed;
            top:340px;
            left:34%;
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

            

            <asp:Button ID="btnPA" runat="server" Width="200" Height="80" Text="Physical Activity History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:35%; top:550px" OnClick="btnPA_Click"/>

            <asp:Button ID="btnST" runat="server" Width="200" Height="80" Text="Screen Time History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:52%; top:550px" OnClick="btnST_Click"/>
            


            <asp:Label ID="Label1" runat="server" Text="" CssClass="style7" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Underline="true" Font-Size="Large" ></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="" CssClass="style8" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="#004080"></asp:Label>
            


            </div>

         <div class="style5">

             <asp:Chart ID="ScreenTimeChart" runat="server" Visible="False" Width="420" Height="500" BackColor="#ffff99">
                 <Series>
                     <asp:Series Name="UserScreenTime"  XValueType="Date" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Screen Time Amount">
                     </asp:Series>
                     <asp:Series Name="ScreenTimeLimit"   Color="Green" 
                        Legend="Legend1" LegendText="Screen Time Limit">
                     </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisX IntervalOffsetType="Days" IntervalType="Days" Interval="1"></AxisX>
                     </asp:ChartArea>
                 </ChartAreas>
                 
             </asp:Chart>

             

             </div>
        <div class="style6">

                <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" Width="400" Height="500" BackColor="#ffcccc">
                 <Series>
                     <asp:Series Name="UserPhysicalSteps"  XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Physical Steps" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedStepsBoys"  YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Steps for Boys" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                <asp:Series Name="RecommendedStepsGirls" YValueType="Int32" Color="Yellow" 
                        Legend="Legend1" LegendText="Recommended Steps for Girls" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisX IntervalOffsetType="Days" IntervalType="Days" Interval="1"></AxisX>
                     </asp:ChartArea>
                 </ChartAreas>
                 
             </asp:Chart>

        </div>
         <a href="Main.aspx" style="position:fixed; left:60%; top:700px">Back to main page</a>
    </form>
</body>
</html>
