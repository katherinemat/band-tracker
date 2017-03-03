using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class VenueTest : IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_VenuesEmptyAtFirst()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToVenueObject()
        {
            //Arrange
            Venue testVenue = new Venue("Hollywood Bowl");
            testVenue.Save();

            //Act
            Venue savedVenue = Venue.GetAll()[0];

            int result = savedVenue.GetId();
            int testId = testVenue.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void UpdateName_OneVenue_NewName()
        {
            Venue newVenue = new Venue("Radi City");
            newVenue.Save();

            newVenue.UpdateName("Radio City Music Hall");

            string newName = newVenue.GetName();

            Assert.Equal("Radio City Music Hall", newName);
        }

        [Fact]
        public void Delete_OneVenue_VenueDeleted()
        {
            Venue newVenue1 = new Venue("Radio City Music Hall");
            newVenue1.Save();
            Venue newVenue2 = new Venue("Hollywood Bowl");
            newVenue2.Save();
            newVenue1.Delete();

            List<Venue> allVenues = Venue.GetAll();
            List<Venue> expected = new List<Venue>{newVenue2};

            Assert.Equal(expected, allVenues);
        }

        [Fact]
        public void AddBand_VenueAndBand_AllVenueBands()
        {
            Band newBand1 = new Band("CCR");
            newBand1.Save();
            Band newBand2 = new Band("B52s");
            newBand2.Save();

            Venue newVenue1 = new Venue("Radio City Music Hall");
            newVenue1.Save();

            newVenue1.AddBand(newBand1.GetId());
            newVenue1.AddBand(newBand2.GetId());

            List<Band> allBandsVenue1 = newVenue1.GetBands();
            List<Band> expected = new List<Band>{newBand1, newBand2};

            Assert.Equal(expected, allBandsVenue1);
        }

        [Fact]
        public void Find_VenueById_FoundVenue()
        {
            Venue newVenue1 = new Venue("Hollywood Bowl");
            newVenue1.Save();
            Venue newVenue2 = new Venue("Irvine Amphitheater");
            newVenue2.Save();

            Venue foundVenue = Venue.Find(newVenue2.GetId());
            Assert.Equal(foundVenue, newVenue2);
        }

        public void Dispose()
        {
            Venue.DeleteAll();
            Band.DeleteAll();
        }
    }
}
