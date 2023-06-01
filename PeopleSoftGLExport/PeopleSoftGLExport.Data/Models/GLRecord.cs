using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSoftGLExport.Data.Models
{
    public class GeneralLedgerRecord
    {
        //GL100_ORG_CODE
        public string Organization { get; set; }
        //GL101_TRANS_DATE
        public DateTime TransactionDate { get; set; }
        //GL101_DESC
        public string Description { get; set; }
        //GL101_AMOUNT, SNm25.3, 134430.390
        public decimal Amount { get; set; }
        //GL101_EVENT_ID,Char15
        public string Project { get; set; }

        //	GL101_ACCOUNT
        public string GLAccount { get; set; }


        public int UniqueId { get; set; }
        public string CC_Code { get; set; }
        public string DepartmentCode { get; set; }
        public string AccountNo { get; set; }
        public string EventCode { get; set; }
        [IgnoreDataMember]
        public string AnchorVenue { get; set; }
   
        public string EventDate { get; set; }
  
        public string EntryNumber { get; set; }
        public int SequenceNumber { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime PostingDate { get; set; }
        public string ExternalDocumentNumber { get; set; }
        public string AccountType { get; set; }
        public string HeaderDescription { get; set; }
        
    }
}
