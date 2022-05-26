<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="calendario.aspx.cs" Inherits="StarzInfiniteWeb.calendario" %>
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
                    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                        <div class="row">
                          
       		                <asp:Repeater ID="Repeater1" runat="server">
					                 <ItemTemplate>
                                           <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                          <div class="grid-block main-block f-grid-block">
                                                <a href="flight-detail-left-sidebar.html">
                                                <div class="main-img f-img">
                                                    <asp:Label ID="Label8" runat="server" ForeColor="Green" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("depDate") %>'> </asp:Label>
                                                    <asp:Button ID="btnComprar" class="btn btn-orange btn-md col-4" OnClick="btnComprar_Click" CommandArgument='<%# Eval("boardAirport") +"|"+Eval("offAirport") +"|"+Eval("depDate") +"|"+Eval("ArrivalDate") %>' runat="server" Text="VER VUELOS" />
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Green" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("ArrivalDate") %>'> </asp:Label>
                                                   <%-- <img src="images/flight-1.jpg" class="img-responsive" alt="flight-img" />--%>
                                                    </div><!-- end f-img -->
                                                    </a>
                                                <ul class="list-unstyled list-inline offer-price-1">
                                                <li class="price"><asp:Label ID="lblCosto" ForeColor="Green" runat="server" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("precio") %>'></asp:Label><span class="divider">|</span>
                                                    <span class="pkg"><asp:Label ID="Label3" runat="server" ForeColor="Green" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("moneda") %>'> </asp:Label></span>
                                                    </li>
                                                    </ul>

                                            </div>
                                               </div>
                                           <%--<li class="active"><a href="#"><span></span>
                                               
                                                                
                                       
                                                              </a></li>--%>
							                </ItemTemplate>
					                </asp:Repeater>

                            

                        </div>
                        </div>
                    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 content-side">
                        <asp:Label ID="lblVueloIdaNoDisponible" runat="server" Text=""></asp:Label>

                        	<div class="row list-inline">
                           <%--<div class="col-xs-12 col-sm-2 col-md-2 dashboard-nav">--%>
                          <%--  <ul class="nav nav-tabs nav-stacked text-center list-inline">--%>
                          
                           
			
					
                               <%-- </ul>--%>
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
