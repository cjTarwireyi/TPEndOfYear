﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
   public class TimeSheetFactory
    {
       public static TimeSheetDTO createTimeSheet(int id, int day, int hour, int minutes)
       {
           return new TimeSheetDTO.TimeSheetBuilder()
           .buildId(id)
           .buildDay(day)
           .buildHour(hour)
           .buildMinutes(minutes)
           .build();
       }
        
    }
}
