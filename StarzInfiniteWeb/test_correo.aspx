<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="test_correo.aspx.cs" Inherits="StarzInfiniteWeb.test_correo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    correo:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    subjetc:<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox><br />
    mensaje:<asp:TextBox ID="txtMensaje" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" OnClick="Button1_Click" OnClientClick="copiar()" runat="server" Text="Enviar" />
    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>

    <div id="invoice2" style="font-size:small">
                                    <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image9" Height="50" ImageUrl="https://psp.starzinfinite.com/StarzInfinite/Logos/encabezado_logo.png" runat="server" /> 
                               </div>
                               <div class="row" style="vertical-align:central">
                                   <asp:Image ID="Image10" Height="20" ImageUrl="https://psp.starzinfinite.com/StarzInfinite/iconos/icono-resumen-reserva.png" runat="server" />  <asp:Label ID="Label50" runat="server" Font-Size="Large"   Font-Bold="true"  Text="Resumen de la reserva"></asp:Label>
                               </div>
                                <hr />
                                 <div class="row col-form-label bg-silver-lighter" style="vertical-align:central">
                                   <asp:Image ID="Image11" Height="20" ImageUrl="https://psp.starzinfinite.com/StarzInfinite/iconos/icono-pasajero--resumen-reserva.png" runat="server" />  <asp:Label ID="Label51" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Pasajeros"></asp:Label>
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
                                   <asp:Image ID="Image12" ImageUrl="https://psp.starzinfinite.com/StarzInfinite/iconos/icono-ida-resumen-reserva.png" Height="20" runat="server" />  <asp:Label ID="Label60" runat="server" Font-Size="Medium"   Font-Bold="true"  Text="Itinerario de Ida"></asp:Label>
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
                                                            ________________________________
                                                                <%--Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'>:</asp:Label> Airline:<asp:Label ID="Label23" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>--%>
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
                                                            Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                               Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                            <%--<asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass") %>'></asp:Label><br />--%>
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
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
                                                            ________________________________
                                                                <%--Fecha:<asp:Label ID="Label7" runat="server" Text='<%# Eval("ArrivalDate") %>'></asp:Label>  Airline:<asp:Label ID="Label24" runat="server" Text='<%# Eval("operCompany") %>'>:</asp:Label>--%>
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
                                                            Maletas: <asp:Label ID="Label9" runat="server" Text='<%# Eval("equipaje") %>'>:</asp:Label>
                                                            Duracion: <asp:Label ID="Label49" runat="server" Text='<%# Eval("duracion") %>'>:</asp:Label>
                                                            <%--<asp:Label ID="Label5" runat="server" Text='<%# "Vuelo " + Eval("flightNumber") + " Clase "  +Eval("bookClass") %>'></asp:Label><br />--%>
                                                        </li>
                                                        <li>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("offAirport") %>'>:</asp:Label>
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
        </div>
    <asp:HiddenField ID="hfDiv" runat="server" />

                <script type="text/javascript">
                    function copiar() {
                        // Crea un input para poder copiar el texto dentro       
                        let copyText = document.getElementById('invoice2').innerHTML
                        const textArea = document.createElement('textarea');
                        textArea.textContent = copyText;
                        document.body.append(textArea);
                        textArea.select();
                        document.execCommand("copy");
                        document.getElementById('<%=hfDiv.ClientID%>').value = textArea.textContent;
                        // Delete created Element       
                        textArea.remove()
                    }

                </script>                       
    
</asp:Content>
