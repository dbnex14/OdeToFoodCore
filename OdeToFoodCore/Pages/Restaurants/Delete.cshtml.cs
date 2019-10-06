using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCore.Core;
using OdeToFoodCore.Data;

namespace OdeToFoodCore.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; } // model to bind against from cshtml file

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        // when Get, present restaurant to delete to user and ask user if they
        // want to delete restaurant.  The page will also have to include form
        // because we dont want to delete restaurant untill user says Yes to
        // delete and POST back to server.
        // Since we want this page to react to url like /restaurants/delete/3, we
        // need to pass the id of restaurant to it.
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            // we found restaurant, so render the page
            return Page();
        }

        // REMEMBER! We never want to modify data during GET, so we create POST here.
        // And after delete, we will redirect and issue GET request for some
        // other page so user is not sitting on top of result from a POST.  That is
        // why we return some IActionResult
        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            // we dont want this page to render and show result based on POST but
            // redirect to list of restaurants page, so this issues another GET
            // request to show all restaurants.  Put user friendly message in
            // TempData so user is notified that delete succeeded.
            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");            
        }
    }
}
