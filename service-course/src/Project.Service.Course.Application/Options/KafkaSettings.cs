using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Course.Application.Options
{
    public class KafkaSettings
    {
        public string BootcampServer { get; set; }
        public string GroupId { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public KafkaTopic KafkaTopic { get; set; }
    }

    public class KafkaTopic
    {
        public string UserTopic { get; set; }
        public string UserKey { get; set; }
    }
}
