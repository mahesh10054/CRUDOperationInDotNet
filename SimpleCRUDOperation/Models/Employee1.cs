﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDOperation.Models;

public partial class Employee1
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? Address { get; set; }

    public string? Department { get; set; }
}
