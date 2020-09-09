// <copyright file="DriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// Driver service.
    /// </summary>
    public class DriverService : IDriverService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// pa.
        /// </summary>
        /// <param name="parkingRepository">parkingrepository.</param>
        public DriverService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        /// <summary>
        /// park vehicle.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>Parking obj.</returns>
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
        /// to unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">slotnumber.</param>
        /// <returns>Parking obj.</returns>
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
    }
}
