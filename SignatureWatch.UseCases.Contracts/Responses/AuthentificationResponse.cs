using SignatureWatch.UseCases.Contracts.Responses.Base;

namespace SignatureWatch.UseCases.Contracts.Responses
{
    public class AuthentificationResponse : BaseResponse
    {
        public string Token { get; set; }
     }
}
