using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{
    public class NeedsCheckTimeCondition : ConditionTask
    {
        public BBParameter<float> checkTime = 4f;

        protected override bool OnCheck()
        {
            checkTime.value -= Time.deltaTime;
            if (checkTime.value <= 0f)
            {
                checkTime.value = 4f;
                return true;
            }
            return false;
        }
    }
}