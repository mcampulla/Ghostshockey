using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model
{
    public static class Dto
    {
        public class Response
        {
            public string Message;

            public string ExceptionMessage;
            public string ExceptionType;
        }

        public class Response<TContent> : Response
        {
            public TContent Content;

            public Response(TContent content)
            {
                this.Content = content;
            }
        }

        public static Response<T> Wrap<T>(T content)
        {
            return new Response<T>(content);
        }
    }
}
