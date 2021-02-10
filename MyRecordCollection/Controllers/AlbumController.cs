using Microsoft.AspNetCore.Mvc;
using MyRecordCollection.Models;
using MyRecordCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecordCollection.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumDBContext _albumDbContext;

        public AlbumController(AlbumDBContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
        }
        public IActionResult AddAlbum()
        {
            return View();
        }
        public IActionResult AddAlbumResult(AddAlbumViewModel model)
        {
            var dbModel = new AlbumDAL();
            dbModel.AlbumArtist = model.Album.AlbumArtist;
            dbModel.AlbumName = model.Album.AlbumName;
            dbModel.AlbumGenre = model.Album.AlbumGenre;
            dbModel.AlbumCoverUrl = model.Album.AlbumCoverUrl;

            _albumDbContext.Albums.Add(dbModel);
            _albumDbContext.SaveChanges();

            var albumList = _albumDbContext.Albums
                .Select(albumDal => new AlbumVM() { AlbumArtist = albumDal.AlbumArtist, AlbumName = albumDal.AlbumName, AlbumGenre = albumDal.AlbumGenre, AlbumCoverUrl = albumDal.AlbumCoverUrl })
                .ToList();
            var viewModel = new AddAlbumResultViewModel();
            viewModel.Albums = albumList;
            return View(viewModel);
        }
        public IActionResult ViewAlbums()
        {
            var albumList = _albumDbContext.Albums
            .Select(albumDal => new AlbumVM() { AlbumArtist = albumDal.AlbumArtist, AlbumName = albumDal.AlbumName, AlbumGenre = albumDal.AlbumGenre, AlbumCoverUrl = albumDal.AlbumCoverUrl })
            .ToList();
            var viewModel = new AddAlbumResultViewModel();
            viewModel.Albums = albumList;
            return View(viewModel);
        }
    }
}
