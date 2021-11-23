﻿using System;
using System.Runtime.Serialization;

namespace DalObject
{
    [Serializable]
    public class DroneException : Exception
    {
        public DroneException()
        {
        }

        public DroneException(string message) : base("Drone exception: " +message)
        {
        }

        public DroneException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DroneException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}