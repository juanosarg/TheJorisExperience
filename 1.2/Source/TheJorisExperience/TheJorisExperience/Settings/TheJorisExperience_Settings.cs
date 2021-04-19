using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;


namespace TheJorisExperience
{
    public class TheJorisExperience_Settings : ModSettings

    {
        private static Vector2 scrollPosition = Vector2.zero;
        public Dictionary<string, bool> pawnSpawnStates = new Dictionary<string, bool>();
        public bool flagBiblicallyAccurateJoris = true;
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref flagBiblicallyAccurateJoris, "flagBiblicallyAccurateJoris", true, true);
            Scribe_Collections.Look(ref pawnSpawnStates, "pawnSpawnStates", LookMode.Value, LookMode.Value, ref pawnKeys, ref boolValues);
        }
        private List<string> pawnKeys;
        private List<bool> boolValues;

        public void DoWindowContents(Rect inRect)
        {

            List<string> keys = pawnSpawnStates.Keys.ToList().OrderByDescending(x => x).ToList();
           
            Listing_Standard lscolumn = new Listing_Standard();
            Rect rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect rect2 = new Rect(0f, 40f, inRect.width - 30f, ((keys.Count / 2) + 2) * 24);


           
            Widgets.BeginScrollView(rect, ref scrollPosition, rect2, true);
            lscolumn.ColumnWidth = rect2.width / 2.2f;
            lscolumn.Begin(rect2);
            lscolumn.CheckboxLabeled("JE_AllowBiblicallyAccurateJoris".Translate(), ref flagBiblicallyAccurateJoris, null);

            for (int num = keys.Count - 1; num >= 0; num--)
            {
                if (num == keys.Count / 2 - 1) { lscolumn.NewColumn(); }
                bool test = pawnSpawnStates[keys[num]];
                lscolumn.CheckboxLabeled("JE_DisableAnimal".Translate(PawnKindDef.Named(keys[num]).LabelCap), ref test);
                pawnSpawnStates[keys[num]] = test;
            }

            lscolumn.End();
            Widgets.EndScrollView();
            base.Write();


        }


    }



}

