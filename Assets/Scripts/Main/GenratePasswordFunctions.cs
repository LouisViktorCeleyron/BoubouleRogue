using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCStarterContent
{
    namespace Common
    {
        public class GenratePasswordFunctions 
        {
            /// <summary>
            /// Generate a password with letter from a to z A to Z and number from 0 to 9
            /// </summary>
            /// <param name="length"></param>
            /// <returns></returns>
            public static string GenerateAlphanumericPassword(int length)
            {
                string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxy0123456789";
                string _returnValue = "";

                for (int i = 0; i < length; i++)
                {
                    _returnValue += _alphabet[Random.Range(0, _alphabet.Length)];
                }

                return _returnValue;
            }
        }
    }
}
