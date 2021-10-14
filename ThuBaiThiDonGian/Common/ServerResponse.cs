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
        SendFile,
        SendList,
        SendStudent,
        SendString,
        BeginExam,
        FinishExam,
        LockClient
    }

    [Serializable]
    public class ServerResponse
    {
        public ServerResponseType Type { get; set; }
        public object Data { get; set; }
    }
}
