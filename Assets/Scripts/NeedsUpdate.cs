using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class NeedsUpdate : ActionTask
    {
        public BBParameter<float> satietyBBP = 100f;
        public BBParameter<float> thirstyBBP = 100f;
        public BBParameter<float> energyBBP = 100f;
        public BBParameter<float> cleanlinessBBP = 100f;
        public BBParameter<float> satietySpeedBBP = 4f;
        public BBParameter<float> thirstySpeedBBP = 2f;
        public BBParameter<float> energySpeedBBP = 1f;
        public BBParameter<float> cleanlinessSpeedBBP = 4f;

        protected override void OnUpdate()
        {
            NeedsUpdateFunction();
        }

        public void NeedsUpdateFunction()
        {
            float satiety = satietyBBP.value;
            float thirsty = thirstyBBP.value;
            float energy = energyBBP.value;
            float cleanliness = cleanlinessBBP.value;

            satiety = UpdateAndConstrain(satiety, "satiety");
            satietyBBP.value = satiety;
            thirsty = UpdateAndConstrain(thirsty, "thirsty");
            thirstyBBP.value = thirsty;
            energy = UpdateAndConstrain(energy, "energy");
            energyBBP.value = energy;
            cleanliness = UpdateAndConstrain(cleanliness, "cleanliness");
            cleanlinessBBP.value = cleanliness;
        }

        private float UpdateAndConstrain(float need, string needName)
        {
            if (needName == "satiety")
                need -= satietySpeedBBP.value * Time.deltaTime;
            else if (needName == "thirsty")
                need -= thirstySpeedBBP.value * Time.deltaTime;
            else if (needName == "energy")
                need -= energySpeedBBP.value * Time.deltaTime;
            else if (needName == "cleanliness")
                need -= cleanlinessSpeedBBP.value * Time.deltaTime;

            return Mathf.Clamp(need, 0f, 100f);
        }
    }
}