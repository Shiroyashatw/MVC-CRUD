using System;
using System.Collections.Generic;

namespace MVC_CRUD.Models;

public partial class UserTable
{
    public int UserId { get; set; }

    public string UserAccount { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime UserSingupTime { get; set; }
}
