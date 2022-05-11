<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="emision_offline.aspx.cs" Inherits="StarzInfiniteWeb.emision_offline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
         <div class="row"  style="text-align:center;">
             <div class="col-12 col-md-6">
                 <h2><asp:Label ID="Label2" CssClass="col-form-label" runat="server" ForeColor="Gray" Font-Size="Medium" Text="Código de reserva (PNR)"></asp:Label></h2>   
                </div>
         </div>
      <div class="row"  style="text-align:center;">
          <div class="col-12 col-md-6" style="text-align:center;">
                    <asp:TextBox ID="txtPNR" CssClass="form-control shadow text-center"  Font-Size="Large" placeholder="* Ingrese el código de reserva"   Height="70px" runat="server"></asp:TextBox><br /><br />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtPNR" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <asp:Label ID="lblAviso" CssClass="form-control-lg" runat="server" Text=""></asp:Label>
                </div>
          </div>
         <div class="row"  style="text-align:center;">
             <div class="col-12 col-md-6" style="text-align:center;width:auto">

            <asp:Button ID="btnEmitir" class="btn btn-primary btn-block rounded-lg shadow-lg" OnClick="btnEmitir_Click" OnClientClick="return confirm('Seguro que desea realizar la emisión offline?')" runat="server" Text="Continuar" />
            </div>
             </div>
                
                
        </div>
</asp:Content>
