using System;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;

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
          searchUrl = searchUrl + "?" + query;
          HttpContext.Current.Response.Redirect(searchUrl);
        }
      }
      catch (Exception ex)
      {
        var bp = ex;
        var breakp = true;
      }

      return WorkflowExecutionStatus.Completed;
    }


    public override List<Exception> ValidateSettings()
    {
      return new List<Exception>();
    }
  }
}
