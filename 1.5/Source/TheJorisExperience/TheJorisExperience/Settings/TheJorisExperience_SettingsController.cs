using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace TheJorisExperience
{





    public class TheJorisExperience_Mod : Mod
    {

        public static TheJorisExperience_Settings settings;

        public TheJorisExperience_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<TheJorisExperience_Settings>();
        }
        public override string SettingsCategory() => "The Joris Experience";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);

            JorisToggleableSpawnDef toggleablespawndef = (from k in DefDatabase<JorisToggleableSpawnDef>.AllDefsListForReading
                                                         where k.defName == "JE_ToggleableAnimals"
                                                         select k).RandomElement();


            if (settings.pawnSpawnStates == null) settings.pawnSpawnStates = new Dictionary<string, bool>();
            foreach (string defName in toggleablespawndef.toggleablePawns)
            {
                if (!settings.pawnSpawnStates.ContainsKey(defName))
                {
                    settings.pawnSpawnStates[defName] = false;
                }
            }



            settings.DoWindowContents(inRect);


        }
    }
}
