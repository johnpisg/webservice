<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Details.aspx.cs" Inherits="Chiquimula.WebSite.Details" %>


<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <h2 class="DDSubHeader"><%= table.DisplayName %></h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                HeaderText="List of validation errors" CssClass="DDValidator" />
            <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />

            <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" OnItemDeleted="FormView1_ItemDeleted" RenderOuterTable="false">
                <ItemTemplate>
                    <table id="detailsTable" class="DDDetailsTable table table-bordered table-condensed" cellpadding="6">
                        <asp:DynamicEntity runat="server" />
                        <tr class="td">
                            <td colspan="2">
                                <asp:DynamicHyperLink runat="server" Action="Edit" CssClass="btn" Text="<i class='fa fa-pencil'></i>&nbsp;Editar" />
                                <asp:LinkButton runat="server" CommandName="Delete" Text="<i class='fa fa-trash-o'></i>&nbsp;Eliminar"
                                    OnClientClick='return confirm("¿Está seguro de eliminar este registro?");' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="DDNoItem">No existe el registro solicitados.</div>
                </EmptyDataTemplate>
            </asp:FormView>

            <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />

            <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
                <asp:DynamicRouteExpression />
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="ListHyperLink" runat="server" Action="List">Regresar al listado</asp:DynamicHyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

