<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="StarzInfiniteWeb.reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<asp:ObjectDataSource ID="odsBoletosVendidos" runat="server" SelectMethod="PR_OBTIENE_BOLETOS_VENDIDOS_WEB" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha1" Name="pd_fechadesde" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha2" Name="pd_fechahasta" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsObtieneGanancias" runat="server" SelectMethod="PR_OBTIENE_REPORTE_GANANCIAS" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMovimientosCuenta" runat="server" SelectMethod="PR_OBTIENE_MOVIMIENTOS_CUENTA" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
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
    	
		<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
         <div class="rounded shadow col-12">
				<!-- begin col-6 -->
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
                         <br />
            <%--<div class="row">
                <br /><br />
                <div class="col-12">
					<div class="rounded border shadow-sm m-2" style="display:inline-block;text-align:center">
                    Boletos vendidos
                    <hr />
                    <asp:Label ID="lblBolVendidos" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
                <div class="rounded border shadow-sm m-2" style="display:inline-block;text-align:center">
                    Reservas pendientes
                    <hr />
                    <asp:Label ID="lblPendientes" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
                 <div class="rounded border shadow-sm m-2" style="display:inline-block;text-align:center">
                    Reservas canceladas
                    <hr />
                    <asp:Label ID="lblCancelados" ForeColor="Red" runat="server" Text="0"></asp:Label>

                </div>
                <div class="rounded border shadow-sm m-2" style="display:inline-block;text-align:center">
                    Reservas expiradas
                    <hr />
                    <asp:Label ID="lblExpirados" ForeColor="Red" runat="server" Text="0"></asp:Label>

                </div>
                </div>
                
            </div>
            <br />--%>
			<%--	 <div class="row">
                        <div>
                                <canvas id="myChart" style="width:100%"  height="350">

                                </canvas>
                            </div>
                            

                    </div>--%>
			
           <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:600px; overflow-x:scroll;overflow-y:scroll">
            <div>
										<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
																<tr>
																	<td>
																		<strong>NRO</strong>
																	</td>
																	<td>
																		<strong>PNR</strong>
																	</td>
																	<td>
																		<strong>Fecha</strong>
																	</td>
																	<td>
                                                                        <strong>Nro. de boletos</strong>
																	</td>
																	<td>
																		<strong>Ruta</strong>
																	</td>
																	
																	<td>
                                                                        <strong>Ganancia</strong>
																	</td>
																	<td>
                                                                        <strong>Monto Bruto</strong>
																	</td>
																	<td>
                                                                        <strong>Monto Neto</strong>
																	</td>
																	<td>
                                                                        <strong>Comision Broker</strong>
																	</td>
																	<td>
                                                                        <strong>Moneda</strong>
																	</td>
																	<td>
                                                                        <strong>Aerolinea</strong>
																	</td>
																	<td>
                                                                        <strong>Tipo Venta</strong>
																	</td>
																	<td>
                                                                        <strong>Detalles</strong>
																	</td>
																</tr>
														</thead>
													<tbody>
																<asp:Repeater ID="Repeater1" DataSourceID="odsBoletosVendidos" runat="server">
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label1" runat="server" Text='<%# Eval("PNR") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label5" runat="server" Text='<%# Eval("FECHA", "{0:dd/MM/yyyy}") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label3" runat="server" Text='<%# Eval("TICKETS") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label2" runat="server" Text='<%# Eval("RUTA") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label4" runat="server" Text='<%# Eval("GANANCIAS") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label10" runat="server" Text='<%# Eval("monto_bruto") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label11" runat="server" Text='<%# Eval("monto_neto") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label12" runat="server" Text='<%# Eval("comision_broker") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label13" runat="server" Text='<%# Eval("moneda") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label14" runat="server" Text='<%# Eval("aerolinea") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label15" runat="server" Text='<%# Eval("tipo_venta") %>'></asp:Label>
																			</td>
																			
																			
																			<td>
                                                                                <asp:LinkButton ID="lbtnVer" CommandArgument='<%# Eval("PNR") %>' OnClick="lbtnVer_Click" runat="server" CssClass="btn-sm btn-orange" ToolTip="Ver detalles reserva">Detalles</asp:LinkButton>
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
            <div class="row col-12 m-t-10">
                <br /><br />
                <div class="col-2 rounded border shadow-sm m-2" style="text-align:center">
                    Ganancia acumulada
                    <hr />
                    <asp:Label ID="lblGanAcu" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
                <div class="col-2 rounded border shadow-sm m-2" style="text-align:center">
                    Ganancias x mis ventas
                    <hr />
                    <asp:Label ID="lblGanMisVentas" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
                 <div class="col-2 rounded border shadow-sm m-2" style="text-align:center">
                    Ganancias x equipo de ventas
                    <hr />
                    <asp:Label ID="lblGanEquipo" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
                <div class="col-2 rounded border shadow-sm m-2" style="text-align:center">
                    Ruta mas vendida
                    <hr />
                    <asp:Label ID="lblRutaMasVendida" ForeColor="Blue" runat="server" Text="-"></asp:Label>

                </div>
            </div>
            <br /><br /><br />
		         <div class="row col-12">
                        <div class="col-12">
                                <canvas id="myChart2" style="width:100%"  height="350">

                                </canvas>
                            </div>
                            

                    </div>
			<br /><br /><br />
            <div class="table-responsive col-12">
														<table id="data-table-default" class="table table-condensed table-bordered">
													<thead>
																<tr>
																	
																	<td>
																		<strong>Fecha</strong>
																	</td>
																	<td>
                                                                        <strong>Descripcion</strong>
																	</td>
																	<td>
																		<strong>Monto</strong>
																	</td>
																</tr>
														</thead>
													<tbody>
																<asp:Repeater ID="Repeater2" DataSourceID="odsObtieneGanancias" runat="server">
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:Label ID="Label5" runat="server" Text='<%# Eval("FECHA", "{0:dd/M/yyyy}") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label3" runat="server" Text='<%# Eval("CONCEPTO") %>'></asp:Label>
																			</td>
																			<td>
																				<asp:Label ID="Label2" ForeColor='<%# Eval("MONTO").ToString().Contains("-".ToString()) ? System.Drawing.Color.Red : System.Drawing.Color.Black %>' runat="server" Text='<%# Eval("MONTO") %>'></asp:Label>
																			</td>
																		</tr>
																	</ItemTemplate>
																</asp:Repeater>
																</tbody>
																
															</table>
								</div>
        </asp:View>
        <asp:View ID="View3" runat="server">
             <div class="row col-12 m-t-10">
                <br /><br />
                <div class="col-2 rounded border shadow-sm m-2" style="text-align:center">
                    Saldo en billetera
                    <hr />
                    <asp:Label ID="lblSaldoBilletera" ForeColor="Blue" runat="server" Text="0"></asp:Label>

                </div>
            </div>
			<br /><br /><br />
            <div class="table-responsive col-12">
				<table id="data-table-default" class="table table-condensed table-bordered">
			        <thead>
						        <tr>
																	
							        <td>
								        <strong>Fecha</strong>
							        </td>
							        <td>
                                        <strong>Descripcion</strong>
							        </td>
							        <td>
								        <strong>Monto</strong>
							        </td>
						        </tr>
				        </thead>
			        <tbody>
						        <asp:Repeater ID="Repeater3" DataSourceID="odsMovimientosCuenta" runat="server">
							        <ItemTemplate>
								        <tr>
									        <td>
										        <asp:Label ID="Label5" runat="server" Text='<%# Eval("FECHA", "{0:dd/M/yyyy}") %>'></asp:Label>
									        </td>
									        <td>
										        <asp:Label ID="Label3" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label>
									        </td>
									        <td>
										        <asp:Label ID="Label2" ForeColor='<%# Eval("MONTO").ToString().Contains("-".ToString()) ? System.Drawing.Color.Red : System.Drawing.Color.Black %>' runat="server" Text='<%# Eval("MONTO") %>'></asp:Label>
									        </td>
								        </tr>
							        </ItemTemplate>
						        </asp:Repeater>
						        </tbody>
																
					        </table>
			</div>
        </asp:View>
        <asp:View ID="View4" runat="server">
			<div class="row">
				<div class="col">
					<asp:Button ID="btnVolverReporte" CssClass="btn btn-primary" OnClick="btnVolverReporte_Click" runat="server" Text="Volver" />
				</div>
			</div>
          <div class="table-responsive col-12">
				<table id="data-table-default1" class="table table-condensed table-bordered">
			        <thead>
						        <tr>
																	
							        <td>
								        <strong>NOMBRES</strong>
							        </td>
									<td>
								        <strong>APELLIDOS</strong>
							        </td>
									<td>
								        <strong>TIPO</strong>
							        </td>
						        </tr>
				        </thead>
			        <tbody>
						        <asp:Repeater ID="Repeater4" runat="server">
							        <ItemTemplate>
								        <tr>
									       
									        <td>
										        <asp:Label ID="Label3" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
									        </td>
											 <td>
										        <asp:Label ID="Label8" runat="server" Text='<%# Eval("APELLIDO") %>'></asp:Label>
									        </td>
									        <td>
										        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TIPO") %>'></asp:Label>
									        </td>
								        </tr>
							        </ItemTemplate>
						        </asp:Repeater>
						        </tbody>
																
					        </table>
			</div>
        </asp:View>
    </asp:MultiView>
      </div>
    </div>
	 <script type="text/javascript">

         function recuperarFechaSalida() {

             document.getElementById('<%=hfFecha1.ClientID%>').value = document.getElementById('fecha_salida1').value;
            document.getElementById('<%=hfFecha2.ClientID%>').value = document.getElementById('fecha_retorno1').value;
         }


     </script>
</asp:Content>
