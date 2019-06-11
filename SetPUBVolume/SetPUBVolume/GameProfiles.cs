using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetPUBVolume
{
    class GameProfiles
    {
        public IDictionary<string, GameProfile> profiles { get; set; }
    }

    class GameProfile
    {
        public int shortcutIndex { get; set; }
        public string volumeAValue { get; set; }
        public string volumeBValue { get; set; }
    }
}
