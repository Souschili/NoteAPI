using System;
using System.Collections.Generic;
using System.Text;

namespace NoteServiceLayer.Models
{
   public  class Token
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }

    }
}
