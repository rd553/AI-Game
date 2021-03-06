﻿using UnityEngine;
using UnitySteer.Behaviors;


	/// <summary>
	/// Trivial example that simply makes the vehicle move towards its forward vector
	/// </summary>

	public class SteerStrafe : Steering
	{
		protected Vector3 _desiredForward = Vector3.zero;

		private bool _overrideForward;

		/// <summary>
		/// Desired forward vector. If set to Vector3.zero we will steer toward the transform's forward
		/// </summary>
		public Vector3 DesiredForward
		{
			get { return _overrideForward ? _desiredForward : Vehicle.Transform.right; }
			set
			{
				_desiredForward = value;
				_overrideForward = value != Vector3.zero;
			}
		}

		/// <summary>
		/// Calculates the force to apply to the vehicle to reach a point
		/// </summary>
		/// <returns>
		/// A <see cref="Vector3"/>
		/// </returns>
		protected override Vector3 CalculateForce()
		{
			return _overrideForward ? DesiredForward : Vehicle.Transform.right;
		}
	}