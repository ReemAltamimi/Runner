<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhysicalActivityManagement.aspx.cs" Inherits="MySteps.PhysicalActivityManagement" MasterPageFile="~/Master Page/MasterPage.master" Title="Physical Activity Management Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
     
        /*Chart Div Style*/
        .style5 {
            position:fixed;
           top:22vh;
        }

     </style>
   </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

    
        <div>
            <asp:Label ID="Label1" runat="server" Text="Physical Activity Statistics" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 25vw; top:30vh" ForeColor="#FFCCCC" Font-Size="XX-Large"></asp:Label>
            
             <asp:Label ID="Label4" runat="server" Text="Based on your Fitbit data" Font-Names="Comic Sans MS" 
                            Font-Bold="True" ForeColor="#004080" Font-Underline="true"
                  style="position:fixed; left: 25vw; top:42vh">
                  </asp:Label>

              <asp:Label ID="Label2" runat="server" Text="" Font-Names="Comic Sans MS" 
                            Font-Bold="True" ForeColor="#004080"
                  style="position:fixed; left: 25vw; top:45vh">

              </asp:Label>

     
            
            <asp:Button ID="btnViewChart" runat="server" Width="150" Text="View Chart"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:30vw; top:84vh" OnClick="btnViewChart_Click" />

             <asp:Button ID="btnSync" runat="server" Width="150" Text="My Physical Workout"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:45vw; top:84vh" OnClick="btnSync_Click" />
            <!--
                     <asp:Button ID="Button1" runat="server" Width="150" Text="ResetToken"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:45vw; top:44vh" OnClick="resetToken" />
            
                     <asp:Button ID="Button2" runat="server" Width="150" Text="RefreshToken"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:30vw; top:44vh" OnClick="refreshToken" />
                -->
                  <asp:Label ID="Label3" runat="server" Text="" Font-Names="Comic Sans MS" 
                              ForeColor="#ff0066" Font-Size="Small" 
                style ="position:fixed; left: 25vw; top:62vh" ></asp:Label>

        </div>
      <a href="Main.aspx" style="position:fixed; left:60vw; top:85vh">Back to Main page</a>
   

     </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">

    
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
            SelectCommand="SELECT * FROM [PhysicalActivityData] WHERE (([UserID] = @UserID) AND ([DateAndTime] = @DateAndTime))">
            <SelectParameters>
                <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                <asp:SessionParameter Name="DateAndTime" SessionField="LastTime" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
 
        <div class="style5" >
        <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" Width="300px" Height="480px" 
            DataSourceID="SqlDataSource1" BackColor="#ffcccc">
            <Series>
                <asp:Series Name="UserPhysicalSteps" XValueMember="DateAndTime" YValueMembers="DailySteps" XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Physical Steps" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedStepsBoys" XValueMember="DateAndTime" YValueMembers="RecomStepsBoys" YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Steps for Boys" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                <asp:Series Name="RecommendedStepsGirls" XValueMember="DateAndTime" YValueMembers="RecomStepsGirls" YValueType="Int32" Color="Yellow" 
                        Legend="Legend1" LegendText="Recommended Steps for Girls" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                    <asp:Legend Name="Legend1" Docking="Bottom">
                    </asp:Legend>
                </Legends>
        </asp:Chart>

  </div> 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>