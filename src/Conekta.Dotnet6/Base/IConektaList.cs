namespace ConektaDotnet6.Base;

public interface IConektaList
{
    public bool has_more { get; }
    public string @object { get; }
    public int total { get; }
    public string next_page_url { get; }
}
