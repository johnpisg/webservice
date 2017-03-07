<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddVideo.aspx.cs" Inherits="Chiquimula.WebSite.SitioTuristico.AddVideo" %>
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
                                    Ingresar URL de video:
                                </div>
                                <div class="col-xs-8">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TxtUrl"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="ReqImage" Display="Dynamic" EnableClientScript="true"
                                        ControlToValidate="TxtUrl" Enabled="true" ErrorMessage="Ingrese una dirección URL correcta" Text="*"
                                        ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-xs-4"></div>
                                <div class="col-xs-8">                                        
                                    <button class="btn btn-warning" onclick="return preview();">Previsualizar</button>
                                    <asp:HiddenField runat="server" ID="HdnUrl" />
                                </div>            
                            </div>
                            <div class="row form-group">
                                <div class="col-xs-4"></div>
                                <div class="col-xs-8">                                        
                                    <iframe id="frmPreview">
                                    </iframe>
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
                <asp:DataList ID="RepeaterVideos" runat="server" CssClass="table table-responsive table-img" 
                    RepeatColumns="6" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="HdnVideo" Value='<%# Eval("Id") %>' />
                    <!-- http://www.youtube.com/embed/7SFLedfl-jQ?enablejsapi=1&origin=http://example.com -->
                    <iframe src='<%# Eval("path") %>'>
                    </iframe>
                    <asp:LinkButton runat="server" CssClass="img-elim" ToolTip="Eliminar" 
                        Text="<i class='fa fa-2x fa-trash-o'></i>" ID="LnkEliminar" 
                        OnCommand="LnkEliminar_Command" CommandName="Delete" CommandArgument='<%# Eval("Id").ToString() %>'
                        OnClientClick='return confirm("¿Está seguro de eliminar este video?");' />
                </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
<script type="text/javascript">
    function preview() {
        var url = $("#<%= TxtUrl.ClientID %>").val();        
        if (url) {
            
            if (url.startsWith("https://www.youtube.com/watch?v=") || url.startsWith("http://www.youtube.com/watch?v=")) {
                var code = url.replace("https://www.youtube.com/watch?v=", "");
                url = "http://www.youtube.com/embed/" + code + "?enablejsapi=1&origin=http://city-tour-chiquimula.somee.com";
                $("#<%= HdnUrl.ClientID %>").val(url);
                $("#frmPreview").attr("src", url);
            } else if (url.startsWith("http://www.youtube.com/embed/")) {
                $("#<%= HdnUrl.ClientID %>").val(url);
                $("#frmPreview").attr("src", url);
            } else {
                $("#frmPreview").attr("src", "/notFound.html");
            }
            
        }
        return false;
    }
</script>
</asp:Content>
