using System;

namespace WebApplication7.Models
{
    public class ErrorViewModel
    {

        public string RequestId { get; set; }

        public string Message { get; set; }

        //Retorna true or false se é nulo ou vazio
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}