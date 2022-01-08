using UnityEngine;
using Data;

public class ServiceMap : MonoBehaviour
{
    // these could eventually become dictionaries to support multiple apps 
    // on one service map
    [HideInInspector] public AppModel appData;
    [HideInInspector] public App app;

    private ServiceMapBuilder builder;

    // MAIN TODO:
    // - get builder to instantiate game objects (later procedurally)
    //      - ideally instantiate services with language type displayed
    // - get CamNav to go to correct service/endpoint depending on what is clicked
    //      - this includes referenceing all 4 cameras in the CamNav script and moving them
    //        depending on what has been clicked
    // - create UI System to make sure the right labels/buttons are on the UI at the correct time and are linked to the right functions/passing correct params to those functions
    // - all UI should have a way to show more info

    void Start()
    {
        appData = DataManager.InitializeDemoApp();

        // this can be removed once builder is generating game objects
        builder = GetComponent<ServiceMapBuilder>();
        ConstructServiceMap();
    }

    void ConstructServiceMap()
    {
        // Get data from DataManager
        // TODO: will be replaced by a call to backend
        appData = DataManager.InitializeDemoApp();

        // TODO: Builder will build gameObjects in scene using data
        app = builder.BuildApp(appData);

        // TODO: UI Manager
        // instantiate UI pieces for each service / endpoint (try to reuse)
    }
}
