﻿using System.Threading.Tasks;

namespace TrainTrain.Domain
{
    public interface ITrainDataService
    {
        Task<Train> GetTrain(string trainId);
        Task BookSeats(ReservationAttempt reservationAttempt);
    }
}