using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Domain.Common
{
	//https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects	
	public abstract class ValueObject
	{
		protected abstract IEnumerable<object> GetEqualityComponents();
		
		protected static bool EqualOperator(ValueObject Left, ValueObject Right)
		{
			if(Left is null ^ Right is null)
			{
				return false;
			}

			return Left?.Equals(Right) != false;
		}

		protected static bool NotEqualOperator(ValueObject Left,ValueObject Right)
		{
			return !EqualOperator(Left, Right);
		}

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != GetType())
			{
				return false;
			}

			ValueObject other = (ValueObject)obj;
			return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
		}

		public override int GetHashCode()
		{
			return this.GetEqualityComponents().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
		}
	}
}
