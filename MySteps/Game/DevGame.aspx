﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DevGame.aspx.cs" Inherits="DevGame" %>

<!doctype html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Runner</title>
    <link rel="stylesheet" href="TemplateData/style.css">
    <link rel="shortcut icon" href="TemplateData/favicon.ico" />
    <script src="TemplateData/UnityProgress.js"></script>
  </head>
  <body class="template">
    <p class="header"><span>Runner</span></p>
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
    dataUrl: "Development/Game.data",
    codeUrl: "Development/Game.js",
    memUrl: "Development/Game.mem",
  };
</script>


<script src="Development/UnityLoader.js"></script>

<script type="text/javascript">
	function onPlayerReady( arg )
	{
        var difficultyMethod = "Setup" + "<%= GetMovement() %>";
		SendMessage ('hero', difficultyMethod);
	}
</script>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>

  </body>
</html>
