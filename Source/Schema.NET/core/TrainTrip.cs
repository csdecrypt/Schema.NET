﻿namespace Schema.NET
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// A trip on a commercial train line.
    /// </summary>
    public partial interface ITrainTrip : ITrip
    {
        /// <summary>
        /// The platform where the train arrives.
        /// </summary>
        OneOrMany<string> ArrivalPlatform { get; set; }

        /// <summary>
        /// The station where the train trip ends.
        /// </summary>
        OneOrMany<ITrainStation> ArrivalStation { get; set; }

        /// <summary>
        /// The platform from which the train departs.
        /// </summary>
        OneOrMany<string> DeparturePlatform { get; set; }

        /// <summary>
        /// The station from which the train departs.
        /// </summary>
        OneOrMany<ITrainStation> DepartureStation { get; set; }

        /// <summary>
        /// The name of the train (e.g. The Orient Express).
        /// </summary>
        OneOrMany<string> TrainName { get; set; }

        /// <summary>
        /// The unique identifier for the train.
        /// </summary>
        OneOrMany<string> TrainNumber { get; set; }
    }

    /// <summary>
    /// A trip on a commercial train line.
    /// </summary>
    [DataContract]
    public partial class TrainTrip : Trip, ITrainTrip, IEquatable<TrainTrip>
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "TrainTrip";

        /// <summary>
        /// The platform where the train arrives.
        /// </summary>
        [DataMember(Name = "arrivalPlatform", Order = 306)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<string> ArrivalPlatform { get; set; }

        /// <summary>
        /// The station where the train trip ends.
        /// </summary>
        [DataMember(Name = "arrivalStation", Order = 307)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<ITrainStation> ArrivalStation { get; set; }

        /// <summary>
        /// The platform from which the train departs.
        /// </summary>
        [DataMember(Name = "departurePlatform", Order = 308)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<string> DeparturePlatform { get; set; }

        /// <summary>
        /// The station from which the train departs.
        /// </summary>
        [DataMember(Name = "departureStation", Order = 309)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<ITrainStation> DepartureStation { get; set; }

        /// <summary>
        /// The name of the train (e.g. The Orient Express).
        /// </summary>
        [DataMember(Name = "trainName", Order = 310)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<string> TrainName { get; set; }

        /// <summary>
        /// The unique identifier for the train.
        /// </summary>
        [DataMember(Name = "trainNumber", Order = 311)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<string> TrainNumber { get; set; }

        /// <inheritdoc/>
        public bool Equals(TrainTrip other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Type == other.Type &&
                this.ArrivalPlatform == other.ArrivalPlatform &&
                this.ArrivalStation == other.ArrivalStation &&
                this.DeparturePlatform == other.DeparturePlatform &&
                this.DepartureStation == other.DepartureStation &&
                this.TrainName == other.TrainName &&
                this.TrainNumber == other.TrainNumber &&
                base.Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this.Equals(obj as TrainTrip);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Of(this.Type)
            .And(this.ArrivalPlatform)
            .And(this.ArrivalStation)
            .And(this.DeparturePlatform)
            .And(this.DepartureStation)
            .And(this.TrainName)
            .And(this.TrainNumber)
            .And(base.GetHashCode());
    }
}
