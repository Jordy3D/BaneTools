using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    /*
     ▄   ▄
    ▄██▄▄██▄          ╔╗ ┌─┐┌┐┌┌─┐█
    ███▀██▀██         ╠╩╗├─┤│││├┤ █
    ▀███████▀         ╚═╝┴ ┴┘└┘└─┘█
      ▀███████▄▄      ▀▀▀▀▀▀▀▀▀▀▀▀█▀
       ██████████▄
     ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▀ */
    public static class BaneTools
    {
        /// <summary>
        /// Formats a string with a color for use with Unity's acceptance of coloured console lines.
        /// Example usage: print(BaneTools.ColorString("MyString", "red"));
        /// </summary>
        /// <param name="_string"></param>
        /// <param name="_colour"></param>
        /// <returns></returns>
        public static string ColorString(string _string, string _colour)
        {
            return string.Format("<color={0}>{1}</color>", _colour, _string);
        }
        /// <summary>
        /// Formats a string with a color for use with Unity's acceptance of coloured console lines.
        /// Example usage: print(BaneTools.ColorString("MyString", BaneTools.Color255(255,0,0)));
        /// </summary>
        /// <param name="_string"></param>
        /// <param name="_colour"></param>
        /// <returns></returns>
        public static string ColorString(string _string, Color _colour)
        {
            Color32 _thing = _colour;
            string _hex = string.Format("#{0:X2}{1:X2}{2:X2}", _thing.r, _thing.g, _thing.b);

            return string.Format("<color={0}>{1}</color>", _hex, _string);
        }

        /// <summary>
        /// Returns a Color from given R, G and B values.
        /// </summary>
        /// <param name="_r">Red Channel 0 - 255</param>
        /// <param name="_g">Green Channel 0 - 255</param>
        /// <param name="_b">Blue Channel 0 - 255</param>
        /// <returns></returns>
        public static Color Color255(float _r, float _g, float _b)
        {
            Color color = new Color(_r / 255, _g / 255, _b / 255);
            return color;
        }
        /// <summary>
        /// Returns a Color from given R, G, B and A values.
        /// </summary>
        /// <param name="_r">Red Channel 0 - 255</param>
        /// <param name="_g">Green Channel 0 - 255</param>
        /// <param name="_b">Blue Channel 0 - 255</param>
        /// <param name="_a">Alpha Channel 0 - 1</param>
        /// <returns></returns>
        public static Color Color255(float _r, float _g, float _b, float _a)
        {
            Color color = new Color(_r / 255, _g / 255, _b / 255, _a);
            return color;
        }

        public static RaycastHit2D GetFirstHit(Vector2 _start, Vector2 _dir, float _dist, Color _color)
        {
            RaycastHit2D[] hits = new RaycastHit2D[2];
            Debug.DrawRay(_start, _dir, _color, _dist);
            Physics2D.RaycastNonAlloc(_start, _dir, hits, _dist);

            if (hits[1])
            {
                Debug.Log("I hit something!");
            }

            return hits[1];
        }
    }

    public static class BaneMath
    {
        public static Vector2 centre = new Vector2(.5f, .5f);

        public static Vector2 AddedVector2(Vector2 _vector2, float _value)
        {
            Vector2 _addedVector2 = new Vector2(_vector2.x + _value, _vector2.y + _value);
            return _addedVector2;
        }
        public static Vector2 SplitAddedVector2(Vector2 _vector2, float _valueX, float _valueY)
        {
            Vector2 _splitAddedVector2 = new Vector2(_vector2.x + _valueX, _vector2.y + _valueY);
            return _splitAddedVector2;
        }
        public static Vector2 MultipliedVector2(Vector2 _vector2, float _value)
        {
            Vector2 _addedVector2 = new Vector2(_vector2.x * _value, _vector2.y * _value);
            return _addedVector2;
        }
        public static Vector2 SplitMultipliedVector2(Vector2 _vector2, float _valueX, float _valueY)
        {
            Vector2 _splitAddedVector2 = new Vector2(_vector2.x * _valueX, _vector2.y * _valueY);
            return _splitAddedVector2;
        }

        public static Vector3 AddedVector3(Vector3 _vector3, float _value)
        {
            Vector3 _addedVector3 = new Vector3(_vector3.x + _value, _vector3.y + _value, _vector3.z + _value);
            return _addedVector3;
        }
        public static Vector3 SplitAddedVector3(Vector3 _vector3, float _valueX, float _valueY, float _valueZ)
        {
            Vector3 _splitAddedVector3 = new Vector3(_vector3.x + _valueX, _vector3.y + _valueY, _vector3.z + _valueZ);
            return _splitAddedVector3;
        }
        public static Vector3 MultipliedVector3(Vector3 _vector3, float _value)
        {
            Vector3 _addedVector3 = new Vector3(_vector3.x * _value, _vector3.y * _value, _vector3.z * _value);
            return _addedVector3;
        }
        public static Vector3 SplitMultipliedVector3(Vector3 _vector3, float _valueX, float _valueY, float _valueZ)
        {
            Vector3 _splitAddedVector3 = new Vector3(_vector3.x * _valueX, _vector3.y * _valueY, _vector3.z * _valueZ);
            return _splitAddedVector3;
        }

        /// <summary>
        /// Returns true if given value is within the provided start and end values.
        /// </summary>
        /// <param name="_value"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <returns></returns>
        public static bool NumberWithinRange(float _value, float _start, float _end)
        {
            if (_value >= _start && _value <= _end)
            {
                return true;
            }
            return false;
        }
    }
}
