using System;
using System.Collections.Generic;

namespace MVC_CRUD.Models;

public partial class ItemTable
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public DateTime ItemInsertTime { get; set; }
}
