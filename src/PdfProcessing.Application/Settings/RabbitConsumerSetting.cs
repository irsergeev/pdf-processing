namespace PdfProcessing.Application.Settings;

public class RabbitConsumerSetting
{
    public string HostName { get; init; } = string.Empty;
    public string Port { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password {  get; init; } = string.Empty;
    public string QueueName { get; init; } = string.Empty;
    public string BindingExchange { get; init; } = string.Empty;
    public bool AutoAck { get; init; }
}
