
namespace Documentation.Plugin.Interfaces
{
    /// <summary>
    /// Interface for documentation repository
    /// </summary>
    public interface IDocumentationRepository
    {
        string GetDocumentationById(string reference);
    }
}
