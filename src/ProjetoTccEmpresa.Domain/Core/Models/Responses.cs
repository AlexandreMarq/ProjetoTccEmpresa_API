using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccEmpresa.Domain.Core.Models
{
    public class Responses
    {
        public Guid Id { get; set; }
        public List<string> Messages { get; set; }
        public object Data { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public string Message
        {
            get
            {
                if (Messages == null || !Messages.Any())
                {
                    return string.Empty;
                }

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < Messages.Count; i++)
                {
                    stringBuilder.Append((i == 0) ? Messages[i] : ("\n " + Messages[i]));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
