﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity<string>
    {
        public string Name { get; set; }


        public Brand()
        {

        }
        public Brand(string id,string name)
        {
            Id= id;
            Name= name;
        }
    }
}