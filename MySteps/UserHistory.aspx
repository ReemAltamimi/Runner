<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHistory.aspx.cs" Inherits="UserHistory" MasterPageFile="~/Master Page/MasterPage.master" Title="User History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
    <style type="text/css">
     
        /*Chart1 Div Style*/
        .style5 {
             position:fixed;
           top:22vh;
           left:54vw;
        }
         /*label1 Style*/
        .style7 {
            position:fixed;
            top:23vh;
            left:23vw;

        }
          /*label2 Style*/
        .style8{
            position:fixed;
            top:28vh;
            left:23vw;
            align-content:center;
            
        }
        .wrap {
            white-space: normal;
        }
       
       
     </style>

         </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">


    
        <div>

            

            <asp:Button ID="btnPA" runat="server" Width="150" Height="50" Text="Physical Activity History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Smaller"
                                style="position:fixed; left:32vw; top:75vh" OnClick="btnPA_Click" CssClass="wrap"/>

            <asp:Button ID="btnST" runat="server" Width="150" Height="50" Text="Screen Time History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Smaller"
                                style="position:fixed; left:32vw; top:65vh" OnClick="btnST_Click"/>
            


            <asp:Label ID="Label1" runat="server" Text="" CssClass="style7" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Underline="true" Font-Size="Medium" ></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="" CssClass="style8" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Small" ForeColor="#004080" Height="200px" 
                Width="400px" BorderColor="#FFCCFF" BackColor="#FFCCFF"></asp:Label>
            


            </div>

    

      
       
         <a href="Main.aspx" style="position:fixed; left:33vw; top:85vh">Back to Main page</a>
  

     </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">

     <div class="style5">

                <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" Width="630" Height="450" BackColor="#ffcccc">
                 <Series>
                     <asp:Series Name="UserPhysicalSteps"  XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Physical Steps" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedSteps"  YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Steps for Adults" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisX IntervalOffsetType="Days" IntervalType="Days" Interval="1"></AxisX>
                     </asp:ChartArea>
                 </ChartAreas>
                 
             </asp:Chart>

        </div>


     <div class="style5">

             <asp:Chart ID="ScreenTimeChart" runat="server" Visible="False" Width="630" Height="450" BackColor="#ffff99">
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

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>





