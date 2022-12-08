using LOR_DiceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_ScarletDevotion : PassiveAbilityBase
    {
        public static string Desc = "[On Hit] and [On Clash Win] effects relating to bleed will be triggered regardless of clash result. Cannot inflict any status ailment on enemies other than Bleed. Enemies does not receive Stagger Damage from clashes with this character";

        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                breakRate = -999,
            });
        }

        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (target.faction != owner.faction && buf.bufType != KeywordBuf.Bleeding)
            {
                return -stack;
            }

            return 0;
        }

        public override void OnDrawParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
        }

        private void ApplyBleedRegardless(BattleDiceBehavior behavior)
        {
            foreach (var ability in behavior.abilityList)
            {
                if (ability.Keywords.Contains("Bleeding_Keyword"))
                {
                    if (IsAttackDice(behavior))
                    {
                        ability.OnWinParrying();
                        ability.OnSucceedAttack();
                        ability.OnSucceedAttack(behavior.card.target);
                    }
                    else
                    {
                        ability.OnWinParryingDefense();
                    }
                }
            }
        }

        private bool IsAttackDice(BattleDiceBehavior behavior)
        {
            return behavior.Detail == LOR_DiceSystem.BehaviourDetail.Slash || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Penetrate || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Hit;
        }
    }
}
