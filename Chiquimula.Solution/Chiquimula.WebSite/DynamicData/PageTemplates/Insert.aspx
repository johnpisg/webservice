<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Insert.aspx.cs" Inherits="Chiquimula.WebSite.Insert" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <h2 class="DDSubHeader">Agregar nuevo <%= table.DisplayName %></h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
            HeaderText="Corrija los siguientes errores:" CssClass="DDValidator" />                    
            
            
            <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />

            <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Insert"
                OnItemCommand="FormView1_ItemCommand" OnItemInserted="FormView1_ItemInserted" RenderOuterTable="false">
                <InsertItemTemplate>
                    <table id="detailsTable" class='<%# GetClassEntidad() + " DDDetailsTable" %>' cellpadding="6">
                        <asp:DynamicEntity runat="server" Mode="Insert" />
                        <tr class="td">
                            <td colspan="2" class="text-center">
                                <asp:LinkButton runat="server" CommandName="Insert" CssClass="btn btn-primary" Text="<i class='fa fa-save'></i>&nbsp;Guardar" />
                                <asp:LinkButton runat="server" CommandName="Cancel" CssClass="btn btn-default" Text="<i class='fa fa-deny'></i>&nbsp;Cancelar" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>

            <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableInsert="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

