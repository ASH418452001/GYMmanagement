namespace GYMmanagement.Extension
{
    public static class DateTimeExtension
    {

        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;

            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;

            return age;
        }
        public static TimeOnly ToTimeOnly(this DateTime dateTime)
        {
            return TimeOnly.FromDateTime(dateTime);
        }

        public static DateOnly ToDateOnly(this DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }
    }
}
