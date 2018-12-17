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
    public class CONF : CommandBase<GreenHouseSession, StringRequestInfo>
    {
        public override void ExecuteCommand(GreenHouseSession session, StringRequestInfo requestInfo)
        {
            DbContent db = new DbContent();
            var greenhouseId = Convert.ToInt32(requestInfo.Parameters[0]);
            var greenhouse = db.GreenHouse.Include("Serials").Where(m=>m.Id== greenhouseId).FirstOrDefault();

            List<Modle.Serial> serials = new List<Modle.Serial>();
            foreach (var s in greenhouse.Serials)
            {
                serials.Add(new Modle.Serial() { Id = s.Id, Delay = s.Delay, Desc = s.Desc, Name = s.Name, Sensorid = s.Sensorid, SensorType = s.SensorType, Humitures = null });
            }
            Modle.GreenHouse house = new Modle.GreenHouse(){ Id = greenhouse.Id, Desc = greenhouse.Desc, Name = greenhouse.Name, Time = greenhouse.Time, Serials = serials };

            var json = JsonHelper.SerializeObject(house);
            session.Send(json);
        }

    }
}
