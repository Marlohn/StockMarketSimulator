﻿using AzureTables.Connector.Models;

namespace Users.Kernel.Models
{
    public class AzureTableUserModel : BaseAzureTableModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid WalletId { get; set; }
    }
}