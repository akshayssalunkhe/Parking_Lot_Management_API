// <copyright file="Sender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Experimental.System.Messaging;

    /// <summary>
    /// sender class.
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// Method to add message to MSMQ.
        /// </summary>
        /// <param name="message">message.</param>
        public static void AddMessageToQueue(string message)
        {
             MessageQueue messageQueue = null;
             try
                {
                    if (MessageQueue.Exists(@".\Private$\parkingbillsQueue"))
                    {
                        messageQueue = new MessageQueue(@".\Private$\parkingbillsQueue");
                    }
                    else
                    {
                        messageQueue = MessageQueue.Create(@".\Private$\parkingbillsQueue");
                    }

                    messageQueue.Label = "This is the ParkinglotMesaageQue";
                    messageQueue.Send(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    messageQueue.Dispose();
            }
        }
    }
}
