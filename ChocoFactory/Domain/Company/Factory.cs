using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Factory
    {
        //properties
        public Company Company { get; set; }
        public Warehouse Warehouse { get; set; }
        public Production Production { get; set; }
        public Accounting Accounting { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();

        //constructor
        public Factory(Company company)
        {
            Company = company;
            Warehouse = new Warehouse(this);
            Production = new Production(this);
            Accounting = new Accounting(this);

            OpeningActions();
        }

        //methods
        private void OpeningActions()
        {
            Accounting.ReceiveOffers();
            Accounting.SendOrder(Accounting.BestOffer);
            Warehouse.GetDailyProducts();
        }

        public void DailyActions(DateTime currentDate)
        {
            Warehouse.DailyActions(currentDate);
        }

        public void YearlyActions()
        {
            Warehouse.AddExperimentalProduct();
            Accounting.ReceiveOffers();
            Accounting.SendOrder(Accounting.BestOffer);
        }


    }
}
