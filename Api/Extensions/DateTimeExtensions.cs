namespace Api.Extensions
{
    public static class DateTimeExtensions
    {
        public static decimal PortionOfYearTurnedSelectedAge(this DateTime birthDay, DateTime toDate, int ageDiscriminator)
        {
            var bornBeforeCutline = toDate.AddYears(-ageDiscriminator);
            // not applicable
            if (birthDay > bornBeforeCutline) return 0;         
            // turned tha age just in the year of the cut date - count months of that year
            if (birthDay.Year == bornBeforeCutline.Year)
            {
                var numberOfYearDays = DateTime.IsLeapYear(toDate.Year) ? 366 : 365;
                return birthDay.DayOfYear / numberOfYearDays;
            }
            // turned the age year or more before the cut date
            return 1m;
        }
    }
}
