using Network.Models.Enum;

namespace Network.Models.Live;

public interface ILiveMessageModel
{
    public LiveMessageType MessageType { get; }
}
