// <copyright file="ResponseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System.Net;

    /// <summary>
    /// Response entity.
    /// </summary>
    public class ResponseEntity
    {
        /// <summary>
        /// Gets or sets status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// response entity.
        /// </summary>
        /// <param name="statusCode">statuscode.</param>
        /// <param name="message">message.</param>
        /// <param name="data">data.</param>
        public ResponseEntity(HttpStatusCode statusCode, string message, object data)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }
    }
}