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

[assembly: RegisterDocumentType(CountCardContent.CLASS_NAME, typeof(CountCardContent))]

namespace K2America.Models
{
	/// <summary>
	/// Represents a content item of type CountCardContent.
	/// </summary>
	public partial class CountCardContent : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "K2America.CountCardContent";


		/// <summary>
		/// The instance of the class that provides extended API for working with CountCardContent fields.
		/// </summary>
		private readonly CountCardContentFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// CountCardContentID.
		/// </summary>
		[DatabaseIDField]
		public int CountCardContentID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CountCardContentID"), 0);
			}
			set
			{
				SetValue("CountCardContentID", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Count.
		/// </summary>
		[DatabaseField]
		public string Count
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Count"), @"");
			}
			set
			{
				SetValue("Count", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with CountCardContent fields.
		/// </summary>
		[RegisterProperty]
		public CountCardContentFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CountCardContent fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CountCardContentFields : AbstractHierarchicalObject<CountCardContentFields>
		{
			/// <summary>
			/// The content item of type CountCardContent that is a target of the extended API.
			/// </summary>
			private readonly CountCardContent mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CountCardContentFields" /> class with the specified content item of type CountCardContent.
			/// </summary>
			/// <param name="instance">The content item of type CountCardContent that is a target of the extended API.</param>
			public CountCardContentFields(CountCardContent instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CountCardContentID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CountCardContentID;
				}
				set
				{
					mInstance.CountCardContentID = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}


			/// <summary>
			/// Count.
			/// </summary>
			public string Count
			{
				get
				{
					return mInstance.Count;
				}
				set
				{
					mInstance.Count = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="CountCardContent" /> class.
		/// </summary>
		public CountCardContent() : base(CLASS_NAME)
		{
			mFields = new CountCardContentFields(this);
		}

		#endregion
	}
}