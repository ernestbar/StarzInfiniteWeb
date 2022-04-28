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
                            <h2>Discover</h2><h1>Australia</h1>
                            <a href="#" class="btn btn-default">View More</a>
                        </div><!-- end container -->
                        </div><!-- end meta -->
                         </li><!-- end item-1 -->
                    <li class="item-2" style="background:			linear-gradient(rgba(0,0,0,0.3),rgba(0,0,0,0.3)),url(images/homepage-slider-1.jpg) 50% 0%;	background-size:cover;	height:100%;">
            
                        <div class=" meta">
                        <div class="container">
                            <h2>Discover</h2>
                            <h1>Australia</h1>
                            <a href="#" class="btn btn-default">View More</a>
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
                                       <div class="col-12 col-md-8">
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
                                                </div><!-- end columns -->
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                        <div class="col-12 col-md-4">
                                        <div class="row">
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                                <input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaSalida" runat="server" />
                                                
                                                </div>
                                                </div><!-- end columns -->
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                                <input id="fecha_retorno" class="form-control" onfocus="verificaSalida()"  style="background:#ecf1fa" type="date" ><asp:HiddenField ID="hfFechaRetorno" runat="server" />
                                                </div>
                                                </div><!-- end columns -->
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                            <div class="row">
                                                 <div class="col-12 col-md-5">
                                                <div class="form-group">
                                                    <div class="panels-group">
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <a href="#panel-1" data-toggle="collapse" >Select Country <span><i class="fa fa-angle-down"></i></span></a>

                                                            </div><!-- end panel-heading -->
                                                            <div id="panel-1" class="panel-collapse collapse">
                                                                <div class="panel-body text-left">
                                                                    <ul class="list-unstyled">
                                                                        <li>Pasajeros Adultos:<asp:TextBox ID="TextBox1" TextMode="Number" Width="40" Text="1" runat="server"></asp:TextBox></li>
                                                                        <li>Pasajeros Niños:<asp:TextBox ID="TextBox2" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>
                                                                        <li>Pasajeros Infantes:<asp:TextBox ID="TextBox3" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>
                                                                        <li>Pasajeros Senior:<asp:TextBox ID="TextBox4" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>

                                                                    </ul>

                                                                </div><!-- end panel-body -->

                                                            </div><!-- end panel-collapse -->

                                                        </div><!-- end panel-default  -->
                                                 <%--   <div class="collapse navbar-collapse" id="myNavbar1">
                                                    <ul class="nav navbar-nav navbar-right navbar-search-link">
                                                        <li class="dropdown active">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Seleccion de Pasajeros<span>
                                                        <i class="fa fa-angle-down"></i></span></a><ul class="dropdown-menu">
                                                            <li>Pasajeros Adultos:<asp:TextBox ID="TextBox1" TextMode="Number" Width="40" Text="1" runat="server"></asp:TextBox></li>
                                                            <li>Pasajeros Niños:<asp:TextBox ID="TextBox2" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>
                                                            <li>Pasajeros Infantes:<asp:TextBox ID="TextBox3" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>
                                                            <li>Pasajeros Senior:<asp:TextBox ID="TextBox4" TextMode="Number" Width="40" Text="0" runat="server"></asp:TextBox></li>
                                                        </ul>

                                                        </li>
                                                    
                                                            
                                                
                                                    </ul>
                                                        </div>--%>
                                                </div>
                                            </div><!-- end columns -->
                                                 <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2 search-btn">
                                        <button class="btn btn-orange">Search</button>
                                            </div><!-- end columns --> 
                                            </div>
                                       
                                        </div><!-- end row -->
                                     </div><!-- end flights -->
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
            
            function recuperarFechaSalida() {

                document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
                document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
            }

           <%-- function TipoVuelo() {

                
                if (document.getElementById("cbSoloIda").checked == true) {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').value = "OW";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'hidden';
                    //window.alert("sirve");
                }
                else
                {
                    document.getElementById('<%=hfTipoRuta.ClientID%>').valuee ="RT";
                    document.getElementById('<%=Panel_fecha_regreso.ClientID%>').style.visibility = 'visible';
                }
                
             }--%>
        </script>
    <%--<script type="text/javascript">

        function recuperarFechaNino() {

            document.getElementById('<%=hfFechaNino.ClientID%>').value = document.getElementById('fecha_nac_nino').value;
		}

    function recuperarFechaInf() {

            document.getElementById('<%=hfFechaNacInf.ClientID%>').value = document.getElementById('fecha_nac_inf').value;
        }
    </script>--%>

    


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
