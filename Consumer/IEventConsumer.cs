﻿namespace CQRS.CORE.Consumer
{
    public interface IEventConsumer
    {
        void Consume(string topic);
    }
}
