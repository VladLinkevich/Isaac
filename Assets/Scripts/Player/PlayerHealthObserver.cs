using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Player
{
	public class PlayerHealthObserver : ITickable
	{
		private readonly PlayerView _playerView;
		static public Action<float> HealthBarUpdate;

		public PlayerHealthObserver(PlayerView playerView)
		{
			_playerView = playerView;
		}

		public void Tick()
		{
			if (_playerView.Health <= 0 && !_playerView.IsDead)
			{
				Die();
			}
			else
			{
				TakeDamage();
			}
		}

		private void Die()
		{
			_playerView.IsDead = true;
		}

		public void TakeDamage()
		{
			_playerView.Health -= 10;
			HealthBarUpdate(_playerView.Health);
		}
	}
}
