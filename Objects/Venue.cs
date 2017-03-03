using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
    public class Venue
    {
        private string _name;
        private int _id;

        public Venue(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if(!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                bool idEquality = this.GetId() == newVenue.GetId();
                bool nameEquality = this.GetName() == newVenue.GetName();
                return (idEquality && nameEquality);
            }
        }

        public int GetId()
        {
            return _id;
        }
        public void SetName(string newName)
        {
            _name = newName;
        }
        public string GetName()
        {
            return _name;
        }

        public static List<Venue> GetAll()
        {
            List<Venue> allVenues = new List<Venue>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);
                Venue newVenue = new Venue(venueName, venueId);
                allVenues.Add(newVenue);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allVenues;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@Name);", conn);

            cmd.Parameters.Add(new SqlParameter("@Name", this.GetName()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(rdr, conn);
        }

        public void UpdateName(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewName OUTPUT INSERTED.name WHERE id=@VenueId;", conn);

            cmd.Parameters.Add(new SqlParameter("@NewName", newName));
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));

            SqlDataReader rdr = cmd.ExecuteReader();

//can't i just set _name = newName ?
            while(rdr.Read())
            {
                this._name = rdr.GetString(0);
            }

            DB.CloseSqlConnection(rdr, conn);
        }

//when i delete a venue, what happens to venue, band pair in join table?
        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Venue Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", id.ToString()));
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundId = 0;
            string foundName = null;

            while(rdr.Read())
            {
                foundId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
            }
            Venue foundVenue = new Venue(foundName, foundId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundVenue;
        }

        public void AddBand(int bandId)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);

            cmd.Parameters.Add(new SqlParameter("@BandId", bandId.ToString()));
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId().ToString()));

            cmd.ExecuteNonQuery();

            if(conn != null)
            {
                conn.Close();
            }
        }

        public List<Band> GetBands()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT bands.* FROM venues JOIN bands_venues ON (venues.id = bands_venues.venue_id) JOIN bands ON (bands_venues.band_id = bands.id) WHERE venues.id = @VenueId;", conn);

            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId().ToString()));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<Band> allBands = new List<Band> {};

            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                string bandName = rdr.GetString(1);
                Band newBand = new Band(bandName, bandId);
                allBands.Add(newBand);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allBands;
        }

        public static void DeleteAll()
        {
            DB.TableDeleteAll("venues");
        }
    }
}
