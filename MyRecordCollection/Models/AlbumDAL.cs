using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecordCollection.Models
{
    public class AlbumDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumGenre { get; set; }
        public string AlbumArtist { get; set; }
        public string AlbumCoverUrl { get; set; }
    }
}
