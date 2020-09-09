// <copyright file="ParkingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using ParkingLotModelLayer;

    /// <summary>
    /// Parking Lot Repository.
    /// </summary>
    public class ParkingRepository : IParkingRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingRepository"/> class.
        /// </summary>
        /// <param name="configuration">configuration.</param>
        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        /// <inheritdoc/>
        public Parking AddVehicleToParking(Parking parking)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spPark", this.sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@VehicleNumber", parking.VehicleNumber);
                    sqlCommand.Parameters.AddWithValue("@EntryTime", parking.EntryTime);
                    sqlCommand.Parameters.AddWithValue("@ParkingType", parking.ParkingType);
                    sqlCommand.Parameters.AddWithValue("@DriverType", parking.DriverType);
                    sqlCommand.Parameters.AddWithValue("@VehicleType", parking.VehicleType);
                    sqlCommand.Parameters.AddWithValue("@SlotNumber", parking.SlotNumber);
                    sqlCommand.Parameters.AddWithValue("@Charges", parking.Charges);

                    this.sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result <= 0)
                    {
                        return parking;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                this.sqlConnection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <inheritdoc/>
        public Parking UnParkVehicle(int slotNumber)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spUnpark", this.sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SlotNumber", slotNumber);

                    this.sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return this.GetVehicleData(slotNumber);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                this.sqlConnection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <inheritdoc/>
        public Parking GetVehicleData(int slotNumber)
        {
            Parking parking = new Parking();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetVehicleBySlotId", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    sqlCommand.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parking.ParkingId = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                            parking.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parking.EntryTime = sqlDataReader.GetDateTime("ENTRY_TIME");
                            parking.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parking.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            parking.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parking.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                            parking.Charges = (sqlDataReader["CHARGES"] is null) ? "0" : sqlDataReader["CHARGES"].ToString();

                            parking.ExitTime = (sqlDataReader["EXIT_TIME"] is null) ? "NULL" : sqlDataReader["EXIT_TIME"].ToString();
                        }

                        return parking;
                    }

                    sqlConnection.Close();
                }

                return parking;
            }
            catch (Exception e)
            {
                this.sqlConnection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <inheritdoc/>
        public Parking GetVehicleDataByNumber(string vehicleNumber)
        {
            Parking parking = new Parking();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetVehicleByVehicleNumber", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    sqlCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parking.ParkingId = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                            parking.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parking.EntryTime = sqlDataReader.GetDateTime("ENTRY_TIME");
                            parking.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parking.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            parking.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parking.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);

                            parking.ExitTime = (sqlDataReader["EXIT_TIME"] is null) ? "NULL" : sqlDataReader["EXIT_TIME"].ToString();
                        }

                        return parking;
                    }

                    sqlConnection.Close();
                }

                return parking;
            }
            catch (Exception e)
            {
                this.sqlConnection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <summary>
        /// To get all parked vehicle list.
        /// </summary>
        /// <returns>List of vehicle.</returns>
        public List<Parking> GetAllVehiclesInParking()
        {
            List<Parking> parkingList = new List<Parking>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetAllVehicles", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Parking parking = new Parking();
                            parking.ParkingId = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                            parking.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parking.EntryTime = sqlDataReader.GetDateTime("ENTRY_TIME");
                            parking.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parking.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            parking.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parking.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);

                            parking.ExitTime = (sqlDataReader["EXIT_TIME"] is null) ? "NULL" : sqlDataReader["EXIT_TIME"].ToString();

                            parkingList.Add(parking);
                        }

                        return parkingList;
                    }

                    sqlConnection.Close();
                }

                return parkingList;
            }
            catch (Exception e)
            {
                this.sqlConnection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <summary>
        /// delete method.
        /// </summary>
        /// <param name="parkingId">id.</param>
        /// <returns>boolean.</returns>
        public bool DeleteParkingIdRecord(int parkingId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteParkingData", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                command.Parameters.AddWithValue("@ParkingId", parkingId);
                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}