namespace GeoVibs_Busisness_API.Service.Utility
{
    public class Functions
    {
        public static DateTime GetStartTimeOfDate(DateTime date)
        {
            return date.Date;
        }

        public static DateTime GetEndTimeOfDate(DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }
    }
}
