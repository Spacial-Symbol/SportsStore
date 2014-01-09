using System;


namespace ProdcutSite.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemPerPages { get; set; }
        public int CurrentPages { get; set; }

        public int TotalPages
        {
            get
            {
                return (int) Math.Ceiling((decimal) TotalItems/ItemPerPages);
            }
        }

    }
}