﻿using System;

namespace Blundergat.Common.Model
{
	/// <summary>
	/// Represents an entity identifier.
	/// </summary>
	/// <remarks>Immutable.</remarks>
	public sealed class TId : IEquatable<TId>
	{
		private readonly Guid _value;

		private TId(Guid idValue)
		{
			_value = idValue;
		}

		public TId() : this(Guid.NewGuid()) { }

		/// <summary>
		/// Creates new instance of <see cref="TId"/> and initializes it with <paramref name="value"/>.
		/// </summary>
		/// <param name="value">String representation of Id to parse.</param>
		/// <returns>New instance of <see cref="TId"/> with <paramref name="value"/> value.</returns>
		public static TId Parse(string value)
		{
			return new TId(Guid.Parse(value));
		}

		#region IEquatable<TId>.
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise <c>false</c>.</returns>
		public bool Equals(TId other)
		{
			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(other, this))
				return true;

			return _value.Equals(other._value);
		}
		#endregion // IEquatable<TId>.

		#region Object Overrides.
		/// <summary>
		/// Determines whether the specified <see cref="TId"/> is equal to the current one.
		/// </summary>
		/// <param name="obj">The <see cref="TId"/> object to compare with the current one.</param>
		/// <returns><c>true</c> if the specified <see cref="TId"/> is equal to the current one;
		/// otherwise <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			return this.Equals(obj as TId);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>A hash code for the current <see cref="TId"/>.</returns>
		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		/// <summary>
		/// Returns a string that represents the current <see cref="TId"/> instance.
		/// </summary>
		/// <returns>A string that represents the current <see cref="TId"/> instance.</returns>
		public override string ToString()
		{
			return _value.ToString();
		}
		#endregion // Object Overrides.

		#region Comparison Operators.
		/// <summary>
		/// Determines whether values of two instances of <see cref="TId"/> are equal.
		/// </summary>
		/// <param name="left">First instance of <see cref="TId"/>.</param>
		/// <param name="right">Second instance of <see cref="TId"/>.</param>
		/// <returns><c>true</c> if <paramref name="left"/> value is equal to the <paramref name="right"/> 
		/// value; otherwise <c>false</c>.</returns>
		public static bool operator ==(TId left, TId right)
		{
			if (ReferenceEquals(left, null))
				return ReferenceEquals(right, null);

			return left.Equals(right);
		}

		/// <summary>
		/// Determines whether values of two instances of <see cref="TId"/> are not equal.
		/// </summary>
		/// <param name="left">First instance of <see cref="TId"/>.</param>
		/// <param name="right">Second instance of <see cref="TId"/>.</param>
		/// <returns><c>true</c> if <paramref name="left"/> value is not equal to the <paramref name="right"/> 
		/// value; otherwise <c>false</c>.</returns>
		public static bool operator !=(TId left, TId right)
		{
			if (ReferenceEquals(left, null))
				return !ReferenceEquals(right, null);

			return !left.Equals(right);
		}
		#endregion // Comparison Operators.

		#region T(x) Operators.
		/// <summary>
		/// Implicitly converts <see cref="TId"/> to <see cref="String"/> value.
		/// </summary>
		/// <param name="instance"><see cref="TId"/> to convert.</param>
		/// <returns><see cref="String"/> value.</returns>
		public static implicit operator string(TId instance)
		{
			return instance.ToString();
		}

		/// <summary>
		/// Explicitly converts <see cref="String"/> to <see cref="TId"/> value.
		/// </summary>
		/// <param name="value"><see cref="String"/> to convert.</param>
		/// <returns><see cref="TId"/> value.</returns>
		public static explicit operator TId(string value)
		{
			return TId.Parse(value);
		}
		#endregion // T(x) Operators.
	}
}
