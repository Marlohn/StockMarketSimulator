namespace Wallets.Kernel.Application.Dtos
{
    public class WalletDto
    {
        public Guid WalletId { get; set; }
        public List<AssetDTO> Assets { get; set; }
    }
}