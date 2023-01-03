using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Spotify.DataAccess;
using static Spotify.DataAccess.AlbumDAL;
using static Spotify.Services.AlbumService;

namespace Spotify.Services.Tests
{
    [TestClass()]
    public class AlbumServiceTests
    {


        [TestMethod()]
        public void testAddAlbum()
        {
            // arrange
            int id = 1;
            string title = "test";
            string artist = "test";
            string link = "test";           
            DateTime created = DateTime.Now;
            AlbumTestDAL albumTestDal = new AlbumTestDAL();
            AlbumLogic albumLogic = new AlbumLogic(albumTestDal);

            // act
            albumLogic.AddAlbum(id, title, artist, link, created);

            // assert
            Assert.AreEqual(title, albumTestDal.getTitle());
            Assert.AreEqual(artist, albumTestDal.getArtist());
            Assert.AreEqual(link, albumTestDal.getLink());
            Assert.AreEqual(created, albumTestDal.getCreated());
        }

        [TestMethod()]
        public void testUpdateAlbum()
        {
            // arrange
            int id = 1;
            string title = "test";
            string artist = "test";
            string link = "test";
            DateTime created = DateTime.Now;
            AlbumTestDAL albumTestDal = new AlbumTestDAL();
            AlbumLogic albumLogic = new AlbumLogic(albumTestDal);
            albumLogic.AddAlbum(id, title, artist, link, created);
            int updateId = 1;
            string updateTitle = "test2";
            string updateArtist = "test2";
            string updateLink = "test2";
            DateTime updateCreated = DateTime.Now;


            // act
            albumLogic.UpdateAlbum(updateId, updateTitle, updateArtist, updateLink, updateCreated);

            // assert
            Assert.AreEqual(updateTitle, albumTestDal.getTitle());
            Assert.AreEqual(updateArtist, albumTestDal.getArtist());
            Assert.AreEqual(updateLink, albumTestDal.getLink());
            Assert.AreEqual(updateCreated, albumTestDal.getCreated());
        }

    } 
}