using System.Text.Json.Serialization;

namespace Network.Models.Accounts
{
    public class MyData : MyInfo
    {
        [JsonPropertyName("coin")]
        public double Coin { get; set; }

        [JsonPropertyName("dynamic")]
        public long Dynamics { get; set; }

        /// <summary>
        /// 关注
        /// </summary>
        [JsonPropertyName("following")]
        public long Follows { get; set; }

        /// <summary>
        /// 粉丝
        /// </summary>
        [JsonPropertyName("follower")]
        public long Followers { get; set; }

        /// <summary>
        /// 新关注
        /// </summary>
        [JsonPropertyName("new_followers")]
        public long NewFollower { get; set; }

        [JsonPropertyName("new_followers_rtime")]
        public long NewFollowersTime { get; set; }
    }
}
