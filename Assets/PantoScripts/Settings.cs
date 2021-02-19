using UnityEngine;

namespace DualPantoFramework
{

    public enum SpeedControlStrategy
    {
        MAX_SPEED,
        EXPLORATION,
        LEASH
    }

    public enum Visualization
    {
        DOOM,
        BLIND,
        OUTLINES,
        DOOM_WITH_OUTLINES
    }

    public class Settings : PantoBehaviour
    {
        public bool tetheringEnabled;
        public float tetherFactor;
        public float innerRadius;
        public float outerRadius;
        public bool pockEnabled;
        public IntroContourStrategy introContourOption;
        public SpeedControlStrategy speedControlOption;
        public Visualization visualization;
        void UpdateSettings()
        {
            if (!pantoSync.debug)
            {
                Debug.Log("updating settings");
                pantoSync.SetSpeedControl(tetheringEnabled, tetherFactor, innerRadius, outerRadius, speedControlOption, pockEnabled);
                //SyncSettings(tetherFactor, innerRadius, outerRadius, speedControlOption);
                //GameObject.Find("PantoManager").GetComponent<PantoManager>().SetVisualization(visualization);
            }
        }

        void Start()
        {
            UpdateSettings();
        }
    }
}