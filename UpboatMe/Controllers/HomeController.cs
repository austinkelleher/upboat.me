﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using UpboatMe.Models;
using System.Linq;
using System.Web.Hosting;

namespace UpboatMe.Controllers
{
    public class HomeController : Controller
    {
        // Note: don't forget to explicitly enable new actions in the route config
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 60)]
        public ActionResult Index()
        {
            var memes = GlobalMemeConfiguration.Memes.GetMemes();
            var root = HostingEnvironment.ApplicationVirtualPath ?? "";
            if (!root.EndsWith("/"))
            {
                root += "/";
            }

            var viewModel = new IndexViewModel()
            {
                RecentMemes = new List<RecentMeme>
                {
                    new RecentMeme
                    {
                        Url = root + "sap/wears-suit-and-tie-to-interview/phone-interview.jpg",
                        Alt = "socially awkward penguin: wears suit and tie to interview" + Environment.NewLine + "phone interview",
                        Title = "socially awkward penguin"
                    },
                    new RecentMeme
                    {
                        Url = root + "fry/not-sure-if-sunny-outside/or-hungover.jpg",
                        Alt = "futurama fry: not sure if sunny outside" + Environment.NewLine + "or hungover",
                        Title = "futurama fry"
                    },
                    new RecentMeme
                    {
                        Url = root + "scc/i-don't-buy-things-with-money/i-buy-them-with-hours-of-my-life.jpg",
                        Alt = "sudden clarity clarence: i don't buy things with money" + Environment.NewLine + "i buy them with hours of my life",
                        Title = "sudden clarity clarence"
                    },
                    new RecentMeme
                    {
                        Url = root + "blb/has-pet-rock/it-runs-away.jpg",
                        Alt = "bad luck brian: has pet rock" + Environment.NewLine + "it runs away",
                        Title = "bad luck brian"
                    }
                },
                BuilderViewModel = new BuilderViewModel
                {
                    Memes = memes,
                    Top = "top-line",
                    Bottom = "bottom-line",
                    SelectedMeme = memes.First().Aliases.First()
                }
            };

            return View(viewModel);
        }

        public ActionResult Terms()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
