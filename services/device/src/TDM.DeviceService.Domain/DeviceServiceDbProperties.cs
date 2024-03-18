namespace TDM.DeviceService;

public static class DeviceServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "DeviceService";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "DeviceService";
}
