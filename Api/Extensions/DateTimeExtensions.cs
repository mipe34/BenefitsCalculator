namespace Api.Extensions
{
    public static class DateTimeExtensions
    {
        public static decimal PortionOfYearTurnedSelectedAge(this DateTime birthDay, DateTime toDate, int ageDiscriminator)
        {
            var bornBeforeCutline = toDate.AddYears(-ageDiscriminator).Year;
            // not applicable
            if (birthDay.Year > bornBeforeCutline) return 0;         
            // turned tha age just in the year of the cut date - count portion of that year
            if (birthDay.Year == bornBeforeCutline)
            {
                var numberOfYearDays = DateTime.IsLeapYear(toDate.Year) ? 366m : 365m;
                return (numberOfYearDays - birthDay.DayOfYear + 1) / numberOfYearDays;
            }
            // turned the age year or more before the cut date
            return 1m;
        }
    }
}
