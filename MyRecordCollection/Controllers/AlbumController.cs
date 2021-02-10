using Microsoft.AspNetCore.Mvc;
using MyRecordCollection.Models;
using MyRecordCollection.Services;
using System;
using System.Linq;

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

        public IActionResult SearchArtist(string searchString)
        {
            var viewModel = new AddAlbumResultViewModel();
            var albums = _albumDbContext.Albums;
            if (!String.IsNullOrEmpty(searchString))
            {
                var Albumlist = albums
                    .Select(AlbumDAL => new AlbumVM
                    {
                        AlbumName = AlbumDAL.AlbumName,
                        AlbumArtist = AlbumDAL.AlbumArtist,
                        AlbumCoverUrl = AlbumDAL.AlbumCoverUrl,
                        AlbumGenre = AlbumDAL.AlbumGenre,
                        
                    })
                    .Where(albums => albums.AlbumArtist.Contains(searchString)).ToList();
                viewModel.Albums = Albumlist;


                return View("ViewAlbums", viewModel);
            }
            return ViewAlbums();

        }

        public IActionResult SearchAlbum(string searchString, string searchType)
        {
            var viewModel = new AddAlbumResultViewModel();
            var albums = _albumDbContext.Albums;
            if (!String.IsNullOrEmpty(searchString))
            {
                var Albumlist = albums
                    .Select(AlbumDAL => new AlbumVM
                    {
                       
                         AlbumName = AlbumDAL.AlbumName,
                        AlbumArtist = AlbumDAL.AlbumArtist,
                        AlbumCoverUrl = AlbumDAL.AlbumCoverUrl,
                        AlbumGenre = AlbumDAL.AlbumGenre,

                    })
                    .Where(albums => albums.AlbumName.Contains(searchString)).ToList();
                viewModel.Albums = Albumlist;


                return View("ViewAlbums", viewModel);
            }
            return ViewAlbums();

        }
        public IActionResult SearchGenre(string searchString)
        {
            var viewModel = new AddAlbumResultViewModel();
            var albums = _albumDbContext.Albums;
            if (!String.IsNullOrEmpty(searchString))
            {
                var Albumlist = albums
                    .Select(AlbumDAL => new AlbumVM
                    {
                        AlbumName = AlbumDAL.AlbumName,
                        AlbumArtist = AlbumDAL.AlbumArtist,
                        AlbumCoverUrl = AlbumDAL.AlbumCoverUrl,
                        AlbumGenre = AlbumDAL.AlbumGenre,

                    })
                    .Where(albums => albums.AlbumGenre.Contains(searchString)).ToList();
                viewModel.Albums = Albumlist;


                return View("ViewAlbums", viewModel);
            }
            return ViewAlbums();

        }
    }
}
