<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="vuelos.aspx.cs" Inherits="StarzInfiniteWeb.vuelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTipoRuta" runat="server" Visible="false" Text=""></asp:Label>
    <asp:Label ID="lblDtSegmentos" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtSegmentosRT" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtOpciones" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtOpcionesRT" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtDatosRTAll" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtDatosAll" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Text=""></asp:Label>
        <div class="container">
        <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-3 side-bar left-side-bar">
            <div class="side-bar-block booking-form-block">
            <h2 class="selected-price">$568.00 <span>FR 5379</span></h2>
            <div class="booking-form">
                <h3>Book Flight</h3>
                <p>Find your dream flight today</p>
                
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="First Name" required/>
                    </div>
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Last Name" required/>
                    </div><div class="form-group">
                    <input type="email" class="form-control" placeholder="Email" required/></div>
                <div class="form-group"><input type="text" class="form-control" placeholder="Phone" required/>
                    </div>
                <div class="form-group">
                    <input type="text" class="form-control dpd3" placeholder="Booking Date" required/>
                    </div>
                <div class="row">
                    <div class="col-sm-6 col-md-12 col-lg-6 no-sp-r">
                    <div class="form-group right-icon">
                        <select class="form-control">
                        <option selected>Adults</option>
                        <option>1</option><option>2</option><option>3</option></select>
                        <i class="fa fa-angle-down"></i>
                        </div>
                        </div>
                    <div class="col-sm-6 col-md-12 col-lg-6 no-sp-l">
                    <div class="form-group right-icon">
                        <select class="form-control">
                        <option selected>Children</option>
                        <option>1</option><option>2</option><option>3</option>
                            </select>
                        <i class="fa fa-angle-down"></i>
                        </div>
                        </div>
                    </div>
                <div class="form-group right-icon">
                    <select class="form-control">
                    <option selected>Payment Method</option>
                    <option>Credit Card</option>
                    <option>Paypal</option>
                        </select><i class="fa fa-angle-down"></i>
                    </div>
                <div class="checkbox custom-check">
                    <input type="checkbox" id="check01" name="checkbox"/>
                    <label for="check01"><span>
                        <i class="fa fa-check"></i></span>By continuing, you are agree to the 
                    <a href="#">Terms & Conditions.</a>
                        </label>
                    </div>
                <button class="btn btn-block btn-orange">Confirm Booking</button>
                </div><!-- end booking-form -->
                </div><!-- end side-bar-block -->
            
            </div>

            <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                 	<asp:Panel ID="Panel_vuelos_ida" runat="server">
				<div class="rounded shadow" >
                 <%--<div class="row">
                     <div class="col">
                         <asp:Button ID="btnElegirOtroIda" OnClick="btnElegirOtroIda_Click" Visible="false" class="btn btn-primary shadow rounded" CausesValidation="false"  runat="server" Text="Nueva busqueda" />
                     </div>
                    
                 </div>--%>
				<div class="row">
                    <div class="col-12">
                        <asp:Label ID="lblSeleccionVueloFecha" runat="server" Text="Seleccione su vuelo" Font-Bold="true" Visible="true"></asp:Label>
                        <asp:Label ID="lblVueloIdaNoDisponible" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" Visible="true"></asp:Label>
						<%--<asp:Label ID="lblTitTipoVuelo" CssClass="col-form-label-sm shadow rounded-corner" runat="server" Font-Bold="true" ForeColor="Black" Text="Solo Ida" Visible="true"></asp:Label>--%>
                    </div>
					</div>
                         
					<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
					 <ItemTemplate>
								<%--<asp:Label ID="Label11" runat="server" ForeColor="Black"  Font-Bold="true" Text='<%# Eval("paradas") %>'></asp:Label><br />--%>
                                       <br />       <br />
								<div class="rounded shadow" style="background-color:lightblue">					
                                    <div class="row">
                                        <div class="col" style="font-size:medium">
                                            <asp:Label ID="ldlOrigen" runat="server" ForeColor="Black"  Font-Bold="true" Text='<%# Eval("ORIGEN") %>' ></asp:Label>-<asp:Label ID="lblDestino"  Font-Bold="true" ForeColor="Black" runat="server" Text='<%# Eval("DESTINO") %>'></asp:Label><asp:Label ID="lblIdDato" runat="server"  Font-Bold="true" Visible="false" Text='<%# Eval("id_datos") %>'></asp:Label>
                                        </div>
                                    </div>
                                    
                                     <%--<div class="row" style="font-size:medium;background-color:white">--%>
                                        <div class="col">
                                            <asp:Image ID="Image8" ImageUrl="~/iconos/icono-ganancia.png" Height="50px" runat="server" />
                                            <asp:Label ID="Label3" runat="server" ForeColor="Blue" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("moneda") %>'> </asp:Label>
                                            <asp:Label ID="lblCosto" ForeColor="Blue" runat="server" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("precio") %>'></asp:Label>
                                            <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("marketCompany") +".png" %>' runat="server" />

                                        </div>
                                                        <div class="col"></div>
                                                        <div class="col"><br />
                                                            
                                                        </div>
                                         <div class="col">
                                             
                                         </div>
                                    <%--</div>--%>
                                                                   
                                            <asp:Repeater ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
												<ItemTemplate>
                                                    
                                                       
                                                        <div id="accordion" class="card-accordion">
			                                        <!-- begin card -->
			                                        <div class="card" style="font-size:smaller;">
				                                        <div class="card-header text-black pointer-cursor" style="background-color:lightgray;" data-toggle="collapse" data-target='<%# "#collapseOneIda" + Eval("id_datos") + Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                              <div class="row">
                                                        <div class="col"><asp:Button ID="btnElegir" OnClientClick="getVScroll()" CausesValidation="false" class="btn btn-primary btn-sm" ToolTip=""   runat="server" Text="Seleccionar Ida" /></div>
                                                                                       
                                                    </div>
                                                              <div class="row">
                                                        <div class="col">
                                                              <strong> Salida </strong> 
                                                             <br /><asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                             
                                                               <asp:Label ID="Label7" runat="server" ForeColor="Blue" Text='<%# Eval("AEROLINEA") %>'> 
                                                                   <br />
                                                               </asp:Label><asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            <strong> Llegada </strong> 
                                                             <br /><asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" Font-Size="XX-Small" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                        
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                            <br />
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                        
                                                    </div>
                                                        <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            Vuelo:<asp:Label ID="lblNroVueloI" ForeColor="Blue" runat="server" Text=""></asp:Label> Clase:<asp:Label ID="lblClaseI" ForeColor="Blue" runat="server" Text=""></asp:Label> Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                         <asp:Label ID="lblNroVueloV" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblClaseV" runat="server" Visible="false" Text=""></asp:Label>
                                                            <asp:Label ID="lblDisponiblesV" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblEquipajeV" runat="server" Visible="false" Text=""></asp:Label>
                                                              
                                                    </div>
                                                         <div class="row">
                                                                  <div class="col">Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                                      <asp:Label ID="lblEquipajeI"  ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                                  </div>
                                                                  <div class="col">
                                                                      
                                                                      <asp:Image ID="imgEMano" runat="server" />
                                                                  </div>
                                                                  <div class="col">
                                                                     
                                                                  </div>
                                                                  </div>      
					                                     
                                                    </div>
				                                                                        
                                                    <div id='<%# "collapseOneIda" + Eval("id_datos") +Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>' class="collapse" data-parent="#accordion">
					                                <div class="card-body"> 
                                                    <asp:Repeater ID="Repeater3" OnItemDataBound="Repeater3_ItemDataBound" runat="server">
												<ItemTemplate>
                                                                                 
                                                                                        
                                                    <div class="row">
                                                        <div class="col">
                                                                Salida
                                                        </div>
                                                        <div class="col">
                                                            <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                               Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                        </div>
                                                        <div class="col">
                                                                Llegada
                                                        </div>
                                                                                        
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                            <br />Duracion: <asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                        </div>
                                                                                        
                                                    </div>
                                                        <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                        </div>
                                                                                         
                                                    </div>

																	               
												</ItemTemplate>
												</asp:Repeater>


                                                            </div>
                                                    </div>
                                                      
                                                    </div>
                                                </div>
                                                    <%--<div class="row">
                                                        <div class="col" style="align-content:end">
                                                            <asp:CheckBox ID="cbElegir" CssClass="form-check-label checkbox-success rounded" AutoPostBack="true" CausesValidation="false" Text="Selecionar" OnCheckedChanged="cbElegir_CheckedChanged" runat="server" />
                                                        </div>
                                                        
                                                                                       
                                                    </div>--%>
                                                      
                                                    <asp:Label ID="lblIdopcion" runat="server"  Font-Baold="true" Visible="false" Text='<%# Eval("id_opcion") %>'></asp:Label>
                                                    <asp:Label ID="lblIdDatos" runat="server"  Font-Bold="true" Visible="false" Text='<%# Eval("id_datos") %>'></asp:Label>
                                                  
                                                                                    


                                                                   
												<%--<asp:Label ID="lblComision" ForeColor="Blue" runat="server" Text='<%# "(Bs: "+ Eval("comision") + " de Ganancia)" %>'></asp:Label><br />--%>
                                                                             
                                                    </ItemTemplate>
												</asp:Repeater>
                                                    <asp:Repeater ID="Repeater5" OnItemDataBound="Repeater5_ItemDataBound" runat="server">
																                        <ItemTemplate>
                                                                                  
                                                                                             <div id="accordionRT" class="card-accordion">
			                                                                                <!-- begin card -->
			                                                                                <div class="card" style="font-size:smaller;">
				                                                                                <div class="card-header text-black pointer-cursor" style="background-color:lightgray" data-toggle="collapse" data-target='<%# "#collapseOneVuelta" + Eval("id_datos") + Eval("id_opcion")+  Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                                                                    <div class="row">
                                                                                               <div class="col">
                                                                                                   <asp:Button ID="btnElegirRT" class="btn btn-success" ToolTip=""  runat="server" Text="Seleccionar Retorno" />

                                                                                               </div>
                                                                                       
                                                                                           </div>
                                                                  
                                                                                                     <div class="row">
                                                        <div class="col">
                                                              <strong>Salida</strong>   
                                                            <br /><asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                               <asp:Label ID="Label7" ForeColor="Blue" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
                                                            <br /><asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                                <strong>Llegada</strong>   
                                                            <br /><asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" ForeColor="Red" Font-Size="XX-Small" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                        
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                            
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                        
                                                    </div>
                                                        <div class="row">
                                                        <div class="col">
                                                                <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                            Vuelo:<asp:Label ID="lblNroVueloI" ForeColor="Blue" runat="server" Text=""></asp:Label> Clase:<asp:Label ID="lblClaseI" ForeColor="Blue" runat="server" Text=""></asp:Label> Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col">
                                                                <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </div>
                                                                                         <asp:Label ID="lblNroVueloV" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblClaseV" runat="server" Visible="false" Text=""></asp:Label>
                                                            <asp:Label ID="lblDisponiblesV" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblEquipajeV" runat="server" Visible="false" Text=""></asp:Label>
                                                              
                                                    </div>
                                                      <div class="row">
                                                                  <div class="col">Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                                    <asp:Label ID="lblEquipajeI" ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                                  </div>
                                                                  <div class="col">
                                                                      <asp:Image ID="imgEMano" runat="server" />
                                                                  </div>
                                                                  <div class="col">
                                                                     
                                                                  </div>
                                                                  </div>                                              

					                                                                              
                                                                                            </div>
				                                                                        
                                                                                           <div id='<%# "collapseOneVuelta" + Eval("id_datos") +Eval("id_opcion")+  Eval("AEROLINEA").ToString().Replace(" ","") %>' class="collapse" data-parent="#accordionRT">
					                                                                        <div class="card-body"> 
                                                                                            <asp:Repeater ID="Repeater6" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
																                        <ItemTemplate>
                                                                                 
                                                                                        
                                                                                            <div class="row">
                                                                                                <div class="col">
                                                                                                     Salida
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                    <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                                                                      Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                     Llegada
                                                                                                </div>
                                                                                        
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col">
                                                                                                     <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                    <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                                                                     <br />Duración:<asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                     <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                                                                </div>
                                                                                        
                                                                                            </div>
                                                                                             <div class="row">
                                                                                                <div class="col">
                                                                                                     <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                    <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                                                                </div>
                                                                                                <div class="col">
                                                                                                     <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                                                                </div>
                                                                                         
                                                                                            </div>

																	               
																                        </ItemTemplate>
																                        </asp:Repeater>


                                                                                                 </div>
                                                                                            </div>
                                                                                            </div>
                                                                                        </div>
                                                                                              
                                                                                            <asp:Label ID="lblIdopcion" runat="server"  Font-Baold="true" Visible="false" Text='<%# Eval("id_opcion") %>'></asp:Label>
                                                                                            <asp:Label ID="lblIdDatos" runat="server"  Font-Bold="true" Visible="false" Text='<%# Eval("id_datos") %>'></asp:Label>
                                                                                          
                                                                                    


                                                                   
																			         <%--<asp:Label ID="lblComision" ForeColor="Blue" runat="server" Text='<%# "(Bs: "+ Eval("comision") + " de Ganancia)" %>'></asp:Label><br />--%>
                                                                            
                                                                                            </ItemTemplate>
																                        </asp:Repeater>                   
                                                                      
                                        

                                                                   
									<br />
									<%--  <span style="color:blue"><asp:Label ID="lblMoneda" ForeColor="Blue"  runat="server" Text='<%# Eval("moneda") %>'></asp:Label>.:
																	   
																	  
										Clase: <asp:Label ID="lblClase" ForeColor="Blue" runat="server"  Text='<%# Eval("clase") %>'></asp:Label></span>--%>
                                
                                </div>
							</ItemTemplate>
					</asp:Repeater>
					
				</div>
    		   </asp:Panel>
            </div>

             <%--<div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                 <div class="table-responsive">
                    <table class="table table-hover">
                        <tbody>
                        <tr>
                            <td class="dash-list-icon booking-list-date">
                            <div class="b-date">
                                <h3>18</h3><p>October</p>
                                </div>
                                </td>
                            <td class="dash-list-text booking-list-detail">
                            <h3>Tom's Restaurant</h3>
                            <ul class="list-unstyled booking-info">
                                <li><span>Booking Date:</span>26.12.2017 at 03:20 pm</li>
                                <li><span>Booking Details:</span>3 to 6 People</li>
                                <li><span>Client:</span>Lisa Smith<span class="line">|</span>lisasmith@youremail.com<span class="line">|</span>125 254 2578</li>
                                </ul>
                            <button class="btn btn-orange">Message</button>
                                </td>
                            <td class="dash-list-btn">
                            <button class="btn btn-orange">Cancel</button>
                            <button class="btn">Approve</button>
                                </td>
                            </tr>
                       </tbody>
            
                    </table>
                </div><!-- end table-responsive -->
            </div>--%>



            </div>

            
            
        </div>
</asp:Content>
