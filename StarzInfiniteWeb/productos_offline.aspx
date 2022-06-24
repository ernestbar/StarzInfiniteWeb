<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="productos_offline.aspx.cs" Inherits="StarzInfiniteWeb.productos_offline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ObjectDataSource ID="odsBoletosVendidosManual" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_MANUAL" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
             <asp:ControlParameter ControlID="hfFecha1" Name="pd_fdesde" Type="String" />
             <asp:ControlParameter ControlID="hfFecha2" Name="pd_fhasta" Type="String" />
			 <asp:Parameter Name="pv_pnr" DefaultValue="" />
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDetalle" runat="server" SelectMethod="PR_OBTIENE_DETALLE_MANUAL" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
             <asp:ControlParameter ControlID="lblPNR" Name="pv_pnr" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRutaInd" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="RUTA INDIVIDUAL" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
    </asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsLineaAerea" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="AEROLINEA" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsProducto" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="PRODUCTO" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsMoneda" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="MONEDA" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsTipoVenta" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="TIPO VENTA" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoVuelo" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="TIPO VUELO" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoPasajero" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="TIPO PASAJERO" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsProductos" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="PRODUCTOS" Name="PV_DOMINIO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoPas" runat="server" SelectMethod="Lista2" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="TIPO PASAJERO" Name="PV_DOMINIO" Type="String" />
			<asp:ControlParameter ControlID="ddlProducto" propertyname="SelectedValue" Name="PV_PRODUCTO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsProveedor" runat="server" SelectMethod="Lista2" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="PROVEEDOR" Name="PV_DOMINIO" Type="String" />
			<asp:ControlParameter ControlID="ddlProducto" propertyname="SelectedValue" Name="PV_PRODUCTO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>

	<asp:ObjectDataSource ID="odsBroker" runat="server" SelectMethod="Lista2" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="BROKER" Name="PV_DOMINIO" Type="String" />
			<asp:ControlParameter ControlID="ddlProducto" propertyname="SelectedValue" Name="PV_PRODUCTO" Type="String" />
		</SelectParameters></asp:ObjectDataSource>

	<div class="container">
        <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
		 <asp:Label ID="lblPNR" runat="server" Visible="false" Text=""></asp:Label> 
		 <asp:Label ID="lblCodClienteTicket" runat="server" Visible="false" Text=""></asp:Label> 
    	
		<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
             <div class="row">
                    <div class="col">
                        <asp:Label ID="Label6" CssClass="form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Medium" Text="Seleccione las fechas"></asp:Label>
                    </div>
                </div> 
                <hr />
            <div class="row">
		        <div class="col-12 col-md-3">
						Fecha inicio
			        <input id="fecha_salida1" class="form-control" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFecha1" runat="server" />
		        </div>
		        <div class="col-12 col-md-3">
					Fecha fin
			        <input id="fecha_retorno1" class="form-control" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFecha2" runat="server" />
			    </div>
					<div class="col">
						<asp:Button ID="btnFiltrarFechas" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnFiltrarFechas_Click" OnClientClick="recuperarFechaSalida()" Text="Reporte" />
						<asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnNuevo_Click" OnClientClick="recuperarFechaSalida()" Text="Nuevo Registro" />
			    </div>
                </div>
            <div class="row">
           <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
										<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
																<tr>
																	<td>
																		<strong>NRO</strong>
																	</td>
																	<td>
																		<strong>COD TICKET</strong>
																	</td>
																	<td>
																		<strong>PRODUCTO</strong>
																	</td>
																	<td>
                                                                        <strong>PROVEEDOR</strong>
																	</td>
																	<td>
																		<strong>PNR</strong>
																	</td>
																	
																	<td>
                                                                        <strong>TOURCODE</strong>
																	</td>
																	<td>
                                                                        <strong>DATOS FACT.</strong>
																	</td>
																	<td>
                                                                        <strong>EMAIL FACT.</strong>
																	</td>
																	<td>
                                                                        <strong>TELEFON FACT.</strong>
																	</td>
																	<td>
                                                                        <strong>ORIGEN IDA</strong>
																	</td>
																	<td>
                                                                        <strong>DESTINO IDA</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA IDA</strong>
																	</td>
																	<td>
                                                                        <strong>CLASE IDA</strong>
																	</td>
																	<td>
                                                                        <strong>CARRIER IDA</strong>
																	</td>
																	<td>
                                                                        <strong>NRO VUELO IDA</strong>
																	</td>
																	<td>
                                                                        <strong>ORIGEN VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>DESTINO VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>CLASE VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>CARRIER VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>NRO VUELO VUELTA</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA LIMIT. EMISION</strong>
																	</td>
																	<td>
                                                                        <strong>ESTADO</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA DE REGISTRO</strong>
																	</td>
																	<td>
                                                                        <strong>BROKER</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA COUNTER</strong>
																	</td>
																	<td>
                                                                        <strong>COUNTER</strong>
																	</td>
																	<td>
                                                                        <strong>TOTAL A COBRAR</strong>
																	</td>
																	<td>
                                                                        <strong>MONEDA</strong>
																	</td>
																	<td>
                                                                        <strong>IMPUESTOS</strong>
																	</td>
																	<td>
                                                                        <strong>MONTO SIN IMP.</strong>
																	</td>
																	<td>
                                                                        <strong>TIPO VENTA</strong>
																	</td>
																	<td>
                                                                        <strong>COMISION SZI</strong>
																	</td>
																	<td>
                                                                        <strong>COMISION BROKER</strong>
																	</td>
																	<td>
                                                                        <strong>TIPO DE REGISTRO</strong>
																	</td>
																	<td>
                                                                        <strong>TIPO VUELO</strong>
																	</td>
																	<td>
                                                                        <strong>OPCIONES</strong>
																	</td>
																</tr>
														</thead>
													<tbody>
																<asp:Repeater ID="Repeater1" DataSourceID="odsBoletosVendidosManual" runat="server">
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label1" runat="server" Text='<%# Eval("COD_CLIENTE_TICKET") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label5" runat="server" Text='<%# Eval("PRODUCTO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label3" runat="server" Text='<%# Eval("PROVEEDOR") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label2" runat="server" Text='<%# Eval("NRO_PNR") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label4" runat="server" Text='<%# Eval("TOURCODE") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label10" runat="server" Text='<%# Eval("DATOSFACTURACION") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label11" runat="server" Text='<%# Eval("EMAILFACT") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label12" runat="server" Text='<%# Eval("TELEFONOFACT") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label13" runat="server" Text='<%# Eval("ORIGENIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label14" runat="server" Text='<%# Eval("DESTINOIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label15" runat="server" Text='<%# Eval("FECHAIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label7" runat="server" Text='<%# Eval("CLASEIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label8" runat="server" Text='<%# Eval("CARRIERIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label16" runat="server" Text='<%# Eval("NUMEROVUELOIDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label17" runat="server" Text='<%# Eval("ORIGENVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label18" runat="server" Text='<%# Eval("DESITINOVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label19" runat="server" Text='<%# Eval("FECHAVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label20" runat="server" Text='<%# Eval("CLASEVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label21" runat="server" Text='<%# Eval("CARRIERVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label22" runat="server" Text='<%# Eval("NUMEROVUELOVUELTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label23" runat="server" Text='<%# Eval("FECHALIMITEEMISION") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label24" runat="server" Text='<%# Eval("ESTADO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label25" runat="server" Text='<%# Eval("FECHA_REGISTRO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label26" runat="server" Text='<%# Eval("BROKER") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label27" runat="server" Text='<%# Eval("FECHA_COUNTER") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label28" runat="server" Text='<%# Eval("COUNTER") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label29" runat="server" Text='<%# Eval("TOTALCOBRAR") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label30" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label31" runat="server" Text='<%# Eval("TOTALIMPUESTOS") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label32" runat="server" Text='<%# Eval("MONTOSINIMPUESTOS") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label33" runat="server" Text='<%# Eval("DESC_TIPO_VENTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label34" runat="server" Text='<%# Eval("COMISION_SZI") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label35" runat="server" Text='<%# Eval("COMISION_BROKER") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label36" runat="server" Text='<%# Eval("TIPO_REGISTRO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label37" runat="server" Text='<%# Eval("TIPO_VUELO") %>'></asp:Label>
																			</td>
																			<td>
                                                                                <asp:LinkButton ID="lbtnVer" CommandArgument='<%# Eval("NRO_PNR") %>' OnClick="lbtnVer_Click" runat="server" CssClass="btn-sm btn-orange" ToolTip="Ver detalles">Detalles</asp:LinkButton>
																				<asp:LinkButton ID="lbtnEditar" CommandArgument='<%# Eval("COD_CLIENTE_TICKET") %>' OnClick="lbtnEditar_Click" runat="server" CssClass="btn-sm btn-primary" ToolTip="Editar">Editar</asp:LinkButton>
																				<%--<asp:LinkButton ID="lbtnCorreo" CommandArgument='<%# Eval("PNR") %>' runat="server" ToolTip="Enviar Correo"><i class="fa fa-mail-bulk"></i></asp:LinkButton>
																				<asp:LinkButton ID="lbtnPublicidad" CommandArgument='<%# Eval("PNR") %>' runat="server" ToolTip="Enviar publicidad"><i class="fa fa-tv"></i></asp:LinkButton>--%>
																			</td>
																		</tr>
																	</ItemTemplate>
																</asp:Repeater>
																</tbody>
																
															</table>
								</div>
               </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
			 <div class="row">
				 <asp:Button ID="btnVoler" runat="server" CssClass="btn btn-primary" OnClick="btnVoler_Click" Text="Volver" />
             <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
										<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
																<tr>
																	<td>
																		<strong>COD TICKET</strong>
																	</td>
																	<td>
																		<strong>NOMBRES</strong>
																	</td>
																	<td>
                                                                        <strong>APELLIDOS</strong>
																	</td>
																	<td>
																		<strong>TIPO PASAJERO</strong>
																	</td>
																	
																	<td>
                                                                        <strong>NRO. DOCUMENTO</strong>
																	</td>
																	<td>
                                                                        <strong>FECHA NAC.</strong>
																	</td>
																	<td>
                                                                        <strong>MONEDA</strong>
																	</td>
																	<td>
                                                                        <strong>MONTO BRUTO</strong>
																	</td>
																	<td>
                                                                        <strong>MONTO NETO</strong>
																	</td>
																	<td>
                                                                        <strong>MONTO IMPUESTOS</strong>
																	</td>
																</tr>
														</thead>
													<tbody>
																<asp:Repeater ID="Repeater2" DataSourceID="odsDetalle" runat="server">
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:Label ID="Label9" runat="server" Text='<%# Eval("COD_TICKET") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label1" runat="server" Text='<%# Eval("NOMBRE_PASAJERO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label5" runat="server" Text='<%# Eval("APELLIDO_PASAJERO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label3" runat="server" Text='<%# Eval("TIPOPASAJERO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label2" runat="server" Text='<%# Eval("NRODOCUMENTOPASAJERO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label4" runat="server" Text='<%# Eval("FECHANAC") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label10" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label11" runat="server" Text='<%# Eval("MONTO_BRUTO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label12" runat="server" Text='<%# Eval("MONTO_NETO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label13" runat="server" Text='<%# Eval("MONTO_IMPUESTOS") %>'></asp:Label>
																			</td>
																																					</tr>
																	</ItemTemplate>
																</asp:Repeater>
																</tbody>
																
															</table>
								</div>
               </div>
			
        </asp:View>

		<asp:View ID="View3" runat="server">
			<div class="row">
					<div class="col-12 col-md-2">
						Producto
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlProducto" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" OnDataBound="ddlProducto_DataBound" DataSourceID="odsProductos" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlProducto" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Proovedor:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlProovedor" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlProovedor_DataBound" DataSourceID="odsProveedor" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlProovedor" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Detalle:
					</div>
					<div class="col-12 col-md-1">
						Nro. Ticket
					</div>
					<div class="col-12 col-md-1">
						Nombre pasajero
					</div>
				<div class="col-12 col-md-1">
						Apellido pasajero
					</div>
				<div class="col-12 col-md-1">
						Tipo pasajero
					</div>

				<div class="col-12 col-md-1">
						Nro. de documento
					</div>
				<div class="col-12 col-md-1">
						Fecha Nacimiento
					</div>
				<div class="col-12 col-md-1">
						Costo
					</div>
				<div class="col-12 col-md-1">
						Monto sin impuesto
					</div>
				<div class="col-12 col-md-1">
						Monto con impuesto
					</div>
				<div class="col-12 col-md-1">
					
					</div>
		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						
					</div>
					<div class="col-12 col-md-1">
						<asp:TextBox ID="txtNroTicket" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
					<div class="col-12 col-md-1">
						<asp:TextBox ID="txtNombrePasajero" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
						<asp:TextBox ID="txtApellidoPasajero" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
						<asp:DropDownList ID="ddlTipoPas" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlTipoPas_DataBound" DataSourceID="odsTipoPas" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>
				<div class="col-12 col-md-1">
						<asp:TextBox ID="txtNroDoc" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
						<input id="fecha_nac" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaNac" runat="server" />
					</div>
				<div class="col-12 col-md-1">
						<asp:TextBox ID="txtCosto" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
						<asp:TextBox ID="txtMontoSinImp" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
						<asp:TextBox ID="txtMontoConImp" ValidationGroup="detalle" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				<div class="col-12 col-md-1">
					<asp:Button ID="btnAgregar" CssClass="btn btn-primary" ValidationGroup="detalle" OnClientClick="recuperarFechas2()" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
					</div>
		</div>
			<div class="row">
					<div class="col-12 col-md-12">
						<asp:ListBox ID="lbDetalle" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="lbDetalle_SelectedIndexChanged"  runat="server"></asp:ListBox>
					</div>

		</div>
		<div class="row">
					<div class="col-12 col-md-2">
						Nro. PNR:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtPNR" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Tour code:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtTourCode" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Datos Facturacion:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtDatosFacturacion" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Email Facturacion:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtEmailFact" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Telefono Facturacion:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtFonoFact" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Origen ida:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlOrigenIda" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlOrigenIda_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Destino ida:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlDestinoIda" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlDestinoIda_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Fecha ida:
					</div>
					<div class="col-12 col-md-3">
						<input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaSalida" runat="server" />
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Clase de ida:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtClaseIda" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Carrier ida:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtCarrierIda" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
				<div class="row">
					<div class="col-12 col-md-2">
						Numero vuelo ida:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtNroVueloIda" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>

			<div class="row">
					<div class="col-12 col-md-2">
						Origen Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlOrigenVuelta" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlOrigenVuelta_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Destino Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlDestinoVuelta" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlDestinoVuelta_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Fecha Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<input id="fecha_vuelta" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaVuelta" runat="server" />
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Clase Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtClaseVuelta" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Carrier Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtCarrierVuelta" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
				<div class="row">
					<div class="col-12 col-md-2">
						Numero vuelo Vuelta:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtNroVueloVuelta" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Fecha Limite Emision:
					</div>
					<div class="col-12 col-md-3">
						<input id="fecha_limite" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaLimite" runat="server" />
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Fecha Registro:
					</div>
					<div class="col-12 col-md-3">
						<input id="fecha_registro" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaRegistro" runat="server" />
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Broker:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlBroker" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlBroker_DataBound" DataSourceID="odsBroker" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Total a cobrar:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtTotalCobrar" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Moneda:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlMoneda" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlMoneda_DataBound" DataSourceID="odsMoneda" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Total impuestos:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtTotalImpuestos" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Monto sin impuestos:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtMontoSinImpuestos" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Tipo Venta:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlTipoVenta" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlTipoVenta_DataBound" DataSourceID="odsTipoVenta" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
		<div class="row">
					<div class="col-12 col-md-2">
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtComisionBroker" CssClass="form-control" Text="0" Visible="false" runat="server"></asp:TextBox>
					</div>

		</div>
			<div class="row">
					<div class="col-12 col-md-2">
						Tipo Vuelo:
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlTipoVuelo" class="form-control" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlTipoVuelo_DataBound" DataSourceID="odsTipoVuelo" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					</div>

		</div>
			
			
			
			
		<%--	<div class="row">
					<div class="col-12 col-md-2">
						Codigo Cliente Ticket:
					</div>
					<div class="col-12 col-md-3">
						<asp:TextBox ID="txtCodClienteTicket" CssClass="form-control" runat="server"></asp:TextBox>
					</div>

		</div>--%>
		<div class="row">
					<div class="col-12 col-md-2">
						<asp:Button ID="btnGuardar" OnClientClick="recuperarFechas()" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
					</div>
					<div class="col-12 col-md-2">
						<asp:Button ID="btnVolverEstABM" CausesValidation="false" OnClick="btnVolverEstABM_Click" CssClass="btn btn-primary" runat="server" Text="Volver" />
					</div>

				</div>
			
		</asp:View>
    </asp:MultiView>
		</div>
     <script type="text/javascript">
        function recuperarFechaSalida() {

            document.getElementById('<%=hfFecha1.ClientID%>').value = document.getElementById('fecha_salida1').value;
            document.getElementById('<%=hfFecha2.ClientID%>').value = document.getElementById('fecha_retorno1').value;
		 }

         function recuperarFechas() {

             document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
              document.getElementById('<%=hfFechaVuelta.ClientID%>').value = document.getElementById('fecha_vuelta').value;
              document.getElementById('<%=hfFechaRegistro.ClientID%>').value = document.getElementById('fecha_registro').value;
              document.getElementById('<%=hfFechaLimite.ClientID%>').value = document.getElementById('fecha_limite').value;
		 }

         function recuperarFechas2() {

             document.getElementById('<%=hfFechaNac.ClientID%>').value = document.getElementById('fecha_nac').value;
         }
     </script>
</asp:Content>
