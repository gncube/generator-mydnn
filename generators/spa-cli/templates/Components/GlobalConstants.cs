namespace <%= fullNamespace %>.Components.Common
{
  public class ModuleDefinition
  {
    public const string FriendlyName = "GSN: <%= extensionName %>s";
  }
  public class JournalType
  {
    public const string <%= extensionName %>Add = "<%= extensionName %>Add";
    public const string <%= extensionName %>Update = "<%= extensionName %>Update";
  }

  public class NotificationType
  {
    public const string <%= extensionName %>s = "GSN<%= extensionName %>s";
  }
}
