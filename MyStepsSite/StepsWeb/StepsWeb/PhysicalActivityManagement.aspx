<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhysicalActivityManagement.aspx.cs" Inherits="MySteps.PhysicalActivityManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physical Activity Management</title>
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
        /*Chart Div Style*/
        .style5 {
            position:fixed;
            top:220px;
        }
        /*table style*/
        .style6 {
            position:fixed;
            left:32%;
            top:350px;

        }
        /*lable style*/
        .style7 {
            position:fixed;
            left:32%;
            top:600px;

        }
     </style>
</head>
<body class="style2">
    <form id="form1" runat="server">
        <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style=" text-align:center; position:fixed; left:4%; top:80px" />

    </div>
        <div class="style3">
            <asp:Label ID="Label1" runat="server" Text="Physical Activity Statistics" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 36%; top:240px" ForeColor="#FFCCCC" Font-Size="XX-Large"></asp:Label>
            <table class="style6">
                <tr>
                    <td>

                        <asp:Label ID="Label2" runat="server" Text="Your Fitbit Data" Font-Names="Comic Sans MS" 
                            Font-Bold="True" Font-Underline="true" ForeColor="#004080"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                         <!-- Show activities on the page -->
    <%
        if (this.Doc != null)
        {
    %>
    <%--Unit System:
    <%=this.Doc["result"]["unitSystem"].InnerText%><br />--%>
    Active Score: 
    <%=this.Doc["result"]["summary"]["activeScore"].InnerText%><br />
    Calories Out: 
    <%=this.Doc["result"]["summary"]["caloriesOut"].InnerText%><br />
    Fairly Active Minutes: 
    <%=this.Doc["result"]["summary"]["fairlyActiveMinutes"].InnerText%><br />
    Lightly Active Minutes: 
    <%=this.Doc["result"]["summary"]["lightlyActiveMinutes"].InnerText%><br />
    Very Active Minutes: 
    <%=this.Doc["result"]["summary"]["veryActiveMinutes"].InnerText%><br />
    Sedentary Minutes: 
    <%=this.Doc["result"]["summary"]["sedentaryMinutes"].InnerText%><br />
    Steps: 
    <%=this.Doc["result"]["summary"]["steps"].InnerText%><br />
    Distances:<br /> ** Detailed in the table **
    <table border="1" style="border-color:#004080; border:solid; position:fixed; left:52%; top: 350px" >
        <tr>
            <th style="text-align:center">
                Activity
            </th>
            <th style="text-align:center">
                Distance
            </th>
        </tr>
        <%
            foreach (System.Xml.XmlNode distance in this.Doc["result"]["summary"]["distances"].ChildNodes)
            {
        %>
        <tr>
            <td style="color:#ff0066">
                <%=distance["activity"].InnerText%>
            </td>
            <td style="text-align:center">
                <%=distance["distance"].InnerText%>
            </td>
        </tr>
        <%
            }
        %>
    </table>
    <%
        }
    %>

                    </td>
                </tr>
            </table>

            
            <asp:Button ID="btnViewChart" runat="server" Width="150" Text="View Chart"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:34%; top:690px" OnClick="btnViewChart_Click" />

        </div>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
            SelectCommand="SELECT * FROM [PhysicalActivityData] WHERE (([UserID] = @UserID) AND ([DateAndTime] = @DateAndTime))">
            <SelectParameters>
                <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                <asp:SessionParameter Name="DateAndTime" SessionField="DateTime" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
 
        <div class="style5" >
        <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" Width="420px" Height="500px" 
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
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
        </asp:Chart>

            <asp:Label ID="Label3" runat="server" Text="" Font-Names="Comic Sans MS" 
                              ForeColor="#ff0066" Font-Size="Small" CssClass="style7"></asp:Label>

            </div> 
        <div style="position:fixed; left:71%; top:220px; width:400px; height:500px; border:8px outset #004080">


            <asp:Image ID="Image2" runat="server"  Width="400px" Height="500px" ImageUrl="~/Images/PA_Kids.png" />

               <a href="Main.aspx" style="position:fixed; left:60%; top:700px">Back to main page</a>


        </div>
   
    </form>
</body>
</html>
