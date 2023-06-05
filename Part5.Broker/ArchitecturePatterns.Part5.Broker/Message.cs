using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part5.Broker;
public class Message
{
    public string Content { get; set; }
    public string Topic { get; set; }
}