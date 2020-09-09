// <copyright file="IDriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ParkingLotModelLayer;

    /// <summary>
    /// driver interface.
    /// </summary>
    public interface IDriverService
    {
        /// <summary>
        /// park vehicle.
        /// </summary>
        /// <param name="parking">parking details.</param>
        /// <returns>parking obj.</returns>
        Parking ParkVehicle(Parking parking);

        /// <summary>
        /// unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking details.</returns>
        Parking UnParkVehicle(int slotNumber);
    }
}
