using Newtonsoft.Json;
using System;

namespace SolicitorCompare.Models
{
  public class TweetModel
  {
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    public DateTime DateTweeted { get; set; }

    [JsonProperty("created_at")]
    public string DateTweetedString { get; set; }
  }
}
