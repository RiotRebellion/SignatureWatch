﻿namespace SignatureWatch.UseCases.Contracts.Responses.Base
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public string[] Errors { get; set; }
    }
}