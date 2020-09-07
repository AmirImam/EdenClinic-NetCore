using Eden.Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    public class TransactionDataModel : BaseModel
    {
        public int? EntryID { get; set; }
        //public JournalEntries JournalEntry { get; set; }
    }
}
