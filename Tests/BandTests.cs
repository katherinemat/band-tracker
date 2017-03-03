using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class BandTest : IDisposable
    {
        public BandTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_BandsEmptyAtFirst()
        {
            //Arrange, Act
            int result = Band.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToBandObject()
        {
            //Arrange
            Band testBand = new Band("CCR");
            testBand.Save();

            //Act
            Band savedBand = Band.GetAll()[0];

            int result = savedBand.GetId();
            int testId = testBand.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void AddVenue_VenueAndBand_AllBandVenues()
        {
            Band newBand1 = new Band("CCR");
            newBand1.Save();

            Venue newVenue1 = new Venue("Radio City Music Hall");
            newVenue1.Save();
            Venue newVenue2 = new Venue("Hollywood Bowl");
            newVenue2.Save();

            newBand1.AddVenue(newVenue1.GetId());
            newBand1.AddVenue(newVenue2.GetId());

            List<Venue> allVenuesBand1 = newBand1.GetVenues();
            List<Venue> expected = new List<Venue>{newVenue1, newVenue2};

            Assert.Equal(expected, allVenuesBand1);
        }

        [Fact]
        public void Find_BandById_FoundBand()
        {
            Band newBand1 = new Band("CCR");
            newBand1.Save();
            Band newBand2 = new Band("Lily Allen");
            newBand2.Save();

            Band foundBand = Band.Find(newBand2.GetId());
            Assert.Equal(foundBand, newBand2);
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
