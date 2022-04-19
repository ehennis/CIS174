using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week13.Models;

namespace Week13.Components
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
