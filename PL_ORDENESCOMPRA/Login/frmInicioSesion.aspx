<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="PL_ORDENESCOMPRA.Login.frmInicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UAM :: SISTEMA CRUD ORDENES DE COMPRA</title>
    <!-- Meta tag Keywords -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8" />
    <meta name="keywords"
        content="freelancer Sign Up Form Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <!-- //Meta tag Keywords -->
    <link href="//fonts.googleapis.com/css2?family=Noto+Sans+JP:wght@400;500;700;900&display=swap" rel="stylesheet">
    <!--/Style-CSS -->
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <!--//Style-CSS -->

    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" media="all">

</head>
<body>
   <div id="block" class="w3lvide-content" data-vide-bg="images/freelan" data-vide-options="position: 0% 50%">
            <!-- /form -->
            <div class="workinghny-form-grid">
                <div class="main-hotair">
                    <div class="content-wthree">
                        <div class="logo" style="display: flex; justify-content:center; height:100px;">
                            <img src="../Base/assets/images/LogoUAM_W.png" class="img-img-fluid" style="height:100px" />
                        </div>
                        <br />
                        <br />
                        <h1>SISTEMA CRUD ORDENES DE COMPRA</h1>
                        <form action="javascript: inicioSesion()" method="post">
                            <input id="txtUsuario" type="email" class="text" name="text" placeholder="Email de Usuario" required="" autofocus>
                            <input id="txtPassword" type="password" class="password" name="password" placeholder="Password de Usuario" required="" autofocus>
                            <button class="btn" type="submit">Iniciar Sesión</button>
                        </form>
                    </div>
                  
                </div>
           
     
        <!-- copyright-->
        <div class="copyright text-center">
            <p class="copy-footer-29">© 2025 SISTEMA CRUD ORDENES DE COMPRA | UAM</p>
        </div>
       </div>
        <!-- //copyright-->
    </div>
    <!-- //form section start -->
      <!-- js -->
  <script src="js/jquery.min.js"></script>
  <!-- //js -->
  <script src="js/jquery.vide.js"></script>
  <script>
    //    $(document).ready(function () {
    //        $("#block").vide("video/ocean"); // Non declarative initialization
    //
    //        var instance = $("#block").data("vide"); // Get instance
    //        var video = instance.getVideoObject(); // Get video object
    //        instance.destroy(); // Destroy instance
    //    });
  </script>

    <script src="../JavaScript/jquery.cookie.js"></script>
    <script src="../JavaScript/InicioSesion.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</body>
</html>

