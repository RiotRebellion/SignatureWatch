namespace SignatureWatch.UseCases.Contracts.Responses
{
    public class AuthentificationResponse
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }

        public string[] Errors { get; set; }
     }
}
