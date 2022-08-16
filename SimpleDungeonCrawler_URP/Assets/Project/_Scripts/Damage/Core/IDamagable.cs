// ######################################################################
// IDamagable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;
using UnityEngine;

namespace Project
{
    public interface IDamagable
	{
		StatType_SO StatType { get; }
		GameObject GO { get; }

		void Consume(float _damageAmount, ConsumeType _consumeType);
	}
}
