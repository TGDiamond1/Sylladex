using System;
using System.Collections.Generic;
using System.Linq;

namespace Sylladex {
	public class CaptchalogueCode {
		public char[] captchaCode = new char[8];
		private readonly int[] _captchalogueCodeBinary = new int[8];
		public int[] CaptchalogueCodeBinary {
			get {
				for (int i = 0; i < 8; i++) {
					_captchalogueCodeBinary[i] = charToBinary[captchaCode[i]];
				}
				return _captchalogueCodeBinary;
			}
		}

		public static Dictionary<char, int> charToBinary = new Dictionary<char, int>() {
		    {'0', 0b0000_0000},
		    {'1', 0b0000_0001},
		    {'2', 0b0000_0010},
		    {'3', 3},
		    {'4', 4},
		    {'5', 5},
		    {'6', 6},
		    {'7', 7},
		    {'8', 8},
		    {'9', 9},
		    {'A', 10},
		    {'B', 11},
		    {'C', 12},
		    {'D', 13},
		    {'E', 14},
		    {'F', 15},
		    {'G', 16},
		    {'H', 17},
		    {'I', 18},
		    {'J', 19},
		    {'K', 20},
		    {'L', 21},
		    {'M', 22},
		    {'N', 23},
		    {'O', 24},
		    {'P', 25},
		    {'Q', 26},
		    {'R', 27},
		    {'S', 28},
		    {'T', 29},
		    {'U', 30},
		    {'V', 31},
		    {'W', 32},
		    {'X', 33},
		    {'Y', 34},
		    {'Z', 35},
		    {'a', 36},
		    {'b', 37},
		    {'c', 38},
		    {'d', 39},
		    {'e', 40},
		    {'f', 41},
		    {'g', 42},
		    {'h', 43},
		    {'i', 44},
		    {'j', 45},
		    {'k', 46},
		    {'l', 47},
		    {'m', 48},
		    {'n', 49},
		    {'o', 50},
		    {'p', 51},
		    {'q', 52},
		    {'r', 53},
		    {'s', 54},
		    {'t', 55},
		    {'u', 56},
		    {'v', 57},
		    {'w', 58},
		    {'x', 59},
		    {'y', 60},
		    {'z', 61},
		    {'?', 62},
		    {'!', 63}
		};
		public static Dictionary<int, char> binaryToChar = charToBinary.ToDictionary(x => x.Value, x => x.Key);

		public CaptchalogueCode(char[] charCode)
		{
			if (charCode.Length == 8) {
				captchaCode = charCode;
			} else {
				throw new ArgumentOutOfRangeException($"Length of captchalogue code must be exactly 8. Provided length: {charCode.Length}");
			}
		}

		public CaptchalogueCode(string stringCode)
		{
			char[] charCode = stringCode.ToCharArray();
			if (charCode.Length == 8) {
				captchaCode = charCode;
			} else {
				throw new ArgumentOutOfRangeException($"Length of captchalogue code must be exactly 8. Provided length: {charCode.Length}");
			}
		}
		

		private char[] BinaryToCaptchaCode(int[] binary)
		{
			if (binary.Length == 8) {
				char[] convertedCode = new char[8];
				for (int i = 0; i < 8; i++) {
					convertedCode[i] = binaryToChar[binary[i]];
				}
				return convertedCode;
			}
			throw new ArgumentOutOfRangeException($"Length of arguement array must be exactly 8. Arguement length: {binary.Length}");
		}

		public static bool operator ==(CaptchalogueCode lCC, CaptchalogueCode rCC) => lCC.captchaCode == rCC.captchaCode;

		public static bool operator !=(CaptchalogueCode lCC, CaptchalogueCode rCC) => lCC.captchaCode != rCC.captchaCode;

		public CaptchalogueCode AND(CaptchalogueCode other)
		{
			int[] andArray = new int[8];
			for(int i = 0; i < 8; i++) {
				andArray[i] = charToBinary[captchaCode[i]] & charToBinary[other.captchaCode[i]];
			}
			return new CaptchalogueCode(BinaryToCaptchaCode(andArray));
		}
		
		public CaptchalogueCode OR(CaptchalogueCode other)
		{
			int[] andArray = new int[8];
			for(int i = 0; i < 8; i++) {
				andArray[i] = charToBinary[captchaCode[i]] | charToBinary[other.captchaCode[i]];
			}
			return new CaptchalogueCode(BinaryToCaptchaCode(andArray));
		}
		
		public CaptchalogueCode XOR(CaptchalogueCode other)
		{
			int[] andArray = new int[8];
			for(int i = 0; i < 8; i++) {
				andArray[i] = charToBinary[captchaCode[i]] ^ charToBinary[other.captchaCode[i]];
			}
			return new CaptchalogueCode(BinaryToCaptchaCode(andArray));
		}

		public CaptchalogueCode NOT() => XOR(new CaptchalogueCode("!!!!!!!!"));

		public override string ToString() => new string(captchaCode);

		public override bool Equals(object obj)
		{
			if (!(obj is CaptchalogueCode)) {
				return false;
			}
			return this == (CaptchalogueCode)obj;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			for (int i = 0; i < 8; i++) {
				hash += CaptchalogueCodeBinary[7 - i] * ((int)Math.Pow(2, 5 * i));
			}
			return unchecked(hash);
		}
	};
}