namespace RezervariBilete.Helper.Model;

public class BreadCrumItem
{
    public string Title { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Controller { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public RouteValueDictionary RouteValues { get; set; } = new RouteValueDictionary();
}