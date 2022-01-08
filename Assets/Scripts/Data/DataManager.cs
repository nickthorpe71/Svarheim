namespace Data
{
    public static class DataManager
    {
        public static AppModel InitializeDemoApp()
        {
            EndpointModel[] service1Endpoints = new EndpointModel[]{
                new EndpointModel("S1-Endpoint1", 1)
            };

            EndpointModel[] service2Endpoints = new EndpointModel[]{
                new EndpointModel("S2-Endpoint1", 1),
                new EndpointModel("S2-Endpoint2", 2)
            };

            EndpointModel[] service3Endpoints = new EndpointModel[]{
                new EndpointModel("S3-Endpoint1", 1),
                new EndpointModel("S3-Endpoint2", 2),
                new EndpointModel("S3-Endpoint3", 3)
            };

            ServiceModel service1 = new ServiceModel("Service1", "python", new ServiceModel[1], service1Endpoints);
            ServiceModel service2 = new ServiceModel("Service2", "java", new ServiceModel[2], service2Endpoints);
            ServiceModel service3 = new ServiceModel("Service3", "postgres", new ServiceModel[1], service3Endpoints);

            ServiceModel[] service1Dependencies = new ServiceModel[] { service2 };
            ServiceModel[] service2Dependencies = new ServiceModel[] { service1, service3 };
            ServiceModel[] service3Dependencies = new ServiceModel[] { service2 };

            service1 = new ServiceModel(service1.Name, service1.ServiceLanguage, service1Dependencies, service1.Endpoints);
            service2 = new ServiceModel(service2.Name, service2.ServiceLanguage, service2Dependencies, service2.Endpoints);
            service3 = new ServiceModel(service3.Name, service3.ServiceLanguage, service3Dependencies, service3.Endpoints);

            return new AppModel("App1", new ServiceModel[] { service1, service2, service3 });
        }
    }
}
