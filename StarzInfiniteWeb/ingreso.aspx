<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ingreso.aspx.cs" Inherits="StarzInfiniteWeb.ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <!-- end page-cover --><!--===== INNERPAGE-WRAPPER ====-->
            <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
            <section class="innerpage-wrapper">
            <div id="login" class="innerpage-section-padding">
                <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                    <div class="flex-content">
                        <div class="custom-form custom-form-fields">
                        <h3>Login</h3><p>Bienvenido al sistema de reservas de StarzInfinite, por favor ingresa tus credenciales</p>
              
                            <div class="form-group">
                                <asp:TextBox ID="txtUsuario" class="form-control" ValidationGroup="login1" placeholder="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="login1" runat="server" ControlToValidate="txtUsuario" ForeColor="Blue" Font-Size="Smaller" ErrorMessage="* Ingrese el usuario"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="login2" runat="server" ControlToValidate="txtUsuario" ForeColor="Blue" Font-Size="Smaller" ErrorMessage="* Ingrese el usuario"></asp:RequiredFieldValidator>
                            <span><i class="fa fa-user"></i></span>
                                </div>
                            <div class="form-group">
                                    <asp:TextBox ID="txtPassword" ValidationGroup="login1" TextMode="Password" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="login1" runat="server" ControlToValidate="txtPassword" ForeColor="Blue" Font-Size="Smaller" ErrorMessage="* Ingrese su contraseña"></asp:RequiredFieldValidator>
                            <span><i class="fa fa-lock"></i></span>
                                </div>
                            
                            <asp:Button ID="btnLogin" ValidationGroup="login1" OnClick="btnLogin_Click" class="btn btn-orange btn-block" runat="server" Text="Ingresar" />
                        <div class="other-links">
                            <asp:LinkButton ID="lbtnReset" class="btn btn-grey btn-block rounded-lg shadow-lg" ValidationGroup="login2" OnClick="lbtnReset_Click" runat="server">Olvidaste tu contraseña?</asp:LinkButton>
                            </div><!-- end other-links --></div>
            <!-- end custom-form -->
                        <div class="flex-content-img custom-form-img">
                        <img src="images/PORTADA-STARZ-INFINITE.png" class="img-responsive" alt="registration-img" />
                            </div><!-- end custom-form-img -->
                        </div><!-- end form-content -->
                        </div><!-- end columns -->
                    </div><!-- end row -->
                    </div><!-- end container -->
                </div><!-- end login -->
                </section><!-- end innerpage-wrapper -->
        </asp:View>
        <asp:View ID="View2" runat="server">
            <section class="innerpage-wrapper">
            <div id="login2" class="innerpage-section-padding">
                <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                    <div class="flex-content">
                        <div class="custom-form custom-form-fields">
                        <h3>Login</h3><p>Bienvenido al sistema de reservas de StarzInfinite, por favor ingresa tus credenciales</p>

						        <div class="form-group m-b-15">
                                   <asp:TextBox ID="txtUsuarioC" ReadOnly="true" class="form-control form-control-lg rounded-corner" Height="50px" runat="server"></asp:TextBox>
						        </div>
                                 <div class="form-group m-b-15">
                                   <asp:TextBox ID="txtCI" class="form-control form-control-lg rounded-corner" placeholder="Documento indentidad" Height="50px" runat="server"></asp:TextBox>
						        </div>
						        <div class="form-group m-b-15">
                                    <asp:TextBox ID="txtPasswordA" class="form-control form-control-lg rounded-corner" Height="50px" TextMode="Password" placeholder="Password Anterior" runat="server"></asp:TextBox>
						        </div>
                              <div class="form-group m-b-15">
                                    <asp:TextBox ID="txtPasswordN" class="form-control form-control-lg rounded-corner" Height="50px" TextMode="Password" placeholder="Password Nuevo" runat="server"></asp:TextBox>
						        </div>
						        <div class="login-buttons">
                                    <asp:LinkButton ID="lbtnCambiar" class="btn btn-primary btn-block rounded-lg shadow-lg" OnClick="lbtnCambiar_Click" runat="server">Cambiar</asp:LinkButton>
						        </div><br />
							<div class="login-buttons">
                                    <asp:LinkButton ID="lbtnReset1" class="btn btn-danger btn-block rounded-lg shadow-lg" OnClick="lbtnReset1_Click" OnClientClick="return confirm('Su password sera reseteado a 123 temporalmente, desea continuar?')" runat="server">Resetear</asp:LinkButton>
						        </div><br />
				        </div>
                        <div class="flex-content-img custom-form-img">
                        <img src="images/PORTADA-STARZ-INFINITE.png" class="img-responsive" alt="registration-img" />
                            </div><!-- end custom-form-img -->
                        </div><!-- end form-content -->
                        </div><!-- end columns -->
                    </div><!-- end row -->
                    </div><!-- end container -->
                </div><!-- end login -->
                </section><!-- end innerpage-wrapper -->
        </asp:View>
    </asp:MultiView>
     
</asp:Content>
