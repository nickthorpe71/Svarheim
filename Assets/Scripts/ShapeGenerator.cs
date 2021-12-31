using UnityEngine;
public class ShapeGenerator
{
    ShapeSettings settings;
    NoiseFilter[] noiseFilters;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilters = new NoiseFilter[settings.noiseLayers.Length];
        for (int i = 0; i < noiseFilters.Length; i++)
            noiseFilters[i] = new NoiseFilter(settings.noiseLayers[i].noiseSettings);
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = (noiseFilters.Length > 0) ? noiseFilters[0].Evaluate(pointOnUnitSphere) : 0;
        float elevation = 0;

        for (int i = 0; i < noiseFilters.Length; i++)
        {
            float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 1;
            elevation += (settings.noiseLayers[i].enabled) ? noiseFilters[i].Evaluate(pointOnUnitSphere) : 0;
        }

        return pointOnUnitSphere * settings.planetRadius * (1 + elevation);
    }
}
