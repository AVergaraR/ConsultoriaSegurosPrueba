﻿namespace ConsultorioSeguros.Entities
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}