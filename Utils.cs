using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundMusic
{
    public static class Utils
    {
        public static void Log(string message)
        {
            UnityEngine.Debug.Log($"[{Info.modName}]: {message}");
        }
    }
}
