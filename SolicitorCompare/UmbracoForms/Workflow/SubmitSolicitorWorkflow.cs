using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;

namespace SolicitorCompare.UmbracoForms.Workflow
{
  public class SubmitSolicitorWorkflow : WorkflowType
  {
    private readonly IContentService _contentService;
    private readonly IMediaService _mediaService;
    private readonly IContentTypeBaseServiceProvider _contentTypeBaseServiceProvider;
    private readonly IDataTypeService _dataTypeService;

    public SubmitSolicitorWorkflow(IContentService contentService, IMediaService mediaService,
      IContentTypeBaseServiceProvider contentTypeBaseServiceProvider, IDataTypeService dataTypeService)
    {
      this.Id = new Guid("7159f821-b97c-4a36-8efd-3b1482017c91");
      this.Name = "SubmitSolicitorWorkflow";
      this.Icon = "icon-user";

      _contentService = contentService;
      _mediaService = mediaService;
      _contentTypeBaseServiceProvider = contentTypeBaseServiceProvider;
      _dataTypeService = dataTypeService;
    }

    class Service
    {
      public string value { get; set; }
    }

    public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
    {
      string solicitorName = "";
      string summary = "";
      string about = "";
      List<string> services = new List<string>();
      string openingHours = "";
      string logoPath = "";
      string addressLineOne = "";
      string postcode = "";
      string city = "";
      bool medicalAttention = false;
      bool minors = false;
      bool obscureLocation = false;
      int maximumMonths = 18;

      //Iterate through the fields and assign variables based on alias.
      foreach (RecordField rf in record.RecordFields.Values)
      {
        if (rf.Alias == "solicitorName")
        {
          solicitorName = rf.ValuesAsString();
        }

        if (rf.Alias == "logo")
        {
          logoPath = rf.ValuesAsString().Replace("/", @"\");
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
          if (!Int32.TryParse(rf.ValuesAsString(), out maximumMonths))
          {
            maximumMonths = 18;
          }
        }
      }

      var solicitorNode = _contentService.CreateAndSave(solicitorName, 1365, "solicitor");

      if (!logoPath.IsNullOrWhiteSpace())
      {
        var projectPath =
          System.AppDomain.CurrentDomain.BaseDirectory.Remove(
            System.AppDomain.CurrentDomain.BaseDirectory.Length - 1);
        var path = projectPath + logoPath;

        var media = _mediaService.CreateMediaWithIdentity(solicitorName, 1227, "Image");

        using (FileStream stream = System.IO.File.Open(path, FileMode.Open))
        {
          media.SetValue(_contentTypeBaseServiceProvider, "umbracoFile", logoPath, stream);
        }

        _mediaService.Save(media);

        solicitorNode.SetValue("logo", media.GetUdi().ToString());
      }

      var servicesString = JsonConvert.SerializeObject(services);
      solicitorNode.SetValue("summary", summary);
      solicitorNode.SetValue("aboutUs", about);
      solicitorNode.SetValue("services", servicesString);
      solicitorNode.SetValue("submittedOpeningHours", openingHours);
      solicitorNode.SetValue("addressLine1", addressLineOne);
      solicitorNode.SetValue("postcode", postcode);
      solicitorNode.SetValue("city", city);
      solicitorNode.SetValue("medicalAttention", medicalAttention);
      solicitorNode.SetValue("minors", minors);
      solicitorNode.SetValue("obscureLocation", obscureLocation);
      solicitorNode.SetValue("maximumTime", maximumMonths);

      _contentService.Save(solicitorNode);

      return WorkflowExecutionStatus.Completed;
    }

    public override List<Exception> ValidateSettings()
    {
      return new List<Exception>();
    }
  }
}
