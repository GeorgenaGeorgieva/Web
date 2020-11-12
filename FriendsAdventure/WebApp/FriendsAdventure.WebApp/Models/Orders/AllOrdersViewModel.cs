namespace FriendsAdventure.WebApp.Models.Orders
{
    using System;
    using System.Collections.Generic;
    using FriendsAdventure.Services.Models.Order;
    public class AllOrdersViewModel
    {
        public IEnumerable<ListingOrderServicesModel> Orders { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;
        public bool PreviousDisabled => this.CurrentPage == 1;
        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 5);

                return maxPage == this.CurrentPage;
            }
        }

    }
}
