namespace Bussiness.Helpers;

public static class UniqIdGenerator
{
    // Generate a unique id based on GUID and split it by '-'
    public static string Generate()
    {
        return Guid.NewGuid().ToString().Split('-')[0];
    }
}
