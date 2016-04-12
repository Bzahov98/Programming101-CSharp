using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Reflection1;

namespace ExtentionMethod
{
	// first bullet implemented-
	public static class A 
	{
		public static int Method(this Object obj)
		{
			
			if (obj.IsIncrementable())
			{
				obj.Incrementing();
				var type = obj.GetType();
				PropertyInfo[] a = type.GetProperties();

				foreach (var prop in a)
				{
					var type2 = prop.PropertyType;
					if (type2 == typeof(Int32))
					{
						var getm = prop.GetGetMethod();
						var setm = prop.GetSetMethod();


						if (getm != null && setm != null)
						{
							var val = (int)getm.Invoke(obj, new object[] {});

							setm.Invoke(obj, new object[] { val+1 });

							//setm.Invoke(prop, new Type[] {(int)val + 1});
							//.SetProperty(obj, "Name") = "MyName";

						}

					}
					

				}
			}
			else
			{
				obj.ThrowPublicProperties();
				//throw new ExecutionEngineException();
			}
			return 1;
		}

		private static bool IsIncrementable(this Object obj)
			// return true if obj is incrementable, else false
		{
			
			if (obj == null)
			{
				return false;
				//throw new NullReferenceException();
				//type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			} 
			var type = obj.GetType();

			return type.IsDefined(typeof(IncrementableAttribute), true);  ;
		}

		public static void Incrementing(this Object obj)
		{
			//need to put it at different methods
			//something
		}
		public static void ThrowPublicProperties(this Object obj)
		{
			//need to put it at different methods

			//something
		}
	}
}
