﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OperationClaimDto : IDto
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
