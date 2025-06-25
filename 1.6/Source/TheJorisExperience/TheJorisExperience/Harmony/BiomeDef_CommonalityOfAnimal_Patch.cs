using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Verse.AI;

namespace TheJorisExperience
{
    /*This Harmony Postfix multiplies commonality of animals in the biome
    */
    [HarmonyPatch(typeof(BiomeDef))]
    [HarmonyPatch("CommonalityOfAnimal")]
    public static class TheJorisExperience_BiomeDef_CommonalityOfAnimal_Patch
    {
        [HarmonyPostfix]
        public static void MultiplyJorisCommonality(PawnKindDef animalDef, ref float __result)

        {

            if (InternalDefOf.JE_ToggleableAnimals.toggleablePawns.Contains(animalDef.defName))
            {
                float TotalMultiplier = TheJorisExperience_Mod.settings.jorisSpawnMultiplier;
                __result *= TotalMultiplier;

            }


        }
    }
}
