// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ParkingLotApplication.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBussinessLayer;
    using ParkingLotModelLayer;

    /// <summary>
    /// Controller for Owner.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;
        private Msmq mSMQService = new Msmq();

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerController"/> class.
        /// </summary>
        /// <param name="ownerService">ownerservice.</param>
        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
          //  this.mSMQService = mSMQService;
        }

        /// <summary>
        /// owner parking controller.
        /// </summary>
        /// <param name="parking">parking.</param>
        /// <returns>parking details.</returns>
        [Route("/api/owner/park")]
        [HttpPost]
        public ActionResult AddOwnerVehicleToParking(Parking parking)
        {
            var result = this.ownerService.ParkVehicle(parking);
            if (result != null)
            {
               // Sender.AddMessageToQueue("Vehicle Number " + result.VehicleNumber + "is parked" + " in Slot Number" + result.SlotNumber + " Parking Id is " + result.ParkingId);

                this.mSMQService.AddToQueue("Vehicle Number " + result.VehicleNumber + "is parked " + " in Slot Number " + result.SlotNumber + " Parking Id is " + result.ParkingId);
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "This vehicle can not be parked", null));
        }

        /// <summary>
        /// unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">slotNumber.</param>
        /// <returns>Unpark vehicle details.</returns>
        [Route("/api/owner/unpark")]
        [HttpPut]
        public ActionResult RemoveOwnerVehicleFromParking(int slotNumber)
        {
            Parking result = this.ownerService.UnParkVehicle(slotNumber);
            if (result != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// To get parking records by slot id.
        /// </summary>
        /// <param name="slotNumber">slot number.</param>
        /// <returns>vehicle details.</returns>
        [Route("/api/owner/{slotNumber}")]
        [HttpGet]
        public ActionResult GetParkingRecordBySlotNumber(int slotNumber)
        {
            Parking vehicleDetails = this.ownerService.GetVehicleData(slotNumber);
            if (vehicleDetails.VehicleNumber != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Record", vehicleDetails));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// To get parking record by vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">vehicle number.</param>
        /// <returns>vehicle details.</returns>
        [Route("/api/owner/vehicleNumber={vehicleNumber}")]
        [HttpGet]
        public ActionResult GetParkingRecordByVehicleNumber(string vehicleNumber)
        {
            Parking vehicleDetails = this.ownerService.GetVehicleDataByNumber(vehicleNumber);
            if (vehicleDetails.SlotNumber >= 0)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Record", vehicleDetails));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// to get all vehicles.
        /// </summary>
        /// <returns>list of vehicles.</returns>
        [Route("/api/owner/allvehicles")]
        [HttpGet]
        public ActionResult GetAllVehicles()
        {
            List<Parking> parking = this.ownerService.GetListOfVehicleInParkingLot();
            if (parking.Count != 0)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Records", parking));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", null));
        }

        /// <summary>
        /// To delete parking id record.
        /// </summary>
        /// <param name="id">ParkingId.</param>
        /// <returns>vehicle details.</returns>
        [Route("/api/owner/{Id}")]
        [HttpDelete]
        public ActionResult DeleteParkingIdRecord(int id)
        {
            var result = this.ownerService.DeleteParkingIdRecord(id);
            if (result)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Deleted succesfully", result));
            }

            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", result));
        }
    }
}
