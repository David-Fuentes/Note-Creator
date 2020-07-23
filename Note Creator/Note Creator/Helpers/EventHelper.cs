using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Creator.Helpers
{
    public static class EventHelper
    {
        public static event EventHandler UpdateNoteContent;

        public static void OnUpdateNoteContent(object sender,EventArgs e)
        {
            var handler = UpdateNoteContent;
            handler?.Invoke(sender, e);
        }
    }
}
