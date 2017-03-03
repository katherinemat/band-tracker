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

            Get["/band/{id}"] = parameters =>
            {
                Dictionary<string, object> model = new Dictionary<string, object>{};

                Band foundBand = Band.Find(parameters.id);
                model.Add("band", foundBand);

                List<Venue> allVenues = Venue.GetAll();
                model.Add("venues", allVenues);

                return View["band.cshtml", model];
            };

            Post["/band/{id}"] = parameters =>
            {
                Dictionary<string, object> model = new Dictionary<string, object>{};

                Band foundBand = Band.Find(parameters.id);
                model.Add("band", foundBand);

                foundBand.AddVenue(Request.Form["venue"]);

                List<Venue> allVenues = Venue.GetAll();
                model.Add("venues", allVenues);

                return View["band.cshtml", model];
            };

            Get["/venue/{id}"] = parameters =>
            {
                Dictionary<string, object> model = new Dictionary<string, object>{};

                Venue foundVenue = Venue.Find(parameters.id);
                model.Add("venue", foundVenue);

                List<Band> allBands = Band.GetAll();
                model.Add("bands", allBands);

                return View["venue.cshtml", model];
            };

            Post["/venue/{id}"] = parameters =>
            {
                Dictionary<string, object> model = new Dictionary<string, object>{};

                Venue foundVenue = Venue.Find(parameters.id);
                model.Add("venue", foundVenue);

                foundVenue.AddBand(Request.Form["band"]);

                List<Band> allBands = Band.GetAll();
                model.Add("bands", allBands);

                return View["venue.cshtml", model];
            };

            Delete["/venue/deleted/{id}"] = parameters =>
            {
                Venue foundVenue = Venue.Find(parameters.id);
                foundVenue.Delete();

                return View["index.cshtml", ModelMaker()];
            };

            Patch["/venue/edit/{id}"] = parameters =>
            {
                Dictionary<string, object> model = new Dictionary<string, object>{};

                Venue foundVenue = Venue.Find(parameters.id);
                foundVenue.UpdateName(Request.Form["new-venue-name"]);
                model.Add("venue", foundVenue);

                List<Band> allBands = Band.GetAll();
                model.Add("bands", allBands);

                return View["venue.cshtml", model];
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
