using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Isaac.Player
{
	public class HealthBarHandler: MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;
		private void Start()
		{
			PlayerHealthObserver.HealthBarUpdate = UpdateSlider;
		}

		public void UpdateSlider(float actualHealth)
		{
			_slider.value = actualHealth;
		}
	}
}
