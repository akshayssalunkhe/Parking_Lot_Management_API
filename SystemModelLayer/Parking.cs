// <copyright file="Parking.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parking class.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets to get and set parking id.
        /// </summary>
        public int ParkingId { get; set; }

        /// <summary>
        /// Gets or sets to get and set Vehicle Number.
        /// </summary>
        [Required(ErrorMessage = "Vehicle Number Is Not According to Format")]
        [RegularExpression(@"[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}", ErrorMessage = "Please enter a valid Vehicle Number")]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets to get and set entry time.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Gets or sets to get and set parking type.
        /// </summary>
        [Required(ErrorMessage = "Parking Type Is Required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please Enter A Valid Parking Type")]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets to get and set Driver Type.
        /// </summary>
        [Required(ErrorMessage = "Driver Type Is Required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please Enter A Valid Driver Type")]
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or sets to set and get Vehicle Type.
        /// </summary>
        [Required(ErrorMessage = "Vehicle Type Is Required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please Enter A Valid Vehicle Type")]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets to get and set parking availability.
        /// </summary>
        public int Disabled { get; set; }

        /// <summary>
        /// Gets or sets to get and set exit time.
        /// </summary>
        public string ExitTime { get; set; }

        /// <summary>
        /// Gets or sets to get and set slot number.
        /// </summary>
        [Required(ErrorMessage = "Slot Type Is Required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please Enter A Valid Slot Number")]
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets charges.
        /// </summary>
        public string Charges { get; set; }
    }
}
