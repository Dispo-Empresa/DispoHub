namespace DispoHub.Mensager.Application.Models.Response
{
    public class EmailMensagerResponseModel
    {
        public bool Success { get; set; } = false;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
