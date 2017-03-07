<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Chiquimula.WebSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City - Tour, Chiquimula</title>
    
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap.min.css" rel="stylesheet" />
    <link href="~/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/css/font-awesome.css" rel="stylesheet" />
    
    <script src='<%# ResolveUrl("~/Scripts/jquery-3.1.1.js") %>'></script>
    <script src='<%# ResolveUrl("~/Scripts/jquery-ui-1.8.20.js") %>'></script>
    <script src='<%# ResolveUrl("~/Scripts/bootstrap.min.js") %>'></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container-fluid">
            <div class="row">
			<div class="col-md-6 col-md-offset-3">
				<div class="panel panel-login">
					<div class="panel-heading">
						<div class="row">
							<div class="col-xs-12 text-center azul">
								<h4>Iniciar sesión</h4>
							</div>							
						</div>
						<hr />
					</div>
					<div class="panel-body">
                        <div class="row form-group">
                            <div class="col-xs-12">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                                HeaderText="Corrija los siguientes errores:" CssClass="DDValidator" ValidationGroup="form" />

                                <asp:Panel runat="server" ID="PanelError" CssClass="DDValidator" Visible="false">
                                    Usuario o contraseña inválidos.
                                </asp:Panel>
                            </div>
                        </div>
                        
						<div class="row form-group">
							<div class="col-lg-12">
								<div class="form-group">
                                    <asp:TextBox runat="server" ID="TxtUsername" tabindex="1" CssClass="form-control" placeholder="usuario"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" Display="Dynamic" EnableClientScript="true"
                                        ControlToValidate="TxtUsername" Enabled="true" ErrorMessage="Ingrese un nombre de usuario" Text="*"
                                        ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
								</div>
								<div class="form-group">
									<asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" tabindex="2" CssClass="form-control" placeholder="contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="ReqPassword" Display="Dynamic" EnableClientScript="true"
                                        ControlToValidate="TxtPassword" Enabled="true" ErrorMessage="Ingrese su contraseña" Text="*"
                                        ToolTip="Requerido" ValidationGroup="form" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
								</div>
								<div class="form-group text-center">
										<asp:CheckBox runat="server" ID="ChkRecordar" tabindex="3" CssClass="" Text="Recordarme" />
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button runat="server" ID="BtnLogin" ValidationGroup="form" CausesValidation="true" 
                                                    TabIndex="4" CssClass="form-control btn btn-primary" Text="Ingresar"
                                                    OnClick="BtnLogin_Click" />
											</div>
										</div>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-lg-12">
												<div class="text-center">
													<a href="#" tabindex="5" class="forgot-password">Recuperar contraseña.</a>
												</div>
											</div>
										</div>
									</div>								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
        </div>            
    </div>
    </form>
</body>
</html>
