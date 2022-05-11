<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="soporte.aspx.cs" Inherits="StarzInfiniteWeb.soporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        	
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>

    <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
    <asp:ObjectDataSource ID="odsVideos1" runat="server" SelectMethod="PR_GET_NOTIFICACIONES" TypeName="StarzInfiniteWeb.datos_bd_local">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsVideos" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="VIDEO TUTORIAL" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
    </asp:ObjectDataSource>
<!-- begin #content -->
 <div class="container">
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
    <%--<div class="row shadow col-12 rounded shadow m-5">
        <div class="row col-12 shadow rounded m-10">
            <div class="col-12"><br /><br /> 
            <asp:Image ID="Image6" ImageUrl="~/iconos/icono-soporte.png" runat="server" /><asp:Label ID="Label1" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Large" Text="Soporte"></asp:Label><br />
                <hr />
                <br />
                <asp:Image ID="Image2" CssClass="offset-4" ImageUrl="~/iconos/imagen-soporte.png" runat="server" />
                <br /><br /><br />
                <asp:Label ID="Label2" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Small" Text="Elija una de las opciones para brindarle asistencia."></asp:Label>
                <br /><br /><br />
                <asp:Label ID="Label3" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Small" Text="Necesito soporte en:"></asp:Label>
                <br /><br />
                <asp:RadioButtonList ID="rblOpSoporte" CssClass="rounded shadow-sm offset-4" BackColor="WhiteSmoke" runat="server">
                    <asp:ListItem>Emision de una reserva</asp:ListItem>
                    <asp:ListItem>Cancelacion de un boleto</asp:ListItem>
                    <asp:ListItem>Cambio de itinerario</asp:ListItem>
                    <asp:ListItem>Pago de reserva</asp:ListItem>
                    <asp:ListItem>Devoluciones</asp:ListItem>
                </asp:RadioButtonList>
                <br /><br /><br />
                <asp:Label ID="Label4" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Small" Text="Describe tu caso para saber mas al respecto"></asp:Label>
                <br />
                <asp:TextBox ID="txtDescripcion" CssClass="form-control shadow text-center" TextMode="MultiLine" Font-Size="Small"  Height="137px" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnEnviar" class="btn btn-primary btn-block rounded-lg shadow-lg"  Height="60px" runat="server" Text="Enviar solicitud" />
                <br /><br /><br />
            </div>
            </div>--%>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side">
            <asp:Image ID="Image1" ImageUrl="~/iconos/icono-soporte.png" runat="server" /><asp:Label ID="Label10" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Large" Text="Videos tutoriales"></asp:Label><br />
                <hr />
                <asp:Repeater ID="Repeater1" DataSourceID="odsVideos" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <asp:Label ID="Label5" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Small" Text='<%# Eval("descripcion") %>'></asp:Label>
                        </div>
                        <div class="row">
                            <iframe class="shadow-sm rounded"  height="250" src='<%# Eval("valor_caracter").ToString().Replace( "watch?v=", "embed/") %>' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="btnVerTodos" class="btn btn-orange"  OnClick="btnVerTodos_Click"  Height="60px" runat="server" Text="Ver todos los tutoriales" />

            </div>
        </div>
  
    
  
</asp:Content>
