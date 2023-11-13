using Bilibili.Broadcast.Message.Main;

namespace ViewConverter.Models.BiliChat;

public class BiliChatBubbleModel
{
    public Bubble Content { get; set; }

    public Bubble UsingList { get; set; }

    public string Title { get; set; }

    public string Ssid { get; set; }
}
