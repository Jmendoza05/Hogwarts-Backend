using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsBackend.Models
{
    public class aspirante
    {
        public int id { get; set; }
        public string name { get; set; }
        public string apellidos { get; set; }
        public int identificacion { get; set; }
        public int edad { get; set; }
        public string casa { get; set; }

    }
}
