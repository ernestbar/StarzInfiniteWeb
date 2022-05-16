<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporte_admin.aspx.cs" Inherits="StarzInfiniteWeb.reporte_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ObjectDataSource ID="odsObtieneGananciasDetalleDetalle" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_DETALLE_ADM" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblPnr" Name="pv_pnr" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsObtieneGanancias" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_ADM" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
             <asp:ControlParameter ControlID="hfFecha1" Name="fecha1" Type="String" />
             <asp:ControlParameter ControlID="hfFecha2" Name="fecha2" Type="String" />
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsObtieneEstados" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM_ESTADO" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
             <asp:ControlParameter ControlID="hfFecha1" Name="fecha1" Type="String" />
             <asp:ControlParameter ControlID="hfFecha2" Name="fecha2" Type="String" />
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsObtieneGananciasDetalle" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_DET_ADM" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
             <asp:ControlParameter ControlID="hfFecha1" Name="fecha1" Type="String" />
             <asp:ControlParameter ControlID="hfFecha2" Name="fecha2" Type="String" />
			  <asp:ControlParameter ControlID="lblBroker" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsEstado" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="ESTADO TICKET" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
    </asp:ObjectDataSource>
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


   <div class="container">
        <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
        <asp:Label ID="lblBroker" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblPnr" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
        
        <div class="row">
            <div class="col-12 col-md-3"><br />
            <asp:Image ID="Image6" ImageUrl="~/iconos/icono-reportes.png" runat="server" /><asp:Label ID="Label1" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Large" Text="Reportes"></asp:Label><br /><br /><br />
            </div>
            <div class="col-12 col-md-3"><br />
                <asp:LinkButton ID="lbtnVoletosVendidos"  OnClick="lbtnVoletosVendidos_Click" class="shadow rounded btn-block" runat="server"><asp:Image ID="Image1" ImageUrl="~/iconos/icono-boleto.png" runat="server" />Boletos Vendidos Mes Anterior</asp:LinkButton>
            </div>
        </div>
        <%--  <div class="col-3"><br />
            <asp:LinkButton ID="lbtnGanancias" OnClick="lbtnGanancias_Click" class="shadow rounded btn-block" runat="server"><asp:Image ID="Image3" Width="51px" ImageUrl="~/iconos/icono-ganancia.png" runat="server" />Gananacias</asp:LinkButton>
        </div>
            <div class="col-3"><br />
            <asp:LinkButton ID="lbtnMovBilletera" OnClick="lbtnMovBilletera_Click" class="shadow rounded btn-block" runat="server"><asp:Image ID="Image2" Width="51px" ImageUrl="~/iconos/icono-saldo-en-cuenta.png" runat="server" />Movimiento Billetara</asp:LinkButton>
        </div>--%>
                      
                  
               
        <asp:MultiView ID="MultiView1" runat="server">
			<asp:View ID="View6" runat="server">
				 <div class="row">
                    <div class="col">
                        <asp:Label ID="Label6" CssClass="form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Medium" Text="Seleccione las fechas"></asp:Label>
                    </div>
                </div> 
                <hr />
            <div class="row">
		        <div class="col-12 col-md-3">
						Fecha inicio
			        <input id="fecha_salida1" class="form-control" style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFecha1" runat="server" />
		        </div>
		        <div class="col-12 col-md-3">
					Fecha fin
			        <input id="fecha_retorno1" class="form-control" style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFecha2" runat="server" />
			    </div>
					<div class="col">
						<asp:Button ID="btnFiltrarFechas" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnFiltrarFechas_Click" OnClientClick="recuperarFechaSalida()" Text="Reporte" />
						<asp:Button ID="btnCambiarEstados" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnCambiarEstados_Click" OnClientClick="recuperarFechaSalida()" Text="Cambiar Estados" />
			    </div>
                </div>
				
			</asp:View>
            <asp:View ID="View1" runat="server">
				<h3>REPORTE GENERAL DE VENTAS</h3>
				
				<asp:Button ID="btnOtraConsulta" runat="server" CssClass="btn btn-primary" OnClick="btnOtraConsulta_Click" Text="Otra consulta" />
				<button onclick="exportTableToExcel('tblData')" class="btn btn-orange">Exportar a Excel</button>
				<div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
               <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
            <div>
						<table id="tblData" class="table table-bordered order-table ">
									<thead>
												<tr>
													<td>
														<strong>NRO</strong>
													</td>
													<td>
														<strong>NOMBRE</strong>
													</td>
													<td>
														<strong>APELLIDOS</strong>
													</td>
													<td>
                                                        <strong>BROKER</strong>
													</td>
													<td>
														<strong>GANACIAS</strong>
													</td>
																	
													<td>
                                                        <strong>TICKETS</strong>
													</td>
                                                    	<td>
                                                        <strong>OPCIONES</strong>
													</td>
												</tr>
										</thead>
									<tbody>
												<asp:Repeater ID="Repeater1" DataSourceID="odsObtieneGanancias" runat="server">
													<ItemTemplate>
														<tr>
															<td>
																<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label1" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label5" runat="server" Text='<%# Eval("APELLIDOS") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label3" runat="server" Text='<%# Eval("BROKER") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label4" runat="server" Text='<%# Eval("GANANCIAS") %>'></asp:Label>
															</td>
                                                            <td>
																<asp:Label ID="Label2" runat="server" Text='<%# Eval("TICKETS") %>'></asp:Label>
															</td>
                                                            <td>
                                                                <asp:Button ID="btnDetalle1" OnClick="btnDetalle1_Click" CommandArgument='<%# Eval("BROKER") %>' CssClass="btn-sm btn-primary" runat="server" Text="Detalles" />
                                                                
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
					<div class="col">
						<asp:Button ID="btnVolver1" runat="server" CssClass="btn btn-primary" OnClick="btnVolver1_Click" Text="Volver" />
			    </div>
					<div class="col">
						<button onclick="exportTableToExcel('tblData2')" class="btn btn-orange">Exportar a Excel</button>
					</div>
				</div>
				
				<div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
            <div>
						<table id="tblData2" class="table table-bordered order-table ">
									<thead>
												<tr>
													<td>
														<strong>NRO</strong>
													</td>
													<td>
														<strong>FECHA</strong>
													</td>
													<td>
														<strong>AEROLINEA</strong>
													</td>
													<td>
                                                        <strong>TICKETS</strong>
													</td>
													<td>
														<strong>GANANCIAS Bs.</strong>
													</td>
													<td>
                                                        <strong>PNR</strong>
													</td>
													<td>
                                                        <strong>RUTA</strong>
													</td>
													<td>
                                                        <strong>DATOS FACTURACION</strong>
													</td>
													<td>
                                                        <strong>ORIGEN IDA</strong>
													</td>
													<td>
                                                        <strong>DESTINO IDA</strong>
													</td>
													<td>
                                                        <strong>ORIGEN VUELTA</strong>
													</td>
													<td>
                                                        <strong>DESTINO VUELTA</strong>
													</td>
													<td>
                                                        <strong>FECHA LIMITE EMISION</strong>
													</td>
													<td>
                                                        <strong>MONEDA</strong>
													</td>
													<td>
                                                        <strong>MONTO BRUTO</strong>
													</td>
													<td>
                                                        <strong>MONTO IMPUESTOS</strong>
													</td>
													<td>
                                                        <strong>MONTO NETO</strong>
													</td>
													<td>
                                                        <strong>COMISION BROKER</strong>
													</td>
													<td>
                                                        <strong>COMISION SZI</strong>
													</td>
													<td>
                                                        <strong>USUARIO RESERVA</strong>
													</td>
													<td>
                                                        <strong>USUARIO EMISION</strong>
													</td>
													<td>
                                                        <strong>FORMA PAGO</strong>
													</td>
													<td>
                                                        <strong>TIPO VENTA</strong>
													</td>
													<td>
                                                        <strong>ESTADO</strong>
													</td>
                                                    	<td>
                                                        <strong>OPCIONES</strong>
													</td>
												</tr>
										</thead>
									<tbody>
												<asp:Repeater ID="Repeater2" DataSourceID="odsObtieneGananciasDetalle" runat="server">
													<ItemTemplate>
														<tr>
															<td>
																<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label1" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label5" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label3" runat="server" Text='<%# Eval("TICKETS") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label4" runat="server" Text='<%# Eval("GANANCIAS_BOB") %>'></asp:Label>
															</td>
                                                            <td>
																<asp:Label ID="Label2" runat="server" Text='<%# Eval("PNR") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label7" runat="server" Text='<%# Eval("RUTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label8" runat="server" Text='<%# Eval("DATOSFACTURACION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label10" runat="server" Text='<%# Eval("ORIGENIDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label11" runat="server" Text='<%# Eval("DESTINOIDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label12" runat="server" Text='<%# Eval("ORIGENVUELTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label13" runat="server" Text='<%# Eval("DESITINOVUELTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label14" runat="server" Text='<%# Eval("FECHALIMITEEMISION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label15" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label16" runat="server" Text='<%# Eval("MONTO_BRUTO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label17" runat="server" Text='<%# Eval("MONTO_IMPUESTOS") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label18" runat="server" Text='<%# Eval("MONTO_NETO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label19" runat="server" Text='<%# Eval("COMISION_BROKER") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label20" runat="server" Text='<%# Eval("COMISION_SZI") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label21" runat="server" Text='<%# Eval("USUARIO_RESERVA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label22" runat="server" Text='<%# Eval("USUARIO_EMISION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label23" runat="server" Text='<%# Eval("FORMA_PAGO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label24" runat="server" Text='<%# Eval("TIPO_VENTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label25" runat="server" Text='<%# Eval("ESTADOD") %>'></asp:Label>
															</td>
                                                            <td>
                                                                <asp:Button ID="btnDetalle2" OnClick="btnDetalle2_Click" CommandArgument='<%# Eval("PNR") %>' CssClass="btn-sm btn-primary" runat="server" Text="Detalles" />
                                                                
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
					<div class="col">
						<asp:Button ID="btnVolver2" runat="server" CssClass="btn btn-primary" OnClick="btnVolver2_Click" Text="Volver" />
			    </div>
					<div class="col">
						<button onclick="exportTableToExcel('tblData3')" class="btn btn-orange">Exportar a Excel</button>
					</div>
				</div>
				
				<div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
            <div>
						<table id="tblData3" class="table table-bordered order-table ">
									<thead>
												<tr>
													<td>
														<strong>COD TICKET</strong>
													</td>
													<td>
														<strong>PASAJERO</strong>
													</td>
													<td>
														<strong>TIPO PASAJERO</strong>
													</td>
													<td>
                                                        <strong>NRO DOC. PASAJERO</strong>
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
                                                        <strong>MONTO IMPUESTO</strong>
													</td>
												</tr>
										</thead>
									<tbody>
												<asp:Repeater ID="Repeater3" DataSourceID="odsObtieneGananciasDetalleDetalle" runat="server">
													<ItemTemplate>
														<tr>
															<td>
																<asp:Label ID="Label9" runat="server" Text='<%# Eval("COD_TICKET") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label1" runat="server" Text='<%# Eval("PASAJERO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label5" runat="server" Text='<%# Eval("TIPOPASAJERO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label3" runat="server" Text='<%# Eval("NRODOCUMENTOPASAJERO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label4" runat="server" Text='<%# Eval("FECHANAC") %>'></asp:Label>
															</td>
                                                            <td>
																<asp:Label ID="Label2" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label7" runat="server" Text='<%# Eval("MONTO_BRUTO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label8" runat="server" Text='<%# Eval("MONTO_NETO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label10" runat="server" Text='<%# Eval("MONTO_IMPUESTOS") %>'></asp:Label>
															</td>
														</tr>
													</ItemTemplate>
												</asp:Repeater>
												</tbody>
																
											</table>
				</div>
               </div>
            </asp:View>
			<asp:View ID="View4" runat="server">
				<h4>REPORTE PARA CAMBIO DE ESTADOS</h4>
				
				<div class="row">
					<div class="col">
						<asp:Button ID="btnVolverEstado" runat="server" CssClass="btn btn-primary" OnClick="btnVolverEstado_Click" Text="Otra consulta" />
			    </div>
					<div class="col">
						<button onclick="exportTableToExcel('tblData4')" class="btn btn-orange">Exportar a Excel</button>
					</div>
				</div>
				
				 <div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
            <div>
						<table id="tblData4" class="table table-bordered order-table ">
									<thead>
												<tr>
													<td>
														<strong>NRO</strong>
													</td>
													<td>
														<strong>FECHA</strong>
													</td>
													<td>
														<strong>AEROLINEA</strong>
													</td>
													<td>
                                                        <strong>TICKETS</strong>
													</td>
													<td>
														<strong>GANANCIAS Bs.</strong>
													</td>
													<td>
                                                        <strong>PNR</strong>
													</td>
													<td>
                                                        <strong>RUTA</strong>
													</td>
													<td>
                                                        <strong>DATOS FACTURACION</strong>
													</td>
													<td>
                                                        <strong>ORIGEN IDA</strong>
													</td>
													<td>
                                                        <strong>DESTINO IDA</strong>
													</td>
													<td>
                                                        <strong>ORIGEN VUELTA</strong>
													</td>
													<td>
                                                        <strong>DESTINO VUELTA</strong>
													</td>
													<td>
                                                        <strong>FECHA LIMITE EMISION</strong>
													</td>
													<td>
                                                        <strong>MONEDA</strong>
													</td>
													<td>
                                                        <strong>MONTO BRUTO</strong>
													</td>
													<td>
                                                        <strong>MONTO IMPUESTOS</strong>
													</td>
													<td>
                                                        <strong>MONTO NETO</strong>
													</td>
													<td>
                                                        <strong>COMISION BROKER</strong>
													</td>
													<td>
                                                        <strong>COMISION SZI</strong>
													</td>
													<td>
                                                        <strong>USUARIO RESERVA</strong>
													</td>
													<td>
                                                        <strong>USUARIO EMISION</strong>
													</td>
													<td>
                                                        <strong>FORMA PAGO</strong>
													</td>
													<td>
                                                        <strong>TIPO VENTA</strong>
													</td>
													<td>
                                                        <strong>ESTADO</strong>
													</td>
                                                    	<td>
                                                        <strong>OPCIONES</strong>
													</td>
												</tr>
										</thead>
									<tbody>
												<asp:Repeater ID="Repeater4" DataSourceID="odsObtieneEstados" runat="server">
													<ItemTemplate>
														<tr>
															<td>
																<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label1" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label5" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label3" runat="server" Text='<%# Eval("TICKETS") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label4" runat="server" Text='<%# Eval("GANANCIAS_BOB") %>'></asp:Label>
															</td>
                                                            <td>
																<asp:Label ID="Label2" runat="server" Text='<%# Eval("PNR") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label7" runat="server" Text='<%# Eval("RUTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label8" runat="server" Text='<%# Eval("DATOSFACTURACION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label10" runat="server" Text='<%# Eval("ORIGENIDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label11" runat="server" Text='<%# Eval("DESTINOIDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label12" runat="server" Text='<%# Eval("ORIGENVUELTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label13" runat="server" Text='<%# Eval("DESITINOVUELTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label14" runat="server" Text='<%# Eval("FECHALIMITEEMISION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label15" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label16" runat="server" Text='<%# Eval("MONTO_BRUTO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label17" runat="server" Text='<%# Eval("MONTO_IMPUESTOS") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label18" runat="server" Text='<%# Eval("MONTO_NETO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label19" runat="server" Text='<%# Eval("COMISION_BROKER") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label20" runat="server" Text='<%# Eval("COMISION_SZI") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label21" runat="server" Text='<%# Eval("USUARIO_RESERVA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label22" runat="server" Text='<%# Eval("USUARIO_EMISION") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label23" runat="server" Text='<%# Eval("FORMA_PAGO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label24" runat="server" Text='<%# Eval("TIPO_VENTA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label25" runat="server" Text='<%# Eval("ESTADO") %>'></asp:Label>
															</td>
                                                            <td>
                                                                <asp:Button ID="btnSeleccionarEst" OnClick="btnSeleccionarEst_Click" CommandArgument='<%# Eval("PNR") %>' CssClass="btn-sm btn-primary" runat="server" Text="Cambiar Estado" />
                                                                
															</td>
														</tr>
													</ItemTemplate>
												</asp:Repeater>
												</tbody>
																
											</table>
				</div>
               </div>
            </asp:View>
			<asp:View ID="View5" runat="server">
				<div class="row">
					<div class="col-12 col-md-3">
						Cambiar estado del PNR Nro.:
					</div>
					<div class="col-12 col-md-2">
						<asp:Label ID="lblPNRestado" CssClass="form-control" runat="server" Text=""></asp:Label>
					</div>
					<div class="col-12 col-md-3">
						<asp:DropDownList ID="ddlEstado" class="form-control" data-size="10" data-live-search="true" ValidationGroup="cambioEstado" data-style="btn-white" OnDataBound="ddlEstado_DataBound" DataSourceID="odsEstado" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="cambioEstado" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEstado" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
					<div class="col-12 col-md-2">
						<asp:Button ID="btnCambiarEstado" ValidationGroup="cambioEstado" OnClick="btnCambiarEstado_Click" CssClass="btn btn-orange" runat="server" Text="Cambiar Estado" />
					</div>
					<div class="col-12 col-md-2">
						<asp:Button ID="btnVolverEstABM" OnClick="btnVolverEstABM_Click" CssClass="btn btn-primary" runat="server" Text="Volver" />
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

        function exportTableToExcel(tableID, filename = '') {
            var downloadLink;
            var dataType = 'application/vnd.ms-excel';
            var tableSelect = document.getElementById(tableID);
            var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

            // Specify file name
            filename = filename ? filename + '.xls' : 'excel_data.xls';

            // Create download link element
            downloadLink = document.createElement("a");

            document.body.appendChild(downloadLink);

            if (navigator.msSaveOrOpenBlob) {
                var blob = new Blob(['ufeff', tableHTML], {
                    type: dataType
                });
                navigator.msSaveOrOpenBlob(blob, filename);
            } else {
                // Create a link to the file
                downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

                // Setting the file name
                downloadLink.download = filename;

                //triggering the function
                downloadLink.click();
            }
        }
    </script>
	<script type="text/javascript">
        (function (document) {
            'use strict';

            var LightTableFilter = (function (Arr) {

                var _input;

                function _onInputEvent(e) {
                    _input = e.target;
                    var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
                    Arr.forEach.call(tables, function (table) {
                        Arr.forEach.call(table.tBodies, function (tbody) {
                            Arr.forEach.call(tbody.rows, _filter);
                        });
                    });
                }

                function _filter(row) {
                    var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
                    row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
                }

                return {
                    init: function () {
                        var inputs = document.getElementsByClassName('light-table-filter');
                        Arr.forEach.call(inputs, function (input) {
                            input.oninput = _onInputEvent;
                        });
                    }
                };
            })(Array.prototype);

            document.addEventListener('readystatechange', function () {
                if (document.readyState === 'complete') {
                    LightTableFilter.init();
                }
            });

        })(document);
    </script>
</asp:Content>
