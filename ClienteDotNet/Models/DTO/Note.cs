using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteDotNet.Models.DTO
{
    //basta copiar o json recebido pelo método Get
    //http://json2csharp.com/  Utilizar para gerar o código dessa classe
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}