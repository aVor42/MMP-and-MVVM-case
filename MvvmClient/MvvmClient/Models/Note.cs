using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmClient.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Day { get; set; }
        public int Order { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString() =>
            $"{Order})\t{Name}\t{(IsComplete ? "(Сделано)" : "")}";
    }
}
