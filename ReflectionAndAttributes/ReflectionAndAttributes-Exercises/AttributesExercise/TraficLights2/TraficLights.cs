
    using System;

public class TraficLights
    {
        public TraficLights(Light light)
        {
            this.TargetLight = light;
        }
        public Light TargetLight { get; set; }

        public void UpdateStatus()
        {
            this.TargetLight = (Light) ((int) ++this.TargetLight % 3);
        }

        public override string ToString()
        {
            return this.TargetLight.ToString();
        }
    }
