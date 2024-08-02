using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCStarterContent
{
    namespace Common
    {
        public static class ListFunction 
        {
            /// <summary>
            /// Perfom a Add even if the list is null
            /// </summary>
            /// <typeparam name="T">type of the list</typeparam>
            /// <param name="list">targeted List</param>
            /// <param name="element">element to add</param>
            public static void AddToListWithSecurity<T>(this List<T> list, T element)
            {
                if(list == null)
                {
                    list = new List<T>();
                }

                list.Add(element);
            }
        }
    }
}
