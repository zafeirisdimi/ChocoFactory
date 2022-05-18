using ChocoFactory.Policy;

namespace ChocoFactory.Services
{
    public class CompanyPolicy
    {
        //properties
        public FactoryPolicy ForFactory { get; private set; }

        public ProductionPolicy ForProduction { get; private set; }

        public PricePolicy ForPrice { get; private set; }
        public ShopPolicy ForShop { get; private set; }

        //constructor
        public CompanyPolicy()
        {
            ForFactory = new FactoryPolicy();
            ForProduction = new ProductionPolicy();
            ForPrice = new PricePolicy();
            ForShop = new ShopPolicy();
        }
    }
}