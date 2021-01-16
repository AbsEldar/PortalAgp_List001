using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SyncAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
              var dep0_id = new Guid("f0653f91-b36a-4f5a-8ced-f75f1549136d"); 
                var dep1_id = new Guid("6ffeb5ad-dba6-47f1-9faf-6225e491672d"); 
                var dep2_id = new Guid("8aa63e96-fb2c-4d1c-9b83-860baca42760"); 
                var dep3_id = new Guid("8981e3df-92c9-43ba-95be-c5047f3d613d"); 
                var dep4_id = new Guid("caad7d26-f088-4317-b9e4-f4a311c940c5"); 
                var dep5_id = new Guid("cf2041dd-3455-4da7-a0b0-81f0697b07cf"); 
                var dep6_id = new Guid("0621ceb1-d54a-4466-8ddb-ab3ce4731fcb"); 
                var dep7_id = new Guid("0b69bad2-7069-476b-8545-315bd32d9844"); 
                var dep8_id = new Guid("084411b7-992c-4a54-8e56-866b2fec9097"); 
                var dep9_id = new Guid("5df52d05-f362-4aa2-9d75-b6086304a60b"); 
            try
            {
                
                if(!context.LstDogs.Any())
                {
                    var dogData = File.ReadAllText("../Infrastructure/Data/SeedData/lstDogs.json");
                    var dogs = JsonSerializer.Deserialize<IReadOnlyList<LstDog>>(dogData);

                    foreach (var dog in dogs)
                    {
                      
                        context.LstDogs.Add(dog);
                    }
                    await context.SaveChangesAsync();
                }

                // if(!context.LstOrders.Any())
                // {
                //     var orderData = File.ReadAllText("../Infrastructure/Data/SeedData/lstOrders.json");
                //     var orders = JsonSerializer.Deserialize<IReadOnlyList<LstOrder>>(orderData);

                //     foreach (var order in orders)
                //     {
                //         context.LstOrders.Add(order);
                //     }
                //     await context.SaveChangesAsync();
                // }


                  // if(dog.Id == Guid.Parse("32aa7f77-7247-46cf-a8f8-9869226ac069"))
                        // {
                        //     dog.Departments.Add(await context.Departments.FirstOrDefaultAsync(x => x.Id == dep0_id));
                        // } 
                        // else if(dog.Id == Guid.Parse("57a7b240-aa77-4153-b610-ce4ca2c5e0ec"))
                        // {
                        //     dog.Departments.Add(await context.Departments.FirstOrDefaultAsync(x => x.Id == dep1_id));
                        // } 
                        // else if(dog.Id == Guid.Parse("35684bc5-d365-4c19-b4e4-e947854a23e8"))
                        // {
                        //     dog.Departments.Add(await context.Departments.FirstOrDefaultAsync(x => x.Id == dep2_id));
                        // } 
                        // else if(dog.Id == Guid.Parse("743fe5fe-8637-4193-ab69-79620103e354"))
                        // {
                        //     dog.Departments.Add(await context.Departments.FirstOrDefaultAsync(x => x.Id == dep3_id));
                        // } 
                        // else if(dog.Id == Guid.Parse("a7e8faf7-87cc-4bc3-a1fb-fdd63e96cc99"))
                        // {
                        //     dog.Departments.Add(await context.Departments.FirstOrDefaultAsync(x => x.Id == dep4_id));
                        // } 

              

                if(!context.Departments.Any())
                {
                    
                   var depList = new List<Department>() {
                        new Department() {Id= dep0_id, Name = "Dep_000", LstDogId = Guid.Parse("32aa7f77-7247-46cf-a8f8-9869226ac069")},
                        new Department() {Id= dep1_id, Name = "Dep_001", LstDogId =  Guid.Parse("57a7b240-aa77-4153-b610-ce4ca2c5e0ec")},
                        new Department() {Id= dep2_id, Name = "Dep_002", LstDogId =  Guid.Parse("35684bc5-d365-4c19-b4e4-e947854a23e8")},
                        new Department() {Id= dep3_id, Name = "Dep_003", LstDogId =  Guid.Parse("743fe5fe-8637-4193-ab69-79620103e354")},
                        new Department() {Id= dep4_id, Name = "Dep_004", LstDogId =  Guid.Parse("a7e8faf7-87cc-4bc3-a1fb-fdd63e96cc99")},
                        new Department() {Id= dep5_id, Name = "Dep_005"},
                        new Department() {Id= dep6_id, Name = "Dep_006"},
                        new Department() {Id= dep7_id, Name = "Dep_007"},
                        new Department() {Id= dep8_id, Name = "Dep_008"},
                        new Department() {Id= dep9_id, Name = "Dep_009"},
                        
                    };

                    foreach (var dep in depList)
                    {
                        context.Departments.Add(dep);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Users.Any())
                {
                    var depId = Guid.Empty;
                    for (int i = 0; i < 10000; i++)
                    {
                        if(i<1000)
                            depId = dep0_id;
                        else if(i>= 1000 && i< 2000)
                            depId = dep1_id;
                        else if(i>= 2000 && i< 3000)
                            depId = dep2_id;
                        else if(i>= 3000 && i< 4000)
                            depId = dep3_id;
                        else if(i>= 4000 && i< 5000)
                            depId = dep4_id;
                        else if(i>= 5000 && i< 6000)
                            depId = dep5_id;
                        else if(i>= 6000 && i< 7000)
                            depId = dep6_id;
                        else if(i>= 7000 && i< 8000)
                            depId = dep7_id;
                        else if(i>= 8000 && i< 9000)
                            depId = dep8_id;
                        else if(i>= 9000)
                            depId = dep9_id;
                        
                        // random pictureUrl
                        string[] pictures = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", 
                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"};
                        Random rand = new Random();
                        int index = rand.Next(pictures.Length);

                        var user = new User()
                        {
                            Id = Guid.NewGuid(),
                            Name = "User_" + i,
                            PictureUrl = $"images/famous/{pictures[index]}.jpg",
                            DepartmentId = depId
                        };
                        context.Users.Add(user);
                    }
                    await context.SaveChangesAsync();
                }


                
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}