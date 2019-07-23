using System;
using System.Collections.Generic;
using System.Web;
using RestSharp;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Core.Logging;

namespace SolicitorCompare.UmbracoForms.Workflow
{
  public class SearchSolicitorWorkflow : WorkflowType
  {
    private readonly IContentService _contentService;
    private readonly IMediaService _mediaService;
    private readonly IContentTypeBaseServiceProvider _contentTypeBaseServiceProvider;
    private readonly IDataTypeService _dataTypeService;

    public SearchSolicitorWorkflow(IContentService contentService, IMediaService mediaService,
      IContentTypeBaseServiceProvider contentTypeBaseServiceProvider, IDataTypeService dataTypeService)
    {
      this.Id = new Guid("2b9064d0-f8b4-441a-af80-8652cbb842e0");
      this.Name = "Search Solicitor";
      this.Icon = "icon-user";

      _contentService = contentService;
      _mediaService = mediaService;
      _contentTypeBaseServiceProvider = contentTypeBaseServiceProvider;
      _dataTypeService = dataTypeService;
    }

    public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
    {
      string searchUrl = "";
      string query = "";

      //Iterate through the fields and assign variables based on alias.
      foreach (RecordField rf in record.RecordFields.Values)
      {
        if (rf.Alias == "searchUrl")
        {
          searchUrl = rf.ValuesAsString();
        }

        if (rf.Alias != "searchUrl")
        {
          query += rf.Alias + "=" + HttpUtility.UrlEncode(rf.ValuesAsString()) + "&";
        }
      }


      try
      {
        if (!searchUrl.IsNullOrWhiteSpace())
        {
          query = query.Replace(@"\/", "-");
          searchUrl = searchUrl.Replace(@"\", "");

          var https = HttpContext.Current.Request.IsSecureConnection;
          var protocol = https ? "https://" : "http://";

          searchUrl = protocol + searchUrl + "?" + query;
          Logger.None.Write(LogEventLevel.Error ,searchUrl);
          HttpContext.Current.Response.Redirect(searchUrl);
        }
        else
        {
          return WorkflowExecutionStatus.Failed;
        }
      }
      catch (Exception ex)
      {
        Logger.None.Write(LogEventLevel.Error, ex, ex.Message + " | " + searchUrl);
      }

      return WorkflowExecutionStatus.Completed;
    }


    public override List<Exception> ValidateSettings()
    {
      return new List<Exception>();
    }
  }
}
