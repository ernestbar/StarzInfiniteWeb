<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="StarzInfiniteWeb.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
    
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <section class="flexslider-container" id="flexslider-container-1">
                <div class="flexslider slider" id="slider-1">
                    <ul class="slides"><li class="item-1" style="background:			linear-gradient(rgba(0,0,0,0.3),rgba(0,0,0,0.3)),url(images/homepage-slider-1.jpg) 50% 0%;	background-size:cover;	height:100%;">
                        <div class=" meta">
                        <div class="container">
                            
                            
                        </div><!-- end container -->
                        </div><!-- end meta -->
                         </li><!-- end item-1 -->
                    <li class="item-2" style="background:			linear-gradient(rgba(0,0,0,0.3),rgba(0,0,0,0.3)),url(images/homepage-slider-1.jpg) 50% 0%;	background-size:cover;	height:100%;">
            
                        <div class=" meta">
                        <div class="container">
                            
                            </div><!-- end container -->
                            </div><!-- end meta -->
                        </li><!-- end item-2 -->
                        </ul>
                    </div><!-- end slider -->

                <div class="search-tabs" id="search-tabs-1">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <ul class="nav nav-tabs center-tabs">
                                    <li class="active"><a href="#flights" data-toggle="tab"><span><i class="fa fa-plane"></i></span>
                                        <span class="st-text">Flights</span></a>
                                    </li>
                                    <li><a href="#hotels" data-toggle="tab"><span><i class="fa fa-building"></i></span>
                                            <span class="st-text">Hotels</span>
                                        </a>
                                    </li>
                                    <li>
                                    <a href="#tours" data-toggle="tab"><span><i class="fa fa-suitcase"></i></span>
                                        <span class="st-text">Tours</span></a></li><li>
                                    <a href="#cruise" data-toggle="tab"><span><i class="fa fa-ship"></i></span>
                                        <span class="st-text">Cruise</span></a></li><li>
                                    <a href="#cars" data-toggle="tab"><span><i class="fa fa-car"></i></span>
                                        <span class="st-text">Cars</span></a></li></ul>

                        <div class="tab-content">
                            <div id="flights" class="tab-pane in active">
                                        <div class="row">
                                            <div class="col-12 col-md-12">
                                        <div class="row">
                                        <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                                      <input id="cbSoloIda" class="checkbox"  onclick="TipoVuelo()" type="checkbox" />Solo Ida
                                                </div>
                                             </div><!-- end columns -->
                                            <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                                     <input id="cbSoloIda2" class="checkbox" checked="checked"  onclick="TipoVuelo2()" type="checkbox" />Ida y vuelta
                                                </div>
                                                </div><!-- end columns --><asp:HiddenField ID="HiddenField1" runat="server" />
                                           
                                            </div><!-- end row -->
                                            </div><!-- end columns -->


                                       <div class="col-12 col-md-12">
                                        <div class="row">
                                        <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                            <asp:DropDownList ID="ddlOrigen" class="chosen-select" tabindex="2" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlOrigen_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlOrigen" InitialValue="ORIGEN"  Font-Bold="True"></asp:RequiredFieldValidator>
                                                </div>
                                             </div><!-- end columns -->
                                            <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                                <asp:DropDownList ID="ddlDestino" class="chosen-select" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlDestino_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDestino" InitialValue="DESTINO"  Font-Bold="True"></asp:RequiredFieldValidator>
                                                </div>
                                                </div><!-- end columns --><asp:HiddenField ID="hfTipoRuta" Value="RT" runat="server" />
                                           
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                            
                                        <div class="col-12 col-md-12">
                                        <div class="row">
                                            
                                            <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                                Fecha de salida:
                                                <input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaSalida" runat="server" />
                                                
                                                </div>
                                                </div><!-- end columns -->
                                            <div class="col-12 col-md-6">
                                            <div class="form-group left-icon">
                                                <asp:Panel ID="Panel_fecha_regreso" Visible="true" runat="server">
                                                    Fecha de retorno:
                                                <input id="fecha_retorno" class="form-control" onfocus="verificaSalida()"  style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaRetorno" runat="server" />
                                                </asp:Panel>
                                                </div>
                                                </div><!-- end columns -->
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                            <div class="row">
                                                 <div class="col-12 col-md-6">
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
                                                
                                            </div>
                                       
                                                 <div class="col-12 col-md-6">
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
                                               
                                            </div>
                                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2 search-btn">
                                        <asp:Button ID="btnVuelos" class="btn button-blue" OnClientClick="recuperarFechaSalida()" OnClick="btnVuelos_Click"  runat="server" Text="Buscar vuelos" />
                                            </div><!-- end columns --> 

                                        </div><!-- end row -->
                                            <div class="row">
                                                 <div class="col-12 col-md-12">
                                                  <strong>Tipo Venta</strong>
                                                    <div class="col-12 col-md-12">
                                                    <asp:RadioButtonList ID="rblTipoVenta" RepeatDirection="Horizontal" runat="server">
					                                                        <asp:ListItem Text="NORMAL" Value="0" Selected="True"></asp:ListItem>
					                                                        <asp:ListItem Text="CORPORATIVO" Value="1"></asp:ListItem>
				                                                        </asp:RadioButtonList>
                                                    </div>
                                                    
                                                      
                                                     </div>
                                                </div>
                                     </div><!-- end flights -->
                            </div>

            
                            </div>
                        </div>
                    </div>
                    </div>
                    </div>
                     </section>
        </asp:View>
        <asp:View ID="View2" runat="server">

        </asp:View>
    </asp:MultiView>

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
</asp:Content>
