using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gear;

namespace SurvivorKnowledge.Patches
{
    internal class BlueprintPatches
    {

        [HarmonyPatch(typeof(BlueprintManager), nameof(BlueprintManager.GetAllBlueprints))]

        public class RemoveVanillaBlueprints
        {
            public static void Postfix(ref Il2CppSystem.Collections.Generic.List<BlueprintData> __result, BlueprintManager __instance)
            {

                //i probably don't even need to call this
                __instance.LoadAddressableBlueprints();

                var tempList = __instance.m_AddressableBlueprints;

                for (int i = tempList.Count - 1; i >= 0; i--)
                {

                    if (tempList[i].m_CraftingResultType == CraftingResult.Decoration) continue;

                    GearItem item = tempList[i].m_CraftedResultGear;

                    var skillLevel = KnowledgeHelper.getCurrentSkillLevel(item);
                    var requiredSkillLevel = KnowledgeHelper.getRequiredSkillLevel(item);

                    if (skillLevel < requiredSkillLevel)
                    {
                        tempList.RemoveAt(i);
                    }
                }

                __result = tempList;
            }


        }

    }
}
