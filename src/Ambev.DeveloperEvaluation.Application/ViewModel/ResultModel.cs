namespace Ambev.DeveloperEvaluation.Application.ViewModel
{

    public class ResultModel : ApiResponse
    {
        public object Data { get; set; }

        public ResultModel(object? data)
        {
            Data = data;
        }

        public ResultModel()
        {

        }


        public ResultModel Result(object? data, string ? message = null)
        {
            Data = data;
            Success = true;
            Message = !string.IsNullOrEmpty(message) ? message : string.Empty;
            return this;
        }

        public ResultModel Ok(string? message = null)
        {
            Message = !string.IsNullOrEmpty(message) ? message : string.Empty;
            Success = true;

            return this;
        }

        public ResultModel ReturnErro(string errorMessage)
        {
            Errors.ToList().Add(new Common.Validation.ValidationErrorDetail() { Detail = Message });
            Success = false;
            return this;
        }

    }
}