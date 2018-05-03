using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using BattleTech;
using System.Reflection;

namespace BTMLVersionMod
{
    [HarmonyPatch(typeof(VersionInfo), "GetReleaseVersion")]
    public static class VersionInfo_GetReleaseVersion_Patch
    {
        static void Postfix(ref string __result)
        {
            string old = __result;
            __result = old + " w/ BTML";
        }
    }

    public static class VersionMod
    {
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.BTMLVersionMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
