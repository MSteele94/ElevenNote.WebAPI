using ElevenNote.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenNote.Models
{
    public class NoteDetail 
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
