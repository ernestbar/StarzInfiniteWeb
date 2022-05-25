<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="vuelos.aspx.cs" Inherits="StarzInfiniteWeb.vuelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
    <asp:Label ID="lblTipoRuta" runat="server" Visible="false" Text=""></asp:Label>
    <asp:Label ID="lblDtSegmentos" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtSegmentosRT" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtOpciones" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtOpcionesRT" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtDatosRTAll" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblDtDatosAll" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Text=""></asp:Label>

     <asp:Label ID="lblItiIda" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblItiVuelta" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="lblOrigen" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblDestino" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblOrigenDes" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblDestinoDes" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblGds" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblNroSeniors" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblNroAdultos" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblNroNinos" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblNroInfante" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblFeeSZI" Visible="false"  runat="server" Text="0"></asp:Label>
    <asp:Label ID="lblFeeBroker" Visible="false"  runat="server" Text="0"></asp:Label>
     <asp:Label ID="lblMoneda" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="lblCodTiket" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="lblFechaLimite" runat="server" Text="" Visible="false"></asp:Label>
    	<asp:Label ID="lblDatosVueloIda" runat="server" Text="" Visible="false"></asp:Label>

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
      
            <asp:Panel ID="Panel_flitros" runat="server">
        <div class="col-xs-12 col-sm-12 col-md-3 side-bar left-side-bar">
               
            <div class="side-bar-block booking-form-block">
            
                 <div id="accordionB" class="card-accordion">
					<!-- begin card -->
						<div class="card-header" data-toggle="collapse" data-target="#collapseB">
                            <h2 class="selected-price"><span>BUSQUEDAS</span></h2>
                          </div>

                         <div id="collapseB"  data-parent="#accordionB">
							
                                  
            <div class="booking-form">
              <asp:HiddenField ID="hfTipoRuta" Value="RT" runat="server" />
                <div class="form-inline">
                 <input id="cbSoloIda" class="checkbox"   onclick="TipoVuelo()" type="checkbox" />Solo Ida
                    <input id="cbSoloIda2" class="checkbox" onclick="TipoVuelo2()" type="checkbox" />Ida y vuelta
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
					    <asp:ListItem Text="NORMAL" Value="0"></asp:ListItem>
					    <asp:ListItem Text="CORPORATIVO" Value="1"></asp:ListItem>
				    </asp:RadioButtonList>
                    </div>
                <asp:Button ID="btnVuelos" class="btn btn-orange" OnClientClick="recuperarFechaSalida()" OnClick="btnVuelos_Click"  BackColor="#309fd9" runat="server" Text="Buscar vuelos" />
                </div><!-- end booking-form -->
               


                             
                             </div>


              </div>
                </div>  
            
            
            </div><!-- end side-bar-block -->

            </asp:Panel>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side" style="height:800px; overflow: scroll;">
                        <asp:Label ID="lblVueloIdaNoDisponible" runat="server" Text=""></asp:Label>
					        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
					         <ItemTemplate>
                                 <%--NUEVA FICHA DE VIAJES--%>
                                  <div class="available-blocks" id="available-tours" style="border:solid 3px;">
                            
                                    <div class="list-block main-block t-list-block">
                                        <div class="list-content">
                                               
                                   
                                            <div class="list-info t-list-info">
                                                <h3 class="block-title">
                                             
                                                </h3>
                                                 <asp:Repeater ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
												        <ItemTemplate>
                                                            <div id="accordion" class="card-accordion">
			                                                <!-- begin card -->
			                                                <div class="card" style="font-size:smaller;">
                                                                <ul class="list-unstyled list-inline" style="background-color:lightgray;height:20px">
                                                                        <li>
                                                                            <asp:CheckBox ID="cbElegirIda" runat="server" Text="Elegir ida" CssClass="ClaseIda"/>
                                                                            <asp:Image ID="Image1" runat="server" Height="15" ImageUrl="~/iconos/icono-avion-ticket.png" />
                                                                            <%--<input id="cbElijeIda" class="checkbox" type="checkbox" OnClick="checkAll(this)" />--%>
                                                                        </li>
                                                           
                                                                    </ul>
				                                                <div class="card-header text-black pointer-cursor" style="background-color:white" data-toggle="collapse" data-target='<%# "#collapseOneIda" + Eval("id_datos") + Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                                  <ul class="list-unstyled list-inline" style="text-align:left;font-size:xx-small;height:30px">
                                                                        <li>
                                                                            <asp:Image ID="imgIda" Height="20" runat="server" />
                                                                            <asp:Label ID="Label7" runat="server" ForeColor="Blue" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
                                                                            </li>
                                                                         </ul>
                                                                            
                                                                    <ul class="list-unstyled list-inline col-12" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                        <li>
                                                                            <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                            <asp:Label ID="lblNroVueloI" ForeColor="Blue" Visible="false" runat="server" Text=""></asp:Label> 
                                                                            <asp:Label ID="lblClaseI" ForeColor="Blue" Visible="false" runat="server" Text=""></asp:Label> 
                                                                            
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                         <li>
                                                                             
                                                                         </li>
                                                                    </ul>
                                                                    <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                         <li>
                                                                            
                                                                            <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                        <li>
                                                                             Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                             <asp:Label ID="Label8" runat="server" ForeColor="Blue" Visible="false" Text='<%# Eval("id_opcion") %>'></asp:Label> 
                                                                             <asp:Image ID="Image6" Visible="false" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                        <li>

                                                                        </li>
                                                                    </ul>
                                                                     <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                         <li>
                                                                             <asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                         <li>
                                                                             Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                                              <asp:Label ID="lblEquipajeI"  ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                                             <asp:Image ID="imgEMano" runat="server" />
                                                                        </li>
                                                                         <li>
                                                                             <asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" Font-Size="XX-Small" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                        </li>
                                                                     </ul>
                                                                      <ul class="list-unstyled list-inline">
                                                                          <li>
                                                                            
                                                                          </li>
                                                                          
                                                                          <li>
                                                                            <asp:Label ID="lblNroVueloV" Visible="false" runat="server" Text=""></asp:Label>
                                                                            <asp:Label ID="lblClaseV" runat="server" Visible="false" Text=""></asp:Label>
                                                                            <asp:Label ID="lblDisponiblesV" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label>
                                                                            <asp:Label ID="lblEquipajeV" runat="server" Visible="false" Text=""></asp:Label>
                                                                          </li>
                                                                 
                                                                      </ul>
                                                                     
                                                           <%--  <div class="row">
                                                                <div class="col">
                                                               </div>     
                                                            </div>--%>
					                                     <asp:Button ID="btnElegir" OnClientClick="getVScroll()" CausesValidation="false" class="btn btn-primary btn-sm" ToolTip="" Visible="false"   runat="server" Text="Seleccionar Ida" /></div>
                                                            
				                                                                        
                                                            <div id='<%# "collapseOneIda" + Eval("id_datos") +Eval("id_opcion")+ Eval("AEROLINEA").ToString().Replace(" ","") %>' class="collapse" data-parent="#accordion">
					                                        <div class="card-body" style="background-color:white"> 
                                                            <asp:Repeater ID="Repeater3" OnItemDataBound="Repeater3_ItemDataBound" runat="server">
												            <ItemTemplate>
                                                             <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
                                                                        <li>
                                                                            Salida
                                                                        </li>
                                                                        <li>
                                                                            <asp:Image ID="Image3" Height="20" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                                            Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            Llegada
                                                                        </li>
                                                                    </ul>
                                                                <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
                                                                        <li>
                                                                            <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'></asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Image ID="Image6" Height="10" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                                    <br />Duracion: <asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'></asp:Label>
                                                                        </li>
                                                                    </ul>
                                                                  <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
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
                                                                 <ul class="list-unstyled list-inline" style="background-color:lightgray;height:20px">
                                                                        <li>
                                                                            <asp:CheckBox ID="cbElegirVuelta" runat="server" Text="Elegir Retorno" CssClass="ClaseVuelta"/>
                                                                            <asp:Image ID="Image1" runat="server" Height="15" ImageUrl="~/iconos/icono-avion-ticket-reverse.png" />
                                                                            <%--<input id="cbElijeIda" class="checkbox" type="checkbox" OnClick="checkAll(this)" />--%>
                                                                        </li>
                                                           
                                                                    </ul>
				                                                <div class="card-header text-black pointer-cursor" style="background-color:white" data-toggle="collapse" data-target='<%# "#collapseOneVuelta" + Eval("id_datos") + Eval("id_opcion")+  Eval("AEROLINEA").ToString().Replace(" ","") %>'>
                                                                   <%-- <div class="row">
                                                                <div class="col">
                                                                    

                                                                </div>
                                                                                       
                                                            </div>--%>
                                                           <asp:Button ID="btnElegirRT" class="btn btn-success" ToolTip="" Visible="false" runat="server" Text="Seleccionar Retorno" />
                                                              <ul class="list-unstyled list-inline col-12" style="text-align:left;font-size:xx-small;vertical-align:top;height:20px">
                                                               
                                                                 <li>
                                                                     <asp:Image ID="imgVuelta" Height="20" runat="server" />
                                                                      <asp:Label ID="Label7" ForeColor="Blue" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
                                                                </li>
                                                               </ul>

                                                                 <ul class="list-unstyled list-inline col-12" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                      <li>

                                                                    <asp:Label ID="lblOrigenI" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                 <li>
                                                                    <asp:Label ID="lblEscalas" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                     <asp:Label ID="lblNroVueloI" Visible="false" ForeColor="Blue" runat="server" Text=""></asp:Label> 
                                                                    <asp:Label ID="lblClaseI" ForeColor="Blue" Visible="false" runat="server" Text=""></asp:Label> 
                                                                 </li>
                                                                     <li>
                                                                      <asp:Label ID="lblDestinoV" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                 </li>
                                                                     <li>

                                                                     </li>
                                                                </ul>
                                                                 
                                                             <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                <li>
                                                                    
                                                                    <asp:Label ID="lblHoraSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                 <li>
                                                                     Lugares disp.:<asp:Label ID="lblDisponiblesI" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                    <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" Visible="false" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%> 
                                                                 </li>
                                                                 <li>
                                                                    
                                                                     <asp:Label ID="lblHoraLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                 </li>
                                                                 <li>

                                                                 </li>
                                                             </ul>
                                                            <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top;height:15px">
                                                                <li>
                                                                    <asp:Label ID="lblFechaSalidaI" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                    <li>
                                                                        Equipaje <asp:Image ID="imgEBodega" ImageUrl="~/iconos/icono-maleta-viaje-png.png" Height="20" runat="server" />
                                                                     <asp:Label ID="lblEquipajeI" ForeColor="Blue" Font-Size="XX-Small" runat="server" Visible="true" Text=""></asp:Label>
                                                                        <asp:Image ID="imgEMano" runat="server" />
                                                                </li>
                                                                    <li>
                                                                        <asp:Label ID="lblFechaLlegadaV" ForeColor="Blue" runat="server" Text=""></asp:Label><asp:Label ID="lblnIndicador" ForeColor="Red" Font-Size="XX-Small" runat="server" Text=""></asp:Label>
                                                                </li>
                                                                <li>

                                                                </li>
                                                            </ul>
                                                             <ul class="list-unstyled list-inline" style="text-align:center;font-size:small;vertical-align:top">
                                                                <li>
                                                                    
                                                                    
                                                                </li>
                                                                 <li>
                                                                      
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
                                                      <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
                                                        <li>
                                                            Salida
                                                        </li>
                                                          <li>
                                                              <asp:Image ID="Image3" Height="20" ImageUrl='<%# "~/Logos/" + Eval("operCompany") +".png" %>' runat="server" />
                                                                Airline:<asp:Label ID="Label7" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                          </li>
                                                          <li>
                                                              Llegada
                                                          </li>
                                                      </ul> 
                                                       <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
                                                        <li>
                                                                <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'></asp:Label>
                                                            </li>
                                                            <li>
                                                                <asp:Image ID="Image6" Height="10" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                        <br />Duracion: <asp:Label ID="Label44" runat="server" ForeColor="Black" Text='<%# Eval("duracion") %>'></asp:Label>
                                                            </li>
                                                            <li>
                                                                <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'></asp:Label>
                                                            </li>
                                                      </ul>
                                                    <ul class="list-unstyled list-inline" style="text-align:center;font-size:xx-small;vertical-align:top">
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
                                            <ul class="list-unstyled list-inline" style="background-color:lightblue;height:70px;width:100%;font-size:xx-small">
                                                   <li>
                                                      <asp:Label ID="ldlOrigen" runat="server" ForeColor="Black"  Font-Bold="true" Text='<%# Eval("ORIGEN") %>' ></asp:Label>-
                                                       <asp:Label ID="lblDestino"  Font-Bold="true" ForeColor="Black" runat="server" Text='<%# Eval("DESTINO") %>'></asp:Label>
                                                       <asp:Label ID="lblIdDato" runat="server"  Font-Bold="true" Visible="false" Text='<%# Eval("id_datos") %>'></asp:Label>
                                                   </li>
                                                   <li>
                                                       <asp:Label ID="Label3" runat="server" ForeColor="Green" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("moneda") %>'> </asp:Label>
                                                        <asp:Label ID="lblCosto" ForeColor="Green" runat="server" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("precio") %>'></asp:Label>
                                                    </li>
                                                    <li>
                                                        <%--<asp:Image ID="Image3" ImageUrl='<%# "~/Logos/" + Eval("marketCompany") +".png" %>' runat="server" />--%>
                                                   </li>
                                                   <li>
                                                       <asp:Button ID="btnComprar" class="btn btn-orange btn-md col-4" OnClick="btnComprar_Click" runat="server" Text="COMPRAR" />
                                                       <%--<a href="tour-detail-left-sidebar.html" class="btn btn-orange btn-lg">COMPRAR</a>--%>
                                                   </li>
                                               </ul>
                                        </div><!-- end list-content -->
                                    </div><!-- end t-list-block -->
                                    </div>
                            <%--FIN NUEVA FICHA DE VIAJES--%>
				
							        </ItemTemplate>
					        </asp:Repeater>
					
				
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                      <%--PANTALLA DE RESUMEN ITINERARIO--%>
                      <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                         
                         
                                 <div class="row">
                                     <%--<div class="col"><asp:Button ID="btnNuevaBusqueda" OnClick="btnNuevaBusqueda_Click" class="btn btn-default rounded" CausesValidation="false" Visible="false"  runat="server" Text="Nueva busqueda" /></div>   --%>     
                                     <asp:Panel ID="panel_continuar" Visible="false" runat="server">
                                        <div class="col"><asp:Button ID="btnContinuar" OnClick="btnContinuar_Click" class="btn btn-primary rounded" CausesValidation="false"  runat="server" Text="Continuar Pasajeros" /></div>
                                        <div class="col"><asp:Button ID="btnVolver"  OnClientClick="exportPDF()" class="btn btn-orange rounded" CausesValidation="false" Visible="true"  runat="server" Text="Exportar a PDF" /></div>
                                        <div class="col"><asp:Button ID="btnVerVuelos" OnClick="btnVerVuelos_Click" class="btn btn-success rounded" CausesValidation="false" Visible="true"  runat="server" Text="Elegir otro vuelo" /></div>
                                    </asp:Panel> 
                                        
                                 </div>
                             
				          
			             <asp:Panel ID="Panel_resumen" runat="server">
                             <asp:Label ID="lblMsgGetPrecioSinPNR" runat="server" ForeColor="Red" Text=""></asp:Label>
                           <div class="rounded shadow">
                               <div id="invoice" style="font-size:small">
                                    <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image25" Height="50" ImageUrl="~/Logos/encabezado_logo.png" runat="server" /> 
                               </div>
                               <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image61" Height="20" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="lblReserva" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                               </div>
                                <hr />
                                 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image2" Height="20" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label10" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
                               </div>
                             <div class="row" style="vertical-align:central;text-align:center">
                                 <div class="col">
                                     <asp:Label ID="lblSeniorsResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                 </div>
                                 <div class="col">
                                     <asp:Label ID="lblSeniorPrecios" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                 </div>
                                   
                                 
                               </div>
                                <div class="row" style="vertical-align:central;text-align:center">
                                    <div class="col">
                                          <asp:Label ID="lblAdultosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                        <asp:Label ID="lblAdultosPrecios" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                 </div>
                                 
                                 
                               </div>
                                 <div class="row" style="vertical-align:central;text-align:center">
                                     <div class="col">
                                         <asp:Label ID="lblNinosResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                         <asp:Label ID="lblNinosPrecios" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                 </div>
                                       
                                   </div>
                                <div class="row" style="vertical-align:central;text-align:center">
                                    <div class="col">
                                        <asp:Label ID="lblInfanteResumen" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                        <asp:Label ID="lblInfantePrecios" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                 </div>
                                 
                                       
                                   </div>
                                   <strong></strong>
				            <asp:Panel ID="panel_ida" Visible="false" Font-Size="XX-Small" runat="server">
                            <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image14" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="lblIdaTitulo" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Ida"></asp:Label>
                               </div>
				                    <div class="row">
                                        <div class="col">
                                        </div>
                                        <div class="col" style="font-size:medium;text-align:center">
                                            <strong>AEROLINEA - <asp:Label ID="lblAreolineaNombResIda" Font-Size="Medium" runat="server" Text="">:</asp:Label></strong>
                                        </div>
                                            <div class="col">
                                            <asp:Label ID="lblEscalasResIda" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                           <asp:Repeater ID="Repeater9"  runat="server">
												<ItemTemplate>
                                                                                 
                                                                                        
                                                  <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                Salida
                                                        </li>
                                                        <li>
                                                                Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'>:</asp:Label> Airline:<asp:Label ID="Label23" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                                Llegada
                                                        </li>
                                                                                        
                                                   </ul>
                                                    <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                        </li>
                                                                                        
                                                    </ul>
                                                       <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                        </li>
                                                             
                                                           <li>
                                                               Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                        </li>
                                                           <li>
                                                               Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                        </li>
                                                    </ul>

																	               
												</ItemTemplate>
												</asp:Repeater>
				            </asp:Panel>
				            <asp:Panel ID="panel_vuelta" Visible="false" Font-Size="XX-Small" runat="server">
					             <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image4" ImageUrl="~/iconos/icono-Vuelta-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="lblVueltaTitulo" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Vuelta"></asp:Label>
                               </div>
                                <div class="row">
                                        <div class="col">
                                        </div>
                                      <div class="col" style="font-size:medium;text-align:center">
                                            <strong>AEROLINEA - <asp:Label ID="lblAreolineaNombResVuelta" runat="server" Text="">:</asp:Label></strong>
                                        </div>
                                            <div class="col">
                                            <asp:Label ID="lblEscalasResVuelta" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                <asp:Repeater ID="Repeater10"  runat="server">
												<ItemTemplate>
                                                                                 
                                                                                        
                                                    <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                Salida
                                                        </li>
                                                        <li>
                                                                Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'></asp:Label>  Airline:<asp:Label ID="Label24" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                                Llegada
                                                        </li>
                                                                                        
                                                    </ul>
                                                     <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> 
                                                        </li>
                                                        <li>
                                                                 <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                        </li>
                                                                                        
                                                    </ul>
                                                         <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                        </li>
                                                              <li>
                                                               Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                        </li>
                                                           <li>
                                                               Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                        </li>
                                                                                         
                                                    </ul>

																	               
												</ItemTemplate>
												</asp:Repeater>
				            </asp:Panel>


                                


				            <asp:Panel ID="panel_total_res" Visible="false" Font-Size="XX-Small" runat="server">
					             <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image7" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" Height="20" runat="server" /><asp:Label ID="Label12" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblMonedaIda" CssClass="col-3" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true" Text=""></asp:Label><asp:Label ID="lblTotalRes" CssClass="col-5" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label>
                               </div>
                                <asp:Panel ID="Panel_total_desglose" Visible="false" runat="server">
                                        <div class="row" style="vertical-align:central;text-align:center">
                                   <asp:Label ID="Label13" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                               </div>
                                 <div class="row" style="vertical-align:central;text-align:center">
                                       <asp:Label ID="Label14" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpuestosRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                               <div class="row" style="vertical-align:central;text-align:center">
                                       <asp:Label ID="Label28" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Fee emision    "></asp:Label><asp:Label ID="lblFeeEmisionRes" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                                <div class="row" style="vertical-align:central;text-align:center">
                                       <asp:Label ID="Label32" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text="Otros cargos    "></asp:Label><asp:Label ID="lblOtrosCargos" CssClass="col-6" runat="server" Font-Size="Medium"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                                 </asp:Panel>
                                </asp:Panel>
                                   <hr />

                                   <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="Label40" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="Informacion Adicional"></asp:Label>
                                   </div>
                                   <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="lblInfoAddFecha" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                                   <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="Label41" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="* Las opciones se encuentran sujetas a la disponibilidad y el precio puede variar sin aviso previo."></asp:Label>
                                   </div>
                                   <div class="row">
                                       <div class="col">
                                           <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="Label42" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="Para cualquier pregunta, contáctenos por correo electronico. "></asp:Label>
                                   </div>
                                           <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="lblInfoAddMail" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                                   <hr />
                                   <div class="row" style="vertical-align:central;font-size:xx-small;text-align:center">
                                       <asp:Label ID="lblInfoAddFechaGeneracion" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text=""></asp:Label>
                                   </div>
                                   
                                       </div>
                                       
                                   </div>
                                   
                                    </div>  
                                <asp:Panel ID="panel_rango" Font-Size="XX-Small" runat="server">
                                        <div class="row">
						                    <div class="col-12 col-md-3"><asp:TextBox ID="txtComision" CssClass="form-control col-12 col-md-3" Text="0" runat="server"></asp:TextBox>
                                                <asp:Label ID="lblAvisoRango" runat="server" ForeColor="Red" Font-Size="XX-Small" Text=""></asp:Label>
                                                <asp:RangeValidator runat="server" id="RangeValidator4" ControlToValidate="txtComision"    Type="Integer"    MinimumValue="0"    MaximumValue="99"    CssClass="input-error"    ErrorMessage="Solo numeros enteros" Font-Size="XX-Small"    Display="Dynamic"></asp:RangeValidator>
						                    </div>
                                            <div class="col">
                                                <asp:ImageButton ID="imgCambiarFee" ImageUrl="~/iconos/heart.png" Height="30" OnClick="imgCambiarFee_Click" runat="server" />
                                            </div>
                                            
                                        </div>
                                            <div class="row">
						                    <div class="col-12 col-md-2"><asp:Label ID="Label5" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="Rango de comision entre:"></asp:Label></div>
						                    <div class="col-12 col-md-2"><asp:Label ID="lblComisionDesde"  runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="0"></asp:Label></div>
						                    <div class="col-12 col-md-2"><asp:Label ID="lblComisionHasta"  runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="0"></asp:Label></div>
                                           </div>
				                    </asp:Panel>
                                 
                        <div class="row">
                                    <div class="col"><asp:Label ID="Label11" runat="server" Font-Size="XX-Small"   Font-Bold="false"  Text="* Verifica la informacion del itinerario."></asp:Label></div>
                                               
                                           </div>
                    </div>
                        
                        </asp:Panel>
                              
                    

           </div>
                </asp:View>

                <asp:View ID="View3" runat="server">
                    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                    <asp:Label ID="lblPasajerosAux" runat="server" Text="" Visible="false"></asp:Label>
                
                                     <div class="row">
                                    <asp:Panel ID="panel_continuar_pasajero" Visible="false" runat="server">
                                        <div class="col">
                                                 <asp:Button ID="btnContinuarPasajero" OnClick="btnContinuarPasajero_Click" class="btn btn-primary rounded" CausesValidation="true"  runat="server" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" Text="Realizar Reserva" />
                                         </div>
				                    </asp:Panel>     
                                         <div class="col">
                                             <%--<asp:Button ID="btnNuevoVueloPas" OnClick="btnNuevoVueloPas_Click" class="btn btn-default rounded" CausesValidation="false"  runat="server" Text="Nueva busqueda" />--%>
                                         </div>
                                       </div>
                                    <div class="row">
				                    <asp:Image ID="Image5" ImageUrl="~/iconos/icono-datos-de-pasajero.png" runat="server" />  <asp:Label ID="Label15" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Datos de pasajero(s)"></asp:Label>
			                    </div>
		                    <div class="col-12 col-md-8">
			
			                    <div class="rounded shadow col-12">
								                    <div id="accordion2" class="card-accordion">
									                    <asp:Panel ID="panel_seniors" runat="server">
									                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor  btn-g-border" style="background-color:silver" data-toggle="collapse" data-target="#collapseTwo">
											                    PASAJEROS TERECERA EDAD      <i class="fa fa-arrow-circle-down"></i>
                                                            <asp:Label ID="lblCountSen" runat="server" Text="0"></asp:Label>
										                    </div>
										                    <div id="collapseTwo" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <%--<div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Codigo viajero frecuente:</span><br />
																	                    <div style="display:inline-block">
																		                    <asp:TextBox ID="TextBox1" ValidationGroup="padulto" CssClass="form-control col-11" runat="server"></asp:TextBox>
																		                    </div>
																		                    <div style="display:inline-block">
																	                    <asp:LinkButton ID="LinkButton1" OnClick="lbtnVerificar_Click" CssClass="submit col-2" CausesValidation="false" Font-Size="Small" runat="server"><i class="fa fa-check-circle"></i>Verificar código</asp:LinkButton>
																                    </div>
																                    </div>
															                    </div>--%>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Tipo de documento:</span>
                                                                                        <asp:DropDownList ID="ddlTipoDocSen" CssClass="form-control" runat="server">
                                                                                            <asp:ListItem Text="Carnet de identidad" Value="NI"></asp:ListItem>
                                                                                            <asp:ListItem Text="Pasaporte" Value="PP"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <br />
																	                    <asp:TextBox ID="txtCiSen" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtCi" ValidationGroup="padultosen" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Nombres:</span><br />
																	                    <asp:TextBox ID="txtNombresSen" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtNombre" ValidationGroup="padultosen" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Apellidos:</span><br />
																	                    <asp:TextBox ID="txtApellidosSen" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtApellidos" ValidationGroup="padultosen" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
								
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">
																	                    <asp:Button ID="btnAgregarPasajeroSen" class="btn btn-primary btn-circle btn-sm" ValidationGroup="padultosen" OnClick="btnAgregarPasajeroSen_Click" runat="server" Text="Agregar" />
																                    </div>
															                    </div>

												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
									
								                    <!-- end card -->
									                    </asp:Panel>
									                    <asp:Panel ID="Panel_adl" runat="server">
									                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor btn-g-border" style="background-color:#309fd9" data-toggle="collapse" data-target="#collapseSeven">
											                    PASAJEROS ADULTOS      <i class="fa fa-arrow-circle-down"></i>
                                                            <asp:Label ID="lblCountAdl" runat="server" Text="0"></asp:Label>
										                    </div>
										                    <div id="collapseSeven" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <%--<div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Codigo viajero frecuente:</span><br />
																	                    <div style="display:inline-block">
																		                    <asp:TextBox ID="txtCodFrec" ValidationGroup="padulto" CssClass="form-control col-11" runat="server"></asp:TextBox>
																		                    </div>
																		                    <div style="display:inline-block">
																	                    <asp:LinkButton ID="lbtnVerificar" OnClick="lbtnVerificar_Click" CssClass="submit col-2" CausesValidation="false" Font-Size="Small" runat="server"><i class="fa fa-check-circle"></i>Verificar código</asp:LinkButton>
																                    </div>
																		
																                    </div>
															                    </div>--%>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Tipo de documento:</span>
                                                                                        <asp:DropDownList ID="ddlTipoDocAdt" CssClass="form-control" runat="server">
                                                                                            <asp:ListItem Text="Carnet de identidad" Value="NI"></asp:ListItem>
                                                                                            <asp:ListItem Text="Pasaporte" Value="PP"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <br />
																	                    <asp:TextBox ID="txtCi" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCi" ValidationGroup="padulto" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Nombres:</span><br />
																	                    <asp:TextBox ID="txtNombre" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNombre" ValidationGroup="padulto" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Apellidos:</span><br />
																	                    <asp:TextBox ID="txtApellidos" ValidationGroup="padulto" CssClass="form-control col-lg-12" runat="server" ></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtApellidos" ValidationGroup="padulto" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
								
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">
																	                    <asp:Button ID="btnAgregarPasajero" class="btn btn-primary btn-circle btn-sm" ValidationGroup="padulto" OnClick="btnAgregarPasajero_Click" runat="server" Text="Agregar" />
																                    </div>
															                    </div>

												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
									
								                    <!-- end card -->
									                    </asp:Panel>
									                    <asp:Panel ID="Panel_chl" runat="server">
								                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor  btn-g-border" style="background-color:#309fd9" data-toggle="collapse" data-target="#collapseFive">
											                    PASAJEROS NIÑOS      <i class="fa fa-arrow-circle-down"></i>
                                                            <asp:Label ID="lblNinosCount" runat="server" Text="0"></asp:Label>
										                    </div>
										                    <div id="collapseFive" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Tipo de documento:</span>
                                                                                        <asp:DropDownList ID="ddlTipoDocNin" CssClass="form-control" runat="server">
                                                                                            <asp:ListItem Text="Carnet de identidad" Value="NI"></asp:ListItem>
                                                                                            <asp:ListItem Text="Pasaporte" Value="PP"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <br />
																	                    <asp:TextBox ID="txtCiNino" ValidationGroup="pnino" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtCiNino" ValidationGroup="pnino" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Nombres:</span><br />
																	                    <asp:TextBox ID="txtNombreNino" ValidationGroup="pnino" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtNombreNino" ValidationGroup="pnino" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Apellidos:</span><br />
																	                    <asp:TextBox ID="txtApellidoNino" ValidationGroup="pnino" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtApellidoNino" ValidationGroup="pnino" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-12 col-md-3">

																	                    <span class="form-label">Fecha de Nacimiento:</span><br />
																	                    <input id="fecha_nac_nino" class="form-control" onfocus="bloquearNino()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaNino" runat="server" />
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-6">
																	                    <asp:Button ID="btnAgregarNino" class="btn btn-primary btn-circle btn-sm" OnClientClick="recuperarFechaNino()" CausesValidation="true" ValidationGroup="pnino" OnClick="btnAgregarNino_Click" runat="server" Text="Agregar" />
																                    </div>
															                    </div>

												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
									
								                    <!-- end card -->
									                    </asp:Panel>
									                    <asp:Panel ID="Panel_inf" runat="server">
									                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor  btn-g-border" style="background-color:#309fd9" data-toggle="collapse" data-target="#collapseSix">
											                    PASAJEROS INFANTES      <i class="fa fa-arrow-circle-down"></i>
                                                            <asp:Label ID="lblInfaneCount" runat="server" Text="0"></asp:Label>
										                    </div>
										                    <div id="collapseSix" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Tipo de documento:</span>
                                                                                        <asp:DropDownList ID="ddlTipoDocInf" CssClass="form-control" runat="server">
                                                                                            <asp:ListItem Text="Carnet de identidad" Value="NI"></asp:ListItem>
                                                                                            <asp:ListItem Text="Pasaporte" Value="PP"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <br />
																	                    <asp:TextBox ID="txtCiInf" ValidationGroup="pinf" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtCiInf" ValidationGroup="pinf" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Nombres:</span><br />
																	                    <asp:TextBox ID="txtNombreInf" ValidationGroup="pinf" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtNombreInf" ValidationGroup="pinf" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Apellidos:</span><br />
																	                    <asp:TextBox ID="txtApellidoInf" ValidationGroup="pinf" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																	                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtApellidoInf" ValidationGroup="pinf" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-12 col-md-3">

																	                    <span class="form-label">Fecha de Nacimiento:</span><br />
																	                    <input id="fecha_nac_inf" class="form-control" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaNacInf" runat="server" />
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-6">
																	                    <asp:Button ID="btnAgregarInfante" class="btn btn-primary btn-circle btn-sm" OnClientClick="recuperarFechaInf()" ValidationGroup="pinf" OnClick="btnAgregarInfante_Click" runat="server" Text="Agregar" />
																                    </div>
															                    </div>

												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
									
								                    <!-- end card -->
										                    </asp:Panel>
									                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor  btn-g-border" style="background-color:#309fd9" data-toggle="collapse" data-target="#collapseTre">
											                    <asp:Image ID="Image15" ImageUrl="~/iconos/icono-facturacion.png" Height="30px" runat="server" />
											                    DATOS DE FACTURACION      <i class="fa fa-arrow-circle-down"></i>
											                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Yellow" ControlToValidate="txtRazonSocial" ErrorMessage="*"></asp:RequiredFieldValidator>
											                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Yellow" ControlToValidate="txtNit" ErrorMessage="*"></asp:RequiredFieldValidator>
										                    </div>
										                    <div id="collapseTre" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Razon Social</span><br />
																	                    <asp:TextBox ID="txtRazonSocial" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>

																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">NIT</span><br />
																	                    <asp:TextBox ID="txtNit" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																                    </div>
															                    </div>

												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
								                    <!-- end card -->
									                    <!-- begin card -->
									                    <div class="card">
										                    <div class="card-header text-white pointer-cursor  btn-g-border" style="background-color:#309fd9" data-toggle="collapse" data-target="#collapseFour">
											                    <asp:Image ID="Image8" ImageUrl="~/iconos/icono-datos-de-contacto.png" Height="30px" runat="server" />
											                    DATOS DE CONTACTO      <i class="fa fa-arrow-circle-down"></i>
											                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ForeColor="Yellow" ControlToValidate="txtEmailTit" ErrorMessage="*"></asp:RequiredFieldValidator>
											                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTelefonoTit" ForeColor="Yellow" ErrorMessage="*"></asp:RequiredFieldValidator>
										                    </div>
										                    <div id="collapseFour" class="collapse" data-parent="#accordion2">
											                    <div class="card-body">
												                    <div class="row">
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Correo electronico titular</span><br />
																	                    <asp:TextBox ID="txtEmailTit" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
                                                                    
																                    </div>
															                    </div>
													                    <div class="col-lg-12">
																                    <div class="form-group col-lg-12">

																	                    <span class="form-label">Telefono del titular</span><br />
																	                    <asp:TextBox ID="txtTelefonoTit" CssClass="form-control col-lg-6" runat="server"></asp:TextBox>
																	
																                    </div>
															                    </div>
												                    </div>
																
												                    </div>
											                    </div>
										                    </div>
								                    <!-- end card -->
									                    </div>
								                    <div class="row">
                                                        <h3>Listado de clientes agregados</h3>
									                    <%--<asp:GridView ID="gvPasajeros" AutoGenerateColumns="false" runat="server"></asp:GridView>--%>
										                    <div class="table-responsive">
											                    <table class="table-condensed">
												                    <thead>
													                    <tr>
														                    <%--<th class="text">NRO</th>--%>
														                    <th class="text">CI</th>
														                    <th class="text">NOMBRES</th>
														                    <th class="text">APELLIDOS</th>
														                    <th class="text">TIPO</th>
														                    <th></th>
														                    </tr>
												                    </thead>
													                    <tbody>
														                    <asp:Repeater ID="Repeater7" DataSourceID="" runat="server">
															                    <ItemTemplate>
																                    <tr>
																	                    <%--<td><asp:Label ID="lblNumero" runat="server" Text='<%# Eval("nro") %>'></asp:Label></td>--%>
																	                    <td><asp:Label ID="lblCI" runat="server" Text='<%# Eval("documento") %>'></asp:Label></td>
																	                    <td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("nombre") %>'></asp:Label></td>
																	                    <td><asp:Label ID="lblApellidos" runat="server" Text='<%# Eval("apellido") %>'></asp:Label></td>
																	                    <td><asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo_pax") %>'></asp:Label></td>
																	                    <td><asp:LinkButton ID="lbtnQuitar" CausesValidation="false" OnClick="lbtnQuitar_Click" CommandArgument='<%# Eval("documento") +"|"+ Eval("tipo_pax") %>' runat="server"> <i class="fa fa-trash"></i></asp:LinkButton></td>
																                    </tr>
																	
															                    </ItemTemplate>
														                    </asp:Repeater>
													                    </tbody>
											                    </table>

										                    </div>
									                    </div>
                                    <asp:Panel ID="panel4" Visible="true" runat="server">
					                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                           <asp:Image ID="Image24" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" runat="server" /><asp:Label ID="Label22" CssClass="col-4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblMonedaPasajero" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label><asp:Label ID="lblTotalReservaPasajero" CssClass="col-4" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text="Vuelta"></asp:Label>
                                       </div>
                                        <div class="row" style="vertical-align:central">
                                           <asp:Label ID="Label30"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBasePasajeros" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                       </div>
                                         <div class="row" style="vertical-align:central">
                                               <asp:Label ID="Label34"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Total impuestos    "></asp:Label><asp:Label ID="lblTotalImpPasajeros" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                           </div>
                                        <div class="row" style="vertical-align:central">
                                               <asp:Label ID="Label39"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Fee de emision:"></asp:Label><asp:Label ID="lblFeeEmisionPasajeros" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="0"></asp:Label>
                                           </div>
                                          <div class="row" style="vertical-align:central">
                                                           <asp:Label ID="Label36" runat="server" Font-Size="Small"   Font-Bold="false"  Text="Otros cargos    "></asp:Label><asp:Label ID="lblOtrosCargosPasajeros" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
                                                       </div>
                                        <div class="row" style="vertical-align:central">
                                               <asp:Label ID="Label43"  runat="server" Font-Size="Small" Visible="false"  Font-Bold="false"  Text="Comision:"></asp:Label><asp:Label ID="lblComisionPasajeros" Visible="false" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text="0"></asp:Label>
                                           </div>
                                        <div class="row" style="vertical-align:central;border-style:solid;border-color:yellow;border-width:1px;">
                                               <asp:Label ID="Label45" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text="Ganancia total     "></asp:Label><asp:Label ID="Label46" CssClass="col-6" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text=""></asp:Label>
                                           </div>
				                    </asp:Panel>
                                  
								
									                    </div>
		                    </div>
                        </div>
                </asp:View>
                <asp:View ID="View4" runat="server">
                  <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                       
		                    <div class="shadow rounded col-12 col-md-6" >
                                 <div class="row">
                                      <asp:Label ID="lblAvisoReserva" runat="server" Text="" ForeColor="Red"></asp:Label>
                                           <asp:Image ID="Image16" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label16" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Reserva creada"></asp:Label>
                        
                                       </div>
                                    <hr />
                                   <div class="row" style="text-align:center;">
                                           <asp:Label ID="Label17" runat="server" Font-Size="Large" CssClass="col-12 align-content-center"  Font-Bold="true"  Text="Tu código de reserva (PNR):"></asp:Label>
                                       </div>
                                    <div style="text-align:center;">
                                           <asp:TextBox ID="txtPNR" ReadOnly="true" CssClass="form-control" Font-Bold="true" Font-Size="Large" Height="50px" runat="server"></asp:TextBox>
                                       </div>
                                 <div class="row align-content-center col-12" style="text-align:center;">
                                           <asp:Image ID="Image17" ImageUrl="~/iconos/icono-tiempo-limite.png" CssClass="offset-6" runat="server" /> 
                                       </div>
                                 <div class="row" style="text-align:center;">
                                           <asp:Label ID="Label18" runat="server" Font-Size="Medium" CssClass="col-12 align-content-center"  Font-Bold="false"  Text="Tiempo limite de emisión:"></asp:Label>
                                       </div>
                                 <div class="row" style="text-align:center;">
                                         <asp:Label ID="lblTiempoLimite" CssClass="col-12 align-content-center" runat="server" Text=""></asp:Label>
                                       </div>
            
                                <div class="row">
					                    <div class="col-12 col-md-5"><asp:Button ID="btnGuardarReserva" OnClick="btnGuardarReserva_Click"  class="btn btn-success rounded"  runat="server" Text="Pagar Luego" /></div>
					                    <div class="col-12 col-md-5"><asp:Button ID="btnComprarReserva" OnClick="btnComprarReserva_Click"  class="btn btn-primary rounded"  runat="server" Text="Pagar Ahora" /></div>	
                                        <%--<div class="col"><asp:Button ID="btnNuevaBusquedaReserva" OnClick="btnNuevaBusquedaReserva_Click"  class="btn btn-default rounded"  runat="server" Text="Nueva busqueda" /></div>	--%>
						
				                    </div>
			
                               <br />
                                <hr />
                                
                                 <asp:Label ID="lblTotalPagarFinal" CssClass="label-default col-md-6" Visible="false" runat="server" Text=""></asp:Label>
	                    </div>
                          </div>


                    <div class="row">
                        <div class="rounded shadow col-12 col-md-6">
                            <div id="invoice2" style="font-size:small">
                                    <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image9" Height="50" ImageUrl="~/Logos/encabezado_logo.png" runat="server" /> 
                               </div>
                               <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image10" Height="20" ImageUrl="~/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label50" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                               </div>
                                <hr />
                                 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image11" Height="20" ImageUrl="~/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label51" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
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
                                   <asp:Image ID="Image12" ImageUrl="~/iconos/icono-ida-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="Label60" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Ida"></asp:Label>
                               </div>
				                    <div class="row">
                                        <div class="col">
                                        </div>
                                        <div class="col" style="font-size:medium;text-align:center">
                                            <strong>AEROLINEA - <asp:Label ID="lblAreolineaNombResIdaRes" Font-Size="Medium" runat="server" Text="">:</asp:Label></strong>
                                        </div>
                                            <div class="col">
                                            <asp:Label ID="lblEscalasResIdaRes" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                           <asp:Repeater ID="Repeater11"  runat="server">
												<ItemTemplate>
                                                                                 
                                                                                        
                                                  <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                Salida
                                                        </li>
                                                        <li>
                                                                Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'>:</asp:Label> Airline:<asp:Label ID="Label23" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                                Llegada
                                                        </li>
                                                                                        
                                                   </ul>
                                                    <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> <%--<i class="fa fa-plane-departure fa-fw"></i><hr />--%>
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                        </li>
                                                                                        
                                                    </ul>
                                                       <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                        </li>
                                                             
                                                           <li>
                                                               Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                        </li>
                                                           <li>
                                                               Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                        </li>
                                                    </ul>

																	               
												</ItemTemplate>
												</asp:Repeater>
				            </asp:Panel>
				            <asp:Panel ID="panel_vueltaRes" Visible="false" Font-Size="XX-Small" runat="server">
					             <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image13" ImageUrl="~/iconos/icono-Vuelta-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="Label63" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Vuelta"></asp:Label>
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
                                <asp:Repeater ID="Repeater12"  runat="server">
												<ItemTemplate>
                                                                                 
                                                                                        
                                                    <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                Salida
                                                        </li>
                                                        <li>
                                                                Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'></asp:Label>  Airline:<asp:Label ID="Label24" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                                Llegada
                                                        </li>
                                                                                        
                                                    </ul>
                                                     <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label47" runat="server" ForeColor="Black" Text='<%# Eval("depDate") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("depTime") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Image ID="Image6" ImageUrl="~/iconos/salida-llegada-ticket.png" runat="server" /> 
                                                        </li>
                                                        <li>
                                                                 <asp:Label ID="Label48" runat="server" ForeColor="Black" Text='<%# Eval("ArrivalDate") %>'></asp:Label> - <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("hora_llegada") %>'>:</asp:Label>
                                                        </li>
                                                                                        
                                                    </ul>
                                                         <ul class="list-unstyled list-inline offer-price-1" style="text-align:center">
                                                        <li>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("boardAirport") %>'>:</asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass")+ " Disponibles "  +Eval("lugres_disponibles")%>'></asp:Label><br />
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
                                                        </li>
                                                              <li>
                                                               Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                        </li>
                                                           <li>
                                                               Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                        </li>
                                                                                         
                                                    </ul>

																	               
												</ItemTemplate>
												</asp:Repeater>
				            </asp:Panel>


                                


				            <asp:Panel ID="panel_total_resRes" Visible="false" Font-Size="XX-Small" runat="server">
					             <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image26" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" Height="20" runat="server" /><asp:Label ID="Label66" CssClass="col-4" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="Label67" CssClass="col-3" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true" Text=""></asp:Label><asp:Label ID="Label68" CssClass="col-5" runat="server" Font-Size="Medium"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label>
                               </div>
                                <asp:Panel ID="Panel8" Visible="false" runat="server">
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

                                   
                                    </div>
                            

                                       <div class="row" style="vertical-align:central">
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
				                    <asp:Panel ID="panel2" Visible="false" runat="server">
					                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                           <asp:Image ID="Image22" ImageUrl="~/iconos/icono-vuelta-resumen-reserva.png" runat="server" />  <asp:Label ID="Label26" runat="server" Font-Size="Large"   Font-Bold="true"  Text=""></asp:Label>
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
				                    <asp:Panel ID="panel3" Visible="true" runat="server">
					                     <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                           <asp:Image ID="Image23" ImageUrl="~/iconos/icono-carrita-resumen-reserva.png" runat="server" /><asp:Label ID="Label27" CssClass="col-4" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Total  "></asp:Label><asp:Label ID="lblMonedaReserva" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text=""></asp:Label><asp:Label ID="lblMontoTotalReserva" CssClass="col-4" runat="server" Font-Size="Large"  ForeColor="#0066ff"  Font-Bold="true"  Text="Vuelta"></asp:Label>
                                       </div>
                                        <div class="row" style="vertical-align:central">
                                           <asp:Label ID="Label29"  runat="server" Font-Size="Small"   Font-Bold="false"  Text="Tarifa base     "></asp:Label><asp:Label ID="lblTarifaBaseReserva" CssClass="col-6" runat="server" Font-Size="Small"   Font-Bold="false"  Text=""></asp:Label>
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
                                               <asp:Label ID="Label38" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text="Ganancia total     "></asp:Label><asp:Label ID="lblGananciaRes" CssClass="col-6" runat="server" Font-Size="Small" Visible="false"   Font-Bold="false"  Text=""></asp:Label>
                                           </div>
				                    </asp:Panel><br /><br />
                            <div class="row">
                                       <div class="row">
                                           <asp:Image ID="Image18" ImageUrl="~/iconos/icono-datos-de-pasajero.png" runat="server" />  <asp:Label ID="Label19" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Lista de pasajeros"></asp:Label>
                                            <br /><br />
                                       </div>
                                    <div class="table-responsive offset-1">
											                    <table class="col-12 col-md-9 table-borderless">
												                    <thead>
													                    <tr>
														                    <%--<th class="text">NRO</th>--%>
														                    <th class="text">CI</th>
														                    <th class="text">NOMBRES</th>
														                    <th class="text">APELLIDOS</th>
														                    <th class="text">TIPO</th>
														
														                    </tr>
												                    </thead>
													                    <tbody>
														                    <asp:Repeater ID="Repeater8" DataSourceID="" runat="server">
															                    <ItemTemplate>
																                    <tr>
																	                    <%--<td><asp:Label ID="lblNumero" runat="server" Text='<%# Eval("nro") %>'></asp:Label></td>--%>
																	                    <td><asp:Label ID="lblCI" runat="server" Text='<%# Eval("documento") %>'></asp:Label></td>
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
                                 <%--   <asp:Panel ID="panel_continuar" Visible="false" runat="server">
                                         <div class="row" style="vertical-align:central">
					                        <asp:Button ID="btnContinuar" OnClick="btnContinuar_Click" class="btn btn-primary btn-lg rounded col-8" Font-Size="Large" CausesValidation="false"  runat="server" Text="Continuar" />
                                             </div>
				                    </asp:Panel>--%>

                        
                    
                                </div>
                    </div>
                </asp:View>
            </asp:MultiView>

            

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

            
            

    <script src="<%=ResolveClientUrl("~/js/jquery.min.js")%>"></script>

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
            console.log(inp.outerHTML);
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
            console.log(inp3.outerHTML);
        };
        function verificaSalida() {

            let inp1 = document.querySelector('#fecha_retorno');
            let d1 = new Date(document.getElementById('fecha_salida').value);
            inp1.min = formatISOLocal2(d1);
            inp1.defaultValue = inp1.min;
            d1.setFullYear(d1.getFullYear() + 1);
            inp1.max = formatISOLocal2(d1);
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

            function setearFechaSalida() {

                document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
                 document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
             }

            function TipoVueloOW() {
                   var cbIV = document.getElementById("cbSoloIda");
                   cbIV.checked = true;
            }

            function TipoVueloRT() {
                var cbIV2 = document.getElementById("cbSoloIda2");
                cbIV2.checked = true;
            }

            function TipoVuelo() {
                if (document.getElementById("cbSoloIda").checked == true) {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').value = "OW";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'hidden';
                    var cbIV = document.getElementById("cbSoloIda2");
                    cbIV.checked = false;
                }
            }

            function TipoVuelo2() {
                if (document.getElementById("cbSoloIda2").checked == true) {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').value = "RT";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'visible';
                    var cbIV = document.getElementById("cbSoloIda");
                    cbIV.checked = false;
                }
            }
        </script>
    <script type="text/javascript">

        function recuperarFechaNino() {

            document.getElementById('<%=hfFechaNino.ClientID%>').value = document.getElementById('fecha_nac_nino').value;
		}

        function recuperarFechaInf() {

            document.getElementById('<%=hfFechaNacInf.ClientID%>').value = document.getElementById('fecha_nac_inf').value;
        }
    </script>

    


    <script>

        const options = {
            pagebreak: { after: ['.Card'] },
            margin: 0.5,
            filename: 'reserva.pdf',
            image: {
                type: 'jpeg',
                quality: 500
            },
            html2canvas: { scale: 1, y: 0, scrollY: 0 },
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
        }
        function ChkSelected() {
            var theone = '';
            var count = 0;

            var Repeater1 = document.getElementById('<%=Repeater1.ClientID %>');
            var Repeater2 = Repeater1.getElementsByTagName('Repeater2');
            var ChkBx2s = Repeater2.getElementsByTagName('cbElegirIda');
            var i = 0;
            for (i = 0; i < ChkBx2s.length; i++) {
                if (ChkBx2s[i].type == 'checkbox' && ChkBx2s[i].id.indexOf("ChkBx2") != -1 && ChkBx2s[i].checked == true) {
                    count = (count + 1);
                    var lbl = ChkBx2s[i].parentElement.getElementsByTagName('label');
                    theone += "," + lbl[0].innerHTML + ';';
                }
            }
            if (count == 0) {
                theone = '';
            }
            window.alert(theone + " Count=" + count);

        }

        $(document).ready(function () {
            $('[id*=cbElegirIda]').on('change', function () {
                $(".ClaseIda input[type='checkbox']").each(function () {
                    this.checked = false;
                });
                this.checked = true;
            });

            $('[id*=cbElegirVuelta]').on('change', function () {
                $(".ClaseVuelta input[type='checkbox']").each(function () {
                    this.checked = false;
                });
                this.checked = true;
            });
        });
    </script>
</asp:Content>
