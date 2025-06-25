
using System.Collections.Generic;
using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace TheJorisExperience
{

    public class ThingSetMaker_JorisResourcePod : ThingSetMaker
    {
        protected override void Generate(ThingSetMakerParams parms, List<Thing> outThings)
        {
            List<PawnKindDef> list = new List<PawnKindDef>();
            List<PawnKindDef> allDefsListForReading = DefDatabase<PawnKindDef>.AllDefsListForReading;
            for (int i = 0; i < allDefsListForReading.Count; i++)
            {
                PawnKindDef pawnKindDef = allDefsListForReading[i];
                bool flag = pawnKindDef.race.race.Animal && pawnKindDef.RaceProps.IsFlesh && (pawnKindDef.defName.Contains("JE_")|| pawnKindDef.defName.Contains("JECom_"));
                if (flag)
                {
                    list.Add(pawnKindDef);
                }
            }
            PawnGenerationRequest request = new PawnGenerationRequest(list.RandomElement<PawnKindDef>(), null, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true);
            Pawn pawn = PawnGenerator.GeneratePawn(request);
            outThings.Add(pawn);
          
        }

        protected override IEnumerable<ThingDef> AllGeneratableThingsDebugSub(ThingSetMakerParams parms)
        {
            yield return PawnKindDefOf.SpaceRefugee.race;
            yield break;
        }

    }
}

