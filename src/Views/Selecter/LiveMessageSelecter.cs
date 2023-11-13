using Network.Models.Live;
using ViewConverter.Models.Live.Message;
using Views.Models;

namespace Views.Selecter;

public class LiveMessageSelecter : DataTemplateSelector
{
    public DataTemplate DanmakuTemplate { get; set; }

    public DataTemplate UserGoRoomTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is ILiveMessageModel itc && itc == null)
            throw new UIException($"未继承{typeof(ILiveMessageModel).FullName}", container, null);
        if (item as DANMU_MSG != null)
        {
            return DanmakuTemplate;
        }
        else if (item as INTERACT_WORD != null)
        {
            return UserGoRoomTemplate;
        }
        throw new UIException($"未收录的Live Messager类型！", container, null);
    }
}
