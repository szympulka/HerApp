using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Her.Commons.Enums
{
    public enum RemindTimeEnum
    {
        [Display(Name = "15 minutes")]
        FifteenMinutes = 15,
        [Display(Name = "30 minutes")]
        ThirtyMinutes = 30,
        [Display(Name = "45 minutes")]
        FourtFiveMinutes = 45,
        [Display(Name = "1 hour")]
        OneHour = 60,

        [Display(Name = "2 hour")]
        TwoHour = 120,

        [Display(Name = "5 hour")]
        FiveHour = 300,

        [Display(Name = "1 day")]
        Day = 720,
    }

}
