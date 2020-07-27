using System;

namespace Note_Creator.Helpers
{
    public static class EventHelper
    {
        public static event EventHandler UpdateNoteContent;

        public static void OnUpdateNoteContent(object sender,EventArgs e)
        {
            UpdateNoteContent?.Invoke(sender, e);
        }
    }
}
