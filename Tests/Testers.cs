using DataLogic;
using DataLogic.Entities;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Testers
{
    /// <summary>
    /// Test Class for Database 
    /// </summary>
    public class Testers
    {
        private readonly DbContextOptions<StoreDBContext> options;

        public Testers()
        {

            options = new DbContextOptionsBuilder<DataLogic.Entities.StoreDBContext>()
            .UseSqlite("Filename=Test.db").Options;
            
            Seed();
        }
        //Test Read Ops
        //When testing methods that do not state of the data in the db only one context instance is needed
        //What methods does not affect db state: Read
        [Fact]
        public void GetAllRestaurantsShouldReturnAllRestaurants()
        {
            //putting in a test context/ connection to our test db
            using (var context = new Entities.StoreDBContext(options))
            {
                //Arrange
                 storeDB _repo = new storeDB(context);

                //Act
                var location = _repo.FindLocation("Scranton");

                //Assert
                Assert.Equal(1, location.Id);
            }
        }
        //When testing operations that change the state of the db (i.e manipulate the data inside the db) 
        //make sure to check if the change has persisted even when accessing the db using a different context/connection
        //This means that you create another instance of your context when testing to check that the method has 
        //definitely affected the db.
        //What operations affect the state of the db? Create, Update, Delete
        private void Seed()
        {
            using (var context = new Entities.StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Locations.Add(
                    new Entities.Location{
                        Id = 1,
                        Name = "Good Taste",
                        Address = "5354 West Pickle St. Scranton, OH 99849"
                    }
                
                );
                context.Products.Add(
                    new Entities.Product{
                        ProductId = 1,
                        Name = "Dirt",
                        Price = 5.99
                    }
                );
                context.SaveChanges();
            }
        }

    }
}