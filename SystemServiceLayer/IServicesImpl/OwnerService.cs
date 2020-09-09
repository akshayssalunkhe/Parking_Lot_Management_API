// <copyright file="OwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// owner class.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        /// <summary>
        /// creating reference of repository.
        /// </summary>
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerService"/> class.
        /// owner constructor.
        /// </summary>
        /// <param name="parkingRepository">parkingrepository.</param>
        public OwnerService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        /// <summary>
        /// parking the vehicle.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking information.</returns>
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
        /// unparking the vehicle.
        /// </summary>
        /// <param name="slotNumber">parking.</param>
        /// <returns>unpark information.</returns>
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
        /// get vehicle data by slot number.
        /// </summary>
        /// <param name="slotNumber">slotnumber.</param>
        /// <returns>vehicle record.</returns>
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
        /// get data by vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>vehicle data.</returns>
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

        /// <summary>
        /// list of vehicles.
        /// </summary>
        /// <returns> vehicle list.</returns>
        public List<Parking> GetListOfVehicleInParkingLot()
        {
            try
            {
                List<Parking> parkingList = new List<Parking>();
                parkingList = this.parkingRepository.GetAllVehiclesInParking();
                return parkingList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// deleting the parking record.
        /// </summary>
        /// <param name="parkingId">parking id.</param>
        /// <returns>record of parking id.</returns>
        public bool DeleteParkingIdRecord(int parkingId)
        {
            try
            {
                var result = this.parkingRepository.DeleteParkingIdRecord(parkingId);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}