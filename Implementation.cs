using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace SurvivorKnowledge
{
    internal sealed class Implementation : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("SurvivorKnowledge started!");
            Settings.OnLoad();
        }
        
    }
}
