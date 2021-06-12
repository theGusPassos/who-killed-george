using UnityEngine;

namespace Assets.Scripts.Lights
{
    public class LightAnimation : MonoBehaviour
    {
        Light[] lights;

        private float currentIntensity;
        private float timer;

        private float originalCurrent;
        private float originalTarget;

        [SerializeField] private float timeToLerp;
        [SerializeField] private float targetIntensity;
        [SerializeField] private float timeToWaitAfterCycle;
        [SerializeField] float randFactor;

        float timeWaiting;

        private void Awake()
        {
            lights = GetComponentsInChildren<Light>();
            currentIntensity = originalCurrent = lights[0].intensity;
            originalTarget = targetIntensity;
        }

        private void Update()
        {
            if (timeWaiting < timeToWaitAfterCycle)
            {
                timeWaiting += Time.deltaTime;
                return;
            }

            timer += Time.deltaTime;

            var value = Mathf.Lerp(currentIntensity, targetIntensity, timer / timeToLerp);

            foreach (var light in lights)
                light.intensity = value;

            if (lights[0].intensity == targetIntensity)
            {
                targetIntensity = lights[0].intensity == originalTarget ? originalCurrent : originalTarget;

                if (targetIntensity == originalTarget)
                    timeWaiting = -Random.Range(0, randFactor);

                currentIntensity = lights[0].intensity;
                timer = 0;
            }
        }
    }
}
