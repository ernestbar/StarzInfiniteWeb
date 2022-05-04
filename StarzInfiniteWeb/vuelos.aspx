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
     <asp:ObjectDataSource ID="odsRutaInd" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="RUTA INDIVIDUAL" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
    </asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsLineaAerea" runat="server" SelectMethod="Lista" TypeName="StarzInfiniteWeb.Dominios">
		<SelectParameters>
			 <asp:Parameter DefaultValue="AEROLINEA" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
	 </asp:ObjectDataSource>
        <div class="container">
            
        <div class="col-xs-12 col-sm-12 col-md-3 side-bar left-side-bar">
            <div class="side-bar-block booking-form-block">
            <h2 class="selected-price"><span>BUSQUEDAS</span></h2>
            <div class="booking-form">
              <asp:HiddenField ID="hfTipoRuta" Value="RT" runat="server" />
                <div class="form-inline">
                     <input id="cbSoloIda" class="checkbox"  onclick="TipoVuelo()" type="checkbox" />Solo Ida
                    <input id="cbSoloIda2" class="checkbox" checked="checked"  onclick="TipoVuelo2()" type="checkbox" />Ida y vuelta
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlOrigen" Width="230px" class="chosen-select" tabindex="2" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlOrigen_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
                        </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlDestino" Width="230px" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlDestino_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
                    </div>
                <div class="form-group">
                     Fecha de salida:
                     <input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaSalida" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Panel ID="Panel_fecha_regreso" Visible="true" runat="server">
                        Fecha de retorno:
                    <input id="fecha_retorno" class="form-control" onfocus="verificaSalida()"  style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaRetorno" runat="server" />
                    </asp:Panel>
                </div>
                <div class="form-group">
                    <div class="panels-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a href="#panel-1" data-toggle="collapse" >Seleccione Pasajeros<span><i class="fa fa-angle-down"></i></span></a>
                            </div><!-- end panel-heading -->
                            <div id="panel-1" class="panel-collapse collapse">
                                <div class="panel-body text-left">
                                    <ul class="list-unstyled">
                                        <li>Pasajeros Adultos:
												<div class="col-12">
													<input id="adtDecrement" type="button" onclick="decrementar_adt()" value="-" />

													                            
													<asp:TextBox ID="txtAdultos" Width="30px" Text="1" runat="server"></asp:TextBox>
                                                    <asp:RangeValidator runat="server" id="valrNumberOfPreviousOwners" ControlToValidate="txtAdultos"    Type="Integer"    MinimumValue="0"    MaximumValue="9"    CssClass="input-error"    ErrorMessage="Solo numeros del 1 - 9" Font-Size="XX-Small"    Display="Dynamic"></asp:RangeValidator>
												<input id="adtIncrement" onclick="incrementar_adt()" type="button" value="+" />

												</div>
                                        </li>
                                        <li>Pasajeros Niños:
                                            <div class="col-12">
													                            
													<input id="ninDecrement" type="button" onclick="decrementar_nin()" value="-" />
													                            
													<asp:TextBox ID="txtNinos" Width="30px"  Text="0" runat="server"></asp:TextBox>
                                                    <asp:RangeValidator runat="server" id="RangeValidator1" ControlToValidate="txtNinos"    Type="Integer"    MinimumValue="0"    MaximumValue="9"    CssClass="input-error"    ErrorMessage="Solo numeros del 1 - 9" Font-Size="XX-Small"    Display="Dynamic"></asp:RangeValidator>
												<input id="ninIncrement" onclick="incrementar_nin()" type="button" value="+" />
											</div>
                                        </li>
                                        <li>Pasajeros Infantes:
                                                <div class="col-12">
													                            
													<input id="infDecrement" type="button" onclick="decrementar_inf()" value="-" />
													                            
													<asp:TextBox ID="txtInfante" Width="30px"  Text="0" runat="server"></asp:TextBox>
                                                    <asp:RangeValidator runat="server" id="RangeValidator2" ControlToValidate="txtInfante"    Type="Integer"    MinimumValue="0"    MaximumValue="9"    CssClass="input-error"    ErrorMessage="Solo numeros del 1 - 9" Font-Size="XX-Small"    Display="Dynamic"></asp:RangeValidator>
													                            
												<input id="infIncrement" onclick="incrementar_inf()" type="button" value="+" />
											</div>
                                        </li>
                                        <li>Pasajeros Senior:
                                            <div class="col-12">
													<input id="senDecrement" type="button" onclick="decrementar_sen()" value="-" />
													<asp:TextBox ID="txtSenior" Width="30px"  Text="0" runat="server"></asp:TextBox>
                                                    <asp:RangeValidator runat="server" id="RangeValidator3" ControlToValidate="txtSenior"    Type="Integer"    MinimumValue="0"    MaximumValue="9"    CssClass="input-error"    ErrorMessage="Solo numeros del 1 - 9" Font-Size="XX-Small"    Display="Dynamic"></asp:RangeValidator>
												<input id="senIncrement" onclick="incrementar_sen()" type="button" value="+" />
											</div>
                                        </li>

                                    </ul>

                                </div><!-- end panel-body -->
                            </div><!-- end panel-collapse -->

                        </div><!-- end panel-default  -->
                </div>
            </div><!-- end columns -->
                <div class="form-group">
                    <div class="panels-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <a href="#panel-2" data-toggle="collapse" >Filtros<span><i class="fa fa-angle-down"></i></span></a>
                            </div><!-- end panel-heading -->
                            <div id="panel-2" class="panel-collapse collapse">
                                <div class="panel-body text-left">
                                    <ul class="list-unstyled">
                                        <li>Linea Aerea:
									            <div class="col-12">
										            <asp:DropDownList ID="ddlLineArea" CssClass="form-control dropdown-toggle"  tabindex="2" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlLineArea_DataBound"  BackColor="#ecf1fa"  DataSourceID="odsLineaAerea" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
									            </div>
                                        </li>
                                        <li>Turnos:
                                            <div class="col-12">
									            <asp:DropDownList ID="ddlTurnos"  BackColor="#ecf1fa"   CssClass="form-control dropdown-toggle" runat="server">
																						            <asp:ListItem Text="TODAS" Value="TODAS"></asp:ListItem>
																						            <asp:ListItem Text="Mañana" Value="0800"></asp:ListItem>
																						            <asp:ListItem Text="Tarde" Value="1300"></asp:ListItem>
																						            <asp:ListItem Text="Noche" Value="2000"></asp:ListItem>
																						            <asp:ListItem Text="01:00" Value="0100"></asp:ListItem>
																						            <asp:ListItem Text="02:00" Value="0200"></asp:ListItem>
																						            <asp:ListItem Text="03:00" Value="0300"></asp:ListItem>
																						            <asp:ListItem Text="04:00" Value="0400"></asp:ListItem>
																						            <asp:ListItem Text="05:00" Value="0500"></asp:ListItem>
																						            <asp:ListItem Text="06:00" Value="0600"></asp:ListItem>
																						            <asp:ListItem Text="07:00" Value="0700"></asp:ListItem>
																						            <asp:ListItem Text="08:00" Value="0800"></asp:ListItem>
																						            <asp:ListItem Text="09:00" Value="0900"></asp:ListItem>
																						            <asp:ListItem Text="10:00" Value="1000"></asp:ListItem>
																						            <asp:ListItem Text="11:00" Value="1100"></asp:ListItem>
																						            <asp:ListItem Text="12:00" Value="1200"></asp:ListItem>
																						            <asp:ListItem Text="13:00" Value="1300"></asp:ListItem>
																						            <asp:ListItem Text="14:00" Value="1400"></asp:ListItem>
																						            <asp:ListItem Text="15:00" Value="1500"></asp:ListItem>
																						            <asp:ListItem Text="16:00" Value="1600"></asp:ListItem>
																						            <asp:ListItem Text="17:00" Value="1700"></asp:ListItem>
																						            <asp:ListItem Text="18:00" Value="1800"></asp:ListItem>
																						            <asp:ListItem Text="19:00" Value="1900"></asp:ListItem>
																						            <asp:ListItem Text="20:00" Value="2000"></asp:ListItem>
																						            <asp:ListItem Text="21:00" Value="2100"></asp:ListItem>
																						            <asp:ListItem Text="22:00" Value="2200"></asp:ListItem>
																						            <asp:ListItem Text="23:00" Value="2300"></asp:ListItem>
																						            <asp:ListItem Text="00:00" Value="0000"></asp:ListItem>
																					            </asp:DropDownList>
								            </div>
                                        </li>
                                        <li>Cabina:
                                                <div class="col-12">
									            <asp:DropDownList ID="ddlCabina"  BackColor="#ecf1fa"   CssClass="form-control dropdown-toggle" runat="server">
																						            <asp:ListItem Text="TODAS" Value="TODAS"></asp:ListItem>
																						            <asp:ListItem Text="Economic" Value="Economic"></asp:ListItem>
																						            <asp:ListItem Text="First" Value="First"></asp:ListItem>
																						            <asp:ListItem Text="Business" Value="Business"></asp:ListItem>
																					            </asp:DropDownList>
								            </div>
                                        </li>
                                        <li>
                                            <div class="col-12">
                                                                                
										            <asp:CheckBox ID="cbEquipaje" Font-Bold="true" Text="Con equipaje?" runat="server" />
								            </div>
                                        </li>
                                            <li>
                                            <div class="col-12">
										            <asp:CheckBox ID="cbVueloDirecto" Font-Bold="true" Text="Vuelos directo?" runat="server" />
								            </div>
                                        </li>
                                    </ul>

                                </div><!-- end panel-body -->
                            </div><!-- end panel-collapse -->

                        </div><!-- end panel-default  -->
                </div>
            </div><!-- end columns -->

               
                <div class="form-group">
                    <asp:RadioButtonList ID="rblTipoVenta" RepeatDirection="Horizontal" runat="server">
					    <asp:ListItem Text="NORMAL" Value="0" Selected="True"></asp:ListItem>
					    <asp:ListItem Text="CORPORATIVO" Value="1"></asp:ListItem>
				    </asp:RadioButtonList>
                    </div>
                <asp:Button ID="btnVuelos" class="btn btn-orange" OnClientClick="recuperarFechaSalida()" OnClick="btnVuelos_Click"  runat="server" Text="Buscar vuelos" />
                </div><!-- end booking-form -->
                </div><!-- end side-bar-block -->
            
            </div>



            <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side" style="height:700px; overflow: scroll;">
                <asp:Label ID="lblVueloIdaNoDisponible" runat="server" Text=""></asp:Label>
					<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
					 <ItemTemplate>
                         <%--NUEVA FICHA DE VIAJES--%>
                          <div class="available-blocks" id="available-tours">
                            
                            <div class="list-block main-block t-list-block">
                                <div class="list-content">
                                       <ul class="list-unstyled list-inline offer-price-1" style="background-color:white">
                                           <li>
                                              <asp:Label ID="ldlOrigen" runat="server" ForeColor="Black"  Font-Bold="true" Text='<%# Eval("ORIGEN") %>' ></asp:Label>-
                                               <asp:Label ID="lblDestino"  Font-Bold="true" ForeColor="Black" runat="server" Text='<%# Eval("DESTINO") %>'></asp:Label>
                                               <asp:Label ID="lblIdDato" runat="server"  Font-Bold="true" Visible="false" Text='<%# Eval("id_datos") %>'></asp:Label>
                                           </li>
                                           <li>
                                               <asp:Label ID="Label3" runat="server" ForeColor="Blue" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("moneda") %>'> </asp:Label>
                                                <asp:Label ID="lblCosto" ForeColor="Blue" runat="server" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("precio") %>'></asp:Label>
                                            </li>
                                            <li>
                                                <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("marketCompany") +".png" %>' runat="server" />
                                           </li>
                                           <li>
                                               <a href="tour-detail-left-sidebar.html" class="btn btn-orange btn-lg">COMPRAR</a>
                                           </li>
                                       </ul>
                                   
                                    <div class="list-info t-list-info">
                                        <h3 class="block-title">
                                             
                                        </h3>
                                         <asp:Repeater ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
												<ItemTemplate>
                                                    <div id="accordion" class="card-accordion">
			                                        <!-- begin card -->
			                                        <div class="card" style="font-size:smaller;">
                                                        <ul class="list-unstyled list-inline offer-price-1" style="background-color:lightgray">
                                                                <li>
                                                                    <input id="cbElijeIda" class="checkbox" type="checkbox" OnClick="checkAll(this)" />
                                                                </li>
                                                            <li>
                                                                Seleccionar ida
                                                            </li>
                                                            </ul>
				                                        <div class="card-header text-black pointer-cursor" style="background-color:lightgoldenrodyellow" data-toggle="collapse" data-target='<%# "#collapseOneIda" + Eval("id_datos") + Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                            
                                                            
                                                             <ul class="list-unstyled list-inline offer-price-1">
                                                                 
                                                                 
                                                                <li>
                                                                    <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                <li>
                                                                    <asp:Label ID="Label7" runat="server" ForeColor="Blue" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
                                                                    <asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                    Vuelo:<asp:Label ID="lblNroVueloI" ForeColor="Blue" runat="server" Text=""></asp:Label> 
                                                                    Clase:<asp:Label ID="lblClaseI" ForeColor="Blue" runat="server" Text=""></asp:Label> 
                                                                    Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                <li>
                                                                    <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                 <li>
                                                                     <asp:Label ID="Label8" runat="server" ForeColor="Blue" Text='<%# Eval("id_opcion") %>'></asp:Label>
                                                                 </li>
                                                                 <li>

                                                                 </li>
                                                            </ul>
                                                            <ul class="list-unstyled list-inline offer-price-1">
                                                                <li>
                                                                    Salida <asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                <li>
                                                                     <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                                </li>
                                                                <li>
                                                                    Llegada <asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" Font-Size="XX-Small" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                </li>
                                                            </ul>
                                                              <ul class="list-unstyled list-inline">
                                                                  <li>
                                                                      Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                                      <asp:Label ID="lblEquipajeI"  ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                                  </li>
                                                                  <li>
                                                                       <asp:Image ID="imgEMano" runat="server" />
                                                                  </li>
                                                                  <li>
                                                                    <asp:Label ID="lblNroVueloV" Visible="false" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lblClaseV" runat="server" Visible="false" Text=""></asp:Label>
                                                                    <asp:Label ID="lblDisponiblesV" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lblEquipajeV" runat="server" Visible="false" Text=""></asp:Label>
                                                                  </li>
                                                                 
                                                              </ul>

                                                             <hr />
                                                     <div class="row">
                                                        <div class="col">
                                                            <asp:Button ID="btnElegir" OnClientClick="getVScroll()" CausesValidation="false" class="btn btn-primary btn-sm" ToolTip="" Visible="false"   runat="server" Text="Seleccionar Ida" /></div>
                                                    </div>
					                                     
                                                    </div>
				                                                                        
                                                    <div id='<%# "collapseOneIda" + Eval("id_datos") +Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>' class="collapse" data-parent="#accordion">
					                                <div class="card-body" style="background-color:white"> 
                                                    <asp:Repeater ID="Repeater3" OnItemDataBound="Repeater3_ItemDataBound" runat="server">
												    <ItemTemplate>
                                                     <ul class="list-unstyled list-inline offer-price-1">
                                                                <li>
                                                                    Salida
                                                                </li>
                                                                <li>
                                                                    <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                                    Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                                </li>
                                                                <li>
                                                                    Llegada
                                                                </li>
                                                            </ul>
                                                        <ul class="list-unstyled list-inline offer-price-1">
                                                                <li>
                                                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'></asp:Label>
                                                                </li>
                                                                <li>
                                                                    <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                            <br />Duracion: <asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                                </li>
                                                                <li>
                                                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                                </li>
                                                            </ul>
                                                          <ul class="list-unstyled list-inline offer-price-1">
                                                                <li>
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                                </li>
                                                                <li>
                                                                   <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                                </li>
                                                                <li>
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                                </li>
                                                            </ul>
																	               
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

                                                <asp:Repeater ID="Repeater5" OnItemDataBound="Repeater5_ItemDataBound" runat="server">
												<ItemTemplate>
                                                                                 
                                                    <div id="accordionRT" class="card-accordion">
			                                        <!-- begin card -->
			                                        <div class="card" style="font-size:smaller;">
				                                        <div class="card-header text-black pointer-cursor" style="background-color:#309fd9" data-toggle="collapse" data-target='<%# "#collapseOneVuelta" + Eval("id_datos") + Eval("id_opcion")+  Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                            <div class="row">
                                                        <div class="col">
                                                            <asp:Button ID="btnElegirRT" class="btn btn-success" ToolTip="" Visible="false" runat="server" Text="Seleccionar Retorno" />

                                                        </div>
                                                                                       
                                                    </div>
                                                           
                                                     <ul class="list-unstyled list-inline offer-price-1">
                                                          <h3>VUELO DE VUELTA</h3> 
                                                        <li>
                                                            <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </li>
                                                         <li>
                                                              <asp:Label ID="Label7" ForeColor="Blue" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
                                                            <asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                              Vuelo:<asp:Label ID="lblNroVueloI" ForeColor="Blue" runat="server" Text=""></asp:Label> 
                                                            Clase:<asp:Label ID="lblClaseI" ForeColor="Blue" runat="server" Text=""></asp:Label> 
                                                            Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                            
                                                         </li>
                                                         <li>
                                                              <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                         </li>
                                                     </ul>
                                                     <ul class="list-unstyled list-inline offer-price-1">
                                                        <li>
                                                            Salida
                                                            <asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                        </li>
                                                         <li>
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%> 
                                                         </li>
                                                         <li>
                                                              Llegada
                                                            <asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" ForeColor="Red" Font-Size="XX-Small" runat="server" Text=""></asp:Label>
                                                             <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                         </li>
                                                     </ul>
                                                     <ul class="list-unstyled list-inline offer-price-1">
                                                        <li>
                                                            Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                             <asp:Label ID="lblEquipajeI" ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                        </li>
                                                         <li>
                                                              <asp:Image ID="imgEMano" runat="server" />
                                                         </li>
                                                         <li>
                                                             <asp:Label ID="lblNroVueloV" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblClaseV" runat="server" Visible="false" Text=""></asp:Label>
                                                            <asp:Label ID="lblDisponiblesV" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="lblEquipajeV" runat="server" Visible="false" Text=""></asp:Label>
                                                         </li>
                                                         
                                                     </ul>
                                                             
                                                    </div>
				                                                                       
                                            <div id='<%# "collapseOneVuelta" + Eval("id_datos") +Eval("id_opcion")+  Eval("AEROLINEA").ToString().Replace(" ","") %>' class="collapse" data-parent="#accordionRT">
					                        <div class="card-body"> 
                                            <asp:Repeater ID="Repeater6" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
										    <ItemTemplate>
                                              <ul class="list-unstyled list-inline offer-price-1">
                                                <li>
                                                    Salida
                                                </li>
                                                  <li>
                                                      <asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                        Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                  </li>
                                                  <li>
                                                      Llegada
                                                  </li>
                                              </ul> 
                                               <ul class="list-unstyled list-inline offer-price-1">
                                                <li>
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                </li>
                                                  <li>
                                                       <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                        <br />Duración:<asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                  </li>
                                                  <li>
                                                      <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                  </li>
                                              </ul>
                                            <ul class="list-unstyled list-inline offer-price-1">
                                                <li>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                </li>
                                                  <li>
                                                      <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                  </li>
                                                  <li>
                                                      <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                  </li>
                                              </ul>
																	               
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
                                        
                                    </div><!-- end t-list-info -->
                                </div><!-- end list-content -->
                            </div><!-- end t-list-block -->
                            </div>
                    <%--FIN NUEVA FICHA DE VIAJES--%>
				
							</ItemTemplate>
					</asp:Repeater>
					
				
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
    <script type="text/javascript">
    function getVScroll() {
        document.getElementById('scroll').value = document.getElementById('scrollVuelos').scrollTop;
        document.getElementById('scrollVuelos').scrollTop = document.getElementById('scroll').value;
    }
</script>

    <script>
        function formatISOLocal(d) {
            let z = n => ('0' + n).slice(-2);
            return d.getFullYear() + '-' + z(d.getMonth() + 1) + '-' + z(d.getDate());
        };
        function formatISOLocal2(d) {
            let z = n => ('0' + n).slice(-2);
            return d.getFullYear() + '-' + z(d.getMonth() + 1) + '-' + z(d.getDate() + 1);
        };
        function formatISOLocalNino(d) {
            let z = n => ('0' + n).slice(-2);
            return d.getFullYear() + '-' + z(d.getMonth() + 1) + '-' + z(d.getDate() + 1);
        };
        function bloquear() {
            let inp = document.querySelector('#fecha_salida');
            let d = new Date();
            inp.min = formatISOLocal(d);
            inp.defaultValue = inp.min;
            d.setFullYear(d.getFullYear() + 1);
            inp.max = formatISOLocal(d);
            // Debug
            console.log(inp.outerHTML);
            //let inp1 = document.querySelector('#fecha_retorno');
            //let d1 = new Date();
            //inp1.min = formatISOLocal(d1);
            //inp1.defaultValue = inp1.min;
            //d1.setFullYear(d1.getFullYear() + 1);
            //inp1.max = formatISOLocal(d1);
            //// Debug
            //console.log(inp1.outerHTML);
        };
        function bloquearNino() {
            let inp3 = document.querySelector('#fecha_nac_nino');
            let d = new Date();
            let d2 = new Date();
            d.setFullYear(d.getFullYear() - 11);
            inp3.min = formatISOLocal(d);

            d2.setFullYear(d2.getFullYear() - 2);
            inp3.max = formatISOLocal(d2);
            inp3.defaultValue = inp3.max;
            // Debug
            console.log(inp3.outerHTML);
            //let inp1 = document.querySelector('#fecha_retorno');
            //let d1 = new Date();
            //inp1.min = formatISOLocal(d1);
            //inp1.defaultValue = inp1.min;
            //d1.setFullYear(d1.getFullYear() + 1);
            //inp1.max = formatISOLocal(d1);
            //// Debug
            //console.log(inp1.outerHTML);
        };
        function verificaSalida() {

            let inp1 = document.querySelector('#fecha_retorno');
            let d1 = new Date(document.getElementById('fecha_salida').value);
            inp1.min = formatISOLocal2(d1);
            inp1.defaultValue = inp1.min;
            d1.setFullYear(d1.getFullYear() + 1);
            inp1.max = formatISOLocal2(d1);
            // Debug
            console.log(inp1.outerHTML);
        };
    </script>
        <script type="text/javascript">
            function incrementar_adt() {

                var tx = document.getElementById('<%=txtAdultos.ClientID%>');
                if (parseInt(tx.value) < 9)
                    tx.value = parseInt(tx.value) + 1;
                document.getElementById('<%=txtAdultos.ClientID%>').value = tx.value;
                document.getElementById('<%=txtSenior.ClientID%>').value = 0;
                document.getElementById('<%=txtInfante.ClientID%>').value = 0;
                document.getElementById('<%=txtNinos.ClientID%>').value = 0;

            }
            function decrementar_adt() {

                var tx = document.getElementById('<%=txtAdultos.ClientID%>');
                if (parseInt(tx.value) > 0)
                    tx.value = parseInt(tx.value) - 1;
                document.getElementById('<%=txtAdultos.ClientID%>').value = tx.value;
            }
            function incrementar_nin() {

                var tx = document.getElementById('<%=txtNinos.ClientID%>');
                var txAdt = document.getElementById('<%=txtAdultos.ClientID%>');
                if (parseInt(tx.value) < (9 - (parseInt(txAdt.value))))
                    tx.value = parseInt(tx.value) + 1;
                document.getElementById('<%=txtNinos.ClientID%>').value = tx.value;
            }
            function decrementar_nin() {

                var tx = document.getElementById('<%=txtNinos.ClientID%>');

                if (parseInt(tx.value) > 0)
                    tx.value = parseInt(tx.value) - 1;
                document.getElementById('<%=txtNinos.ClientID%>').value = tx.value;
            }
            function incrementar_inf() {

                var tx = document.getElementById('<%=txtInfante.ClientID%>');
                var txAdt = document.getElementById('<%=txtAdultos.ClientID%>');
                if (parseInt(tx.value) < parseInt(txAdt.value))
                    tx.value = parseInt(tx.value) + 1;
                document.getElementById('<%=txtInfante.ClientID%>').value = tx.value;
            }
            function decrementar_inf() {

                var tx = document.getElementById('<%=txtInfante.ClientID%>');
                if (parseInt(tx.value) > 0)
                    tx.value = parseInt(tx.value) - 1;
                document.getElementById('<%=txtInfante.ClientID%>').value = tx.value;
			}
            function incrementar_sen() {

                var tx = document.getElementById('<%=txtSenior.ClientID%>');
                if (parseInt(tx.value) < 9)
                    tx.value = parseInt(tx.value) + 1;
                document.getElementById('<%=txtSenior.ClientID%>').value = tx.value;
                document.getElementById('<%=txtInfante.ClientID%>').value = 0;
                document.getElementById('<%=txtNinos.ClientID%>').value = 0;
                document.getElementById('<%=txtAdultos.ClientID%>').value = 0;
			}
            function decrementar_sen() {

                var tx = document.getElementById('<%=txtSenior.ClientID%>');
				if (parseInt(tx.value) > 0)
					tx.value = parseInt(tx.value) - 1;
                document.getElementById('<%=txtSenior.ClientID%>').value = tx.value;
            }
            function recuperarFechaSalida() {

                document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
                document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
            }

            function TipoVuelo() {

                
                if (document.getElementById("cbSoloIda").checked == true) {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').value = "OW";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'hidden';
                    var cbIV = document.getElementById("cbSoloIda2");
                    cbIV.checked = false;
                    //window.alert("sirve");
                }
                <%--else
                {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').valuee ="RT";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'visible';
                    var cbIV = document.getElementById("cbSoloIda2");
                    cbIV.checked = true;
                }--%>
                
            }

            function TipoVuelo2() {


                if (document.getElementById("cbSoloIda2").checked == true) {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').value = "RT";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'visible';
                    var cbIV = document.getElementById("cbSoloIda");
                    cbIV.checked = false;
                    //window.alert("sirve");
                }
                <%--else
                {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').valuee ="OW";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'hidden';
                    var cbIV = document.getElementById("cbSoloIda2");
                    cbIV.checked = true;
                }--%>

            }
        </script>
    <script type="text/javascript">

   <%--     function recuperarFechaNino() {

            document.getElementById('<%=hfFechaNino.ClientID%>').value = document.getElementById('fecha_nac_nino').value;
		}

    function recuperarFechaInf() {

            document.getElementById('<%=hfFechaNacInf.ClientID%>').value = document.getElementById('fecha_nac_inf').value;
        }--%>
    </script>

    


    <script>

        const options = {
            margin: 0.5,
            filename: 'invoice.pdf',
            image: {
                type: 'jpeg',
                quality: 500
            },
            html2canvas: {
                scale: 1
            },
            jsPDF: {
                unit: 'in',
                format: 'letter',
                orientation: 'portrait'
            }
        }

        $('.btn-download').click(function (e) {
            e.preventDefault();
            const element = document.getElementById('invoice');
            html2pdf().from(element).set(options).save();
        });

        function exportPDF() {
            const element = document.getElementById('invoice');
            html2pdf().from(element).set(options).save();
            printDiv('invoice');
        }


        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            //window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <script type="text/javascript">
        function checkAll(cb) {

            var elemArray = document.getElementsByClassName('Repeater1');
            for (var i = 0; i < elemArray.length; i++) {
                window.alert(cb);
                var elem = elemArray[i].value;
            }


<%--            var ctrls = document.getElementsByName('<%=Repeater1.NamingContainer %>');
            for (var i = 0; i < ctrls.length; i++) {
                window.alert(cb);
                var cbox = ctrls[i];
                if (cbox.type == "Repeater") {
                    var ctrls2 = document.getElementsByTagName('Repeater2');
                   
                    for (var x = 0; x < ctrls2.length; x++) {
                        var cbox2 = ctrls[x];
                        if (cbox2.type == "checkbox") {
                            cbox2.checked = cb.checked;
                        }
                    }
                }
                
            }--%>
        }
    </script>
</asp:Content>
