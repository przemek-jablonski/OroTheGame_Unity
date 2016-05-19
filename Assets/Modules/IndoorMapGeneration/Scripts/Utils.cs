using System;

namespace AssemblyCSharp {
	
	public static class Utils {

		static System.Random random;

		static Utils() {
			random = new System.Random ();
		}

		/**
		 * returns bool, chance of getting true is proportional to percentChance
		 * percentChance is an integer in range (0, 100)
		 **/
		public static bool randomBool(int percentChance) {
			if (random.Next (0, 100) < percentChance)
				return true;
			return false;
		}

		/**
		 * returns bool, chance of getting true is proportional to percentChance
		 * percentChance is a floating point number in range (0.0, 1.0)
		 **/
		public static bool randomBool(float percentChance) {
			if (random.NextDouble () < percentChance)
				return true;
			return false;
		}

	}

}

