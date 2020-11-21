<<%= openDirective %> Control Language="c#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="<%= fullNamespace %>.View" <%= closeDirective %>>
<<%= openDirective %> Import Namespace="DotNetNuke.Services.Localization" <%= closeDirective %>>
<<%= openDirective %> Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" <%= closeDirective %>>

  <asp:Panel ID="pnlAdd<%= extensionName %>" runat="server" Visible="false">
    <div class="row">
        <div class="col-md-12">
            <asp:LinkButton ID="btnNew<%= extensionName %>" runat="server" CssClass="btn btn-primary pull-right" OnClick="btnNew<%= extensionName %>_Click">
        <i class="fa fa-plus" aria-hidden="true"></i>  Add <%= extensionName %>
            </asp:LinkButton>
        </div>
    </div>
</asp:Panel>

<div class="row">
    <div class="col-md-12">
          <asp:Repeater ID="rpt<%= extensionName %>s" runat="server" OnItemCommand="rpt<%= extensionName %>s_ItemCommand" OnItemDataBound="rpt<%= extensionName %>s_ItemDataBound">
              <HeaderTemplate>
                  <div id="pnlNo<%= extensionName %>s">
                      <div id="NoRecords" runat="server" class="alert alert-info" role="alert" visible="false">
                          <<%= closeDirective %>=LocalizeString("NoRecords")<%= closeDirective %>>
                      </div>
                  </div>
                <ul class="list-unstyled">
              </HeaderTemplate>
              <ItemTemplate>
                   <li>
                      <h3>
                          <asp:Label ID="lblTitle" runat="server" Text='<<%= closeDirective %>#DataBinder.Eval(Container.DataItem,"Title") <%= closeDirective %>>'></asp:Label></h3>
                      <p class="lead">
                         <asp:Label ID="lblDescription" runat="server" Text='<<%= closeDirective %>#DataBinder.Eval(Container.DataItem,"Description") <%= closeDirective %>>'></asp:Label>
                      </p>
                      <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                          <div class="pull-left">
                              <asp:HyperLink ID="lnkEdit" runat="server" CssClass="btn btn-primary" ResourceKey="EditItem.Text" Visible="false" Enabled="false">Edit</asp:HyperLink>
                              <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-danger" ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete"></asp:LinkButton>
                          </div>
                      </asp:Panel>
                  </li>
              </ItemTemplate>
              <FooterTemplate>
                  </ul>
              </FooterTemplate>
          </asp:Repeater>
    </div>
</div>

