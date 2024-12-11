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

                __instance.LoadAddressableBlueprints();

                var blueprints = __instance.m_AddressableBlueprints;
                var moddedBlueprints = __instance.m_AllBlueprints;

                //ensures modded items always remain
                foreach (BlueprintData item in moddedBlueprints)
                {
                    if (!blueprints.Contains(item))
                    {
                        blueprints.Add(item);
                    }
                }

                for (int i = blueprints.Count - 1; i >= 0; i--)
                {

                    if (blueprints[i].m_CraftingResultType == CraftingResult.Decoration) continue;

                    GearItem item = blueprints[i].m_CraftedResultGear;

                    var skillLevel = KnowledgeHelper.getCurrentSkillLevel(item);
                    var requiredSkillLevel = KnowledgeHelper.getRequiredSkillLevel(item);

                    if (skillLevel < requiredSkillLevel)
                    {
                        blueprints.RemoveAt(i);
                    }
                }

                __result = blueprints;
            }


        }

    }
}
