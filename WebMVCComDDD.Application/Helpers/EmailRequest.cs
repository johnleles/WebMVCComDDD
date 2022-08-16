using Microsoft.AspNetCore.Http;
using System.Security;

namespace WebMVCComDDD.Application.Helpers
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<IFormFile> Attachments { get; set; }
        public SecureString? Password { get; internal set; }
        public string? Mail { get; internal set; }
    }
}
