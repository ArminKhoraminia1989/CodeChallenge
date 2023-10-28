using CodeChallenge.Core.Entities.Enums;

namespace CodeChallenge.Application.Utilities
{
    public static class Utilities
    {
        public static bool CheckTypeDoctor(object type)
        {
            return Enum.IsDefined(typeof(EnumDoctorType), type);
        }
        public static bool CheckGender(object type)
        {
            return Enum.IsDefined(typeof(EnumGender), type);
        }
        public static bool CheckDate(DateTime StartTime, DateTime EndTime)
        {
            if (StartTime >= EndTime)
                return false;
            if (StartTime < DateTime.Now || EndTime < DateTime.Now)
                return false;
            return true;
        }

        public static bool CheckDayOfWeek(DateTime StartTime, DateTime EndTime)
        {
            List<DayOfWeek> Days = new List<DayOfWeek>
            { DayOfWeek.Saturday, DayOfWeek.Sunday , DayOfWeek.Monday, DayOfWeek.Tuesday,DayOfWeek.Wednesday};

            if (!(Days.Contains(StartTime.DayOfWeek) && Days.Contains(EndTime.DayOfWeek)))
                return false;

            if (StartTime < DateTime.Now || EndTime < DateTime.Now)
                return false;

            TimeSpan MinTime = new TimeSpan(09, 00, 00);
            TimeSpan MaxTime = new TimeSpan(18, 00, 00);

            if (!(StartTime.TimeOfDay >= MinTime && StartTime.TimeOfDay <= MaxTime
                && EndTime.TimeOfDay >= MinTime && EndTime.TimeOfDay <= MaxTime))
                return false;

            return true;
        }

    }
}
