﻿using System;
using System.Collections.Generic;

namespace CosmosManagementApi.Models;

public partial class CustomerProductBill
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Customer id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Product id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Bill id
    /// </summary>
    public int BillId { get; set; }

    /// <summary>
    /// How many product bought
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    /// how is it paid
    /// </summary>
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Staff who made this purchase
    /// </summary>
    public int? StaffId { get; set; }

    /// <summary>
    /// Unit price 
    /// </summary>
    public string? UnitPrice { get; set; }

    /// <summary>
    /// Net price calculated by unit price
    /// </summary>
    public string? NetPrice { get; set; }

    /// <summary>
    /// Discount
    /// </summary>
    public string? Discount { get; set; }

    public virtual Bill Bill { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
