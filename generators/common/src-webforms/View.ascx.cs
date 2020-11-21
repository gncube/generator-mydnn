using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Entities;

namespace <%= fullNamespace %>
{
    public partial class View : <%= extensionName %>ModuleBase, IActionable
    {
        private bool _hasRecords;

        #region Event Handlers

            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    if (!Page.IsPostBack)
                    {
                        BindModule();
                    }
                }
                catch (Exception exc)
                {
                    // Module failed to load
                    Exceptions.ProcessModuleLoadException(this, exc, IsEditable);
                }
            }

            protected void btnNew<%= extensionName %>_Click(object sender, EventArgs e)
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "mid=" + ModuleId.ToString(), "userId=" + UserId.ToString()));
                //Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, PortalSettings, "Edit", "mid=" + ModuleId.ToString(), "userId=" + UserId.ToString()));
            }

            protected void rpt<%= extensionName %>s_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName == "Edit")
                {
                    Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "gsid=" + e.CommandArgument));
                }

                if (e.CommandName == "Delete")
                {
                    var tc = new <%= extensionName %>InfoRepository();
                    var t = tc.GetItem(Convert.ToInt32(e.CommandArgument), ModuleId);
                    t.IsDeleted = true;
                    t.LastUpdatedByUserId = UserId;
                    t.LastUpdatedOnDate = DateTime.Now;
                    tc.UpdateItem(t);
                }
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
            }

            protected void rpt<%= extensionName %>s_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (!_hasRecords)
                {
                    if (e.Item.ItemType == ListItemType.Header)
                    {
                        HtmlGenericControl noRecordsDiv = (e.Item.FindControl("NoRecords") as HtmlGenericControl);
                        if (noRecordsDiv != null)
                        {
                            noRecordsDiv.Visible = true;
                        }
                    }
                }
                if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
                {
                    var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                    var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;

                    try
                    {
                        var t = (<%= extensionName %>Info)e.Item.DataItem;

                        if (lnkDelete != null && lnkEdit != null && pnlAdminControls != null)
                        {
                            pnlAdminControls.Visible = true;
                            lnkDelete.CommandArgument = t.<%= extensionName %>Id.ToString();
                            lnkDelete.Enabled = lnkDelete.Visible = true;
                            lnkEdit.Enabled = lnkEdit.Visible = true;
                            lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, "Edit", "gsid=" + t.<%= extensionName %>Id.ToString());
                        }
                        else
                        {
                            pnlAdminControls.Visible = false;
                        }
                    }
                    catch (Exception exc) // Module failed to load
                    {
                        Exceptions.ProcessModuleLoadException(this, exc);
                    }
                }
            }

      #endregion

        #region Private Helper Methods

            private void BindModule()
            {
                var tc = new <%= extensionName %>InfoRepository();
                IEnumerable<<%= extensionName %>Info> infos = tc.GetItems(ModuleId);
                _hasRecords = infos.Any();
                rpt<%= extensionName %>s.DataSource = infos;
                rpt<%= extensionName %>s.DataBind();


                LocalizeModule();			
            }
        
            private void LocalizeModule()
            {
                // do nothing
            }

      #endregion

        #region IActionable Implementation

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                {
                    {
                        GetNextActionID(), 
						GetLocalizedString("View.MenuItem.Title"), string.Empty,
                        string.Empty,
                        string.Empty, EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false
                    }
                };
                return actions;
            }
        }

        #endregion
    }
}
