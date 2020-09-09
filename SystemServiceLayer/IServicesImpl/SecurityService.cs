﻿// <copyright file="SecurityService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.IServicesImpl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ParkingLotBussinessLayer;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// security service.
    /// </summary>
    public class SecurityService : ISecurityService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        /// <param name="parkingRepository">parking repository.</param>
        public SecurityService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        /// <summary>
        /// park vehicle.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking obj.</returns>
        public Parking ParkVehicle(Parking parking)
        {
            try
            {
                return this.parkingRepository.AddVehicleToParking(parking);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking obj.</returns>
        public Parking UnParkVehicle(int slotNumber)
        {
            try
            {
                return this.parkingRepository.UnParkVehicle(slotNumber);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// vehicle data.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking obj.</returns>
        public Parking GetVehicleData(int slotNumber)
        {
            try
            {
                return this.parkingRepository.GetVehicleData(slotNumber);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// vehicle data.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>parking obj.</returns>
        public Parking GetVehicleDataByNumber(string vehicleNumber)
        {
            try
            {
                return this.parkingRepository.GetVehicleDataByNumber(vehicleNumber);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}