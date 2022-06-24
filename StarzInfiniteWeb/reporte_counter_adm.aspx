<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporte_counter_adm.aspx.cs" Inherits="StarzInfiniteWeb.reporte_counter_adm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="odsReporteCounter" runat="server" SelectMethod="PR_OBTIENE_REPORTE_COUNTER" TypeName="StarzInfiniteWeb.LocalBD">
		 <SelectParameters>
			  <asp:ControlParameter ControlID="lblUsuario" Name="pv_usuario" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha1" Name="pd_fechadesde" Type="String" />
			 <asp:ControlParameter ControlID="hfFecha2" Name="pd_fechahasta" Type="String" />
		 </SelectParameters>
		</asp:ObjectDataSource>
     <div class="container">
        <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
        <asp:Label ID="lblBroker" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblPnr" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label6" CssClass="form-label" runat="server" ForeColor="Gray" Font-Bold="true" Font-Size="Medium" Text="Seleccione las fechas"></asp:Label>
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
						<asp:Button ID="btnFiltrarFechas" runat="server" CssClass="btn btn-primary shadow rounded" OnClick="btnFiltrarFechas_Click" OnClientClick="recuperarFechaSalida()" Text="Reporte" />
			    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <h3>REPORTE COUNTER</h3>
				
				<asp:Button ID="btnOtraConsulta" runat="server" CssClass="btn btn-primary" OnClick="btnOtraConsulta_Click" Text="Otra consulta" />
				<button id="export" class="btn btn-orange">Exportar a Excel</button>
				<div class="row">
											<div class="col-12 col-md-3">
											<input class="form-control light-table-filter" data-table="order-table" type="text" placeholder="Buscador..">
												</div>
										</div>
               <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 content-side"  style="height:500px; overflow-x:scroll;overflow-y:scroll">
            <div>
						<table id="tblData" class="table table-bordered order-table ">
									<thead>
												<tr>
													<td>
														<strong>NRO</strong>
													</td>
													<td>
														<strong>FECHA</strong>
													</td>
													<td>
														<strong>AEROLINEA</strong>
													</td>
													<td>
                                                        <strong>NRO_TICKET</strong>
													</td>
													<td>
														<strong>TOTAL</strong>
													</td>
													<td>
														<strong>NETO</strong>
													</td>
													<td>
														<strong>FEE</strong>
													</td>
													<td>
														<strong>COMISION COUNTER</strong>
													</td>
													<td>
                                                        <strong>USUARIO EMISION</strong>
													</td>
													<td>
                                                        <strong>NOMBRE PASAJERO</strong>
													</td>
													<td>
                                                        <strong>PNR</strong>
													</td>
													<td>
                                                        <strong>USUARIO BROKER</strong>
													</td>
													<td>
                                                        <strong>ESTADO</strong>
													</td>
													<td>
                                                        <strong>TIPO VENTA</strong>
													</td>
													<td>
                                                        <strong>FORMA PAGO</strong>
													</td>
												</tr>
										</thead>
									<tbody>
												<asp:Repeater ID="Repeater1" DataSourceID="odsReporteCounter" runat="server">
													<ItemTemplate>
														<tr>
															<td>
																<asp:Label ID="Label9" runat="server" Text='<%# Eval("NRO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label1" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label5" runat="server" Text='<%# Eval("AEROLINEA") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label3" runat="server" Text='<%# Eval("NRO_TICKET") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label4" runat="server" Text='<%# Eval("TOTAL") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label26" runat="server" Text='<%# Eval("NETO") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label27" runat="server" Text='<%# Eval("FEE") %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="Label28" runat="server" Text='<%# Eval("COMISION_COUNTER") %>'></asp:Label>
															</td>
                                                            <td>
																<asp:Label ID="Label2" runat="server" Text='<%# Eval("USUARIO_EMISION") %>'></asp:Label>
															</td>
															 <td>
																<asp:Label ID="Label7" runat="server" Text='<%# Eval("NOMBRE_PASAJERO") %>'></asp:Label>
															</td>
															 <td>
																<asp:Label ID="Label8" runat="server" Text='<%# Eval("PNR") %>'></asp:Label>
															</td>
															 <td>
																<asp:Label ID="Label10" runat="server" Text='<%# Eval("USUARIO_BROKER") %>'></asp:Label>
															</td>
															 <td>
																<asp:Label ID="Label11" runat="server" Text='<%# Eval("ESTADO") %>'></asp:Label>
																<td>
																<asp:Label ID="Label12" runat="server" Text='<%# Eval("TIPO_VENTA") %>'></asp:Label>
																	   <td>
																<asp:Label ID="Label13" runat="server" Text='<%# Eval("FORMA_PAGO") %>'></asp:Label>
															</td>
														</tr>
													</ItemTemplate>
												</asp:Repeater>
												</tbody>
																
											</table>
				</div>
               </div>
            </asp:View>
        </asp:MultiView>
         
     
     
     </div>

	<script type="text/javascript">
     function recuperarFechaSalida() {

            document.getElementById('<%=hfFecha1.ClientID%>').value = document.getElementById('fecha_salida1').value;
            document.getElementById('<%=hfFecha2.ClientID%>').value = document.getElementById('fecha_retorno1').value;
		}

        function exportTableToExcel(tableID, filename = '') {
            var downloadLink;
            var dataType = 'application/vnd.ms-excel';
            var tableSelect = document.getElementById(tableID);
            var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

            // Specify file name
            filename = filename ? filename + '.xls' : 'excel_data.xls';

            // Create download link element
            downloadLink = document.createElement("a");

            document.body.appendChild(downloadLink);

            if (navigator.msSaveOrOpenBlob) {
                var blob = new Blob(['ufeff', tableHTML], {
                    type: dataType
                });
                navigator.msSaveOrOpenBlob(blob, filename);
            } else {
                // Create a link to the file
                downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

                // Setting the file name
                downloadLink.download = filename;

                //triggering the function
                downloadLink.click();
            }
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
	
	<script>
        var table2excel = new Table2Excel();

        document.getElementById('export').addEventListener('click', function () {
            table2excel.export(document.getElementById('tblData'));
		});
    </script>
</asp:Content>
