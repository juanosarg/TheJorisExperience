using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace TheJorisExperience
{
    public class IncidentWorker_JorisResourcePodCrash : IncidentWorker
    {




        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            List<Thing> things = DefDatabase<ThingSetMakerDef>.GetNamed("JE_JorisResourcePod").root.Generate();
            IntVec3 intVec = DropCellFinder.RandomDropSpot(map);
            DropPodUtility.DropThingsNear(intVec, map, things, 110, false, true, true, true);
            base.SendStandardLetter("JE_LetterLabelJorisCargoPodCrash".Translate(), "JE_JorisCargoPodCrash".Translate(), LetterDefOf.PositiveEvent, parms, new TargetInfo(intVec, map, false), Array.Empty<NamedArgument>());
            return true;
        }
    }
}