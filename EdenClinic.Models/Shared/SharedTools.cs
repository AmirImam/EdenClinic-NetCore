using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden.Accounting.Models.Abstract
{
    public class SharedTools
    {
        public static List<string> Pages
        {
            get
            {
                return new List<string>()
                {
                    "Accounts",
                    "Banks",
                    "Assets",
                    "AssetsSales",
                    "Boxes",
                    "ExpensesActions",
                    "Expenses",
                    "SalariesPayments",
                    "Employees",
                    "CostCenters",
                    "SalaryAllowances",
                    "Allowances",
                    "FinancialPapers",
                    "JournalEntries",
                    "Patients",
                    "Suppliers"
                };
            }
        }
    }
}
