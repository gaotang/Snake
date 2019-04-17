﻿using MassTransit;
using Snake.Core.Events;
using Snake.Core.Models;
using Snake.Core.Mongo;
using Snake.Core.Util;
using System;
using System.Threading.Tasks;

namespace Snake.ApiTrackService.Consumers
{
    public class TrackLogCreatedEventConsumer : IConsumer<TrackLogCreatedEvent>
    {
        public Task Consume(ConsumeContext<TrackLogCreatedEvent> context)
        {
            return Task.Run(() =>
            {
                if (context.Message != null)
                {
                    var repository = MongoRepository<TrackLog>.Instance;
                    TrackLog trackLog = MapperProvider.MapTo<TrackLog>(context.Message);
                    var obj = repository.Add(trackLog);
                }
                Console.WriteLine($"Recevied By TrackLogCreatedEventConsumer:{context.Message.GUID}");
            });
        }
    }
}
