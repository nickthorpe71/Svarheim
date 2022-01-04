using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;

    private GameObject planet;

    void Start()
    {
        GameObject planet = new GameObject("planet");
        planet.transform.position = Vector3.zero;

        planet.AddComponent<Planet>();
        Planet planetComponenet = planet.GetComponent<Planet>();
        planetComponenet.resolution = 256;
        planetComponenet.shapeSettings = shapeSettings;
        planetComponenet.colorSettings = colorSettings;
        planetComponenet.GeneratePlanet();
    }
}
