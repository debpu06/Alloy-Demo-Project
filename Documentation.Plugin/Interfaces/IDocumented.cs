
namespace Documentation.Plugin.Interfaces
{
    /// <summary>
    /// Interface for instances of IContent that we want to display documentation for.
    /// </summary>
    public interface IDocumented
    {
        string DocumentationReference { get; set; }
    }
}
