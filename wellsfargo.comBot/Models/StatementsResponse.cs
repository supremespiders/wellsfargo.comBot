using System.Collections.Generic;

namespace wellsfargo.comBot.Models
{
    public class StatementsResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AccountList
    {
        public string accountDisplayName { get; set; }
        public bool selected { get; set; }
        public bool subAccount { get; set; }
        public string url { get; set; }
    }

    public class DocumentErrorMsg
    {
        public string message { get; set; }
        public string messageStyle { get; set; }
    }

    public class Statement
    {
        public string documentDisplayName { get; set; }
        public DocumentErrorMsg documentErrorMsg { get; set; }
        public string documentKey { get; set; }
        public string url { get; set; }
    }

    public class TimePeriodList
    {
        public bool selected { get; set; }
        public string timePeriod { get; set; }
        public string url { get; set; }
    }

    public class StatementsDisclosuresInfo
    {
        public string accountIntroText { get; set; }
        public List<AccountList> accountList { get; set; }
        public bool consumerXCC { get; set; }
        public string defaultAccountId { get; set; }
        public List<object> disclosures { get; set; }
        public bool displayMortgageStatementsHeader { get; set; }
        public bool displayRetailLinks { get; set; }
        public bool displayStatementsHeader { get; set; }
        public bool displayStudentLoanBack { get; set; }
        public string downloadFormUrl { get; set; }
        public bool enableBulkDownload { get; set; }
        public List<object> escrowStatements { get; set; }
        public bool isMortgageAccount { get; set; }
        public List<string> legalDisclosureTexts { get; set; }
        public List<Statement> statements { get; set; }
        public List<TimePeriodList> timePeriodList { get; set; }
    }

    public bool IS_YEAREND_SUMMARY_LINK { get; set; }
    public StatementsDisclosuresInfo statementsDisclosuresInfo { get; set; }
    public string viewName { get; set; }

    }
}