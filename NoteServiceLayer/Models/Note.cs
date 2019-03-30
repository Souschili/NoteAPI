using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoteServiceLayer.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Title  { get; set; }
        public string Text { get; set; }
        public DateTime posted { get; set; }
    }
}
