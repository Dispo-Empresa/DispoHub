namespace DispoHub.API.Models
{
    public class ResponseModelBuilder
    {
        private object? _data = null;
        private string _message = string.Empty;
        private bool _success = false;
        private string _alertType = string.Empty;

        public ResponseModelBuilder WithData(object? data)
        {
            _data = data;
            return this;
        }

        public ResponseModelBuilder WithMessage(string message)
        {
            _message = message;
            return this;
        }

        public ResponseModelBuilder WithSuccess(bool success)
        {
            _success = success;
            return this;
        }

        public ResponseModel Build()
        {
            return new ResponseModel
            {
                Data = _data,
                Message = _message,
                Success = _success,
                AlertType = _alertType
            };
        }
    }

    public class ResponseModel
    {
        public object? Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string AlertType { get; set; }
    }
}