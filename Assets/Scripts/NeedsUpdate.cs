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
        public BBParameter<float> satietySpeedBBP = 0.1f;
        public BBParameter<float> thirstySpeedBBP = 0.1f;
        public BBParameter<float> energySpeedBBP = 0.1f;
        public BBParameter<float> cleanlinessSpeedBBP = 0.1f;

        public void NeedsUpdateFunction()
        {
            float satiety = satietyBBP.value;
            float thirsty = thirstyBBP.value;
            float energy = energyBBP.value;
            float cleanliness = cleanlinessBBP.value;
            if (satiety < 20f)
            {
                // Handle low satiety
            }
            if (thirsty < 20f)
            {
                // Handle low thirst
            }
            if (energy < 20f)
            {
                // Handle low energy
            }
            if (cleanliness < 20f)
            {
                // Handle low cleanliness
            }
        }

        private float UpdateAndConstrain(float need)
        {

            return Mathf.Clamp(need, 0f, 100f);
        }
    }
}