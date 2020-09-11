// <copyright file="IMSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Experimental.System.Messaging;

    /// <summary>
    /// interface.
    /// </summary>
    public interface IMSMQService
    {
        /// <summary>
        /// add to queue.
        /// </summary>
        /// <param name="message">message.</param>
        public void AddToQueue(string message);

        /// <summary>
        /// receive from queue.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="eventArgs">event arg.</param>
        public void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs eventArgs);
    }
}
