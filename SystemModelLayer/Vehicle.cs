// <copyright file="Vehicle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.PortableExecutable;
    using System.Text;

    /// <summary>
    /// vehicle class.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets to get set vehicle id.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets to get set vehicle Type.
        /// </summary>
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or sets to  get set vehicle charge.
        /// </summary>
        public int VehicleCharge { get; set; }
    }
}
