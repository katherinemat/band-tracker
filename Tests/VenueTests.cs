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

        public void Dispose()
        {
            Venue.DeleteAll();
        }
    }
}
