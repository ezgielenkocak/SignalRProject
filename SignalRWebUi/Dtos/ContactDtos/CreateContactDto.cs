﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUi.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string FooterDescription { get; set; }
    }
}
