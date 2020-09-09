// <copyright file="Roles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// roles class.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Gets or sets to get set role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets to get set role type.
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// Gets or sets to get and set charge.
        /// </summary>
        public int Charge { get; set; }
    }
}
