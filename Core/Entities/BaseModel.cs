﻿using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace team_manegement_api.Core
{
    public class BaseModel : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
