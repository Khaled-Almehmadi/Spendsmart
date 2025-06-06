﻿using System.ComponentModel.DataAnnotations;

namespace Spendsmart.Models
{
    public class Expense
    {

    public int Id { get; set; }
    public decimal Value { get; set; }

      [Required]
    public String? Description { get; set; }
    }
}
