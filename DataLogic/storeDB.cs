using System.Linq;
using System.Collections.Generic;

using DataLogic.Entities;

namespace DataLogic
{
    public class storeDB
    {
        private Entities.StoreDBContext _context;
        public storeDB(Entities.StoreDBContext context)
        {
            _context = context;
        }
        public void ViewInventory()
        {

        }

        public void AddLocation(string name, string address)
        {
            _context.Locations.Add(
                new Entities.Location{
                    Name = name,
                    Address = address
                }
            );
            _context.SaveChanges();
        }

        public List<Entities.Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public DataLogic.Entities.Customer FindCustomer(int customerId)
        {
            return _context.Customers.FirstOrDefault(cust => cust.Id.Equals(customerId));
        }
        public DataLogic.Entities.Customer FindCustomer(string customerName)
        {
            return _context.Customers.FirstOrDefault(cust => cust.Name.Equals(customerName));
        }

        public int CheckItemAmount(int productId)
        {
            return _context.LocationProductInventories
            .Where(prod => prod.ProductId.Equals(productId))
            .Sum(s => s.Quantity);
        }

        public Product GetProductInfo(int productId)
        {
            return _context.Products.FirstOrDefault(prod => prod.ProductId.Equals(productId));
        }

        public void SellItems(int productId, int requestedQuantity){
            int max = _context.LocationProductInventories
            .Where(prod => prod.ProductId.Equals(productId))
            .Max(prod => prod.Quantity);

            if(max < quantity)
            
        }
    }
}