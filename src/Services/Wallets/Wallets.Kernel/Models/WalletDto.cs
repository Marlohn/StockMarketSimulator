namespace Wallets.Kernel.Models
{
    public class WalletDto
    {
        public Guid WalletId { get; set; }
        public List<AssetDTO> Assets { get; set; }
    }
}