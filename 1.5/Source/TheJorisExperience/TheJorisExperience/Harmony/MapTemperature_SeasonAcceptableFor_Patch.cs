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

    [HarmonyPatch(typeof(MapTemperature))]
    [HarmonyPatch("SeasonAcceptableFor")]
    public static class TheJorisExperience_MapTemperature_SeasonAcceptableFor_Patch
    {
        [HarmonyPostfix]
        public static void AllowAnimalSpawns(ThingDef animalRace, ref bool __result)

        {

           

            if (TheJorisExperience_Mod.settings.pawnSpawnStates != null && TheJorisExperience_Mod.settings.pawnSpawnStates.Keys.Contains(animalRace.defName))
            {
                if (TheJorisExperience_Mod.settings.pawnSpawnStates[animalRace.defName])
                {

                    __result = false;
                }

            }


        }
    }





}
