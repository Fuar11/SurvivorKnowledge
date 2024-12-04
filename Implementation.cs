using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using ComplexLogger;

namespace SurvivorKnowledge
{
    internal sealed class Implementation : MelonMod
    {
        public static ComplexLogger<Implementation> Logger = new();
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Survivor Knowledge started!");
            Settings.OnLoad();
        }
        
    }
}
