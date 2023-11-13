using Bilibili.Community.Service.Dm.V1;
using INetwork;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliNetWork.Providers
{
    public class DanmakuProvider : IDanmakuProvider
    {
        public DanmakuProvider(
            IHttpClientProvider httpClientProvider,
            IRequestMessage requestMessage,
            IBiliDataViewModelConverter biliDataViewModelConverter,
            IBIliDocument bIliDocument
        )
        {
            HttpClientProvider = httpClientProvider;
            RequestMessage = requestMessage;
            BiliDataViewModelConverter = biliDataViewModelConverter;
            BIliDocument = bIliDocument;
        }

        public IHttpClientProvider HttpClientProvider { get; }
        public IRequestMessage RequestMessage { get; }
        public IBiliDataViewModelConverter BiliDataViewModelConverter { get; }
        public IBIliDocument BIliDocument { get; }

        public async Task<IEnumerable<DanmakuSession>> GetVideoDanmakuAsync(
            long aid,
            long cid,
            int segmentIndex,
            CancellationToken canceltoken = default
        )
        {
            DmSegMobileReq req =
                new()
                {
                    Pid = aid,
                    Oid = cid,
                    Type = 1,
                    SegmentIndex = segmentIndex
                };
            var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.BILI_DANMAKU, req);
            var response = await BIliDocument.ParseMessageAsync<DmSegMobileReply>(
                await HttpClientProvider.SendAsync(request),
                DmSegMobileReply.Parser
            );
            return BiliDataViewModelConverter.ConverterDanmaku(response);
        }

        public async Task<string> SendDanmaku(
            string content,
            long aid,
            long cid,
            int type,
            long progress,
            int color,
            DanmakuType danmakuType,
            CancellationToken canceltoken = default
        )
        {
            string dy = (
                danmakuType == DanmakuType.Bottom
                    ? 4
                    : danmakuType == DanmakuType.Top
                        ? 5
                        : danmakuType == DanmakuType.Scrool
                            ? 1
                            : 0
            ).ToString();
            Dictionary<string, string> valueParamters =
                new()
                {
                    { "aid", aid.ToString() },
                    { "type", type.ToString() },
                    { "color", color.ToString() },
                    { "oid", cid.ToString() },
                    { "progress", progress.ToString() },
                    { "fontsize", "25" },
                    { "mode", dy },
                    { "rnd", DateTimeOffset.Now.ToLocalTime().ToUnixTimeMilliseconds().ToString() },
                    { "msg", content }
                };

            var request = await RequestMessage.GetHttpRequestMessageAsync(
                Apis.BILI_SEND_DANMAKU,
                RequestType.IOS,
                HttpMethod.Post,
                valueParamters,
                true,
                false,
                true
            );
            var resultcontent = await HttpClientProvider.SendToStringAsync(request);
            return resultcontent;
        }
    }
}
