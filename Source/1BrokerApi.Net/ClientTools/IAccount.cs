using Jojatekok.OneBrokerAPI.JsonObjects;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public interface IAccount
    {
        /// <summary>Gets basic information about the account being used.</summary>
        AccountInfo GetAccountInfo();

        /// <summary>Gets the Bitcoin deposit address of the account being used.</summary>
        string GetBitcoinDepositAddress();
    }
}
