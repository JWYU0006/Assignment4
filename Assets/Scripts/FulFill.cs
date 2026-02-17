using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class FulFill : ActionTask
    {
        public BBParameter<float> satietyBBP;
        public BBParameter<float> thirstyBBP;
        public BBParameter<float> energyBBP;
        public BBParameter<float> cleanlinessBBP;
        public BBParameter<int> actionIndexBBP;

        protected override void OnUpdate()
        {
            if (actionIndexBBP.value == 1) FulFillSatiety();
            else if (actionIndexBBP.value == 2) FulFillThirsty();
            else if (actionIndexBBP.value == 3) FulFillEnergy();
            else if (actionIndexBBP.value == 4) FulFillCleanliness();
        }

        protected override void OnStop()
        {
            actionIndexBBP.value = 0;
        }

        private void FulFillSatiety()
        {
            if (satietyBBP.value >= 80f) EndAction(true);
            else satietyBBP.value += Time.deltaTime * 20f;
        }
        private void FulFillThirsty()
        {
            if (thirstyBBP.value >= 80f) EndAction(true);
            else thirstyBBP.value += Time.deltaTime * 20f;
        }
        private void FulFillEnergy()
        {
            if (energyBBP.value >= 80f) EndAction(true);
            else energyBBP.value += Time.deltaTime * 5f;
        }
        private void FulFillCleanliness()
        {
            if (cleanlinessBBP.value >= 80f) EndAction(true);
            else cleanlinessBBP.value += Time.deltaTime * 10f;
        }
    }
}