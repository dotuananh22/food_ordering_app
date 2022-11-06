using food_ordering_app.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using food_ordering_app.Services;

namespace food_ordering_app.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                this._SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return this._SelectedCategory;
            }
        }

        public ObservableCollection<FoodItem> FoodItemsByCategory { get; set; }

        private int _TotalFoodItems;
        public int TotalFoodItems
        {
            set
            {
                this._TotalFoodItems = value;
                OnPropertyChanged();
            }
            get
            {
                return this._TotalFoodItems;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            FoodItemsByCategory = new ObservableCollection<FoodItem>();
            GetFoodItems(category.CategoryID);
        }

        private async void GetFoodItems(int categoryID)
        {
            var data = await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
            FoodItemsByCategory.Clear();

            foreach (var item in data)
            {
                FoodItemsByCategory.Add(item);
            }
            TotalFoodItems = FoodItemsByCategory.Count;
        }
    }
}
