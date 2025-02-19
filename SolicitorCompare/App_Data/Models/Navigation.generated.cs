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
	// Mixin Content Type with alias "navigation"
	/// <summary>Navigation</summary>
	public partial interface INavigation : IPublishedContent
	{
		/// <summary>Disable Link</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		bool DisableLink { get; }

		/// <summary>Hide in Navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		bool HideInNavigation { get; }

		/// <summary>Hide Submenu</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		bool HideSubmenu { get; }

		/// <summary>Redirect</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		Umbraco.Web.Models.Link Redirect { get; }
	}

	/// <summary>Navigation</summary>
	[PublishedModel("navigation")]
	public partial class Navigation : PublishedContentModel, INavigation
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const string ModelTypeAlias = "navigation";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Navigation, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Navigation(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Disable Link: Tick this if you wish for this page to be a category in navigation but not be clickable
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("disableLink")]
		public bool DisableLink => GetDisableLink(this);

		/// <summary>Static getter for Disable Link</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static bool GetDisableLink(INavigation that) => that.Value<bool>("disableLink");

		///<summary>
		/// Hide in Navigation: Tick this box if you wish to hide this page from navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation => GetHideInNavigation(this);

		/// <summary>Static getter for Hide in Navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static bool GetHideInNavigation(INavigation that) => that.Value<bool>("hideInNavigation");

		///<summary>
		/// Hide Submenu: Hides submenu for this item
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("hideSubmenu")]
		public bool HideSubmenu => GetHideSubmenu(this);

		/// <summary>Static getter for Hide Submenu</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static bool GetHideSubmenu(INavigation that) => that.Value<bool>("hideSubmenu");

		///<summary>
		/// Redirect: Set a page to redirect to, if this is filled in then the user will automatically be redirected to that page when trying to access this current one.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("redirect")]
		public Umbraco.Web.Models.Link Redirect => GetRedirect(this);

		/// <summary>Static getter for Redirect</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static Umbraco.Web.Models.Link GetRedirect(INavigation that) => that.Value<Umbraco.Web.Models.Link>("redirect");
	}
}
