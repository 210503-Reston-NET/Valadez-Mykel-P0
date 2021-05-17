using System;
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

        public int GetUserID(string email, string password){
            return _context.Customers.First(cust => cust.Email.Equals(email) && cust.Password.Equals(password)).Id;
        }

        public int AddUser(string name, string email, string password){
            _context.Customers.Add(new Entities.Customer{
                Name = name,
                Email = email,
                Password = password
            });
            _context.SaveChanges();
            return GetUserID(email, password);
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

        public void SellItems(int productId, int requestedQuantity, int customerId){
            int leftToBeSold = 0;
            int paritalRequestedQuantity = 0;

            do{
                List<LocationProductInventory> invWithProduct = _context.LocationProductInventories
                .Where(inv => inv.ProductId.Equals(productId)).ToList();

                int max = invWithProduct.Max(inv => inv.Quantity);

                if(max < requestedQuantity){
                    leftToBeSold = requestedQuantity - max;
                    paritalRequestedQuantity = max;
                }

                LocationProductInventory invent = invWithProduct.First(inv => inv.Quantity.Equals(max)); 
                invent.Quantity -= paritalRequestedQuantity;

                CreateOrder(productId, requestedQuantity, customerId, invent.LocationId);

            } while (leftToBeSold > 0);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            
        }

        public void CreateOrder(int productId, int requestedQuantity, int customerId, int locationId){
            _context.Orders.Add(new Entities.Order{
                LocationId = locationId,
                CustomerId = customerId
            });

            int orderId = _context.Orders.Max(ord => ord.OrderId);

            _context.OrderDetails.Add(new Entities.OrderDetail{
                OrderId = orderId,
                ProductId = productId,
                Quantity = requestedQuantity,
            });

            _context.SaveChanges();

        }
    }
}