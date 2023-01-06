using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppTLD.Gear;

namespace SurvivorKnowledge
{
    internal class Patches
    {

        [HarmonyPatch(typeof(BlueprintData), nameof(BlueprintData.CanCraftBlueprint))]

        class BPD_CanCraftBlueprint
        {

            static void Postfix(ref bool __result, BlueprintData __instance)
            {

                if (__result == false) return;

                GearItem item = __instance.m_CraftedResult;

                var skillLevel = KnowledgeHelper.getCurrentSkillLevel(item);
                var requiredSkillLevel = KnowledgeHelper.getRequiredSkillLevel(item);

                if (skillLevel < requiredSkillLevel)
                {
                    __result = false;
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.RefreshSelectedBlueprint))]
        public class PanelCrafting_RefreshSelectedBlueprint
        {
            const float WhiteColorValue = 0.7843137f;
            private static Color WhiteColor = new Color(WhiteColorValue, WhiteColorValue, WhiteColorValue);
            private static Color RedColor = new Color(0.7f, 0f, 0f);

            private static void Postfix(Panel_Crafting __instance)
            {

                __instance.m_SelectedDescription.color = WhiteColor;
                var bpi = __instance.m_SelectedBPI;
                if (!bpi)
                {
                    return;
                }
                if (!bpi.m_CraftedResult)
                {
                    return;
                }


                GearItem item = __instance.m_SelectedBPI.m_CraftedResult;

                var skillLevel = KnowledgeHelper.getCurrentSkillLevel(item);
                var requiredSkillLevel = KnowledgeHelper.getRequiredSkillLevel(item);

                string skill = KnowledgeHelper.getSkillByItem(item);

                if (skill == "Survival") skill = "FIRE STARTING";

                skill = skill.ToUpper();

                if (skillLevel < requiredSkillLevel)
                {
                    __instance.m_SelectedDescription.text = "REQUIRES " + skill + " LEVEL " + requiredSkillLevel;
                    __instance.m_SelectedDescription.color = RedColor;
                }

            }

        }

    }
}
