// <copyright file="DriverController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBussinessLayer;
    using ParkingLotModelLayer;

    /// <summary>
    /// Driver controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverController"/> class.
        /// </summary>
        /// <param name="driverService">ownerservice.</param>
        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        /// <summary>
        /// owner parking controller.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking details.</returns>
        [Route("/api/driver/park")]
        [HttpPost]
        public ActionResult AddOwnerVehicleToParking(Parking parking)
        {
            var result = this.driverService.ParkVehicle(parking);
            if (result != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "Vehicle already Parked", null));
        }

        /// <summary>
        /// unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">parking.</param>
        /// <returns>Unpark vehicle details.</returns>
        [Route("/api/driver/unpark")]
        [HttpPut]
        public ActionResult RemoveOwnerVehicleFromParking(int slotNumber)
        {
            Parking result = this.driverService.UnParkVehicle(slotNumber);
            if (result != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }
    }
}
