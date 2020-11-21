using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using System;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Entities;

namespace <%= fullNamespace %>
{
    public partial class Edit : <%= extensionName %>ModuleBase
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          var t = new <%= extensionName %>Info();
          var tc = new <%= extensionName %>InfoRepository();

          if (Page.IsValid)
          {
            if (<%= extensionName %>Id > 0)
            {
              t = tc.GetItem(<%= extensionName %>Id, ModuleId);

              if (t != null)
              {
                t.Title = txtTitle.Text.Trim();
                t.Description = txtDescription.Text.Trim();
              }
            }
            else
            {
              t = new <%= extensionName %>Info()
              {
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                CreatedOnDate = DateTime.Now,
                CreatedByUserId = UserId,
              };
            }

            t.LastUpdatedByUserId = UserId;
            t.LastUpdatedOnDate = DateTime.Now;
            t.ModuleId = ModuleId;

            if (t.<%= extensionName %>Id > 0)
            {
              tc.UpdateItem(t);
            }
            else
            {
              tc.CreateItem(t);
            }
            Response.Redirect(Globals.NavigateURL());
          }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          Response.Redirect(Globals.NavigateURL());
        }


  #endregion

        #region Helper Methods

            private void BindData()
            {
                if (!Page.IsPostBack)
                {
                    if (<%= extensionName %>Id > 0)
                    {
                        var tc = new <%= extensionName %>InfoRepository();
                        var t = tc.GetItem(<%= extensionName %>Id, ModuleId);

                        if (t != null)
                        {
                            txtTitle.Text = t.Title;
                            txtDescription.Text = t.Description;
                        }
                        if (CurrentUserCanEdit)
                        {

                        }
                    }
                }


              LocalizeModule();
            }

            private void LocalizeModule()
            {

            }

      #endregion
    }
}
