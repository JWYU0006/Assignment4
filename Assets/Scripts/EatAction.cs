using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class EatAction : ActionTask
    {
        public BBParameter<float> satietyBBP;

        protected override void OnUpdate()
        {
            if (satietyBBP.value >= 80f) EndAction(true);
            else satietyBBP.value += Time.deltaTime * 20f;
        }
    }
}