namespace Note_Creator.Helpers
{
    public static class TextHelper
    {
        public static bool IsNullOrEmpty(string text)
        {
            return text == null || text.Trim() == "";
        }
    }
}
