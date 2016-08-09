<%@ Page Title="Information Statement Page" Language="C#" MasterPageFile="~/Master Page/MasterPage.master" AutoEventWireup="true" CodeFile="InfoStatement.aspx.cs" Inherits="InfoStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">

          /*div1 style*/
        .div1 {
            position: absolute;
            top: 0vh;
            left: 0vw;
            background:#adaaaa;
            height:70vh;
            width:97vw;
         }
         .infoFrame
         {
             vertical-align: middle;
             min-height: 90%;
             min-width: 100%;
            max-height: 90%;
            max-width: 100%;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
    
      <div class="div1">
        
         <iframe src="Information Statement.pdf" class="infoFrame" runat="server"></iframe>
           <a href="Default.aspx" style="position:absolute; left:44vw; top:65vh; font-weight:bold">Back to home page</a>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

