<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .gridview {
    width: 100%; 
    word-wrap:break-word;
    table-layout: fixed;
}
        .buttonDiv
        {
             width: 100vw;
             height: 20vh;
             background-color:#adaaaa;
             position:fixed;
             left: 0vw;
             top: 0vh;
             text-align:center;
        }
        .tableDiv
        {
            
           position: fixed;
           top: 22vh;
          left:0vw;
          width: 100vw;
           height: 70vh;
           overflow-x:scroll; 
           overflow-y:scroll;
          
        }
        .body
        {
            background-color:peachpuff; 
            overflow-x:hidden; 
            overflow-y:hidden
        }
    </style>
</head>
<body class="body" >
    <form id="form1" runat="server">
    <div class="buttonDiv">
    
        <asp:Button ID="btnUserData" runat="server" Text="Show User Data Table" OnClick="btnUserData_Click" Height="40px" />
    
        <asp:Button ID="btnScrnTimData" runat="server" Text="Show Screen Time Table" OnClick="btnScrnTimData_Click" Height="40px" />
    
        <asp:Button ID="btnPhysicalData" runat="server" Text="Show Physical Activity Table" OnClick="btnPhysicalData_Click" Height="40px" />
        <asp:Button ID="btnGameData" runat="server" Text="Show Game Data Table" OnClick="btnGameData_Click" Height="40px" />
        <asp:Button ID="btnUserLevels" runat="server" Text="Show User Levels Table" OnClick="btnUserLevels_Click" Height="40px" />
    
        <asp:Button ID="btnUserPhysicalScreen" runat="server" Text="Show User, Physical & Screen Data" OnClick="btnUserPhysicalScreen_Click" Height="40px" />
        <asp:Button ID="btnUserGameLevels" runat="server" Text="Show User, Game & Levels Data" OnClick="btnUserGameLevels_Click" Height="40px" />
    
        <asp:Button ID="btnForum" runat="server" Text="Show Forum Data" OnClick="btnForum_Click" Height="40px" />
        <asp:Button ID="btnThread" runat="server" Text="Show Thread Data" OnClick="btnThread_Click" Height="40px" />
    
        <asp:Button ID="btnReminder" runat="server" Text="Send a Reminder" OnClick="btnReminder_Click" Height="40px" />
    
          <asp:Label ID="lblUserID" runat="server" Text="Enter User Id: " style="position:fixed; top:15vh; left:0vw;" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium" ></asp:Label>
       
         <asp:TextBox ID="txbUserId" runat="server" style="position:fixed; top:15vh; left:10vw;"></asp:TextBox>

          <asp:Label ID="lblError" runat="server" Text="Hi" style="position:fixed; top:15vh; left:30vw;" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium" ForeColor="Maroon" ></asp:Label>
    
    </div>
    
     <div class="tableDiv">
          <asp:GridView ID="GridView1" runat="server"
            BorderStyle="Outset" RowStyle-Wrap="true" 
            RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            class="gridview" BorderColor="#333333" BorderWidth="2"
            Font-Name="cambria"
                Font-Size="10pt" Cellpadding="4"
            HeaderStyle-BackColor="#444444"
            HeaderStyle-ForeColor="White"
                AlternatingRowStyle-BackColor="#dddddd">

            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="20px"></RowStyle>
        
          </asp:GridView>
     </div> 
    
       
    </form>
</body>
</html>
