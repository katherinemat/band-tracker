using Nancy;
using System;
using System.Collections.Generic;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["index.cshtml", ModelMaker()];
            };

            Post["/"] = _ =>
            {
                Band newBand = new Band(Request.Form["band"]);
                newBand.Save();

                Venue newVenue = new Venue(Request.Form["venue"]);
                newVenue.Save();
                newVenue.AddBand(newBand.GetId());

                return View["index.cshtml", ModelMaker()];
            };
        }

        public static Dictionary<string, object> ModelMaker()
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            model.Add("bands", Band.GetAll());
            model.Add("venues", Venue.GetAll());
            return model;
        }
    }
}
