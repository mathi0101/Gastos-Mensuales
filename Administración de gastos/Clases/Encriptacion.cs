using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_gastos.Clases {

	public static class Encriptacion {

		#region Encriptacion Mas complicada

		//private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV) {
		//	MemoryStream ms = new MemoryStream();
		//	Rijndael alg = Rijndael.Create();
		//	alg.Key = Key;
		//	alg.IV = IV;
		//	CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
		//	cs.Write(clearData, 0, clearData.Length);
		//	cs.Close();
		//	byte[] encryptedData = ms.ToArray();
		//	return encryptedData;
		//}

		///// <summary>
		///// Encripta la cadena ingresada
		///// </summary>
		///// <param name="Data"></param>
		///// <param name="Password"></param>
		///// <param name="Bits"></param>
		///// <returns> La cadena expresada en hexadecimal encriptada </returns>
		//public static string Encrypt(string Data, string Password, int Bits) {
		//	byte[] clearBytes = Encoding.Unicode.GetBytes(Data);
		//	PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x0, 0x1, 0x2, 0x1C, 0x1D, 0x1E, 0x3, 0x4, 0x5, 0xF, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });
		//	if (Bits == 128) {
		//		byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
		//		return Convert.ToBase64String(encryptedData);
		//	} else if (Bits == 192) {
		//		byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
		//		return Convert.ToBase64String(encryptedData);
		//	} else if (Bits == 256) {
		//		byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
		//		return Convert.ToBase64String(encryptedData);
		//	} else {
		//		return String.Concat(Bits);
		//	}
		//}

		#endregion Encriptacion Mas complicada

		#region Métodos

		/// <summary>
		/// Encripta una cadena en Base 64
		/// </summary>
		/// <param name="_cadenaAencriptar"></param>
		/// <returns> La cadena encriptada </returns>
		public static string Encriptar(string _cadenaAencriptar) {
			string result = string.Empty;
			byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
			result = Convert.ToBase64String(encryted);
			return result;
		}

		/// <summary>
		/// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
		/// </summary>
		/// <param name="_cadenaAdesencriptar"></param>
		/// <returns> La clave en texto plano </returns>
		public static string DesEncriptar(string _cadenaAdesencriptar) {
			string result = string.Empty;
			byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
			//result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
			result = Encoding.Unicode.GetString(decryted);
			return result;
		}

		#endregion Métodos
	}
}