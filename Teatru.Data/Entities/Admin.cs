﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Data.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
    }
}
