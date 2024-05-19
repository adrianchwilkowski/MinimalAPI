namespace MinimalApiProject
{
    public static class DateTimeConverter
    {
        public static DateTime ToDate(this string text)
        {
            var dateParts = text.Split("-");
            try
            {
                if (dateParts.Length == 3)
                {
                    var day = int.Parse(dateParts[0]);
                    var month = int.Parse(dateParts[1]);
                    var year = int.Parse(dateParts[2]);
                    return new DateTime(year, month, day);
                }
                throw new Exception();
            }
            catch { throw new ArgumentException("Niepoprawny format daty. Użyj \"dd-mm-rrrr\""); }
        }
        public static string FromDate(this DateTime date) {
            return date.Day + "-" + date.Month + "-" + date.Year;
        }
    }
}
