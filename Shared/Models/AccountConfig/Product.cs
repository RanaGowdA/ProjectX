﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagement.Shared.Models.AccountConfig
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProjectAccountId")]
        public int ProjectAccountId { get; set; }
        public ProjectAccount? ProjectAccount { get; set; }
    }
}
