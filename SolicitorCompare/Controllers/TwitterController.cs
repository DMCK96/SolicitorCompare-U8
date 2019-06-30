using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RestSharp;
using SolicitorCompare.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace SolicitorCompare.Controllers
{
  public class TwitterController : SurfaceController
  {
    public string OAuthConsumerSecret { get; set; }
    public string OAuthConsumerKey { get; set; }

    public IEnumerable<TweetModel> GetTweets(string userName = "solicitorcom", int count = 2)
    {
      IContent settings = Services.ContentService.GetById(1243);

      var accessToken = settings.GetValue<string>("twitterAccessToken");

      if (accessToken == null)
      {
        accessToken = GetAccessToken();
        settings.SetValue("twitterAccessToken", accessToken);
        Services.ContentService.SaveAndPublish(settings);
      }

      RestClient restClient = new RestClient("https://api.twitter.com");
      RestRequest restRequest = new RestRequest("/1.1/statuses/user_timeline.json", Method.GET);
      restRequest.AddHeader("Authorization", "Bearer " + accessToken);
      restRequest.AddParameter("screen_name", (object) userName);
      restRequest.AddParameter(nameof (count), (object) count);
      restRequest.AddParameter("exclude_replies", (object) true);
      return JsonConvert.DeserializeObject<IEnumerable<TweetModel>>(restClient.Execute((IRestRequest) restRequest).Content);
    }

    public string GetAccessToken()
    {
      this.OAuthConsumerKey = "rUb0qogE2QXlYIDD2kWIKWbz3";
      this.OAuthConsumerSecret = "pqJ2THsSJZT2RcBPjaOSDc1QWnM6weWwcjgdfeLmkPBdmHF8dO";
      RestClient restClient = new RestClient("https://api.twitter.com");
      RestRequest restRequest = new RestRequest("/oauth2/token", Method.POST);
      string base64String = Convert.ToBase64String(new UTF8Encoding().GetBytes(this.OAuthConsumerKey + ":" + this.OAuthConsumerSecret));
      restRequest.AddHeader("Authorization", "Basic " + base64String);
      restRequest.AddParameter("grant_type", (object) "client_credentials");

      var response = restClient.Execute(restRequest);

      JObject json = JObject.Parse(response.Content);
      return json.GetValue("access_token").ToString();
    }
  }
}

