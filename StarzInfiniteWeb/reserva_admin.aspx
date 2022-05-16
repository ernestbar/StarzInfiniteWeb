<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reserva_admin.aspx.cs" Inherits="StarzInfiniteWeb.reserva_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ObjectDataSource ID="odsReservasTodos" runat="server" SelectMethod="PR_OBTIENE_TICKETS_WEB_FILTRO" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
			 <asp:ControlParameter ControlID="lblCliente" Name="pv_cliente" Type="String" />
			 <asp:ControlParameter ControlID="lblPnr" Name="pv_pnr" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha1" Name="pd_fdesde" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha2" Name="pd_fhasta" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
       <!-- begin #content -->
	   <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblCliente" runat="server" Text="" Visible="false"></asp:Label>

	<asp:Label ID="lblPNR" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblTotalPagar" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblMoneda" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblEmail" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblDatosVueloIda" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
							<div class="container">
								<div class="row">
									<asp:Image ID="Image1" ImageUrl="~/iconos/icono-reservas.png" runat="server" />
									<asp:Label ID="Label6" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Large" Text="Reservas"></asp:Label>
								</div>

								<asp:MultiView ID="MultiView1" runat="server">

									<asp:View ID="View1" runat="server">
										<div class="row">
											<div class="col">
												<asp:Label ID="Label5" CssClass="form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Medium" Text="Seleccione las fechas"></asp:Label>
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
												<asp:Button ID="btnFiltrarFechas" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnFiltrarFechas_Click" OnClientClick="recuperarFechaSalida()" Text="Filtrar Reporte" />
										</div>
										</div>
											<div class="col-lg-12">
									<div class="form-group col-lg-12">
                                        <asp:RadioButtonList ID="rblFiltro" OnSelectedIndexChanged="rblFiltro_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
											<asp:ListItem Text="Ver Todos" Selected="True"></asp:ListItem>
											<asp:ListItem Text="Emitido" Selected="False"></asp:ListItem>
											<asp:ListItem Text="Pendiente" Selected="False"></asp:ListItem>
											<asp:ListItem Text="Cancelado" Selected="False"></asp:ListItem>
                                        </asp:RadioButtonList>
								</div>
									</div>
										<div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
								 <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
									<div>
											<table class="table table-bordered order-table ">
												<thead>
																<tr>
																	<td>
																		<strong>Nro</strong>
																	</td>
                                                                    <td>
																		<strong>Código de reserva</strong>
																	</td>
																	<td>
																		<strong>Total a cobrar</strong>
																	</td>
																	<td>
																		<strong>Moneda</strong>
																	</td>
																	<td>
																		<strong>Fecha</strong>
																	</td>
																	
																	<td>
                                                                        <strong>Apellido/Nombre</strong>
																	</td>
																	<td>
                                                                        <strong>Estado</strong>
																	</td>
																	<td>
                                                                        <strong>Opciones</strong>
																	</td>
																</tr>
														</thead>
													<tbody>
																<asp:Repeater ID="Repeater1" DataSourceID="odsReservasTodos" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:Label ID="Label5" Font-Size="Smaller" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
																			</td>
                                                                            <td>
																				<asp:Label ID="lblPnr" Font-Size="Smaller" runat="server" Text='<%# Eval("NRO_PNR") %>'></asp:Label>
																			</td>
																			  <td>
																				<asp:Label ID="Label7" Font-Size="Smaller" runat="server" Text='<%# Eval("TOTALCOBRAR") %>'></asp:Label>
																			</td>
																			  <td>
																				<asp:Label ID="Label8" Font-Size="Smaller" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label1" Font-Size="Smaller" runat="server" Text='<%#Eval("FECHA_LIMITE", "{0:dd/M/yyyy}")%>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label9" Font-Size="Smaller" runat="server" Text='<%# Eval("EMAILFACT") %>'></asp:Label>
																			</td>
																			<td>
                                                                                <asp:Image ID="Image5" ImageUrl="~/iconos/estado-emitido.png" Visible='<%# Eval("ESTADO").ToString().Equals("EMITIDO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server" />
                                                                                <asp:Image ID="Image6" ImageUrl="~/iconos/estado-cancelado.png" Visible='<%# Eval("ESTADO").ToString().Equals("CANCELADO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server" />
                                                                                <asp:Image ID="Image7" ImageUrl="~/iconos/estado-pendiente.png" Visible='<%# Eval("ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server" />
																				<asp:Label ID="Label4" runat="server" Text='<%# Eval("ESTADO") %>'></asp:Label><br /> 
                                                                                <asp:Label ID="lblFechaLim" runat="server" Visible='<%# Eval("ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' Font-Size="Smaller" Text=""></asp:Label>
                                                                                    <asp:Label ID="lblFechaLim2" runat="server" Visible="false" Text='<%#Eval("FECHA_LIMITE")%>'></asp:Label>
																			</td>
																			<td>
                                                                                <asp:LinkButton ID="lbtnVer" CommandArgument='<%# Eval("NRO_PNR") %>' runat="server" CssClass="btn-sm btn-orange" OnClick="lbtnVer_Click" ToolTip="Ver detalles reserva">Detalles</asp:LinkButton><br />
																				<asp:LinkButton ID="lbtnCambiarFecha" Visible='<%# Eval("ESTADO").ToString().Equals("EMITIDO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CssClass="btn-sm btn-default" CommandArgument='<%# Eval("NRO_PNR") %>' runat="server" OnClick="lbtnCambiarFecha_Click" ToolTip="Cambiar la fecha">Cambiar fecha</asp:LinkButton><br />
																				<asp:LinkButton ID="btnPagar" Visible='<%# Eval("ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CssClass="btn-sm btn-success"  CommandArgument='<%# Eval("NRO_PNR") +"|"+ Eval("COD_CLIENTE_TICKET") +"|"+ Eval("SECURITYTOGEN")+"|"+ Eval("DATOSFACTURACION")+"|"+ Eval("FECHA_LIMITE") %>' runat="server" OnClick="btnPagar_Click" ToolTip="Pagar reserva">Pagar</asp:LinkButton><br />
                                                                                <asp:LinkButton ID="btnCancelar" Visible='<%# Eval("ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CssClass="btn-sm btn-danger" CommandArgument='<%# Eval("NRO_PNR") %>' runat="server" OnClick="btnCancelar_Click" ToolTip="Cancelar reserva">Cancelar</asp:LinkButton>
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
										<iframe name="myIframe" id="myIframe" width="800" height="600" runat="server"></iframe>
									<div class="btn-group col-md-12">
									<div class="col-md-6">
									<div class="form-btn">
										<asp:Button ID="btnCanelarIframe" OnClick="btnCanelarIframe_Click"  class="btn btn-primary rounded shadow-sm"  runat="server" Text="Volver" />
									</div>
								</div>
								
								</div>
									</asp:View>
                                    <%--VER                   RESERVA--%>
                                    <asp:View ID="View3" runat="server">
										<asp:Button ID="btnVolverReserva" CssClass="btn btn-orange" OnClick="btnVolverReserva_Click" runat="server" Text="Volver" />
                                        <div class="row">
		                                    <div class="col-12 col-md-6 shadow rounded">
                                                 <div class="row" style="text-align:center;">
                                                           <asp:Image ID="Image9" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label1" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Reserva creada"></asp:Label>
                        
                                                       </div>
                                                    <hr />
                                                   <div class="row" style="text-align:center;">
                                                           <asp:Label ID="Label2" runat="server" Font-Size="Large" CssClass="col-12 align-content-center"  Font-Bold="true"  Text="Tu código de reserva (PNR):"></asp:Label>
                                                       </div>
                                                    <div style="text-align:center;">
                                                           <asp:TextBox ID="txtPNR" ReadOnly="true" CssClass="form-control offset-5 col-md-3 " Font-Bold="true" Font-Size="Large" Height="50px" runat="server"></asp:TextBox>
                                                       </div>
                                                 <div class="row align-content-center col-12" style="text-align:center;">
                                                           <asp:Image ID="Image3" ImageUrl="~/iconos/icono-tiempo-limite.png" CssClass="offset-6" runat="server" /> 
                                                       </div>
                                                 <div class="row" style="text-align:center;">
                                                           <asp:Label ID="Label3" runat="server" Font-Size="Medium" CssClass="col-12 align-content-center"  Font-Bold="false"  Text="Tiempo limite de emisión:"></asp:Label>
                                                       </div>
                                                 <div class="row" style="text-align:center;">
                                                         <asp:Label ID="lblTiempoLimite" CssClass="col-12 align-content-center" runat="server" Text=""></asp:Label>
                                                       </div>
            
                                                
			
                                               <br />
                                                <hr />
                                                <div class="row">
                                                       <div class="row" style="text-align:center">
                                                           <asp:Image ID="Image8" ImageUrl="~/iconos/icono-datos-de-pasajero.png" runat="server" />  <asp:Label ID="Label4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Lista de pasajeros"></asp:Label>
                                                            <br /><br />
                                                       </div>
                                                    <div class="table-responsive offset-1">
											                                    <table class="col-8 table-borderless">
												                                    <thead>
													                                    <tr>
														                                    <%--<th class="text">NRO</th>--%>
														                                    <th class="text">NRO</th>
														                                    <th class="text">NOMBRES</th>
														                                    <th class="text">APELLIDOS</th>
														                                    <th class="text">TIPO</th>
														
														                                    </tr>
												                                    </thead>
													                                    <tbody>
														                                    <asp:Repeater ID="Repeater4" runat="server">
															                                    <ItemTemplate>
																                                    <tr>
																	                                    <%--<td><asp:Label ID="lblNumero" runat="server" Text='<%# Eval("nro") %>'></asp:Label></td>--%>
																	                                    <td><asp:Label ID="lblCI" runat="server" Text='<%# Eval("nro") %>'></asp:Label></td>
																	                                    <td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("nombre") %>'></asp:Label></td>
																	                                    <td><asp:Label ID="lblApellidos" runat="server" Text='<%# Eval("apellido") %>'></asp:Label></td>
																	                                    <td><asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo_pax") %>'></asp:Label></td>
																	
																                                    </tr>
																	
															                                    </ItemTemplate>
														                                    </asp:Repeater>
													                                    </tbody>
											                                    </table>

										                                    </div>
                                                </div>
                                                 
	                                    </div>
      


                                        <div class="rounded shadow col-12 col-md-6" style="height:640px;">
                                                       <div class="row" style="vertical-align:central">
                                                           <asp:Image ID="Image6" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="lblReserva" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                        
                                                       </div>
                                                        <hr />
                                                         <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                           <asp:Image ID="Image2" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label10" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
                                                       </div>
                                                        <div class="row" style="vertical-align:central">
                                                           <asp:Label ID="lblAdultosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                         <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblNinosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                        <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblInfanteResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>

				                                    <asp:Panel ID="panel_ida" Visible="false" runat="server">
					                                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                           <asp:Image ID="Image4" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" runat="server" />  <asp:Label ID="lblIdaTitulo" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Ida"></asp:Label>
                                                       </div>
                                                        <div class="row" style="vertical-align:central">
                                                           <asp:Label ID="lblFechaIdaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                         <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblOrgDestIdaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                        <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblHorarioIdaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
					                                    <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblVueloIdaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
				                                    </asp:Panel>
				                                    <asp:Panel ID="panel_vuelta" Visible="false" runat="server">
					                                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                           <asp:Image ID="Image5" ImageUrl="~/iconos/icono-vuelta-resumen-reserva.png" runat="server" />  <asp:Label ID="lblVueltaTitulo" runat="server" Font-Size="Large"   Font-Bold="true"  Text=""></asp:Label>
                                                       </div>
                                                        <div class="row" style="vertical-align:central">
                                                           <asp:Label ID="lblFechaVueltaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                         <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblOrgDestVueltaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                        <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblHorarioVueltaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
					                                    <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblVueloVueltaRes" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
				                                    </asp:Panel>
				                                    <asp:Panel ID="panel_total_res" Visible="false" runat="server">
					                                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                           <asp:Image ID="Image7" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" runat="server" /><asp:Label ID="Label12"  runat="server" Font-Size="Large"   Font-Bold="true"  Text="Total a pagar:  "></asp:Label><asp:Label ID="lblMonedaRes" CssClass="col" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label><asp:Label ID="lblTotalRes" CssClass="col" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label>
                                                       </div>
                                                        <div class="row" style="vertical-align:central">
                                                           <asp:Label ID="Label13" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseRes" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                         <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="Label14" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpuestosRes" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                        <div class="row" style="vertical-align:central;border-style:solid;border-color:yellow;border-width:1px;">
                                                               <asp:Label ID="Label15" CssClass="col-6" runat="server" Font-Size="Small" Visible="false"  Font-Bold="false"  Text="Ganancia total     "></asp:Label><asp:Label ID="lblGananciaRes" CssClass="col-6" runat="server" Font-Size="Small" Visible="false"  Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
				                                    </asp:Panel><br /><br />
                                                 <%--   <asp:Panel ID="panel_continuar" Visible="false" runat="server">
                                                         <div class="row" style="vertical-align:central">
					                                        <asp:Button ID="btnContinuar" OnClick="btnContinuar_Click" class="btn btn-primary btn-lg rounded col-8" Font-Size="Large" CausesValidation="false"  runat="server" Text="Continuar" />
                                                             </div>
				                                    </asp:Panel>--%>

                        
                    
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
