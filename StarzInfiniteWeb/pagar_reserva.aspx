<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="pagar_reserva.aspx.cs" Inherits="StarzInfiniteWeb.pagar_reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- begin #content -->
	<div class="container">
	   <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblPNR" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblCodTicket" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblGds" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblFechaLimite" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblTotalPagar" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblMoneda" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblEmail" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblDatosVueloIda" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>


            
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Panel ID="Panel1" HorizontalAlign="Center" runat="server">
                <div class="row">
                <div class="col-12 shadow rounded">
                     <div class="row" style="text-align:left;">
                       <asp:Image ID="Image1" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" /><asp:Label ID="Label1" CssClass="col-12" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Pagar reserva"></asp:Label>
                        
                   </div>    
                    <hr />
                    <br />
                    <div class="row col-12 offset-2">
                        <asp:Label ID="lblTotalTit" CssClass="col-10 shadow align-content-center" runat="server" Font-Size="Medium" Font-Bold="true" Text=""></asp:Label>
                        <asp:TextBox ID="txtTotalPagar" Font-Size="Medium" Visible="false" Font-Bold="true" ReadOnly="true" CssClass="col-2" runat="server"></asp:TextBox>
                    </div>
                    <br /><br />
                    <div class="row">
                         <asp:Panel ID="Panel_billetera" class="col m-10 shadow rounded-corner" Visible="false" runat="server">
                             <div style="text-align:center;height:300px"><br />
                                
                            <asp:Label ID="Label2" CssClass="col-12" runat="server" Font-Size="Medium" Font-Bold="true" Text="Tu saldo en billetera"></asp:Label><br /><br />
                             |<asp:Image ID="Image2" ImageUrl="~/iconos/icono-billetera.png" runat="server" /><br /><br />
                            <asp:Label ID="lblSaldo" CssClass="col-12" runat="server" Font-Size="Large" Font-Bold="true" Text="Tu saldo en billetera"></asp:Label><br /><br />
                            <asp:Button ID="btnPagarSaldo" OnClick="btnPagarSaldo_Click"  class="btn btn-primary rounded shadow"  runat="server" Text="Pagar con saldo" />
                      
                        </div>
                          </asp:Panel>
                        
                       
                        <div class="col m-10 shadow rounded-corner" style="text-align:center;height:300px"><br />
                            <asp:Label ID="Label3" CssClass="col-12" runat="server" Font-Size="Medium" Font-Bold="true" Text="Otras formas de pago"></asp:Label><br /><br />
                            |<asp:Image ID="Image3" ImageUrl="~/iconos/Portal-vendedor-web-[Recovered].png" runat="server" /><br /><br /><br />
                           <asp:Button ID="btnOtrasFormasPago" OnClick="btnOtrasFormasPago_Click"  class="btn btn-primary rounded shadow"  runat="server" Text="Realizar el Pago" />
                        </div>
                    </div>
                    <br /><br />
                </div>
							
						</div>
	        </asp:Panel>
        </asp:View>
            
            
		<asp:View ID="View2" runat="server">
			<div class="row" style="text-align:center">
                 <div class="col-12 shadow rounded">
                     <div class="row" style="text-align:left;">
                       <asp:Image ID="Image9" ImageUrl="~/iconos/icono-confirmacion-de-seguridad.png" runat="server" /><asp:Label ID="Label4" CssClass="col-10" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Autenticacion de seguridad"></asp:Label>
                        
                   </div>   
                     <hr />
                     <br /><br />
                     <div class="row align-content-center" style="text-align:center;">
                         <asp:Label ID="Label5" CssClass="col-form-label col-10" runat="server" Font-Size="Medium" Text="Ingresa tu contraseña para confirmar la transaccion"></asp:Label>.
                     </div><br /><br />
                     <div class="row">
                              <asp:TextBox ID="txtClave" CssClass="form-control col-12 text-center" TextMode="Password" Height="50px" runat="server"></asp:TextBox>
                     </div><br /><br />
                      <div class="row">
                          <asp:Button ID="btnPagar" OnClick="btnPagar_Click"  class="btn btn-primary rounded col-12" Height="50px"  runat="server" Text="Continuar" />
                      </div>
							

						</div>
                <asp:Panel ID="Panel_reserva" class="rounded shadow col-6" runat="server">
                    <div class="rounded shadow col-6" style="height:640px;">
                   <div class="row" style="vertical-align:central">
                       <asp:Image ID="Image6" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="lblReserva" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                        
                   </div>
                    <hr />
                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                       <asp:Image ID="Image4" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label10" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
                   </div>
                    <div class="row" style="vertical-align:central">
                       <asp:Label ID="lblAdultosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="5 adultos"></asp:Label>
                   </div>
                     <div class="row" style="vertical-align:central">
                           <asp:Label ID="lblNinosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="5 niños"></asp:Label>
                       </div>
                    <div class="row" style="vertical-align:central">
                           <asp:Label ID="lblInfanteResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="5 infantes"></asp:Label>
                       </div>

				<asp:Panel ID="panel_ida" Visible="false" runat="server">
					 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                       <asp:Image ID="Image5" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" runat="server" />  <asp:Label ID="lblIdaTitulo" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Ida"></asp:Label>
                   </div>
                    <div class="row" style="text-align:center">
                       <asp:Label ID="lblFechaIdaRes" CssClass="col-lg-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
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
                       <asp:Image ID="Image7" ImageUrl="~/iconos/icono-vuelta-resumen-reserva.png" runat="server" />  <asp:Label ID="lblVueltaTitulo" runat="server" Font-Size="Large"   Font-Bold="true"  Text=""></asp:Label>
                   </div>
                    <div class="row" style="text-align:center">
                       <asp:Label ID="lblFechaVueltaRes" CssClass="col-lg-12" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
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
                       <asp:Image ID="Image8" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" runat="server" /><asp:Label ID="Label12" CssClass="col-4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblTotalRes" CssClass="col-4" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text="Vuelta"></asp:Label>
                   </div>
                    <div class="row" style="vertical-align:central">
                       <asp:Label ID="Label13" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseRes" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="05/08/2021"></asp:Label>
                   </div>
                     <div class="row" style="vertical-align:central">
                           <asp:Label ID="Label14" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpuestosRes" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="5 niños"></asp:Label>
                       </div>
                    <div class="row" style="vertical-align:central;border-style:solid;border-color:yellow;border-width:1px;">
                           <asp:Label ID="Label15" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Ganancia total     "></asp:Label><asp:Label ID="lblGananciaRes" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="5 infantes"></asp:Label>
                       </div>
				</asp:Panel>

                        
                 </div>  
                </asp:Panel>
              
            </div>
		</asp:View>
		<asp:View ID="View3" runat="server">
              <asp:Panel ID="Panel2" HorizontalAlign="Center" runat="server">
			<div class="row" style="text-align:center;margin:0;">
               <div class="rounded shadow col-12" >
                   <div class="row col-12" style="text-align:center;width:100%">
                       .<asp:Image ID="Image10" CssClass="offset-6"  ImageUrl="~/iconos/icono-boleto.png" runat="server" />  
                       </div>
                       <hr />
                       <br /><br />
                   <div class="row" style="text-align:center">
                       <asp:Label ID="Label6" runat="server" Font-Size="Large" CssClass="col-12"   Font-Bold="false"  Text="Boleto emitido correctamente"></asp:Label>
                       <br /><br />
                   </div>
                   <div class="row col-12" style="text-align:center;width:100%"> 
                       <asp:Image ID="Image11" CssClass="offset-4" ImageUrl="~/Logos/logo_smartz.png" runat="server" />  
                       <br /><br />
                       </div>
                <div class="row col-12" style="text-align:center;width:100%"> 
                       <asp:Label ID="Label7" runat="server" Font-Size="Large" CssClass="col-12 text-center"   Font-Bold="false"  Text="¡Felicidades una nueva venta!"></asp:Label>
                       <br /><br />
                       <asp:Label ID="Label8" runat="server" Font-Size="Large" CssClass="col-12 text-center"   Font-Bold="false"  Text="Tu cliente recibirá la confirmación en su correo electrónico con los detalles (Factura electrónica)."></asp:Label>
                       <br /><br />
                       <asp:Label ID="lblCorreoFin" runat="server" Font-Size="Large" CssClass="col-12 text-center"   Font-Bold="true"  Text=""></asp:Label>
                   </div>
                   <br /><br />
                   <div class="row rounded shadow">
                       <div class="row col-12" style="text-align:left;">
                            <asp:Image ID="Image12" ImageUrl="~/iconos/icono-informacion-de-boleto-emitido.png" runat="server" />  
                            <asp:Label ID="Label11" runat="server" Font-Size="Large" CssClass="col-8" ForeColor="Black"  Font-Bold="true"  Text="Información boleto emitido"></asp:Label>
                       </div><br />
                       <hr />
                       <br /><br />
                       <div class="row col-12">
                            <asp:Image ID="Image13" ImageUrl="~/iconos/icono-boleto-emitido.png" runat="server" />  
                            <asp:Label ID="Label16" runat="server" Font-Size="Large" CssClass="col-2 align-content-lg-start" Font-Bold="false"  Text="Tickets emitidos"></asp:Label>
                       </div>
                       <div class="row col-12">
                           	<asp:Repeater ID="Repeater1" runat="server">
											<ItemTemplate><br />
                                                <div class="shadow rounded col-4 m-10">
                                                <div style="display:inline-block">
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                </div>
                                                    <div style="display:inline-block">
                                                    (<asp:Label ID="Label17" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>)
                                                </div>
                                                <div style="display:inline-block">
                                                    <asp:ImageButton ID="ibtnVer" ImageUrl="~/iconos/icono-ver-detalles.png" OnClick="ibtnVer_Click" CommandArgument='<%# Eval("nombre") + "|" + Eval("tipo")+ "|" + Eval("sessionId")+ "|" + Eval("token")+ "|" + Eval("ticket")+ "|" + Eval("correo") %>' runat="server" />

                                                </div>
                                                    <div style="display:inline-block">
                                                    <%--<asp:ImageButton ID="ibtnCompartir" ImageUrl="~/iconos/icono-equipo-de-ventas.png" OnClick="ibtnCompartir_Click" CommandArgument='<%# Eval("nombre") + "|" + Eval("tipo")+ "|" + Eval("sessionId")+ "|" + Eval("token")+ "|" + Eval("ticket")+ "|" + Eval("correo") %>' runat="server" />--%>

                                                </div>
                                                </div>
                                                <br /><br />
											</ItemTemplate>
                                   </asp:Repeater>
                       </div>
                       <br /><br />
                   </div>

                </div>
						<%--	<div class="tab-content col-lg-6">
								<div class="col-lg-12">
									<div class="form-group col-lg-12">
											<strong> LA VENTA SE REALIZO CON EXITO    <i class="fa fa-money"></i></strong>
								</div>
									</div>
								
								<div class="btn-group col-md-12">
									<div class="col-md-6">
									<div class="form-btn">
										<asp:Button ID="btnNuevaVenta" OnClick="btnNuevaVenta_Click"  class="btn btn-success btn-circle btn-sm"  runat="server" Text="Nueva venta" />
										<asp:Button ID="btnIrReservas" OnClick="btnIrReservas_Click"  class="btn btn-success btn-circle btn-sm"  runat="server" Text="Ver Reservas" />
									</div>
								</div>
								
								</div>
								

							</div>--%>
						</div>
                  </asp:Panel>
		</asp:View>
		<asp:View ID="View4" runat="server">
			<iframe name="myIframe" id="myIframe" width="800px" height="600px" runat="server"></iframe>
			<div class="btn-group col-md-12">
									<div class="col-md-6">
									<div class="form-btn">
										<asp:Button ID="btnCanelarIframe" OnClick="btnCanelarIframe_Click"  class="btn btn-primary rounded shadow-sm"  runat="server" Text="Volver a reservas" />
									</div>
								</div>
								
								</div>
		</asp:View>
    </asp:MultiView>
      
	</div>
</asp:Content>
