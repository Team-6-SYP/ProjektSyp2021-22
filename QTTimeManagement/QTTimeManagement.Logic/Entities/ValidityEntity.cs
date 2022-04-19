﻿using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class ValidityEntity : VersionEntity, IValidityable
    {
        [Required]
        public DateTime Begin { get; set; }

        public DateTime? End { get; set; }
    }
}