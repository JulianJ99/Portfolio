using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Spotify.Services;
using Spotify.DataAccess;

namespace SpotifyProject.Controllers
{
    public class HomeController : Controller
    {
        AlbumDAL albumDAL = new AlbumDAL();

        public IActionResult Index()
        {
            
            AlbumService.AlbumLogic Albumlogic = new AlbumService.AlbumLogic(albumDAL);
            List<Album> albums = Albumlogic.GetAll();

            return View(albums);
        }

        [HttpPost]
        public ActionResult Insert(string txtTitle, string txtArtist, string txtLink)
        {
            
            AlbumService.AlbumLogic Albumlogic = new AlbumService.AlbumLogic(albumDAL);
            int id = 0;
            string title = txtTitle;
            string artist = txtArtist;
            string link = txtLink;
            DateTime created = DateTime.Now;
            Albumlogic.AddAlbum(id, title, artist, link, created);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            
            AlbumService.AlbumLogic Albumlogic = new AlbumService.AlbumLogic(albumDAL);
            Albumlogic.DeleteAlbum(id);
            return RedirectToAction("index");
        }


        //GET Edit
        public ActionResult Edit(int id)
        {
            
            AlbumService.AlbumLogic Albumlogic = new AlbumService.AlbumLogic(albumDAL);
            List<Album> albums = Albumlogic.EditAlbum(id);
            return View(albums);
            
        }

        //POST edit
        [HttpPost]
        public ActionResult Edit(string txtTitleEdit, string txtArtistEdit, string txtLinkEdit, int id)
        {
            
            AlbumService.AlbumLogic Albumlogic = new AlbumService.AlbumLogic(albumDAL);
            string title = txtTitleEdit;
            string artist = txtArtistEdit;
            string link = txtLinkEdit;
            DateTime created = DateTime.Now;
            Albumlogic.UpdateAlbum(id, title, artist, link, created);
            return RedirectToAction("index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
