<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type = "text/javascript">
         window.onload = function Confirm() {
             var answer=confirm('Unable to locate your search item. Do you want to search the closest match from your item?');
                if (answer)
             {
             document.getElementById("btnSample").click();
             }
         else
         {
             alert("you responded CANCEL");
             }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
          <asp:Button ID="btnConfirm" runat="server"
                  OnClientClick = "Confirm()"
                  OnClick="OnConfirm" 
                  Text="Raise Confirm"/>
        <asp:Button runat="server" ID="btnSample" Text="" style="display:none;" OnClick="btnSample_Click" />

    
    </div>
    </form>
</body>
</html>
