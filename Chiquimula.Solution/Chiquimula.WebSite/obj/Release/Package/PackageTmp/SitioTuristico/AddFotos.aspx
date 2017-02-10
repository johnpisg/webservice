<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddFotos.aspx.cs" Inherits="Chiquimula.WebSite.SitioTuristico.AddFotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-primary">
                    <div class="panel-heading text-center">
                        <h4><asp:Label runat="server" ID="LblTitulo" Text=""></asp:Label></h4>
                    </div>
                    <div class="panel-body">
                        <div class="container-fluid">
                            <div class="row form-group">
                                <div class="col-xs-12">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                                    HeaderText="Corrija los siguientes errores:" CssClass="DDValidator" ValidationGroup="form" />                    
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-xs-4">
                                    Seleccionar imágen
                                </div>
                                <div class="col-xs-8">
                                    <asp:FileUpload runat="server" ID="UploadImage" />
                                    <asp:RequiredFieldValidator runat="server" ID="ReqImage" Display="Dynamic" EnableClientScript="true"
                                        ControlToValidate="UploadImage" Enabled="true" ErrorMessage="Seleccione una imágen" Text="*"
                                        ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-xs-4"></div>
                                <div class="col-xs-8">                                        
                                    <div id="dvPreview"></div>
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
        </div>
        <div class="row form-group">
            <div class="col-xs-12 text-center">
                <asp:DataList ID="RepeaterImages" runat="server" CssClass="table table-responsive table-img" RepeatColumns="6" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="HdnImagen" Value='<%# Eval("Id") %>' />
                    <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("path") %>' CssClass="img-tile" />
                    <asp:LinkButton runat="server" CssClass="img-elim" ToolTip="Eliminar" 
                        Text="<i class='fa fa-2x fa-trash-o'></i>" ID="LnkEliminar" 
                        OnCommand="LnkEliminar_Command" CommandName="Delete" CommandArgument='<%# Eval("Id").ToString() %>'
                        OnClientClick='return confirm("¿Está seguro de eliminar esta imágen?");' />
                </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>

<script type="text/javascript">
    jQuery(document).ready(function () {

        jQuery("#<%= UploadImage.ClientID %>").change(function () {
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
