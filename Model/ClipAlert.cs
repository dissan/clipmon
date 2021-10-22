using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clipmon.Model
{
    public class ClipAlert
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string ClipRegex { get; set; }
        public string Img { get; set; }
        public string Color { get; set; }
        public string RemoveString { get; set; }
    }
}
