//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.0.4
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Solicitor</summary>
	[PublishedModel("solicitor")]
	public partial class Solicitor : PublishedContentModel, INavigation, ISEO
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		public new const string ModelTypeAlias = "solicitor";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		public new static PublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Solicitor, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Solicitor(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// About Us: Text for the about us section
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("aboutUs")]
		public IHtmlString AboutUs => this.Value<IHtmlString>("aboutUs");

		///<summary>
		/// Address Line 1: This is required if you wish to display a map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("addressLine1")]
		public string AddressLine1 => this.Value<string>("addressLine1");

		///<summary>
		/// City: This is required if you wish to display a map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("city")]
		public string City => this.Value<string>("city");

		///<summary>
		/// Logo
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("logo")]
		public Image Logo => this.Value<Image>("logo");

		///<summary>
		/// Maximum Time: Maximum amount of months since time of accident that this solicitor will accept (if not filled in will default to 18 months).
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("maximumTime")]
		public int MaximumTime => this.Value<int>("maximumTime");

		///<summary>
		/// Medical Attention: Tick if will take when medical attention has not been sought.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("medicalAttention")]
		public bool MedicalAttention => this.Value<bool>("medicalAttention");

		///<summary>
		/// Minors: Tick if this solicitor will accept minors
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("minors")]
		public bool Minors => this.Value<bool>("minors");

		///<summary>
		/// Obscure Location: Tick if solicitor will take RTA that occurred in an obscure location such as a roundabout.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("obscureLocation")]
		public bool ObscureLocation => this.Value<bool>("obscureLocation");

		///<summary>
		/// Opening Hours
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("openingHours")]
		public OpeningHours OpeningHours => this.Value<OpeningHours>("openingHours");

		///<summary>
		/// Postcode: This is required if you wish to display a map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("postcode")]
		public string Postcode => this.Value<string>("postcode");

		///<summary>
		/// Services: Services that the solicitor provides
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("services")]
		public IEnumerable<string> Services => this.Value<IEnumerable<string>>("services");

		///<summary>
		/// Summary: Short paragraph summarizing the solicitor
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("summary")]
		public string Summary => this.Value<string>("summary");

		///<summary>
		/// Disable Link: Tick this if you wish for this page to be a category in navigation but not be clickable
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("disableLink")]
		public bool DisableLink => Navigation.GetDisableLink(this);

		///<summary>
		/// Hide in Navigation: Tick this box if you wish to hide this page from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation => Navigation.GetHideInNavigation(this);

		///<summary>
		/// Hide Submenu: Hides submenu for this item
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("hideSubmenu")]
		public bool HideSubmenu => Navigation.GetHideSubmenu(this);

		///<summary>
		/// Redirect: Set a page to redirect to, if this is filled in then the user will automatically be redirected to that page when trying to access this current one.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("redirect")]
		public Umbraco.Web.Models.Link Redirect => Navigation.GetRedirect(this);

		///<summary>
		/// Browser Title: The title that will appear in the browser window/tabs and appear in search engines. If this is empty it will just use the node name instead.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("browserTitle")]
		public string BrowserTitle => SEO.GetBrowserTitle(this);

		///<summary>
		/// Meta Description: The description for the page that will appear in a search engine. If this is empty it will default to the description on the homepage.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.0.4")]
		[ImplementPropertyType("metaDescription")]
		public string MetaDescription => SEO.GetMetaDescription(this);
	}
}