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

        [Name("Level required for crafting the survival bow")]
        [Description("Archery experience level required for crafting the survival bow.")]
        [Slider(1, 5)]
        public int BowLevel = 3;

        [Name("Level required for crafting arrow equipment")]
        [Description("Archery experience level required for crafting simple arrows and arrow shafts.")]
        [Slider(1, 5)]
        public int ArrowLevel = 2;

        [Name("Level required for forging arrowheads")]
        [Description("Archery experience level required for forging arrowheads.")]
        [Slider(1, 5)]
        public int ArrowheadLevel = 3;

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
        [Description("Firestarting experience level required for crafting prepared birch bark.")]
        [Slider(1, 5)]
        public int BarkLevel = 3;

        [Name("Level required for preparing rosehips and mushrooms")]
        [Description("Firestarting experience level required for crafting prepared rosehips and reishi mushrooms for cooking.")]
        [Slider(1, 5)]
        public int TeasLevel = 2;

        [Name("Level required for crafting with old man's beard")]
        [Description("Firestarting experience level required for crafting old man's beard wound dressing.")]
        [Slider(1, 5)]
        public int OMBLevel = 3;

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

            SetFieldVisible(nameof(GPLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(BarkLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(TeasLevel), Settings.settings.active != Active.Disabled);

            SetFieldVisible(nameof(OMBLevel), Settings.settings.active != Active.Disabled);

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
