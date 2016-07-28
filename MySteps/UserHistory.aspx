<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHistory.aspx.cs" Inherits="UserHistory" MasterPageFile="~/Master Page/MasterPage.master" Title="User History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
    <style type="text/css">  
        .chartDiv
        {
            position:absolute;
            top:0;
            left:0; 
            width:50vw;
            height:70vh;
            text-align:center;       
               
        }
    
        .Chart
        {
           /* position:absolute; 
            top:0; 
            left:0; */
            position: relative;
            top: 50%;
            transform: translateY(-50%);
            
        }
        
         /*label1 Style*/
        .style7 {
            position:relative;
            top:5vh;
            left:1vw;
             text-align:center;
            vertical-align:middle;
        }
          /*label2 Style*/
        .style8{
            position:relative;
            top:10vh;
            left:1vw;
            display:table-cell;
            text-align:center;
            vertical-align:middle; 
            line-height:1.5;  
        }
        .wrap {
            white-space: normal;
        }
       
       
     </style>

         </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">

       <asp:Label ID="Label1" runat="server" Text="" CssClass="style7" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Medium" ></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="" CssClass="style8" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Small" ForeColor="#004080" 
                 BorderColor="#FFCCFF" BackColor="#FFCCFF" Visible="true"
                 Width="250px" Height="350px"></asp:Label>
            




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

    
    <div class="chartDiv"> 
                <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" BackColor="#ffcccc" CssClass="Chart"
                     Width="600px" Height="450px">
                 <Series>
                     <asp:Series Name="UserPhysicalSteps"  XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Physical Steps" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedSteps"  YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Number of Steps for Adults" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisX IntervalOffsetType="Days" IntervalType="Days" Interval="1"></AxisX>
                     </asp:ChartArea>
                 </ChartAreas>
                  <Legends>
                    <asp:Legend Name="Legend1" Docking="Bottom">
                    </asp:Legend>
                </Legends>
             </asp:Chart>
      

    </div>
   <div class="chartDiv">

             <asp:Chart ID="ScreenTimeChart" runat="server" Visible="False" CssClass="Chart" BackColor="#ffff99"
                 Width="600px" Height="450px" >
                 <Series>
                     <asp:Series Name="UserScreenTime"  XValueType="Date" YValueType="Single"
                        Color="Red" Legend="Legend1" LegendText="Your Screen Time Amount" IsValueShownAsLabel="True" Label="#VAL hours">
                     </asp:Series>
                     <asp:Series Name="ScreenTimeLimit"   Color="Green" 
                        Legend="Legend1" LegendText="Screen Time Limit" IsValueShownAsLabel="True" Label="#VAL hours">
                     </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisX IntervalOffsetType="Days" IntervalType="Days" Interval="1"></AxisX>
                     </asp:ChartArea>
                 </ChartAreas>
                   <Legends>
                    <asp:Legend Name="Legend1" Docking="Bottom">
                    </asp:Legend>
                </Legends>
             </asp:Chart>
    
     </div>
     </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">

       <div>

            

            <asp:Button ID="btnPA" runat="server" Width="150" Height="50" Text="Physical Activity History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Smaller"
                                style="position:absolute; left:4vw; top:30vh" OnClick="btnPA_Click" CssClass="wrap"/>

            <asp:Button ID="btnST" runat="server" Width="150" Height="50" Text="Screen Time History"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Smaller"
                                style="position:absolute; left:4vw; top:40vh" OnClick="btnST_Click"/>
            


         
            </div>

    

      
       
         <a href="Main.aspx" style="position:absolute; left:5vw; top:50vh">Back to Main page</a>
  



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>





