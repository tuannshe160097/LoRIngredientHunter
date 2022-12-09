using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_Adaptation : PassiveAbilityBase
    {
        public static string Desc = "Add special Combat Pages to hand depending on certain conditions";

        /* @TODO
            Allies alive => Add card: [On play] kill ally
            Allies dead, has Hunter's Perseverance => Add mass attack: Add a 1-1 dice to this page for each stack of Hunter's Perseverance. [On Hit] Double current bleed
            Allies dead, no Hunter's Perseverance => Add card: [On play] Die after x scenes. Each scene, gain x light, draw x pages, gain x Bloodveil. When inflicting bleed, inflict bleed on all enemies. At the end of the scene, enemies receive damage equal to bleed. On killing an enemy, gain 1 Hunter's Perseverance.
        */
        public override void OnRoundStart()
        {
/*            owner.personalEgoDetail.RemoveCard(01);
            owner.personalEgoDetail.RemoveCard(02);
            owner.personalEgoDetail.RemoveCard(03);

            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count > 0)
            {
                owner.personalEgoDetail.AddCard(01);
            }
            else if (owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_HuntersPerseverance) != null)
            {
                owner.personalEgoDetail.AddCard(02);
            } 
            else
            {
                owner.personalEgoDetail.AddCard(03);
            }*/
        }
    }
}
