<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Default2" %>

<!doctype html>
<html lang="en-us">

    <head>
       <style type="text/css">
        /*Page style*/
        .style2 {
            background-color:#004080;
        }
           </style>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Unity WebGL Player | _2D v3</title>
    <link rel="stylesheet" href="TemplateData/style.css">
    <link rel="shortcut icon" href="TemplateData/favicon.ico" />
    <script src="TemplateData/UnityProgress.js"></script>
    <script src="Scripts/jquery-2.2.3.js"></script>
  </head>
  <body class="template">
    <p class="header"><span>Unity WebGL Player | </span>_2D v3</p>
    <div class="template-wrap clear">
      <canvas class="emscripten" id="canvas" oncontextmenu="event.preventDefault()" height="600px" width="960px"></canvas>
      <br>
      <div class="logo"></div>
      <div class="fullscreen"><img src="TemplateData/fullscreen.png" width="38" height="38" alt="Fullscreen" title="Fullscreen" onclick="SetFullscreen(1);" /></div>
      <div class="title">_2D v3</div>
    </div>
    <p class="footer">&laquo; created with <a href="http://unity3d.com/" title="Go to unity3d.com">Unity</a> &raquo;</p>
    <script type='text/javascript'>
  var Module = {
    TOTAL_MEMORY: 268435456,
    errorhandler: null,			// arguments: err, url, line. This function must return 'true' if the error is handled, otherwise 'false'
    compatibilitycheck: null,
    dataUrl: "Release/Game.data",
    codeUrl: "Release/Game.js",
    memUrl: "Release/Game.mem",
  };
</script>

<script src="Release/UnityLoader.js"></script>

    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
           
        </asp:ScriptManager>
    
    </div>
    </form>


      <script type="text/javascript">
    
    //
    // called when the menu is set up
    function onMenuReady(){
        console.log("onMenuReady");
        SendMessage('Menu', 'SetUnlocked', <%= UnlockedLevels %>)
    }

	function onPlayerReady( arg )
	{
	    var difficultyMethod = "Setup" + "<%= GetMovement() %>";
	    $.ajax({
	        type: "POST",
	        url: 'Game.aspx/CompleteLevel',
	        data: "{ level : "+level+" }",
	        contentType: 'application/json; charset=utf-8'
	    }).done(function() {
          
	    });

	    SendMessage('hero', difficultyMethod);
	    SendMessage('hero', "SetSteps", <%= Steps %>);
	}

    function onLevelComplete(level){
        $.ajax({
            type: "POST",
            url: 'Game.aspx/CompleteLevel',
            data: "{ level : "+level+" }",
            contentType: 'application/json; charset=utf-8'
        }).done(function() {
          
        });
    }

    function onHeartbeat(timeRemaining){
        $.ajax({
            type: "POST",
            url: 'Game.aspx/DoHeartbeat',
            data: "{ time : "+timeRemaining+" }",
            contentType: 'application/json; charset=utf-8'
        }).done(function() {
          
        });
    }

</script>

  </body>
</html>
