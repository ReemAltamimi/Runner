<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .body {
  text-align: center;
  padding: 0 30px;
  
}
        .header
        {
            box-sizing: border-box;
  width: 95vw;
  height: 20vh;
  padding: 1vw;
  text-align: center;
  background-color: yellow;
  margin: 0 auto;
  color: #222;
        }

.content {
  box-sizing: border-box;
  width: 50vw;
  height: 70vh;
  padding: 1vw;
  text-align: center;
  background-color: orange;
  margin: 0 auto;
  color: #222;
   position:relative;
  left:22%;
  top:22%;
}
.leftSide
{
 box-sizing: border-box;
  width: 20vw;
  height: 70vh;
  position:relative;
  left:0%;
  top:22%;
  padding: 1vw;
  text-align: center;
  background-color: orange;
  margin: 0 auto;
  color: #222;
}
.rightSide
{
     box-sizing: border-box;
  width: 20vw;
  height: 70vh;
  padding: 1vw;
  text-align: center;
  background-color: orange;
  margin: 0 auto;
  color: #222;
   position:relative;
  left:74%;
  top:22%;
}
.footer
{
    box-sizing: border-box;
  width: 95vw;
  height: 10vh;
  padding: 1vw;
  text-align: center;
  background-color: seagreen;
  margin: 0 auto;
  color: #222;
}
.middle
{
     box-sizing: border-box;
  width: 95vw;
  height: 70vh;
  padding: 1vw;
  text-align: center;
  background-color: gray;
  margin: 0 auto;
  color: #222;
}

    </style>
</head>
<body class="body">
    <form id="form1" runat="server">

        <div class="header">
        <p>header</p>
            </div>
        <div class="middle">

    <div class="content">
    <p>middle div</p>
    </div>

        <div class="leftSide">
            <p>left panel</p>
        </div>

        <div class="rightSide">
            <p>right panel</p>
        </div>
        </div>
        <div class="footer">
            <p>footer</p>
        </div>
    </form>
</body>
</html>
