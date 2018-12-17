using GreenHouseService.DB;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseService.Protocol
{
    public class HT : CommandBase<GreenHouseSession, StringRequestInfo>
    {
        public override void ExecuteCommand(GreenHouseSession session, StringRequestInfo requestInfo)
        {
            DbContent db = new DbContent();

            var aa = db.Humitures.ToList();
            session.Send("OK");
        }
    }
}
