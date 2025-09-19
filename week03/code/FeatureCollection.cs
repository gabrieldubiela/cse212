public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    // Go inside the features of json
    public Feature[] features { get; set; }
}

public class Feature
{
    // Go inside the properties of the feature
    public Properties properties { get; set; }
}

public class Properties
{
    // get place and mag from the properties
    public string place { get; set; }
    public double mag { get; set; }
}