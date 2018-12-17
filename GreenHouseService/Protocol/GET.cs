using Common;
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
    public class GET : CommandBase<GreenHouseSession, StringRequestInfo>
    {
        public override void ExecuteCommand(GreenHouseSession session, StringRequestInfo requestInfo)
        {
            DbContent db = new DbContent();
            var greenhouseId = Convert.ToInt32(requestInfo.Parameters[0]);
            var control = db.GreenHouse.Where(m => m.Id == greenhouseId).Select(m => m.Control).FirstOrDefault();
            var json = JsonHelper.SerializeObject(control);
            session.Send(json);
        }
    }
}
