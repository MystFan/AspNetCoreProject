namespace AspNetCoreApp.Models
{
    using System.Collections.Generic;

    public class CatListViewModel
    {
        public IEnumerable<CatModel> Cats { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
