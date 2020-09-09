// <copyright file="IOwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ParkingLotModelLayer;

    /// <summary>
    /// owner service.
    /// </summary>
    public interface IOwnerService
    {
        /// <summary>
        /// park.
        /// </summary>
        /// <param name="parking">vehicle details.</param>
        /// <returns>vehicles details.</returns>
        Parking ParkVehicle(Parking parking);

        /// <summary>
        /// unpark.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking.</returns>
        Parking UnParkVehicle(int slotNumber);

        /// <summary>
        /// vehicle data.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking details.</returns>
        Parking GetVehicleData(int slotNumber);

        /// <summary>
        /// get data by number.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>parking details.</returns>
        Parking GetVehicleDataByNumber(string vehicleNumber);

        /// <summary>
        /// list of vehicle.
        /// </summary>
        /// <returns>list of parked vehicle.</returns>
        List<Parking> GetListOfVehicleInParkingLot();

        /// <summary>
        /// delete id.
        /// </summary>
        /// <param name="parkingId">parking id.</param>
        /// <returns>boolean value.</returns>
        bool DeleteParkingIdRecord(int parkingId);
    }
}
