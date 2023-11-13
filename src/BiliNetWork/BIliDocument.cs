using LanguageExt;

namespace BiliNetWork
{
    public sealed class BIliDocument : IBIliDocument
    {
        public async Task<T> JsonDeserializeAsync<T>(
            string json,
            JsonSerializerOptions options = null,
            CancellationToken cancelltoken = default
        )
            where T : class
        {
            try
            {
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

                using (MemoryStream stream = new MemoryStream(jsonBytes))
                {
                    return await JsonSerializer.DeserializeAsync<T>(stream)!;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<string> JsonSerializeAsync<T>(
            T value,
            JsonSerializerOptions options = null,
            CancellationToken cancelltoken = default
        )
            where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, value);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public async Task<ResultCode<T>> CheckDataCode<T>(
            HttpRequestMessage Message,
            HttpResponseMessage Responsemessage
        )
            where T : class
        {
            var result = await CheckDataCodeOption<T>(Message, Responsemessage);
            return result.Match(
                Some: val =>
                {
                    return val;
                },
                None: () => null
            );
        }

        async Task<Option<ResultCode<T>>> CheckDataCodeOption<T>(
            HttpRequestMessage Message,
            HttpResponseMessage Responsemessage
        )
            where T : class
        {
            try
            {
                if(Responsemessage==null)
                    return Option<ResultCode<T>>.None;
                var result = await Responsemessage.Content.ReadAsStringAsync();
                if (result == null || result.Length == 0)
                    return Option<ResultCode<T>>.None;
                var obj = await this.JsonDeserializeAsync<ResultCode<T>>(result);
                if (obj.Code != 0)
                    return Option<ResultCode<T>>.None;
                return obj;
            }
            catch (Exception)
            {
                return Option<ResultCode<T>>.None;
            }
        }

        public async Task<ResultData<T>> CheckDataResult<T>(
            HttpRequestMessage Message,
            HttpResponseMessage Responsemessage
        )
            where T : class
        {
            var result = await CheckDataResultOption<T>(Message, Responsemessage);
            return result.Match(
                Some: val =>
                {
                    return val;
                },
                None: () => null
            );
        }

        async Task<Option<ResultData<T>>> CheckDataResultOption<T>(
            HttpRequestMessage Message,
            HttpResponseMessage Responsemessage
        )
            where T : class
        {
            try
            {
                var result = await Responsemessage.Content.ReadAsStringAsync();
                var obj = await this.JsonDeserializeAsync<ResultData<T>>(result);
                if (obj.Code != 0)
                    return Option<ResultData<T>>.None;
                return obj;
            }
            catch (Exception)
            {
                return Option<ResultData<T>>.None;
            }
        }

        public async Task<T> ParseMessageAsync<T>(
            HttpResponseMessage response,
            MessageParser<T> parser
        )
            where T : IMessage<T>
        {
            var result = ParseMessageOptionAsync<T>(response, parser);
            if (result == null) return default;
            return await result.Match(
                Some: val =>
                {
                    return val;
                },
                None: () => default
            );
        }



        public async Task<Option<T>> ParseMessageOptionAsync<T>(
            HttpResponseMessage response,
            MessageParser<T> parser
        )
            where T : IMessage<T>
        {
            if (response == null)
                return Option<T>.None;
            //读取返回的byte
            var bytes = await response.Content.ReadAsByteArrayAsync();
            
            if (bytes.Length < 5)
                return Option<T>.None;
            // 使用grpc生成类对比特进行转换并跳过前五位（必须跳过）
            return parser.ParseFrom(bytes.Skip(5).ToArray());
        }

    }
}
