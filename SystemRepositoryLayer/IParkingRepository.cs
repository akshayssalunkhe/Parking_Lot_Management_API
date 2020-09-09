// <copyright file="IParkingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ParkingLotModelLayer;

    /// <summary>
    /// Repository interface.
    /// </summary>
    public interface IParkingRepository
    {
        /// <summary>
        /// Adding vehicle in parking.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking details.</returns>
        Parking AddVehicleToParking(Parking parking);

        /// <summary>
        /// Unparking the vehicle.
        /// </summary>
        /// <param name="slotNumber">parking.</param>
        /// <returns>vehicle details.</returns>
        Parking UnParkVehicle(int slotNumber);

        /// <summary>
        /// Get vehicle data.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>vehicle details.</returns>
        Parking GetVehicleData(int slotNumber);

        /// <summary>
        /// get vehicle details by number.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>vehicle details.</returns>
        Parking GetVehicleDataByNumber(string vehicleNumber);

        /// <summary>
        /// to return list of vehicle.
        /// </summary>
        /// <returns> list of vehicle.</returns>
        List<Parking> GetAllVehiclesInParking();

        /// <summary>
        /// Deleting parking Id Record.
        /// </summary>
        /// <param name="parkingId">parkingId.</param>
        /// <returns>boolean.</returns>
        bool DeleteParkingIdRecord(int parkingId);
    }
}
