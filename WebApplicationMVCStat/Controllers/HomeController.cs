﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCStat.Models;

namespace WebApplicationMVCStat.Controllers
{
    public class HomeController : Controller
    {
        private ModelStatCesiContainer db = new ModelStatCesiContainer();

        // GET: Home
        public ActionResult Index(string LangCode)
        {
            var statisticsSet = db.StatisticsSet.Include(s => s.Academy);
            string lang = "fr_fr";

            if(LangCode != null)
                lang = LangCode;

            setI18n(lang);

            return View(statisticsSet.ToList());
        }

        public ActionResult Contact(string LangCode)
        {   
            string lang = "fr_fr";

            if (LangCode != null)
                lang = LangCode;
            setI18n(lang);
            return View();
        }



        /// <summary>
        /// Traduction des vues du controller
        /// </summary>
        /// <param name="lang"></param>
        private void setI18n(string lang)
        {
            switch (lang)
            {

                case "fr_fr":
                    ViewData["StatTitle"] = I18n_fr.StatTitle;
                    ViewData["Academy"] = I18n_fr.Academy;
                    ViewData["Result"] = I18n_fr.Result;
                    ViewData["Area"] = I18n_fr.Area;
                    ViewData["Contact"] = I18n_fr.ContactUS;
                    ViewData["Introduction"] = I18n_fr.Intrdoduction;
                    ViewData["Score"] = I18n_fr.Score;
                    break;
                case "en_en":
                    ViewData["StatTitle"] = I18n_en.StatTitle;
                    ViewData["Academy"] = I18n_en.Academy;
                    ViewData["Result"] = I18n_en.Result;
                    ViewData["Area"] = I18n_en.Area;
                    ViewData["Contact"] = I18n_en.ContactUS;
                    ViewData["Introduction"] = I18n_en.Introduction;
                    ViewData["Score"] = I18n_en.Score;
                    break;
                default:
                    break;
            }
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
