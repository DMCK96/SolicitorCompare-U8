using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Forms.Core.Data.Storage;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Models;

namespace SolicitorCompare.UmbracoForms.FieldType
{
  public class StarRating : Umbraco.Forms.Core.FieldType
  {
    public StarRating()
    {
      this.Id = new Guid("25414613-6a01-4f4a-ab73-c5ae02e7ac02");
      this.Name = "StarRating";
      this.Description = "Render a star rating field";
      this.Icon = "icon-rate";
      this.DataType = FieldDataType.Integer;
      this.SortOrder = 10;
      this.SupportsRegex = false;
    }

    // You can do custom validation in here which will occur when the form is submitted.
    // Any strings returned will cause the submit to be invalid!
    // Where as returning an empty ienumerable of strings will say that it's okay.
    public override IEnumerable<string> ValidateField(Form form, Field field, IEnumerable<object> postedValues,
      HttpContextBase context, IFormStorage formStorage)
    {
      var returnStrings = new List<string>();

      if (!postedValues.Any(value => Int32.Parse(value.ToString()) >= 1) && !postedValues.Any(value => Int32.Parse(value.ToString()) <= 5))
      {
        returnStrings.Add("Rating must be between 1 and 5.");
      }

      // Also validate it against the original default method.
      returnStrings.AddRange(base.ValidateField(form, field, postedValues, context, formStorage));

      return returnStrings;
    }
  }
}
