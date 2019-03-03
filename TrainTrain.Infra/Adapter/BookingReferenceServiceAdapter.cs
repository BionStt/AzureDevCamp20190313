﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrainTrain.Domain;
using TrainTrain.Domain.Port;

namespace TrainTrain.Infra.Adapter
{
    public class BookingReferenceServiceAdapter : IProvideBookingReference
    {
        private readonly string _uriBookingReferenceService;

        public BookingReferenceServiceAdapter(string uriBookingReferenceService)
        {
            _uriBookingReferenceService = uriBookingReferenceService;
        }

        public async Task<BookingReference> GetBookingReference()
        {
            using (var client = new HttpClient())
            {
                var value = new MediaTypeWithQualityHeaderValue("application/json");
                client.BaseAddress = new Uri(_uriBookingReferenceService);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(value);

                // HTTP GET
                var response = await client.GetAsync("/booking_reference");
                response.EnsureSuccessStatusCode();
                return new BookingReference(await response.Content.ReadAsStringAsync());
            }
        }
    }
}