namespace DispoHub.Mensager.Application.Models.Request
{
    public class EmailMensagerRequestModel
    {
        public string Subject { get; set; }
        public string EmailTo { get; set; }
        public string Body { get; set; }
    }
}
