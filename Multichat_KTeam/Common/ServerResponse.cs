using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public enum ServerResponseType
    {
        SendString,
        SendStudentList,
        SendBitmap,
        SendDoc,
        SendDocx,
        SendZip,
        SendRar
    }

    [Serializable]
    public class ServerResponse
    {
        public ServerResponseType Type { get; set; }
        public object Data { get; set; }

        public ServerResponse()
        {

        }

        public ServerResponse(ServerResponseType type, object data)
        {
            Type = type;
            Data = data;
        }
    }
}
