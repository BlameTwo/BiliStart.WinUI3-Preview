using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Network.Models.Services
{
    public class LotteryResultMode
    {
        [JsonPropertyName("business_id")]
        public long BusinessId { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("lottery_time")]
        public int LotteryTime { get; set; }

        [JsonPropertyName("lottery_at_num")]
        public int LotteryAtNum { get; set; }

        [JsonPropertyName("lottery_feed_limit")]
        public int LotteryFeedLimit { get; set; }

        [JsonPropertyName("first_prize")]
        public int FirstPrize { get; set; }

        [JsonPropertyName("second_prize")]
        public int SecondPrize { get; set; }

        [JsonPropertyName("third_prize")]
        public int ThirdPrize { get; set; }

        [JsonPropertyName("first_prize_cmt")]
        public string FirstPrizeCmt { get; set; }

        [JsonPropertyName("second_prize_cmt")]
        public string SecondPrizeCmt { get; set; }

        [JsonPropertyName("third_prize_cmt")]
        public string ThirdPrizeCmt { get; set; }

        [JsonPropertyName("first_prize_pic")]
        public string FirstPrizePic { get; set; }

        [JsonPropertyName("second_prize_pic")]
        public string SecondPrizePic { get; set; }

        [JsonPropertyName("third_prize_pic")]
        public string ThirdPrizePic { get; set; }

        [JsonPropertyName("need_post")]
        public int NeedPost { get; set; }

        [JsonPropertyName("business_type")]
        public int BusinessType { get; set; }

        [JsonPropertyName("sender_uid")]
        public long SenderUid { get; set; }

        [JsonPropertyName("prize_type_first")]
        public PrizeTypeFirst PrizeTypeFirst { get; set; }

        [JsonPropertyName("prize_type_second")]
        public PrizeTypeSecond PrizeTypeSecond { get; set; }

        [JsonPropertyName("prize_type_third")]
        public PrizeTypeThird PrizeTypeThird { get; set; }

        [JsonPropertyName("pay_status")]
        public int PayStatus { get; set; }

        [JsonPropertyName("ts")]
        public int Ts { get; set; }

        [JsonPropertyName("lottery_id")]
        public int LotteryId { get; set; }

        [JsonPropertyName("_gt_")]
        public int Gt { get; set; }
    }

    public class PrizeTypeFirst
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("value")]
        public Value Value { get; set; }
    }

    public class PrizeTypeSecond
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("value")]
        public Value Value { get; set; }
    }

    public class PrizeTypeThird
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("value")]
        public Value Value { get; set; }
    }


    public class Value
    {
        [JsonPropertyName("stype")]
        public int Stype { get; set; }
    }


}
