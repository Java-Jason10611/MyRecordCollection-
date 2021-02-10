using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecordCollection.Models
{
    public class AlbumVM
    {
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public string AlbumGenre { get; set; }
        [Required]
        public string AlbumArtist { get; set; }
        public string AlbumCoverUrl { get; set; }
    }
}
