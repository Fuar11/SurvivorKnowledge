using Il2Cpp;
using Il2CppTLD.Gear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivorKnowledge
{
    internal class KnowledgeHelper
    {

        /*public static bool IsClothing(GearItem gearItem)
        {
            if (gearItem == null) return false;
            return gearItem.IsGearType(GearType.Clothing) || gearItem.name == "GEAR_BearSkinBedRoll";
        } */

        public static string getSkillByItem(GearItem item)
        {

            switch (item.name)
            {
                case "GEAR_Bow":
                    return "Archery";
                case "GEAR_Arrow":
                    return "Archery";
                case "GEAR_ArrowHead":
                    return "Archery";
                case "GEAR_ArrowShaft":
                    return "Archery";
                case "GEAR_Bullet":
                    return "Gunsmithing";
                case "GEAR_GunpowderCan":
                    return "Gunsmithing";
                case "GEAR_RevolverAmmoSingle":
                    return "Gunsmithing";
                case "GEAR_OldMansBeardDressing":
                    return "Survival";
                case "GEAR_RosehipsPrepared":
                    return "Survival";
                case "GEAR_ReishiPrepared":
                    return "Survival";
                case "GEAR_BirchbarkPrepared":
                    return "Survival";
                default:
                    return "Default";
            }

        }

        public static int getCurrentSkillLevel(GearItem item)
        {
            string skill = getSkillByItem(item);

            if (skill == "Default") return 1;

            if (skill == "Archery")
            {
                return GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
            }
            else if (skill == "Gunsmithing")
            {
                return GameManager.GetSkillGunsmithing().GetCurrentTierNumber() + 1;
            }
            else if (skill == "Survival")
            {
                return GameManager.GetSkillFireStarting().GetCurrentTierNumber() + 1;
            }
            else
            {
                return 1;
            }

        }

        public static int getRequiredSkillLevel(GearItem item)
        {   
            string name = item.name;
            var settings = Settings.settings;

            if (name.StartsWith("GEAR_Bow")) return settings.BowLevel;

            if (name.StartsWith("GEAR_Arrow") || name.StartsWith("GEAR_ArrowShaft")) return settings.ArrowLevel;

            if (name.StartsWith("GEAR_ArrowHead")) return settings.ArrowheadLevel;

            if (name.StartsWith("GEAR_Bullet")) return settings.BulletLevel;

            if (name.StartsWith("GEAR_GunpowderCan")) return settings.GPLevel;

            if (name.StartsWith("GEAR_RevolverAmmoSingle") || name.StartsWith("GEAR_RifleAmmoSingle")) return settings.RoundLevel;

            if (name.StartsWith("GEAR_OldMansBeardDressing")) return settings.OMBLevel;

            if (name.StartsWith("GEAR_RosehipsPrepared") || name.StartsWith("GEAR_ReishiPrepared")) return settings.TeasLevel;

            if (name.StartsWith("GEAR_BirchbarkPrepared")) return settings.BarkLevel;

            return 0;
        }
    }
}
