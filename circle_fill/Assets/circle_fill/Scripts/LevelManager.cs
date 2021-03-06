﻿
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#if AADOTWEEN
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AppAdvisory.ab
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager self;

		public List<Level> levels;

		void Awake()
		{
			self = this;

			int level = PlayerPrefs.GetInt ("LEVEL_PLAYED");
			if (level > 1200) {
				PlayerPrefs.SetInt ("LEVEL_PLAYED", 1200);
			}
		}

			#if UNITY_EDITOR
				[ContextMenu("Execute")]
				public virtual void CreateLevels ()
			{
				Debug.Log("execute");
		
		
				levels = new List<Level> ();
		
				for (int i = 1; i <= 1200; i++) 
				{
					Level l = new Level (i);
		//			if (i % 2 == 0) {
		//				l.rotateRight = true;
		//			} else {
		//				l.rotateRight = false;
		//			}
					levels.Add (l);
				}
			}
			#endif

		public static Level GetLevel(int level)
		{
			Level l = new Level (level);
			return l;
		}
	}

	[Serializable]
	public class Level
	{
		static int maxLevel = 1200;

		public int levelNumber = 0;
		public int numberDotsToCreate = 0;
		public int numberDotsOnCircle = 0;
		public float sizeRayonRation = 0.7f; // min = 0.7f max = 1.5f
		public float rotateDelay = 8f;
		public Ease rotateEaseType = Ease.Linear; //Ease.Linear;
		public LoopType rotateLoopType = LoopType.Yoyo;

		public Level (int level)
		{
			levelNumber = level;

			rotateEaseType = Ease.Linear;

			rotateLoopType = LoopType.Yoyo;

			sizeRayonRation = 0.4f - ((level % 3) / 10f);

			rotateDelay = 9f - (level % 3);

			if (level == 1) {
				sizeRayonRation = 0.7f;
		
				numberDotsToCreate = 3;
				numberDotsOnCircle = 0;

			} else if (level == 2) {
				sizeRayonRation = 0.7f;
	
				numberDotsToCreate = 2;
				numberDotsOnCircle = 2;

			} else if (level == 3) {
				sizeRayonRation = 1f;
		
				numberDotsToCreate = 2;
				numberDotsOnCircle = 4;

			} else if (level == 4) {
				sizeRayonRation = 1f;
	
				numberDotsToCreate = 4;
				numberDotsOnCircle = 2;

			} else if (level == 5) {
				sizeRayonRation = 0.7f;
		
				numberDotsToCreate = 3;
				numberDotsOnCircle = 3;

			} else if (level == 6) {
				sizeRayonRation = 0.7f;
		
				numberDotsToCreate = 5;
				numberDotsOnCircle = 2;

			} else if (level == 7) {
				sizeRayonRation = 1.2f;
		
				numberDotsToCreate = 5;
				numberDotsOnCircle = 4;

			} else if (level == 8) {
				sizeRayonRation = 1.3f;

				numberDotsToCreate = 6;
				numberDotsOnCircle = 5;

			} else if (level == 9) {
				sizeRayonRation = 1.5f;

				numberDotsToCreate = 6;
				numberDotsOnCircle = 6;

			} else {

				sizeRayonRation = 0.7f + ((float)(level % 9))/10f;

				Debug.Log("sizeRayonRation = " + sizeRayonRation);

				numberDotsToCreate = 
					(int)(
						(3 + level%5)
						* (0.5f + sizeRayonRation));

				numberDotsOnCircle = 
					(int)(
						(8 - numberDotsToCreate)
						* (0.5f + sizeRayonRation));

				if (level%2 <1) {

					rotateLoopType = LoopType.Yoyo;

				} else {

					rotateLoopType = LoopType.Restart;
				}

				int numOfEnum = (System.Enum.GetValues (typeof(Ease)).Length) - 10;

				int enumNumber = level % numOfEnum;
				rotateEaseType = (Ease)(enumNumber);
			}

			if (level > maxLevel)
			{
				PlayerPrefs.SetInt ("LEVEL", 1200);

				level = 1200;
				PlayerPrefs.SetInt ("LEVEL_PLAYED", 1200);

				Application.OpenURL ("http://barouch.fr/moregames.php");
			}
		}
	}
}
#endif