namespace WebApp.Pages.Clients.Models
{
    public class ClientPageModel
    {
        public ClientPageModel()
        {
            Client = new();
        }

        public ClientModel Client { get; set; }
    }
}
