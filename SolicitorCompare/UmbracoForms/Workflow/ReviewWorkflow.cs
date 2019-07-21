using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace SolicitorCompare.UmbracoForms.Workflow
{
  public class ReviewWorkflow : WorkflowType
  {
    private readonly IContentService _contentService;

    public ReviewWorkflow(IContentService contentService)
    {
      this.Id = new Guid("ccbeb0d5-adaa-4729-8b4c-4bb439dc0202");
      this.Name = "ReviewWorkflow";
      this.Icon = "icon-rate";

      _contentService = contentService;
    }
    public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
    {
      var starRating = 0;
      var solicitor = "";
      var customerName = "";
      var comment = "";
      var date = record.Created;

      //Iterate through the fields and assign variables based on alias.
      foreach (RecordField rf in record.RecordFields.Values)
      {
        if (rf.Alias == "starRating")
        {
          starRating = Int32.Parse(rf.ValuesAsString());
        }

        if (rf.Alias == "solicitor")
        {
          solicitor = rf.ValuesAsString();
        }

        if (rf.Alias == "name")
        {
          customerName = rf.ValuesAsString();
        }

        if (rf.Alias == "comment")
        {
          comment = rf.ValuesAsString();
        }
      }

      var solicitorNode = _contentService.GetById(Int32.Parse(solicitor));

      //has to be a <string> as we wish to get the JSON value and not the IPublishedElement
      var property = solicitorNode.GetValue<string>("listOfReviews");

      //Create the list as a fallback.
      List<Dictionary<string, object>> reviews = new List<Dictionary<string, object>>();

      //if property is null and deserialize is attempted the workflow will return success but wont actually complete the workflow.
      if (property != null)
      {
        //if property is not null we can overwrite the fallback list.
        reviews = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(property);
      }

      // Each entry requires a unique GUID, generate here.
      var key = Guid.NewGuid().ToString();

      //Adds a new entry to the nested content, name always set to 'Daniel Mckibbin' due to same name as original Admin account.
      reviews.Add(new Dictionary<string, object>() {
        {
          "key",
          key
        },
        {
          "name",
          "Daniel Mckibbin"
        },
        {
          "ncContentTypeAlias",
          "review"
        },
        {
          "customerName",
          customerName
        },
        {
          "rating",
          starRating
        },
        {
          "date",
          date
        },
        {
          "comment",
          comment
        }
      });

      var ratings = new List<int>();

      //add the current starRating as it will not be in the node when you getValue.
      ratings.Add(starRating);
      foreach (var entry in reviews)
      {
        ratings.Add(Int32.Parse(entry["rating"].ToString()));
      }

      var avgRating = ratings.Average();

      solicitorNode.SetValue("listOfReviews", JsonConvert.SerializeObject(reviews));
      solicitorNode.SetValue("rating", avgRating);

      try
      {
        _contentService.SaveAndPublish(solicitorNode);
      }
      catch (Exception ex)
      {
        var bp = true;
      }

      return WorkflowExecutionStatus.Completed;
    }

    public override List<Exception> ValidateSettings()
    {
      return new List<Exception>();
    }
  }
}

