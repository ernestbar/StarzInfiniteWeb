<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ofertas.aspx.cs" Inherits="StarzInfiniteWeb.ofertas" %>
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
    <asp:ObjectDataSource ID="odsNotificaciones" runat="server" SelectMethod="PR_GET_NOTIFICACIONES" TypeName="StarzInfiniteWeb.datos_bd_local">
    </asp:ObjectDataSource>
<!-- begin #content -->
 <div class="container">
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side">
        <div class="row col-12">
            <div class="col-12"><br /><br /> 
            <asp:Image ID="Image6" ImageUrl="~/iconos/icono-ofertas.png" runat="server" /><asp:Label ID="Label1" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Large" Text="Ofertas para vender mas"></asp:Label><br />
                <hr />
                <br />
            </div>
            </div>
        
			<asp:Repeater ID="Repeater1" DataSourceID="odsNotificaciones" runat="server">
				<ItemTemplate>
                <div class="row rounded shadow-sm col-12 m-5" style="background-color:whitesmoke">
                    <div class="row m-5">
                        <div style="display:inline-block">
                            <asp:ImageButton ID="ibtnDetalles" ImageUrl='<%# Eval("DETALLE") %>' Height="150px" ImageAlign="Middle" runat="server" />
                	        <%--<img class="media-object rounded m-2" style="height:100px" src="../assets/img/gallery/gallery-1.jpg" alt="" />--%>
                        </div>
                        <div class="m-1" style="display:inline-block">
                            <p><asp:Label ID="Label3" CssClass="col-form-label" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small" Text="Nombre publicidad"></asp:Label><br />
                            <asp:Label ID="Label2" CssClass="col-form-label text-justify" runat="server" ForeColor="Gray"  Font-Size="Small" Text='<%# Eval("DENOMINACION") %>'></asp:Label><br />
                            <asp:Label ID="Label4" CssClass="col-form-label" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small" Text="Descripcion"></asp:Label><br />
                            <asp:Label ID="Label5" CssClass="col-form-label text-justify" runat="server" ForeColor="Gray"  Font-Size="Small" Text='<%# Eval("DESCRIPCION") %>'></asp:Label><br />
                            <asp:Label ID="Label6" CssClass="col-form-label" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small" Text="Duracion"></asp:Label><br />
                            <asp:Label ID="Label7" CssClass="col-form-label text-justify" runat="server" ForeColor="Gray"  Font-Size="Small" Text='<%# "Desde:" + ((String.IsNullOrEmpty(Eval("FECHA_DESDE").ToString()))? "No Date Available" : Eval("FECHA_DESDE", "{0:dd/M/yyyy}") + " a " + Eval("FECHA_HASTA", "{0:dd/M/yyyy}")) %>'></asp:Label><br />
                            <asp:Label ID="Label8" CssClass="col-form-label" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small" Text="Condiciones"></asp:Label><br />
                            <asp:Label ID="Label9" CssClass="col-form-label text-justify" runat="server" ForeColor="Gray"  Font-Size="Small" Text='<%# Eval("CONDICIONES") %>'></asp:Label>
                            </p>
                        </div>
                        <div style="display:inline-block;float:right">
                            <asp:ImageButton ID="ibtnCompartir" ImageUrl="~/iconos/icono-compartir.png" Visible="false" Height="30px" runat="server" />
                	        <%--<img class="media-object rounded m-2" style="height:100px" src="../assets/img/gallery/gallery-1.jpg" alt="" />--%>
                        </div>
					</div>			
                </div>
				</ItemTemplate>
			</asp:Repeater>
            

        </div>
    
</div>
</asp:Content>
