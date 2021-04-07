using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        //GUID is Globally Unique ID
        //32 digit hexadecimals grouped in chunks of 8-4-4-12
        //10^38 possible GUIDS, almost always unique. 
        //hard to access so bad for debugging good for security.
        // still small chance of duplication (1 in 1 trillion chance)
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
