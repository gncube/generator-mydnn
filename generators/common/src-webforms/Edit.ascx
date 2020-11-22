<<%= openDirective %> Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="<%= fullNamespace %>.Edit" <%= closeDirective %>>
<<%= openDirective %> Import Namespace="DotNetNuke.Services.Localization" <%= closeDirective %>>
<<%= openDirective %> Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" <%= closeDirective %>>

<div class="dnnForm dnn<%= extensionName %>Form dnnClear" id="<%= extensionName %>sForm">
    <asp:Label runat="server" CssClass="dnnFormMessage dnnFormInfo" ResourceKey="Intro" />
    <div class="dnnFormItem dnnFormHelp dnnClear">
        <p class="dnnFormRequired">
            <asp:Label runat="server" ResourceKey="Required Indicator" />
        </p>
    </div>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtTitle" ResourceKey="Title" />
            <asp:TextBox runat="server" ID="txtTitle" CssClass="dnnFormRequired"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                CssClass="dnnFormMessage dnnFormError" ResourceKey="Title.Required" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtDescription" ResourceKey="Description" />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescription" CssClass="dnnFormRequired"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                CssClass="dnnFormMessage dnnFormError" ResourceKey="Description.Required" />
        </div>
    </fieldset>
    <ul class="dnnActions dnnClear">
        <li>
            <asp:LinkButton ID="btnSave" runat="server" CssClass="dnnPrimaryAction" ResourceKey="Save" OnClick="btnSave_Click"></asp:LinkButton>

        </li>
        <li>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="dnnSecondaryAction" ResourceKey="Cancel" OnClick="btnCancel_Click" CausesValidation="False"></asp:LinkButton>

        </li>
    </ul>
</div>
