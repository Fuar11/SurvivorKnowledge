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

        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.CanCraftSelectedBlueprint))]

        class PC_CanCraftBlueprint
        {

            static void Postfix(ref bool __result, Panel_Crafting __instance)
            {
                if (Settings.settings.active == Active.Disabled) return;

                if (__result == false) return;

                GearItem item = __instance.m_SelectedBPI.m_CraftedResult;

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

                if (Settings.settings.active == Active.Disabled) return;

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

        [HarmonyPatch(typeof(Panel_BodyHarvest), nameof(Panel_BodyHarvest.StartHarvest))]

        public class PanelBodyHarvest_StartHarvest
        {

            static bool Prefix(Panel_BodyHarvest __instance)
            {
                if (Settings.settings.active == Active.Disabled) return true;

                var skillLevel = KnowledgeHelper.getHarvestSkillLevel();
                var skillLevelRequired = KnowledgeHelper.getRequiredHarvestingSkillLevel(__instance.m_BodyHarvest.m_LocalizedDisplayName.Text(), "harvest");

                var errorMessage = "Carcass Harvesting level " + skillLevelRequired + " required to harvest.";

                if((__instance.m_MenuItem_Hide.m_HarvestAmount > 0 || __instance.m_MenuItem_Gut.m_HarvestAmount > 0) || (__instance.m_MenuItem_Hide.m_HarvestAmount > 0 && __instance.m_MenuItem_Gut.m_HarvestAmount > 0))
                {
                    if(skillLevel < skillLevelRequired)
                    {
                        __instance.DisplayErrorMessage(errorMessage);
                        GameAudioManager.PlayGUIError();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        [HarmonyPatch(typeof(Panel_BodyHarvest), nameof(Panel_BodyHarvest.StartQuarter))]

        public class PanelBodyHarvest_StartQuarter
        {

            static bool Prefix(Panel_BodyHarvest __instance)
            {
                if (Settings.settings.active == Active.Disabled) return true;

                var skillLevel = KnowledgeHelper.getHarvestSkillLevel();
                var skillLevelRequired = KnowledgeHelper.getRequiredHarvestingSkillLevel(__instance.m_BodyHarvest.m_LocalizedDisplayName.Text(), "quarter");

                var errorMessage = "Carcass Harvesting level " + skillLevelRequired + " required to quarter.";

                    if (skillLevel < skillLevelRequired)
                    {
                        __instance.DisplayErrorMessage(errorMessage);
                        GameAudioManager.PlayGUIError();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
        }


        [HarmonyPatch(typeof(AchievementManager))]
        [HarmonyPatch("CraftedItem")]
        public class PatchCrafteditem
        {
            public static void Prefix(string itemName)
            {
                var xp = KnowledgeHelper.GetXpForCrafting(itemName);
                if (xp > 0)
                {
                    KnowledgeHelper.AddMendingXP(xp);
                }
            }
        }   


    }
}
