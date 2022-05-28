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
                                        <asp:Button ID="btnEnviar" CssClass="btn btn-orange" OnClientClick="traerHTML()" OnClick="btnEnviar_Click" runat="server" Text="Enviar Correo" />
                                        <asp:HiddenField ID="hfHTML" runat="server" />
										<asp:Button ID="btnVolverReserva" CssClass="btn btn-orange" OnClick="btnVolverReserva_Click" runat="server" Text="Volver" />
                                        <div class="row" style="text-align:left">
                                            <div id="invoice2" style="font-size:small">
		                                    <div class="col-12 col-md-6 shadow rounded">
                                                 <div class="row" style="text-align:center;">
                                                           <asp:Image ID="Image9" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label1" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Reserva creada"></asp:Label>
                        
                                                       </div>
                                                    <hr />
                                                   <div class="row" style="text-align:center;">
                                                           <asp:Label ID="Label2" runat="server" Font-Size="Large" CssClass="col-12 align-content-center"  Font-Bold="true"  Text="Tu código de reserva (PNR):"></asp:Label>
                                                       </div>
                                                    <div style="text-align:center;">
                                                           <asp:TextBox ID="txtPNR" ReadOnly="true" CssClass="form-control col-md-3 text-center" Font-Bold="true" Font-Size="Large" Height="50px" runat="server"></asp:TextBox>
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
                                                 </div>
                                                <div class="col-12 col-md-6 shadow rounded">
                                                        <div class="row" style="vertical-align:central">
                                                       <asp:Image ID="Image10" Height="50" ImageUrl="~/Logos/encabezado_logo.png" runat="server" /> 
                                                   </div>
                                                   <div class="row" style="vertical-align:central">
                                                       <asp:Image ID="Image11" Height="20" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label50" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                                                   </div>
                                                    <hr />
                                                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                       <asp:Image ID="Image12" Height="20" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label51" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
                                                   </div>
                                                 <div class="row" style="vertical-align:central;text-align:center">
                                                     <div class="col">
                                                         <asp:Label ID="lblSeniorsResumenRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                     </div>
                                                     <div class="col">
                                                         <asp:Label ID="lblSeniorPreciosRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                     </div>
                                   
                                 
                                                   </div>
                                                    <div class="row" style="vertical-align:central;text-align:center">
                                                        <div class="col">
                                                              <asp:Label ID="lblAdultosResumenRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                            <asp:Label ID="lblAdultosPreciosRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                     </div>
                                 
                                 
                                                   </div>
                                                     <div class="row" style="vertical-align:central;text-align:center">
                                                         <div class="col">
                                                             <asp:Label ID="lblNinosResumenRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                             <asp:Label ID="lblNinosPreciosRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                     </div>
                                       
                                                       </div>
                                                    <div class="row" style="vertical-align:central;text-align:center">
                                                        <div class="col">
                                                            <asp:Label ID="lblInfanteResumenRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                            <asp:Label ID="lblInfantePreciosRes" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                     </div>
                                 
                                       
                                                       </div>
                                                       <strong></strong>
				                                <asp:Panel ID="panel_idaRes" Visible="false" Font-Size="XX-Small" runat="server">
                                                <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                       <asp:Image ID="Image13" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="Label60" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Ida"></asp:Label>
                                                   </div>
				                                        <div class="row">
                                                            <div class="col">
                                                            </div>
                                                            <div class="col" style="font-size:medium;text-align:center">
                                                                <strong><asp:Label ID="lblAreolineaNombResIdaRes" Font-Size="Medium" runat="server" Text="">:</asp:Label></strong>
                                                            </div>
                                                                <div class="col">
                                                                <asp:Label ID="lblEscalasResIdaRes" runat="server" Text=""></asp:Label>
                                                            </div>
                                                        </div>
                                                               
                                                                                 
                                                                                        
                                                                      <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    Salida
                                                                            </li>
                                                                            <li>
                                                                                   Airline:<asp:Label ID="lblAreolineaIda" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                    Llegada
                                                                            </li>
                                                                                        
                                                                       </ul>
                                                                        <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    <asp:Label ID="lblFechaSalidaIda" runat="server" ForeColor="Black" Text=""></asp:Label> - <asp:Label ID="lblHoraSalidaIda" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                                            </li>
                                                                            <li>
                                                                                    <asp:Label ID="lblFechaLlegadaIda" runat="server" ForeColor="Black" Text=""></asp:Label> - <asp:Label ID="lblHoraLLegadaIda" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                                            </li>
                                                                                        
                                                                        </ul>
                                                                           <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    <asp:Label ID="lblOrigenIda" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                <asp:Label ID="lblVueloClaseIda" runat="server" Text=""></asp:Label><br />
                                                                            </li>
                                                                            <li>
                                                                                    <asp:Label ID="lblDestinoIda" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                             
                                                                            <%--   <li>
                                                                                   Maletas: <asp:Label ID="lblMaletasIda" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                               <li>
                                                                                   Duracion: <asp:Label ID="lblDuracionIda" runat="server" Text=""></asp:Label>
                                                                            </li>--%>
                                                                        </ul>

														</asp:Panel>			               
												                    
				                                <asp:Panel ID="panel_vueltaRes" Visible="false" Font-Size="XX-Small" runat="server">
					                                 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                       <asp:Image ID="Image14" ImageUrl="~/iconos/icono-Vuelta-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="Label63" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Vuelta"></asp:Label>
                                                   </div>
                                                    <div class="row">
                                                            <div class="col">
                                                            </div>
                                                          <div class="col" style="font-size:medium;text-align:center">
                                                                <strong>AEROLINEA - <asp:Label ID="lblAreolineaNombResVueltaRes" runat="server" Text="">:</asp:Label></strong>
                                                            </div>
                                                                <div class="col">
                                                                <asp:Label ID="lblEscalasResVueltaRes" runat="server" Text=""></asp:Label>
                                                            </div>
                                                        </div>
                                                   
                                                                                 
                                                                                        
                                                                        <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    Salida
                                                                            </li>
                                                                            <li>
                                                                                    Airline:<asp:Label ID="Label24" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                    Llegada
                                                                            </li>
                                                                                        
                                                                        </ul>
                                                                         <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    <asp:Label ID="lblFechaSalidaVuelta" runat="server" ForeColor="Black" Text=""></asp:Label> - <asp:Label ID="lblHoraSalidaVuelta" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                <asp:Image ID="Image7" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> 
                                                                            </li>
                                                                            <li>
                                                                                     <asp:Label ID="lblFechaLlegadaVuelta" runat="server" ForeColor="Black" Text=""></asp:Label> - <asp:Label ID="lblHoraLLegadaVuelta" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                                            </li>
                                                                                        
                                                                        </ul>
                                                                             <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                                            <li>
                                                                                    <asp:Label ID="lblOrigenVuelta" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                            <li>
                                                                                <asp:Label ID="lblVueloClaseVuelta" runat="server" Text=""></asp:Label><br />
                                                                            </li>
                                                                            <li>
                                                                                    <asp:Label ID="lblDestinoVuelta" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                                 <%-- <li>
                                                                                   Maletas: <asp:Label ID="lblMaletasVuelta" runat="server" Text=""></asp:Label>
                                                                            </li>
                                                                               <li>
                                                                                   Duracion: <asp:Label ID="lblDuracionVuelta" runat="server" Text=""></asp:Label>
                                                                            </li>--%>
                                                                                         
                                                                        </ul>

																	               
												                    
				                                </asp:Panel>


                                


				                                <asp:Panel ID="panel_total_resRes" Visible="true" Font-Size="XX-Small" runat="server">
					                                 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                       <asp:Image ID="Image26" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" Height="20" runat="server" /><asp:Label ID="Label66" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblTotalReservaRes" CssClass="col-3" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true" Text=""></asp:Label><asp:Label ID="lblMonedaResRes" CssClass="col-5" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label>
                                                   </div>
                                                    <asp:Panel ID="Panel8" Visible="true" runat="server">
                                                            <div class="row" style="vertical-align:central;text-align:center">
                                                       <asp:Label ID="Label69" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseResRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                   </div>
                                                     <div class="row" style="vertical-align:central;text-align:center">
                                                           <asp:Label ID="Label71" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpuestosResRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                   <div class="row" style="vertical-align:central;text-align:center">
                                                           <asp:Label ID="Label73" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Fee emision    "></asp:Label><asp:Label ID="lblFeeEmisionResRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                    <div class="row" style="vertical-align:central;text-align:center">
                                                           <asp:Label ID="Label75" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Otros cargos    "></asp:Label><asp:Label ID="lblOtrosCargosRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                                     </asp:Panel>
                                                    </asp:Panel>
                                                       <hr />

                                   
                                                      
                            

                                                          <%-- <div class="row" style="vertical-align:central">
                                                               <asp:Image ID="Image19" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label20" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                        
                                                           </div>
                                                            <hr />
                                                             <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                               <asp:Image ID="Image20" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" Visible="false" runat="server" />  <asp:Label ID="Label21" Visible="false" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
                                                           </div>
                                                            <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="lblReservaADT" CssClass="col-12" runat="server" Font-Size="Large"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                             <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="lblReservaNinos" CssClass="col-12" runat="server" Font-Size="Large"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="lblRservaInfantes" CssClass="col-12" runat="server" Font-Size="Large"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>

				                                        <asp:Panel ID="panel1" Visible="false" runat="server">
					                                         <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                               <asp:Image ID="Image21" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" runat="server" />  <asp:Label ID="Label25" runat="server" Font-Size="Large"   Font-Bold="True"></asp:Label>
                                                           </div>
                                                            <div class="row" style="text-align:center">
                                                               <asp:Label ID="Label11" CssClass="col-lg-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                             <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label16" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label17" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
					                                        <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label18" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
				                                        </asp:Panel>
				                                        <asp:Panel ID="panel2" Visible="false" runat="server">
					                                         <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                               <asp:Image ID="Image22" ImageUrl="~/iconos/icono-vuelta-resumen-reserva.png" runat="server" />  <asp:Label ID="Label26" runat="server" Font-Size="Large"   Font-Bold="true"  Text=""></asp:Label>
                                                           </div>
                                                            <div class="row" style="text-align:center">
                                                               <asp:Label ID="Label19" CssClass="col-lg-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                             <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label22" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label27" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
					                                        <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label28" CssClass="col-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
				                                        </asp:Panel>
				                                        <asp:Panel ID="panel3" Visible="true" runat="server">
					                                         <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                                               <asp:Image ID="Image23" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" Height="30" runat="server" /><asp:Label ID="Label29" CssClass="col-4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblMonedaReserva" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label><asp:Label ID="lblMontoTotalReserva" CssClass="col-4" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text="Vuelta"></asp:Label>
                                                           </div>
                                                            <div class="row" style="vertical-align:central">
                                                               <asp:Label ID="Label30"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseReserva" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                           </div>
                                                             <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label31"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpRserva" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label33"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Fee de Emision:"></asp:Label><asp:Label ID="lblFeeEmisionReserva" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="0"></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label35"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Otros Cargos:"></asp:Label><asp:Label ID="lblOtrosCargosReserva" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="0"></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central">
                                                                   <asp:Label ID="Label37"  runat="server" Font-Size="Small" Visible="false"  Font-Bold="false"  Text="Comision:"></asp:Label><asp:Label ID="lblComisionReserva" Visible="false" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="0"></asp:Label>
                                                               </div>
                                                            <div class="row" style="vertical-align:central;border-style:solid;border-color:yellow;border-width:1px;">
                                                                   <asp:Label ID="Label38" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text="Ganancia total     "></asp:Label><asp:Label ID="Label32" CssClass="col-6" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text=""></asp:Label>
                                                               </div>
				                                        </asp:Panel><br /><br />--%>
                                                <div class="row">
                                                       <div class="row">
                                                           <asp:Image ID="Image8" ImageUrl="~/iconos/icono-datos-de-pasajero.png" Height="30" runat="server" />  <asp:Label ID="Label4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Lista de pasajeros"></asp:Label>
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
    </div></div>
                                                 
										
                                    </asp:View>

								</asp:MultiView>
							
								
								

							
						
   

	 <script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFecha1.ClientID%>').value = document.getElementById('fecha_salida1').value;
            document.getElementById('<%=hfFecha2.ClientID%>').value = document.getElementById('fecha_retorno1').value;
		}

         function traerHTML() {
             alert();
             var MyDiv1 = document.getElementById('invoice2').innerHTML;
             alert(MyDiv1);
             document.getElementById('<%=lblAviso.ClientID%>').text = MyDiv1;
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
