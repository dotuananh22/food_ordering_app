using Firebase.Database;
using Firebase.Database.Query;
using food_ordering_app.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace food_ordering_app.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderingapp-d61a2-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (121 Ratings)",
                    HomeSelected = "CompleteHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.9",
                    RatingDetail = " (181 Ratings)",
                    HomeSelected = "EmptyHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 3",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.5",
                    RatingDetail = " (140 Ratings)",
                    HomeSelected = "CompleteHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.jpg",
                    Name = "Burger and Pizza Hub 4",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.9",
                    RatingDetail = " (215 Ratings)",
                    HomeSelected = "EmptyHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "MainPizza.jpg",
                    Name = "Pizza",
                    Description = "Pizza - Breakfast",
                    Rating = " 4.6",
                    RatingDetail = " (113 Ratings)",
                    HomeSelected = "CompleteHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 6,
                    CategoryID = 2,
                    ImageUrl = "MainPizza.jpg",
                    Name = "Pizza Hub 2",
                    Description = "Pizza Hub 2 - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (153 Ratings)",
                    HomeSelected = "CompleteHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 7,
                    CategoryID = 3,
                    ImageUrl = "Dessert.png",
                    Name = "Ice Creams",
                    Description = "Ice Creams - Breakfast",
                    Rating = " 4.6",
                    RatingDetail = " (158 Ratings)",
                    HomeSelected = "CompleteHeart.png",
                    Price = 45,
                },
                new FoodItem
                {
                    ProductID = 8,
                    CategoryID = 3,
                    ImageUrl = "Dessert.png",
                    Name = "Cakes",
                    Description = "Cool Cakes - Breakfast",
                    Rating = " 4.6",
                    RatingDetail = " (128 Ratings)",
                    HomeSelected = "EmptyHeart.png",
                    Price = 45,
                },
            };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
