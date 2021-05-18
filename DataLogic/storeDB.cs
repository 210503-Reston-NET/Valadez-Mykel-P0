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
        public void ViewInventory(int locationId)
        {
            int counter = 1;

            _context.Locations.Join(_context.LocationProductInventories,
                loc => loc.Id,
                lpi => lpi.LocationId,
                (loc, lpi) =>
                new {
                    Name = loc.Name,
                    LocationId = loc.Id,
                    Address = loc.Address,
                    ProductId = lpi.Product.Name,
                    Quantity = lpi.Quantity
                }
            ).Where(inv => inv.LocationId.Equals(locationId))
            .ToList()
            .ForEach(inv => {
                if(counter == 1){
                    Console.WriteLine("Location Name: "+inv.Name);
                    Console.WriteLine("Location Id: "+inv.LocationId);
                    Console.WriteLine("Address: "+inv.Address);
                    Console.WriteLine("");
                }
                Console.WriteLine("Product : "+inv.ProductId);
                Console.WriteLine("Quantity: "+inv.Quantity);
                Console.WriteLine();

                counter = 2;
            });
        }

        public void TransactionByLocation(int locationId){
            _context.Orders.Where(loc => loc.LocationId.Equals(locationId))
            .ToList()
            .ForEach(loc => ViewOrder(loc.OrderId));
        }

        public void ViewOrder(int orderId){
            _context.Orders.Join(_context.OrderDetails,
                ord => ord.OrderId,
                dets => dets.OrderId,
                (ord, dets) => 
                new {
                    OrderId = ord.OrderId,
                    CustomerId = ord.CustomerId,
                    LocationId = ord.LocationId,
                    ProductId = dets.ProductId,
                    Quantity = dets.Quantity,
                    Delivered = dets.Delivered
                    }
                ).Where(ord => ord.OrderId.Equals(orderId))
                .ToList()
                .ForEach(row => {
                    Console.WriteLine("Order Id: "+row.OrderId);
                    Console.WriteLine("Customer Id: "+row.CustomerId);
                    Console.WriteLine("Location Id: "+row.LocationId);
                    Console.WriteLine("ProductId: "+row.ProductId);
                    Console.WriteLine("Quantity Ordered: "+row.Quantity);
                    Console.WriteLine("Delivered Yet?: "+row.Delivered);
                });

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

        public Location FIndLocation(string name){
            return _context.Locations.First(loc => loc.Name.Equals(name));
        }

        public void AddInventory(int productId, int quantity, int locationId){
            
            IQueryable<Entities.LocationProductInventory> currentStock = _context.LocationProductInventories
            .Where(inv => inv.ProductId.Equals(productId) && inv.LocationId.Equals(locationId));
            
            if(currentStock.Count() == 0){

                _context.LocationProductInventories.Add(new Entities.LocationProductInventory{
                    LocationId = locationId,
                    ProductId = productId,
                    Quantity = quantity
                });
            }else{
                currentStock.ToList()[0].Quantity += quantity;
            }

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

        public void GetCustomerOrderAndDetails(int customerId){
            int cs = _context.Orders.Count(ord => ord.CustomerId.Equals(customerId));
            Console.WriteLine(cs);

            _context.Orders.Where(ord => ord.CustomerId.Equals(customerId))
            .ToList()
            .ForEach(ord => {

                _context.Orders.Join(_context.OrderDetails,
                ord => ord.OrderId,
                dets => dets.OrderId,
                (ord, dets) => 
                new {
                    OrderId = ord.OrderId,
                    CustomerId = ord.CustomerId,
                    LocationId = ord.LocationId,
                    ProductId = dets.ProductId,
                    Quantity = dets.Quantity,
                    Delivered = dets.Delivered
                    }
                ).ToList()
                .ForEach(row => {
                    Console.WriteLine("Order Id: "+row.OrderId);
                    Console.WriteLine("Customer Id: "+row.CustomerId);

                    Console.WriteLine("Location Id: "+row.LocationId);
                    Console.WriteLine("ProductId: "+row.ProductId);
                    Console.WriteLine("Quantity Ordered: "+row.Quantity);
                    Console.WriteLine("Delivered Yet?: "+row.Delivered);
                });


            });
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