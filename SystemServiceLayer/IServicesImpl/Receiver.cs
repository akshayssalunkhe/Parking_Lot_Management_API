// <copyright file="Receiver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Experimental.System.Messaging;

    /// <summary>
    /// receiver.
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Method to fetch message from MSMQ.
        /// </summary>
        /// <param name="message">message.</param>
        public static void ReceiveFromQueue()
        {
            MessageQueue messageQueue = null;
            try
            {
                messageQueue = new MessageQueue(@".\Private$\parkingbillsQueue");
                Message[] messages = messageQueue.GetAllMessages();
                if (messages.Length > 0)
                {
                    foreach (Message m in messages)
                    {
                        m.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        string message = m.Body.ToString();
                        messageQueue.Receive();
                        using StreamWriter file = new StreamWriter(@"D:\ParkingRecords.txt", true);
                        file.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine("No New Messages in Message Queue");
                }

                messageQueue.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                messageQueue.Close();
            }
        }
    }
}