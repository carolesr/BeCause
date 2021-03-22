using System.Collections.Generic;

namespace UserService.Core.Responses
{
    public class Response
    {
        private object _object { get; set; }
        private List<string> _messages { get; set; }

        public Response() { }
        public Response(object obj) => _object = obj;
        public Response(string message) => AddMessage(message);
        public Response(List<string> messages) => _messages = messages;

        public Response AddObject(object obj)
        {
            _object = obj;
            return this;
        }

        public Response AddMessage(string message)
        {
            _messages.Add(message);
            return this;
        }

        public Response AddMessage(List<string> messages)
        {
            messages.ForEach(m => _messages.Add(m));
            return this;
        }
    }
}
