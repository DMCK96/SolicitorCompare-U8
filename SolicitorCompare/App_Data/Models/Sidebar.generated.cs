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
	// Mixin Content Type with alias "sidebar"
	/// <summary>Sidebar</summary>
	public partial interface ISidebar : IPublishedContent
	{
		/// <summary>Sidebar Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		string SidebarHeading { get; }

		/// <summary>Sidebar Items</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		IEnumerable<SidebarLink> SidebarItems { get; }
	}

	/// <summary>Sidebar</summary>
	[PublishedModel("sidebar")]
	public partial class Sidebar : PublishedContentModel, ISidebar
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const string ModelTypeAlias = "sidebar";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Sidebar, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Sidebar(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Sidebar Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("sidebarHeading")]
		public string SidebarHeading => GetSidebarHeading(this);

		/// <summary>Static getter for Sidebar Heading</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static string GetSidebarHeading(ISidebar that) => that.Value<string>("sidebarHeading");

		///<summary>
		/// Sidebar Items
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("sidebarItems")]
		public IEnumerable<SidebarLink> SidebarItems => GetSidebarItems(this);

		/// <summary>Static getter for Sidebar Items</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static IEnumerable<SidebarLink> GetSidebarItems(ISidebar that) => that.Value<IEnumerable<SidebarLink>>("sidebarItems");
	}
}
