// <copyright file="ParkingTypes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// parkingtypes.
    /// </summary>
    public class ParkingTypes
    {
        /// <summary>
        /// Gets or sets to get set parking type id.
        /// </summary>
        public int ParkingTypeId { get; set; }

        /// <summary>
        /// Gets or sets to get set parking Type.
        /// </summary>
        public char ParkingType { get; set; }

        /// <summary>
        /// Gets or sets to get and set parking charge.
        /// </summary>
        public int ParkingCharge { get; set; }
    }
}
