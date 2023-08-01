using System;
using System.Collections.Generic;

namespace back_mvc_aspNet.Context;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
