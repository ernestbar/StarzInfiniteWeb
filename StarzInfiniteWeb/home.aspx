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
    <div class="row">
                            <div class="col">
    <asp:DropDownList ID="DropDownList1" CssClass="ChosenSelector" OnDataBound="ddlOrigen_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
                                </div>
        </div>
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
                            <div class="col-sm-12">
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
                                        <div class="col-xs-12 col-sm-12 col-md-5 col-lg-4">
                                        <div class="row">
                                        <div class="col-xs-12 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                            <asp:DropDownList ID="ddlOrigen" CssClass="ChosenSelector" data-size="10" data-live-search="true" data-style="btn-white" OnDataBound="ddlOrigen_DataBound" DataSourceID="odsRutaInd" DataValueField="codigo" DataTextField="descripcion" runat="server"></asp:DropDownList>
					                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlOrigen" InitialValue="ORIGEN"  Font-Bold="True"></asp:RequiredFieldValidator>
                                                </div>
                                             </div><!-- end columns -->
                                            <div class="col-xs-12 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                                <input type="text" class="form-control" id="search" placeholder="To" ><i class="fa fa-map-marker"></i>
                                                </div>
                                                </div><!-- end columns -->
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                        <div class="col-xs-12 col-sm-12 col-md-5 col-lg-4">
                                        <div class="row">
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                                <input type="text" class="form-control dpd1" placeholder="Check In" ><i class="fa fa-calendar"></i>
                                                </div>
                                                </div><!-- end columns -->
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                            <div class="form-group left-icon">
                                                <input type="text" class="form-control dpd2" placeholder="Check Out" ><i class="fa fa-calendar"></i>
                                                </div>
                                                </div><!-- end columns -->
                                            </div><!-- end row -->
                                            </div><!-- end columns -->
                                        <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">
                                        <div class="form-group right-icon">
                                            <select class="form-control">
                                            <option selected>Adults</option><option>1</option><option>2</option><option>3</option>
                                                </select><i class="fa fa-angle-down"></i>
                                            </div>
                                            </div><!-- end columns -->
                                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2 search-btn">
                                        <button class="btn btn-orange">Search</button>
                                            </div><!-- end columns -->
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
        $(function () {
            $("#search").focus();
            $(document).keypress(function (e) {
                if (e.which == '13') e.preventDefault();
            });
            var csrf = $("input[name=csrfmiddlewaretoken]").val();
            $("#search").keyup(function (e) {
                var search_text = $("#search").val();
                if (e.which != '13' && search_text.length >= 3) {
                    $.ajax({
                        type: "POST",
                        url: "/search/",
                        data: {
                            'csrfmiddlewaretoken': csrf,
                            'search_text': $("#search").val()
                        },
                        success: searchSuccess,
                        dataType: 'html'
                    });
                }
            });
        });

        function searchSuccess(data, textStatus, jqXHR) {
            $('#search-results').html(data);
        }
    </script>
    
</asp:Content>
