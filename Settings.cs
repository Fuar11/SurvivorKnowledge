using ModSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using System.Reflection;


namespace SurvivorKnowledge
{
    public enum Active
    {
        Disabled, Enabled
    }
    internal class CustomSettings : JsonModSettings
    {

        [Section("Mod Options")]

        [Name("Mod Active")]
        [Description("Enable or Disable this mod")]
        [Choice("Disabled", "Enabled")]
        public Active active = Active.Enabled;

        [Section("Crafting")]

        [Name("Level required for crafting the survival bow")]
        [Description("Archery experience level required for crafting the survival bow.")]
        [Slider(1, 5)]
        public int BowLevel = 3;

        [Name("Level required for crafting arrow equipment")]
        [Description("Archery experience level required for crafting simple arrows and arrow shafts.")]
        [Slider(1, 5)]
        public int ArrowLevel = 2;

        [Name("Level required for crafting fire-hardened arrows")]
        [Description("Archery experience level required for crafting fire-hardened arrows.")]
        [Slider(1, 5)]
        public int FireArrowLevel = 1;

        [Name("Level required for forging arrowheads")]
        [Description("Archery experience level required for forging arrowheads.")]
        [Slider(1, 5)]
        public int ArrowheadLevel = 3;

        [Name("Level required for crafting fishing gear")]
        [Description("Fishing experience level required for crafting fishing tackles, simple lures and line.")]
        [Slider(1, 5)]
        public int SimpleFishingLevel = 1;

        [Name("Level required for crafting fishing lures")]
        [Description("Fishing experience level required for crafting complex fishing lures")]
        [Slider(1, 5)]
        public int AdvancedFishingLevel = 2;

        [Name("Level required for crafting fishing tipups")]
        [Description("Fishing experience level required for crafting fishing tipups")]
        [Slider(1, 5)]
        public int TipUpLevel = 3;

        [Name("Level required for forging bullets")]
        [Description("Gunsmithing experience level required for forging bullets out of scrap lead.")]
        [Slider(1, 5)]
        public int BulletLevel = 3;

        [Name("Level required for crafting rounds of ammunition")]
        [Description("Gunsmithing experience level required for pressing rifle and revolver cartridges.")]
        [Slider(1, 5)]
        public int RoundLevel = 2;

        [Name("Level required for crafting gunpowder")]
        [Description("Gunsmithing experience level required for creating cans of gunpoweder.")]
        [Slider(1, 5)]
        public int GPLevel = 2;

        [Name("Level required for preparing birch bark")]
        [Description("Cooking experience level required for crafting prepared birch bark.")]
        [Slider(1, 5)]
        public int BarkLevel = 3;

        [Name("Level required for preparing rosehips and mushrooms")]
        [Description("Cooking experience level required for crafting prepared rosehips and reishi mushrooms for cooking.")]
        [Slider(1, 5)]
        public int TeasLevel = 2;

        [Name("Level required for crafting with old man's beard")]
        [Description("Firestarting experience level required for crafting old man's beard wound dressing.")]
        [Slider(1, 5)]
        public int OMBLevel = 3;

        [Section("Better Mending XP")]

        [Name("Crafting bandages sometimes give XP")]
        [Description("Crafting bandages have a 33% chance of giving mending experience.")]
        public bool CraftingBandagesGivesXP = true;

        [Name("Level required for crafting Rabbit Skin items")]
        [Description("Mending experience level required for crafting Rabbit Skin items")]
        [Slider(1, 5)]
        public int RabbitCraftLevel = 1;

        [Name("Level required for crafting Deer Skin items")]
        [Description("Mending experience level required for crafting Deer Skin items")]
        [Slider(1, 5)]
        public int DeerCraftLevel = 2;

        [Name("Level required for crafting Wolfskin items")]
        [Description("Mending experience level required for crafting Wolfskin items")]
        [Slider(1, 5)]
        public int WolfCraftLevel = 4;

        [Name("Level required for crafting Bearskin items")]
        [Description("Mending experience level required for crafting Bearskin items")]
        [Slider(1, 5)]
        public int BearCraftLevel = 5;

        [Name("Level required for crafting Moose Hide items")]
        [Description("Mending experience level required for crafting Moose Hide items")]
        [Slider(1, 5)]
        public int MooseCraftLevel = 4;

        [Name("XP for crafting Improvised Clothing items")]
        [Description("Mending experience points for crafting Improvised Clothing items")]
        [Slider(0, 10)]
        public int ImprovisedXp = 1;

        [Name("XP for crafting Rabbit Skin items")]
        [Description("Mending experience points for crafting Rabbit Skin items")]
        [Slider(0, 10)]
        public int RabbitXp = 3;

        [Name("XP for crafting Deer Hide items")]
        [Description("Mending experience points for crafting Deer Hide items")]
        [Slider(0, 10)]
        public int DeerXp = 4;

        [Name("XP for crafting Wolfskin items")]
        [Description("Mending experience points for crafting Wolfskin items")]
        [Slider(0, 10)]
        public int WolfXp = 5;

        [Name("XP for crafting Bearskin items")]
        [Description("Mending experience points for crafting Bearskin items")]
        [Slider(0, 10)]
        public int BearXp = 7;

        [Name("XP for crafting Moose Hide items")]
        [Description("Mending experience points for crafting Moose Hide items")]
        [Slider(0, 10)]
        public int MooseXp = 8;

        [Section("Harvesting")]

        [Name("Level required for harvesting small game")]
        [Description("Carcass harvesting experience level required for harvesting rabbit hide & guts & ptarmigan down.")]
        [Slider(1, 5)]
        public int SmallGameLevel = 2;

        [Name("Level required for harvesting wolves")]
        [Description("Carcass harvesting experience level required for harvesting wolf hide & guts.")]
        [Slider(1, 5)]
        public int WolfLevel = 3;

        [Name("Level required for harvesting deer")]
        [Description("Carcass harvesting experience level required for harvesting deer hide & guts.")]
        [Slider(1, 5)]
        public int DeerLevel = 3;

        [Name("Level required for harvesting bears")]
        [Description("Carcass harvesting experience level required for harvesting bear hide & guts.")]
        [Slider(1, 5)]
        public int BearLevel = 4;

        [Name("Level required for harvesting moose")]
        [Description("Carcass harvesting experience level required for harvesting moose hide & guts.")]
        [Slider(1, 5)]
        public int MooseLevel = 5;

        [Section("Quartering")]

        [Name("Level required for quartering wolves")]
        [Description("Carcass harvesting experience level required for quarting wolves")]
        [Slider(1, 5)]
        public int WolfQuarterLevel = 3;

        [Name("Level required for quartering deer")]
        [Description("Carcass harvesting experience level required for quartering deer")]
        [Slider(1, 5)]
        public int DeerQuarterLevel = 4;

        [Name("Level required for quartering bears")]
        [Description("Carcass harvesting experience level required for quartering bears")]
        [Slider(1, 5)]
        public int BearQuarterLevel = 4;

        [Name("Level required for quartering moose")]
        [Description("Carcass harvesting experience level required for quartering moose")]
        [Slider(1, 5)]
        public int MooseQuarterLevel = 5;
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(active))
            {
                RefreshSections();
            }
        }

        internal void RefreshSections()
        {

            SetFieldVisible(nameof(BowLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(ArrowLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(ArrowheadLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(BulletLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(RoundLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(SimpleFishingLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(AdvancedFishingLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(TipUpLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(GPLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(BarkLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(TeasLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(OMBLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(SmallGameLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(WolfLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(DeerLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(BearLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(MooseLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(WolfQuarterLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(DeerQuarterLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(BearQuarterLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(MooseQuarterLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(FireArrowLevel), Settings.settings.active != Active.Disabled);

        }

    }

    static class Settings
    {
        internal static CustomSettings settings;
        internal static void OnLoad()
        {
            settings = new CustomSettings();
            settings.AddToModSettings("Survivor Knowledge");
            settings.RefreshSections();

        }
    }
}
