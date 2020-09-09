// <copyright file="PoliceController.cs" company="PlaceholderCompany">
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
    /// Police controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IPoliceService policeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceController"/> class.
        /// </summary>
        /// <param name="policeService">police service.</param>
        public PoliceController(IPoliceService policeService)
        {
            this.policeService = policeService;
        }

        /// <summary>
        /// owner parking controller.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking details.</returns>
        [Route("/api/police/park")]
        [HttpPost]
        public ActionResult AddPoliceVehicleToParking([FromBody] Parking parking)
        {
            var result = this.policeService.ParkVehicle(parking);
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
        [Route("/api/police/unpark")]
        [HttpPut]
        public ActionResult RemovePoliceVehicleFromParking([FromBody] int slotNumber)
        {
            Parking result = this.policeService.UnParkVehicle(slotNumber);
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
        /// <returns>parking record.</returns>
        [Route("/api/police/slotNumber")]
        [HttpGet]
        public ActionResult GetParkingRecordBySlotNumber(int slotNumber)
        {
            Parking vehicleDetails = this.policeService.GetVehicleData(slotNumber);
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
        [Route("/api/police/&vehicleNumber={vehicleNumber}")]
        [HttpGet]
        public ActionResult GetParkingRecordByVehicleNumber(string vehicleNumber)
        {
            Parking vehicleDetails = this.policeService.GetVehicleDataByNumber(vehicleNumber);
            if (vehicleDetails != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Record", vehicleDetails));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }
    }
}