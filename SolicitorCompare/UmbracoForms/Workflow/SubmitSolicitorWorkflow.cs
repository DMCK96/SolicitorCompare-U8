using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Serilog.Core;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;
using File = System.IO.File;

namespace SolicitorCompare.UmbracoForms.Workflow
{
  public class SubmitSolicitorWorkflow : WorkflowType
  {
    private readonly IContentService _contentService;
    private readonly IMediaService _mediaService;
    private readonly IContentTypeBaseServiceProvider _contentTypeBaseServiceProvider;

    public SubmitSolicitorWorkflow(IContentService contentService, IMediaService mediaService, IContentTypeBaseServiceProvider contentTypeBaseServiceProvider)
    {
      this.Id = new Guid("7159f821-b97c-4a36-8efd-3b1482017c91");
      this.Name = "SubmitSolicitorWorkflow";
      this.Icon = "icon-user";

      _contentService = contentService;
      _mediaService = mediaService;
      _contentTypeBaseServiceProvider = contentTypeBaseServiceProvider;
    }
    public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
    {
      string solicitorName = "";
      string summary;
      string about;
      List<string> services = new List<string>();
      string openingHours;
      string addressLineOne;
      string postcode;
      string city;
      bool medicalAttention;
      bool minors;
      bool obscureLocation;
      int maximumMonths;

      //Iterate through the fields and assign variables based on alias.
      foreach (RecordField rf in record.RecordFields.Values)
      {
        if (rf.Alias == "solicitorName")
        {
          solicitorName = rf.ValuesAsString();
        }

        if (rf.Alias == "logo")
        {
          try
          {
            var logoPath = rf.ValuesAsString().Replace("/", @"\");
            var projectPath =
              System.AppDomain.CurrentDomain.BaseDirectory.Remove(
                System.AppDomain.CurrentDomain.BaseDirectory.Length - 1);
            var path = projectPath + logoPath;

            var file = new FileStream(path, FileMode.Open);
            var media = _mediaService.CreateMediaWithIdentity(solicitorName, 1227, "Image");

            using (FileStream stream = System.IO.File.Open(path, FileMode.Open))
            {
              media.SetValue(_contentTypeBaseServiceProvider, "umbracoFile", solicitorName, stream);
            }
            _mediaService.Save(media);
          }

          catch (Exception ex)
          {
            var bp = ex;
          }
        }

        if (rf.Alias == "summary")
        {
          summary = rf.ValuesAsString();
        }

        if (rf.Alias == "about")
        {
          about = rf.ValuesAsString();
        }

        if (rf.Alias == "services")
        {
          foreach (var val in rf.Values)
          {
            services.Add(val.ToString());
          }
        }

        if (rf.Alias == "openingHours")
        {
          openingHours = rf.ValuesAsString();
        }

        if (rf.Alias == "addressLine1")
        {
          addressLineOne = rf.ValuesAsString();
        }

        if (rf.Alias == "postcode")
        {
          postcode = rf.ValuesAsString();
        }

        if (rf.Alias == "city")
        {
          city = rf.ValuesAsString();
        }

        if (rf.Alias == "medicalAttention")
        {
          medicalAttention = rf.ValuesAsString().ToLower() == "yes";
        }

        if (rf.Alias == "minors")
        {
          minors = rf.ValuesAsString().ToLower() == "yes";
        }

        if (rf.Alias == "obscureLocation")
        {
          obscureLocation = rf.ValuesAsString().ToLower() == "yes";
        }

        if (rf.Alias == "maximumMonthsSinceIncident")
        {
          if(!Int32.TryParse(rf.ValuesAsString(), out maximumMonths))
          {
            maximumMonths = 18;
          }
        }
      }

      //var solicitorNode = _contentService.CreateAndSave(solicitorName, 1189, "solicitor");
      var node = _contentService.GetByLevel(2);

      // Each entry requires a unique GUID, generate here.
      var key = Guid.NewGuid().ToString();

      //_contentService.SaveAndPublish(solicitorNode);

      return WorkflowExecutionStatus.Completed;
    }

    public override List<Exception> ValidateSettings()
    {
      return new List<Exception>();
    }
  }
}

