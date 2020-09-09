// <copyright file="SecurityController.cs" company="PlaceholderCompany">
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
    /// Security controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        /// <param name="securityService">security service.</param>
        public SecurityController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        /// <summary>
        /// owner parking controller.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking details.</returns>
        [Route("/api/security/park")]
        [HttpPost]
        public ActionResult AddSecurityVehicleToParking([FromBody] Parking parking)
        {
            var result = this.securityService.ParkVehicle(parking);
            if (result != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">parking.</param>
        /// <returns>Unpark vehicle details.</returns>
        [Route("/api/security/unpark")]
        [HttpPut]
        public ActionResult RemoveSecurityVehicleFromParking([FromBody] int slotNumber)
        {
            Parking result = this.securityService.UnParkVehicle(slotNumber);
            if (result != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// To get parking record by slot number.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>parking details.</returns>
        [Route("/api/security/{slotNumber}")]
        [HttpGet]
        public ActionResult GetParkingRecordBySlotNumber(int slotNumber)
        {
            Parking vehicleDetails = this.securityService.GetVehicleData(slotNumber);
            if (vehicleDetails != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Record", vehicleDetails));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// To get parking record by vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>parking record.</returns>
        [Route("/api/security/&vehicleNumber{vehicleNumber}")]
        [HttpGet]
        public ActionResult GetParkingRecordByVehicleNumber(string vehicleNumber)
        {
            Parking vehicleDetails = this.securityService.GetVehicleDataByNumber(vehicleNumber);
            if (vehicleDetails != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Record", vehicleDetails));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }
    }
}
