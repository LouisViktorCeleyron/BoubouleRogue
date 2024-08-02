using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LCStarterContent
{
    namespace Common
    {
        public static class ArrayAndListExtention
        {
            /// <summary>
            /// Add and Element to the array, verry heavy use it in editor only.
            /// </summary>
            /// <typeparam name="T">Type of the array</typeparam>
            /// <param name="array"> ref of the array</param>
            public static T[] Add<T>(ref T[] array, T newElement)
            {
                var _temp = new T[array.Length];
                array.CopyTo(_temp, 0);

                array =  new T[array.Length+1];
                _temp.CopyTo(array, 0);
                array[array.Length - 1] = newElement;

                return array;
            }
            /// <summary>
            /// Add and Element to the array, verry heavy use it in editor only.with an additional action
            /// </summary>
            /// <typeparam name="T">Type of the array</typeparam>
            /// <param name="array"> ref of the array</param>
            public static T[] Add<T>(ref T[] array, T newElement, UnityAction action)
            {
                Add(ref array, newElement);
                action.Invoke();
                return array;
            }
            /// <summary>
            /// Add and Element to the array, verry heavy use it in editor only. with an additional action on new element
            /// </summary>
            /// <typeparam name="T">Type of the array</typeparam>
            /// <param name="array"> ref of the array</param>
            public static T[] Add<T>(ref T[] array, T newElement, UnityAction<T> action)
            {
                Add(ref array, newElement);
                action.Invoke(newElement);
                return array;
            }
            
            /// <summary>
            /// Does the list contain an item that match the Predicate ? 
            /// </summary>
            public static bool ContainsByPredicate<T> (this List<T> array, System.Predicate<T> predicate)
            {
                foreach (T item in array)
                {
                    if(predicate.Invoke(item))
                    {
                        return true;
                    }
                }

                return false;
            }
            /// <summary>
            /// Does the Array contain an item that match the Predicate ? 
            /// </summary>
            public static bool ContainsByPredicate<T> (this T[] array, System.Predicate<T> predicate)
            {
                foreach (T item in array)
                {
                    if(predicate.Invoke(item))
                    {
                        return true;
                    }
                }

                return false;
            }
            
            /// <summary>
            /// Launch a System.Action<T> on each memeber of the array
            /// </summary>
            public static void LaunchAction<T> (this T[] array, System.Action<T> action)
            {
                foreach (var item in array)
                {
                    action(item);      
                }
            }
            /// <summary>
            /// Launch a System.Action<T> on each memeber of the List
            /// </summary>
            public static void LaunchAction<T>(this List<T> list, System.Action<T> action)
            {
                foreach (var item in list)
                {
                    action(item);
                }
            }

            /// <summary>
            /// convert T array to child C array
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="C"></typeparam>
            /// <param name="array"></param>
            /// <returns></returns>
            public static C[] ConvertToChild<T, C>(this T[] array) where C : T
            {
                var _tempList = new List<C>();
                foreach (var item in array)
                {
                    if (item.GetType() == typeof(C) || item.GetType().IsSubclassOf(typeof(C)))
                    {
                        _tempList.Add((C)item);
                    }
                }

                var _returnArray = new C[_tempList.Count];

                for (int i = _tempList.Count-1; i >=0; i--)
                {
                    _returnArray[i] = _tempList[i];
                }

                return _returnArray;
            }
            public static string[] ConvertToIndexArray(  int min, int max)
            {
              var  list = new string[max - min];
                for (int i = min; i < max; i++)
                {
                    list[i-min] = (i).ToString();
                }
                return list;
            }

            public static T GetRandomElement<T>(this List<T> list)
            {
                return list[Random.Range(0, list.Count)];
            }
            public static T GetRandomElement<T>(this T[] list)
            {
                return list[Random.Range(0, list.Length)];
            }
        }
    }
}
