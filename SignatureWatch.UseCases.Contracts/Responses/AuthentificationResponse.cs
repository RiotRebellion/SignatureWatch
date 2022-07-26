﻿using SignatureWatch.UseCases.Contracts.Responses.Base;

namespace SignatureWatch.UseCases.Contracts.Responses
{
    public class AuthentificationResponse : BaseResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
     }
}
