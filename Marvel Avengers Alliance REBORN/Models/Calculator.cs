using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    class Calculator
    {
        Random rand;
        protected ArrayList StateObserver;
        protected ArrayList BarObserver;

        public Calculator()
        {
            rand = new Random();
            StateObserver = new ArrayList();
            BarObserver = new ArrayList();
        }

        public void NotifyAll()
        {
            foreach (BattleState state in StateObserver)
            {
                state.Notify(this);
            }
            foreach (StatusBar component in BarObserver)
            {
                component.Notify(this);
            }
        }

        public void AttachStateObserver(BattleState game)
        {
            StateObserver.Add(game);
        }

        public void AttachBarObserver(StatusBar bar)
        {
            BarObserver.Add(bar);
        }

        public void HeathCalculate(Character subject, List<Character> objects)
        {
            foreach(var target in objects)
            {
                int total_damage = rand.Next(subject.cur_skill.Get_Damage()[0], subject.cur_skill.Get_Damage()[1]) + subject.Get_Attack() - target.Get_Defense();

                if (total_damage < 0) total_damage = 0;

                target.Set_Health(target.Get_Health() - total_damage);

                target._hp_bar.Set_Value(target.Get_Health());
            }
            NotifyAll();
        }

        public void StaminaCalculate(Character actor)
        {
            int stamina_cost = (actor.cur_skill.Get_StaminaCost() * actor.Get_Max_Stamina()) / 100;

            actor.Set_Stamina(actor.Get_Stamina() - stamina_cost);

            actor._sp_bar.Set_Value(actor.Get_Stamina());

            NotifyAll();
        }
    }
}
