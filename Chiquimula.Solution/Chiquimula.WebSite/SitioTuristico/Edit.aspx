<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Chiquimula.WebSite.SitioTuristico.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid normal-font">
        <div class="row">
            <div class="col-xs-2">
            </div>
            <div class="col-xs-8">
                <div class="panel panel-primary">
                <div class="panel-heading text-center">
                    <h3>Editar Sitio Turístico</h3>
                </div>
                <div class="panel-body">
                    <div class="container-fluid">
                    <div class="row">&nbsp;</div>
                    <div class="row ">
                        <div class="col-xs-12">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                            HeaderText="Corrija los siguientes errores:" CssClass="DDValidator" ValidationGroup="form" />                    
                        </div>
                    </div>
                    <div class="row form-group">&nbsp;</div>
                    <div class="row form-group">
                        <div class="col-xs-2">Nombre:</div>
                        <div class="col-xs-4">
                            <asp:HiddenField ID="HdnSitioId" runat="server" />
                            <asp:TextBox runat="server" ID="TxtNombre" MaxLength="499" 
                                TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqNombre" Display="Dynamic" EnableClientScript="true"
                                ControlToValidate="TxtNombre" Enabled="true" ErrorMessage="Ingrese el nombre" Text="*"
                                ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-2">Título:</div>
                        <div class="col-xs-4">
                            <asp:TextBox runat="server" ID="TxtTitulo" MaxLength="499" 
                                TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqTitulo" Display="Dynamic" EnableClientScript="true"
                                ControlToValidate="TxtTitulo" Enabled="true" ErrorMessage="Ingrese el título" Text="*"
                                ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-2">Descripción resumen del sitio turístico:</div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="TxtDescripcion" MaxLength="3999" 
                                TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqDescripcion" Display="Dynamic" EnableClientScript="true"
                                ControlToValidate="TxtDescripcion" Enabled="true" ErrorMessage="Ingrese una descripción" Text="*"
                                ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </div>                        
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-2">Horario de atención:</div>
                        <div class="col-xs-4">
                            <div class="panel panel-default">
                                <table class="table table-bordered table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Día</th>
                                            <th>Desde</th>
                                            <th>Hasta</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkDom" Text="Domingo" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeDom" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaDom" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkLun" Text="Lunes" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeLun" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaLun" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkMar" Text="Martes" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeMar" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaMar" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkMie" Text="Miércoles" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeMie" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaMie" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkJue" Text="Jueves" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeJue" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaJue" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkVie" Text="Viernes" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeVie" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaVie" Width="50px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><asp:CheckBox runat="server" ID="ChkSab" Text="Sábado" CssClass="chkDia" /></td>
                                            <td><asp:TextBox runat="server" ID="TxtDesdeSab" Width="50px"></asp:TextBox></td>
                                            <td><asp:TextBox runat="server" ID="TxtHastaSab" Width="50px"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>                               
                                
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-xs-4">Precio de ingreso (USD):</div>
                                    <div class="col-xs-8">
                                        <asp:TextBox runat="server" ID="TxtPrecio" MaxLength="10"  Text="0.00"
                                            Columns="14" type="number" CssClass="form-control text-right"></asp:TextBox>
                                    </div>            
                                </div>
                                <div class="row">
                                    <div class="col-xs-4">Imágen principal del sitio:</div>
                                    <div class="col-xs-8">
                                        <asp:FileUpload runat="server" ID="UploadImage" ToolTip="Seleccione una imágen" />
                                    </div>            
                                </div>
                                <div class="row">
                                    <div class="col-xs-4"></div>
                                    <div class="col-xs-8">                                        
                                        <div id="dvPreview" class="dvPreview"></div>
                                        <asp:Image runat="server" ID="ImagenPrincipal" CssClass="imgPreview" />
                                        <asp:HiddenField runat="server" ID="HdnCambio" Value="0" />
                                        &nbsp;
                                        <asp:HyperLink runat="server" Text="<i class='fa fa-upload'></i>&nbsp;Subir más imágenes"
                                        ID="LnkMasFotos" CssClass="btn btn-warning"
                                         CausesValidation="false" ></asp:HyperLink>
                                    </div>            
                                </div>
                            </div>
                        </div>                        
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-2">Información Turística (historia):</div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="TxtInfo" MaxLength="3999" 
                                TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-2">Dirección/Ubicación descriptiva:</div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="TxtDatos" MaxLength="3999" 
                                TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-2">Más datos del sitio turístico:</div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="TxtMasDatos" MaxLength="3999" 
                                TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                    <div class="row form-group">
                        <div class="col-xs-12 text-center">
                            <asp:LinkButton runat="server" type="button" Text="<i class='fa fa-save'></i>&nbsp;Guardar"
                                ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-primary"
                                CausesValidation="true" ValidationGroup="form" ></asp:LinkButton>
                            &nbsp;
                            <asp:HyperLink runat="server" Text="<i class='fa fa-ban'></i>&nbsp;Cancelar"
                                ID="BtnCancelar" CssClass="btn btn-default"
                                NavigateUrl="~/Sitio/List.aspx" CausesValidation="false" ></asp:HyperLink>
                        </div>                        
                    </div>
                </div>
                </div>
                </div>
            </div>
            <div class="col-xs-2">

            </div>
        </div>
    </div>

<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#dvPreview").css("display", "none");
        jQuery(".imgPreview").css("display", "block");
        //CssClass="chkDia"
        //jQuery(".chkDia > input").attr("checked", true);

        jQuery(".chkDia > input").change(function () {
            var id = jQuery(this).attr("id");
            var txtD = id.replace("Chk", "TxtDesde");
            var txtH = id.replace("Chk", "TxtHasta");

            jQuery("#" + txtD).prop("disabled", !this.checked);
            jQuery("#" + txtH).prop("disabled", !this.checked);
            if (this.checked)
                jQuery("#" + txtD).focus();
        });

        jQuery("#<%= UploadImage.ClientID %>").change(function () {
            jQuery("#dvPreview").css("display", "block");
            jQuery(".imgPreview").css("display", "none");
            jQuery("#<%= HdnCambio.ClientID %>").val("1");

            jQuery("#dvPreview").html("");
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
            if (regex.test(jQuery(this).val().toLowerCase())) {
                
                if (navigator.userAgent.match(/msie/i) || navigator.userAgent.match(/trident/i)) {
                    jQuery("#dvPreview").show();
                    jQuery("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = jQuery(this).val();
                }
                else {
                    if (typeof (FileReader) != "undefined") {
                        jQuery("#dvPreview").show();
                        jQuery("#dvPreview").append("<img />");
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            jQuery("#dvPreview img").attr("src", e.target.result);
                        }
                        reader.readAsDataURL(jQuery(this)[0].files[0]);
                    } else {
                        alert("El explorador no soporta FileReader.");
                    }
                }
            } else {
                alert("Por favor seleccione un archivo de imágen válida.");
            }
        });

    });
</script>

</asp:Content>
