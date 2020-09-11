// <copyright file="Msmq.cs" company="PlaceholderCompany">
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
    /// MSMQ class.
    /// </summary>
    public class Msmq : IMSMQService
        {
            private readonly MessageQueue messageQueue = new MessageQueue();

            /// <summary>
            /// Initializes a new instance of the <see cref="Msmq"/> class.
            /// </summary>
            public Msmq()
            {
                this.messageQueue.Path = @".\private$\ParkingLotbills";

                if (MessageQueue.Exists(this.messageQueue.Path))
                {
                }
                else
                {
                    // Creates the new queue.
                    MessageQueue.Create(this.messageQueue.Path);
                }
            }

            /// <summary>
            /// Method to add message to MSMQ.
            /// </summary>
            /// <param name="message">Message Text.</param>
            public void AddToQueue(string message)
            {
                this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                this.messageQueue.ReceiveCompleted += this.ReceiveFromQueue;

                this.messageQueue.Send(message);

                this.messageQueue.BeginReceive();

                this.messageQueue.Close();
            }

            /// <summary>
            /// Method to fetch message from MSMQ.
            /// </summary>
            /// <param name="sender">Object data.</param>
            /// <param name="eventArgs">ReceiveCompletedArgs Object.</param>
            public void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs eventArgs)
            {
                try
                {
                    var msg = this.messageQueue.EndReceive(eventArgs.AsyncResult);

                    string data = msg.Body.ToString();

                    //// Process the logic be sending the message
                    using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\ParkingRecords.txt", true))
                    {
                        file.WriteLine(data);
                    }
                    //// Restart the asynchronous receive operation.
                    this.messageQueue.BeginReceive();
                }
                catch (MessageQueueException qexception)
                {
                    Console.WriteLine(qexception);
                }
            }
        }
}