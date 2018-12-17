using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modle
{
    public class Humitures
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public float Humi { get; set; }
        public float Temp { get; set; }

    }
    public class Serial
    {
        public int Id { get; set; }
        public virtual ICollection<Humitures> Humitures { get; set; }
        public int Sensorid { get; set; }
        public int SensorType { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Delay { get; set; }

    }
    public class GreenHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime Time { get; set; }
        public int HumituresDelay { get; set; }
        public virtual ICollection<Serial> Serials { get; set; }
        public Control Control { get; set; } = new Control();

    }
    public class Control
    {
        public int Id { get; set; }
        public bool QuiltUp { get; set; } = false;
        public bool QuiltDown { get; set; } = false;
        public bool Penstock { get; set; } = false;
        public bool Lighting { get; set; } = false;
        public bool Dehumidi { get; set; } = false;
        public bool Door { get; set; } = false;
    }
}
