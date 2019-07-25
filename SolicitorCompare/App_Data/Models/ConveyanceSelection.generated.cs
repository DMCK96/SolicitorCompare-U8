//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.1.0
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
	/// <summary>Conveyance Selection</summary>
	[PublishedModel("conveyanceSelection")]
	public partial class ConveyanceSelection : PublishedContentModel, INavigation, ISEO
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const string ModelTypeAlias = "conveyanceSelection";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ConveyanceSelection, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public ConveyanceSelection(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Card Links: Note: Card titles must match the page title under services. Otherwise the button link will not return results.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("cardLinks")]
		public IEnumerable<CardLink> CardLinks => this.Value<IEnumerable<CardLink>>("cardLinks");

		///<summary>
		/// Text: If you wish to display any text before the card links, here's the place to do it
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("text")]
		public IHtmlString Text => this.Value<IHtmlString>("text");

		///<summary>
		/// Disable Link: Tick this if you wish for this page to be a category in navigation but not be clickable
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("disableLink")]
		public bool DisableLink => Navigation.GetDisableLink(this);

		///<summary>
		/// Hide in Navigation: Tick this box if you wish to hide this page from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation => Navigation.GetHideInNavigation(this);

		///<summary>
		/// Hide Submenu: Hides submenu for this item
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("hideSubmenu")]
		public bool HideSubmenu => Navigation.GetHideSubmenu(this);

		///<summary>
		/// Redirect: Set a page to redirect to, if this is filled in then the user will automatically be redirected to that page when trying to access this current one.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("redirect")]
		public Umbraco.Web.Models.Link Redirect => Navigation.GetRedirect(this);

		///<summary>
		/// Browser Title: The title that will appear in the browser window/tabs and appear in search engines. If this is empty it will just use the node name instead.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("browserTitle")]
		public string BrowserTitle => SEO.GetBrowserTitle(this);

		///<summary>
		/// Meta Description: The description for the page that will appear in a search engine. If this is empty it will default to the description on the homepage.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("metaDescription")]
		public string MetaDescription => SEO.GetMetaDescription(this);
	}
}
