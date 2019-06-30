using System;
using Umbraco.Forms.Core.Enums;

namespace SolicitorCompare.UmbracoForms.FieldType
{
  public class StarRating : Umbraco.Forms.Core.FieldType
  {
    public StarRating()
    {
      Id = new Guid("25414613-6a01-4f4a-ab73-c5ae02e7ac02");
      Name = "StarRating";
      Description = "Render a star rating field";
      Icon = "icon-rate";
      DataType = FieldDataType.Integer;
    }
  }
}
