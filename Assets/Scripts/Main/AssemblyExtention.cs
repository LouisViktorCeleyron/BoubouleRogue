using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LCStarterContent
{
    namespace Editor
    {
        public static class AssemblyExtention
        {    
            /// <summary>
            /// Get a list of all field in the class
            /// </summary>
            /// <typeparam name="T">type of the class</typeparam>
            /// <param name="target">shortcut to call the methods</param>
            /// <param name="exceptions">You do not want theses field to be includes</param>
            /// <returns></returns>
            public static List<string> GetFieldsName<T>(this T target, params string[] exceptions)
            {
                var _fields = typeof(T).GetFields();
                var _return = new List<string>();

                foreach (var field in _fields)
                {
                    var _name = field.Name;

                    var _isOk = true;
                    foreach (var _except in exceptions)
                    {
                        if (_except == _name)
                        {
                            _isOk = false;
                        }
                    }
                    if (_isOk)
                    {
                        _return.Add(_name);
                    }
                }

                return _return;
            }

            /// <summary>
            /// Get a list of all field in the class
            /// </summary>
            /// <param name="target">targetetd class</param>
            /// <param name="exceptions">You do not want theses field to be includes
            /// <returns></returns>
            public static List<string> GetFieldsName(this System.Type target, params string[] exceptions)
            {
                var _fields = target.GetFields();
                var _return = new List<string>();

                foreach (var field in _fields)
                {
                    var _name = field.Name;

                    var _isOk = true;
                    foreach (var _except in exceptions)
                    {
                        if (_except == _name)
                        {
                            _isOk = false;
                        }
                    }
                    if (_isOk)
                    {
                        _return.Add(_name);
                    }
                }

                return _return;
            }
         
            /// <summary>
            /// Get A list of all Type that are a subclass of the given parent
            /// </summary>
            public static List<System.Type> GetAllSubclassOf(this System.Type parentClass)
            {
                var _return = new List<System.Type>();

                //Get the assembly
                var _assembly = parentClass.Assembly;

                //Foreach on all type in the assembly
                foreach (var _type in _assembly.GetTypes())
                {
                    //Check if t is a child of Node Editor
                    if (_type.IsSubclassOf(parentClass))
                    {
                        //Add to the list if it's so
                        _return.Add(_type);
                    }
                }

                return _return;
            }
            /// <summary>
            /// Get the name of all the subclass of the entered Type
            /// </summary>
            public static string[] GetNamesOfAllSubclass(this System.Type parentClass)
            {
                var _allSubClass = parentClass.GetAllSubclassOf();
                var _return = new string[_allSubClass.Count];

                for (int i = 0; i < _allSubClass.Count; i++)
                {
                    _return[i] = _allSubClass[i].ToString();
                }

                return _return;
            }
        }
    }
}

