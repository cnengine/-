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
    public class ECHO : CommandBase<GreenHouseSession, StringRequestInfo>
    {
        public override void ExecuteCommand(GreenHouseSession session, StringRequestInfo requestInfo)
        {
            DbContent db = new DbContent();
            List<Modle.Humitures> humi = new List<Modle.Humitures>();
            for (int i = 0; i < 2; i++)
            {
                humi.Add(new Modle.Humitures() { Humi = 50, Temp = 50, Time = DateTime.Now });
            }
            List<Modle.Serial> serial = new List<Modle.Serial>();
            serial.Add(new Modle.Serial() { Name = "一号传感器", Desc = "东南上", Sensorid = 1, SensorType = 1, Delay = 5, Humitures = humi });
            serial.Add(new Modle.Serial() { Name = "二号传感器", Desc = "东南下", Sensorid = 2, SensorType = 1, Delay = 5, Humitures = null });
            Modle.GreenHouse house = new Modle.GreenHouse() { Name = "一号实验棚", Time = DateTime.Now, Desc = "测试用", Serials = serial, HumituresDelay=1 };
            db.GreenHouse.Add(house);
            db.SaveChanges();
             




            var json = JsonHelper.SerializeObject("");
            session.Send(json);
        }
    }
}
