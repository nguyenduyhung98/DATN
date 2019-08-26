namespace TinTucCTSV.Data.Extends
{
        public static class GetFullName
    {
        public static string FullName(this string lastName, string firstName)
        {
            return firstName + " " + lastName;
        }
    }
}