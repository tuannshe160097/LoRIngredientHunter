using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_PreciseDrawCut : PassiveAbilityBase
    {
        public static string Desc = "When inflicting Bleed using Combat Pages, double the amount inflicted";

        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (buf.bufType == KeywordBuf.Bleeding)
            {
                return stack;
            }

            return 0;
        }
    }

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
                return 0;
            }

            return stack;
        }

        public override void OnDrawParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
            ResetBufsToOriginal(behavior);
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
            ResetBufsToOriginal(behavior);
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

        private void ResetBufsToOriginal(BattleDiceBehavior behavior)
        {

        }
    }

    public class PassiveAbility_FreshIngredient : PassiveAbilityBase
    {
        public static string Desc = "Enemies does not lose Bleed in a clash with this character";
        

    }
}
