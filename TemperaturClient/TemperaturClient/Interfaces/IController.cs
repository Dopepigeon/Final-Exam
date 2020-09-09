using System;
using System.Collections.Generic;

namespace TemperaturClient
{
    public interface IController
    {
        void SetModel(IModel model);
        List<Temperatur> GetDataFromServer(DateTime start, DateTime end);
    }
}