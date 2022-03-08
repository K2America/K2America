﻿//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using K2America.Models;

[assembly: RegisterDocumentType(TabContentItem.CLASS_NAME, typeof(TabContentItem))]

namespace K2America.Models
{
	/// <summary>
	/// Represents a content item of type TabContentItem.
	/// </summary>
	public partial class TabContentItem : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "K2America.TabContentItem";


		/// <summary>
		/// The instance of the class that provides extended API for working with TabContentItem fields.
		/// </summary>
		private readonly TabContentItemFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// TabContentItemID.
		/// </summary>
		[DatabaseIDField]
		public int TabContentItemID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("TabContentItemID"), 0);
			}
			set
			{
				SetValue("TabContentItemID", value);
			}
		}


		/// <summary>
		/// Key Points.
		/// </summary>
		[DatabaseField]
		public string KeyPoints
		{
			get
			{
				return ValidationHelper.GetString(GetValue("KeyPoints"), @"");
			}
			set
			{
				SetValue("KeyPoints", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with TabContentItem fields.
		/// </summary>
		[RegisterProperty]
		public TabContentItemFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with TabContentItem fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class TabContentItemFields : AbstractHierarchicalObject<TabContentItemFields>
		{
			/// <summary>
			/// The content item of type TabContentItem that is a target of the extended API.
			/// </summary>
			private readonly TabContentItem mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="TabContentItemFields" /> class with the specified content item of type TabContentItem.
			/// </summary>
			/// <param name="instance">The content item of type TabContentItem that is a target of the extended API.</param>
			public TabContentItemFields(TabContentItem instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// TabContentItemID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.TabContentItemID;
				}
				set
				{
					mInstance.TabContentItemID = value;
				}
			}


			/// <summary>
			/// Key Points.
			/// </summary>
			public string KeyPoints
			{
				get
				{
					return mInstance.KeyPoints;
				}
				set
				{
					mInstance.KeyPoints = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="TabContentItem" /> class.
		/// </summary>
		public TabContentItem() : base(CLASS_NAME)
		{
			mFields = new TabContentItemFields(this);
		}

		#endregion
	}
}
