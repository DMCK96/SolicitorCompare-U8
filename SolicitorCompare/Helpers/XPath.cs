namespace SolicitorCompare.Helpers
{
  public static class XPath
  {
    public static readonly string SiteSettingsNode = "//settings";
    public static readonly string SolicitorListing = "//home//solicitorListing";
    public static readonly string RTAClaim = "//home//services//formPage[@nodeName='Road Traffic Accident Claim']";
    public static readonly string RTASearch = "//home//services//formPage[@nodeName='Road Traffic Accident']";
    public static readonly string Conveyance = "//home//services//conveyanceSelection";
    public static readonly string ConveyanceRemortgage = "//home//services//conveyanceSelection//formPage[@nodeName='Remortgage']";
    public static readonly string ConveyanceTransferEquity = "//home//services//conveyanceSelection//formPage[@nodeName='Transfer of Equity']";
    public static readonly string ConveyanceBuyProperty = "//home//services//conveyanceSelection//formPage[@nodeName='Purchase Property']";
    public static readonly string ConveyanceSellProperty = "//home//services//conveyanceSelection//formPage[@nodeName='Sell Property']";
    public static readonly string ContactUs = "//home//contactUs";
  }
}
