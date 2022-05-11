<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="notificaciones.aspx.cs" Inherits="StarzInfiniteWeb.notificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ObjectDataSource ID="odsNotificaciones" runat="server" SelectMethod="PR_OBTIENE_COMUNICADOS" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
       <!-- begin #content -->
 <div class="container">
	   <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblPNR" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblTotalPagar" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblMoneda" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblEmail" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblDatosVueloIda" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
	<div class="col-12 shadow rounded" style="height:auto">
		<div class="col-lg-12">
			 <asp:Image ID="Image6" ImageUrl="~/iconos/icono-notificaciones.png" runat="server" /><asp:Label ID="Label1" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Large" Text="Notificaciones"></asp:Label><br />
              <hr />
              <br />
		</div>
		<div class="row">
							
						<asp:Repeater ID="Repeater1" DataSourceID="odsNotificaciones" runat="server">
							<ItemTemplate>
								
								<asp:Label ID="Label3" CssClass="form-text" runat="server" Text='<%# Eval("FECHA_DESDE", "{0:dd/M/yyyy}") %>'></asp:Label>
								<div class="col-12 shadow-sm rounded bg-silver-lighter" style="height:30%">
									<div class="form-group">
										<asp:Label ID="Label1" CssClass="form-text bg-white" ForeColor="Black" Font-Bold="true" runat="server" Text='<%# Eval("DENOMINACION") %>'></asp:Label>
										<asp:Label ID="Label2" CssClass="form-text" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label>
										
										</div>
									</div>
								
							</ItemTemplate>
						</asp:Repeater>
			</div><br /><br /><br /><br />
	</div>
</div>
</asp:Content>
