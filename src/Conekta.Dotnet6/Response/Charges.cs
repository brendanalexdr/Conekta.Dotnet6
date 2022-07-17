using ConektaDotnet6.Base;

namespace ConektaDotnet6.Response
{
    public class Charges : IConektaList
    {
        public bool has_more { get; set; }

        public string @object { get; set; }

        public int total { get; set; }

        public string next_page_url { get; set; }

        public List<ConektaDotnet6.Models.Charge> data { get; set; }
    }
}
