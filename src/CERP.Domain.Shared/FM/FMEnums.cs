using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.FM
{
    public enum AccountStatementTypeEnum
    {
        BalanceSheet,
        ProfitAndLoss
    }
    public enum AccountStatementDetailTypeEnum
    {
        Zakat,
        Revenue,
        NonCurrentAssets,
        GAExpenses,
        Equity,
        DirectCosts,
        CurrentLiabilities,
        CurrentAssets,
        NonCurrentLiabilities,
    }
    public enum CashFlowStatementTypeEnum
    {
        [Description("Cash Generated From Operations")]
        CashGeneratedFromOperations,
        [Description("Cash Flow From Operating Activities")]
        CashFlowFromOperatingActivities,
        [Description("Cash Flow From Financing Activites")]
        CashFlowFromFinancingActivites,
        [Description("Net Profit Before Tax")]
        NetProfitBeforeTax,
        [Description("Operating Profit Before Working Capital")]
        OperatingProfitBeforeWorkingCapital,
        [Description("Cash And Cash Equivalents")]
        CashAndCashEquivalents
    }
}
