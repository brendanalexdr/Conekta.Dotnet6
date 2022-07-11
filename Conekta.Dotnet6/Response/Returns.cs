using Conekta.Dotnet6.Base;

namespace Conekta.Dotnet6.Response
{
    public class Returns : IConektaList
    {

        public bool has_more { get; set; }

        public string @object { get; set; }

        public int total { get; set; }

        public string next_page_url { get; set; }

        public List<Models.Return> data { get; set; }
    }
}
