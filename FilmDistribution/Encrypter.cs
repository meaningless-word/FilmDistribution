using System;
using System.Security.Cryptography;

namespace Logic
{
	internal class Encrypter
	{
		public static string HashPassword(string password)
		{
			byte[] salt;
			byte[] buffer;
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
			{
				salt = bytes.Salt;
				buffer = bytes.GetBytes(0x20);
			}
			byte[] dst = new byte[0x31];
			Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
			Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
			return Convert.ToBase64String(dst);
		}

		public static bool VerifyHashedPassword(string hashedPassword, string password)
		{

			if (hashedPassword == null)
			{
				return false;
			}
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			byte[] src = Convert.FromBase64String(hashedPassword);
			if ((src.Length != 0x31) || (src[0] != 0))
			{
				return false;
			}
			byte[] salt = new byte[0x10];
			Buffer.BlockCopy(src, 1, salt, 0, 0x10);
			byte[] buffer = new byte[0x20];
			Buffer.BlockCopy(src, 0x11, buffer, 0, 0x20);
			byte[] buffer_;
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt, 0x3e8))
			{
				buffer_ = bytes.GetBytes(0x20);
			}
			return ByteArraysEqual(buffer, buffer_);
		}

		private static bool ByteArraysEqual(byte[] firstHash, byte[] secondHash)
		{
			int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
			var xor = firstHash.Length ^ secondHash.Length;
			for (int i = 0; i < _minHashLength; i++)
				xor |= firstHash[i] ^ secondHash[i];
			return 0 == xor;
		}
	}
}
