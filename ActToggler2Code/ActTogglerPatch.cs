using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Random;

namespace ActToggler2.ActToggler2Code;

[HarmonyPatch(typeof(ActModel), nameof(ActModel.GetRandomList))]
[HarmonyPriority(Priority.Last)]
public class ActTogglerPatch
{
    public static void Finalizer(ref IEnumerable<ActModel> __result, Rng rng)
    {
        var list = __result.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            var slot = i + 1;
            if (slot > 3) break;
            list[i] = ActTogglerConfig.GetWeightedAct(slot, rng);
        }
        __result = list;
    }
}