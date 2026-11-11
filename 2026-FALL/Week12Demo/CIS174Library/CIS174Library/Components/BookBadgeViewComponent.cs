using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174Library.Models;

namespace CIS174Library.Components
{
    public class BookBadgeViewComponent : ViewComponent
    {
        private IBook book { get; set; }
        public BookBadgeViewComponent(IBook b)
        {
            book = b;
        }

        public IViewComponentResult Invoke()
        {
            return View(book);
        }

        /*public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(book);
        }*/

    }
}
