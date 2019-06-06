using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOfLifeWebApplication.Models;

namespace GameOfLifeWebApplication.Controllers
{
    public class GridController : Controller
    {
        public ActionResult Index()
        {
            bool[,] game = new bool[12, 12];
            Grid grid = new Grid(game);

           
            return View(grid);
        }

    }
}
