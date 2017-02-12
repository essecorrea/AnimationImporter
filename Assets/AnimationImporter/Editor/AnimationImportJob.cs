﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace AnimationImporter
{
	public class AnimationImportJob
	{
		private string _assetPath;

		public string name { get { return Path.GetFileNameWithoutExtension(fileName); } }
		public string fileName { get { return Path.GetFileName(_assetPath); } }
		public string assetDirectory { get { return GetBasePath(_assetPath); } }

		public string directoryPathForSprites = "";
		public string directoryPathForAnimations = "";

		public string imageAssetFilename
		{
			get
			{
				return directoryPathForSprites + "/" + name + ".png";
			}
		}

		public PreviousImportSettings previousImportSettings = null;

		// additional import settings
		public string additionalCommandLineArguments = null;
		public bool createUnityAnimations = true;
		public ImportAnimatorController importAnimatorController = ImportAnimatorController.None;
		public bool useExistingAnimatorController = false;

		// ================================================================================
		//  constructor
		// --------------------------------------------------------------------------------

		public AnimationImportJob(string assetPath)
		{
			_assetPath = assetPath;
		}

		// ================================================================================
		//  private methods
		// --------------------------------------------------------------------------------

		private string GetBasePath(string path)
		{
			string extension = Path.GetExtension(path);
			if (extension.Length > 0 && extension[0] == '.')
			{
				extension = extension.Remove(0, 1);
			}

			string fileName = Path.GetFileNameWithoutExtension(path);
			string lastPart = "/" + fileName + "." + extension;

			return path.Replace(lastPart, "");
		}
	}
}