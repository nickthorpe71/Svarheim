using UnityEngine;
using Data;

public class ServiceMap : MonoBehaviour
{
    // these could eventually become dictionaries to support multiple apps 
    // on one service map
    [HideInInspector] public AppModel appData;
    [HideInInspector] public App app;

    private Builder builder;

    void Start()
    {
        appData = DataManager.InitializeDemoApp();

        // this can be removed once builder is generating game objects
        builder = GetComponent<Builder>();
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
