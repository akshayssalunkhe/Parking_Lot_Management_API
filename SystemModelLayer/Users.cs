// <copyright file="Users.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// users class.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets to get set user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets to get And set Roles.
        /// </summary>
        public int Roles { get; set; }

        /// <summary>
        /// Gets or sets to get set email id.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets to get set password.
        /// </summary>
        public string Password { get; set; }
    }
}
