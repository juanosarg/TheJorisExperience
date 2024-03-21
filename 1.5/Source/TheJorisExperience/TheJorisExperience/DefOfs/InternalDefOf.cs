using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace TheJorisExperience
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static JorisToggleableSpawnDef JE_ToggleableAnimals;




    }
}
