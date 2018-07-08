using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBot.Models
{

    public enum BedSizeOption
    {
        King,
        Queen,
        Single,
        Double
    }

    public enum AmenitiesOptions
    {
        Kitchen,
        ExtraTowel,
        GymAccess,
        WiFi
    }

    [Serializable]
    public class RoomReservation
    {
        public BedSizeOption? BedSize;
        public int? NumberOfOccupants;
        public DateTime? CheckInDate;
        public int? NumeerOfDaysToStay;
        public List<AmenitiesOptions> Amenities;

        public static IForm<RoomReservation> BuildForm()
        {
            return new FormBuilder<RoomReservation>()
                .Message("Welcome to the hotel reservation bot!")
                .Build();
        }
    }
}