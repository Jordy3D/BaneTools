using System;
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

  public static class BaneExtenstions
  {
    #region Maths

    #endregion

    #region Transforms
    /// <summary>
    /// Returns true if the dot product of the objects reference direction is closer to the target direction being checked than the opposite direction. 
    /// <para>The Reference Axis is normal circumstances would be transform.up, while the Target Axis would be Vector3.Down. This returns true if the object's up is closer to world down than not. </para>
    /// <para>The Threshold is how close it needs to get before considering itself tilted. Closer to 1 means closer to the Target Axis. </para>
    /// </summary>
    /// <param name="_object"></param>
    /// <param name="_referenceAxis"></param>
    /// <param name="_targetAxis"></param>
    /// <param name="_threshold"></param>
    /// <returns></returns>
    public static bool Tilted(this Transform _object, Vector3 _referenceAxis, Vector3 _targetAxis, float _threshold = 0)
    {
      float _tiltAmount = Vector3.Dot(_referenceAxis, _targetAxis);

      return _tiltAmount > _threshold;
    }
    public static float Tilt(this Transform _object, Vector3 _referenceAxis, Vector3 _targetAxis)
    {
      return Vector3.Dot(_referenceAxis, _targetAxis);
    }
    #endregion

    #region Checks
    public static bool AllEqual(this bool[] _array, bool _value)
    {
      int count = 0;
      foreach (var element in _array)
        if (element == _value)
          count++;

      return count == _array.Length;
    }

    public static bool[] Set(this bool[] _array, bool _value)
    {
      bool[] setArray = _array;
      for (int i = 0; i < setArray.Length; i++)
        setArray[i] = false;

      return setArray;
    }

    #endregion
  }

  public static class BaneTransform
  {
    /// <summary>
    /// Destroys all child objects.
    /// </summary>
    /// <param name="transform"></param>
    public static void Clear(this Transform transform)
    {
      foreach (Transform child in transform)
        GameObject.Destroy(child.gameObject);
    }


    /// <summary>
    /// Multiplies the scale of the object provided in World Space.
    /// </summary>
    /// <param name="_object"></param>
    /// <param name="_parent"></param>
    /// <param name="_scale"></param>
    public static void SetWorldScale(Transform _object, Transform _parent, float _scale)
    {
      _object.SetParent(null);
      _object.localScale = BaneMath.MultipliedVector3(_object.localScale, _scale);
      _object.SetParent(_parent);
    }


    public static void UnParent(this Transform _transform)
    {
      _transform.SetParent(null);
    }
  }

  public static class BaneMath
  {
    public static Vector2 centre = new Vector2(.5f, .5f);
    /// <summary>
    /// Centre of the screen. Useful for First Person situations.
    /// </summary>
    public static Vector2 screenCentre = new Vector2((Screen.width / 2), (Screen.height / 2));


    /// <summary>
    /// Returns distance from this transform to another.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static float Distance(this Transform _pointA, Transform _pointB)
    {
      return Vector3.Distance(_pointA.position, _pointB.position);
    }
    
    /// <summary>
    /// Returns direction from this transform to another.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static Vector3 Direction(this Transform _pointA, Transform _pointB)
    {
      return (_pointB.position - _pointA.position).normalized;
    }


    /// <summary>
    /// Remaps a value from a point in a range to a point in another range and returns it as a float.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_from1"></param>
    /// <param name="_to1"></param>
    /// <param name="_from2"></param>
    /// <param name="_to2"></param>
    /// <returns></returns>
    public static float Remap(this float _value, float _from1, float _to1, float _from2, float _to2)
    {
      return (_value - _from1) / (_to1 - _from1) * (_to2 - _from2) + _from2;
    }
    /// <summary>
    /// Remaps a value from a point in a range to a point in another range and returns it as a float.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_from1"></param>
    /// <param name="_to1"></param>
    /// <param name="_from2"></param>
    /// <param name="_to2"></param>
    /// <returns></returns>
    public static float Remap(this int _value, float _from1, float _to1, float _from2, float _to2)
    {
      return (_value - _from1) / (_to1 - _from1) * (_to2 - _from2) + _from2;
    }

    /// <summary>
    /// Returns true if given value is within the provided start and end values.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_start"></param>
    /// <param name="_end"></param>
    /// <returns></returns>
    public static bool WithinRange(this float _value, float _start, float _end)
    {
      return _value >= _start && _value <= _end;
    }
    /// <summary>
    /// Returns true if given value is within the provided start and end values.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_start"></param>
    /// <param name="_end"></param>
    /// <returns></returns>
    public static bool WithinRange(this int _value, float _start, float _end)
    {
      return _value >= _start && _value <= _end;
    }

    /// <summary>
    /// Returns the midpoint between two Vector3 values.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static Vector3 MidPoint(this Vector3 _pointA, Vector3 _pointB)
    {
      return (_pointA + _pointB) / 2;
    }
    /// <summary>
    /// Returns the midpoint between two Vector2 values.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static Vector2 MidPoint(this Vector2 _pointA, Vector2 _pointB)
    {
      return (_pointA + _pointB) / 2;
    }

    /// <summary>
    /// Returns true if point A is within a given distance to point B.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <param name="_dist"></param>
    /// <returns></returns>
    public static bool CloseTo(this Vector3 _pointA, Vector3 _pointB, float _dist)
    {
      if (_pointA.x.WithinRange(_pointB.x + -_dist, _pointB.x + _dist) && _pointA.y.WithinRange(_pointB.y + -_dist, _pointB.y + _dist) && _pointA.z.WithinRange(_pointB.z + -_dist, _pointB.z + _dist))
      {
        return true;
      }
      return false;
    }
    /// <summary>
    /// Returns true if point A is within a given distance to point B.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <param name="_dist"></param>
    /// <returns></returns>
    public static bool CloseTo(this Vector2 _pointA, Vector2 _pointB, float _dist)
    {
      if (_pointA.x.WithinRange(_pointB.x + -_dist, _pointB.x + _dist) && _pointA.y.WithinRange(_pointB.y + -_dist, _pointB.y + _dist))
      {
        return true;
      }
      return false;
    }

    #region Vector Combinations
    /// <summary>
    /// Adds a given value to both the X and Y of a Vector2.
    /// </summary>
    /// <param name="_vector2"></param>
    /// <param name="_value"></param>
    /// <returns></returns>
    public static Vector2 AddedVector2(Vector2 _vector2, float _value)
    {
      Vector2 _addedVector2 = new Vector2(_vector2.x + _value, _vector2.y + _value);
      return _addedVector2;
    }
    /// <summary>
    /// Adds a given value to the X and a given value to the Y of a Vector2.
    /// </summary>
    /// <param name="_vector2"></param>
    /// <param name="_valueX"></param>
    /// <param name="_valueY"></param>
    /// <returns></returns>
    public static Vector2 SplitAddedVector2(Vector2 _vector2, float _valueX, float _valueY)
    {
      Vector2 _splitAddedVector2 = new Vector2(_vector2.x + _valueX, _vector2.y + _valueY);
      return _splitAddedVector2;
    }
    /// <summary>
    /// Multiplies a given value to both the X and Y of a Vector2.
    /// </summary>
    /// <param name="_vector2"></param>
    /// <param name="_value"></param>
    /// <returns></returns>
    public static Vector2 MultipliedVector2(Vector2 _vector2, float _value)
    {
      Vector2 _addedVector2 = new Vector2(_vector2.x * _value, _vector2.y * _value);
      return _addedVector2;
    }
    /// <summary>
    /// Multiplies a given value to the X and a given value to the Y of a Vector2.
    /// </summary>
    /// <param name="_vector2"></param>
    /// <param name="_valueX"></param>
    /// <param name="_valueY"></param>
    /// <returns></returns>
    public static Vector2 SplitMultipliedVector2(Vector2 _vector2, float _valueX, float _valueY)
    {
      Vector2 _splitAddedVector2 = new Vector2(_vector2.x * _valueX, _vector2.y * _valueY);
      return _splitAddedVector2;
    }
    /// <summary>
    /// Adds a given value to both the X, Y and Z of a Vector3.
    /// </summary>
    /// <param name="_vector3"></param>
    /// <param name="_value"></param>
    /// <returns></returns>
    public static Vector3 AddedVector3(Vector3 _vector3, float _value)
    {
      Vector3 _addedVector3 = new Vector3(_vector3.x + _value, _vector3.y + _value, _vector3.z + _value);
      return _addedVector3;
    }
    /// <summary>
    /// Adds a given value to the X, a given value to the Y, and a given value to the Z of a Vector3.
    /// </summary>
    /// <param name="_vector3"></param>
    /// <param name="_valueX"></param>
    /// <param name="_valueY"></param>
    /// <param name="_valueZ"></param>
    /// <returns></returns>
    public static Vector3 SplitAddedVector3(Vector3 _vector3, float _valueX, float _valueY, float _valueZ)
    {
      Vector3 _splitAddedVector3 = new Vector3(_vector3.x + _valueX, _vector3.y + _valueY, _vector3.z + _valueZ);
      return _splitAddedVector3;
    }
    /// <summary>
    /// Multiples a given value to both the X, Y and Z of a Vector3.
    /// </summary>
    /// <param name="_vector3"></param>
    /// <param name="_value"></param>
    /// <returns></returns>
    public static Vector3 MultipliedVector3(Vector3 _vector3, float _value)
    {
      Vector3 _addedVector3 = new Vector3(_vector3.x * _value, _vector3.y * _value, _vector3.z * _value);
      return _addedVector3;
    }
    /// <summary>
    /// Multiplies a given value to the X, a given value to the Y, and a given value to the Z of a Vector3.
    /// </summary>
    /// <param name="_vector3"></param>
    /// <param name="_valueX"></param>
    /// <param name="_valueY"></param>
    /// <param name="_valueZ"></param>
    /// <returns></returns>
    public static Vector3 SplitMultipliedVector3(Vector3 _vector3, float _valueX, float _valueY, float _valueZ)
    {
      Vector3 _splitAddedVector3 = new Vector3(_vector3.x * _valueX, _vector3.y * _valueY, _vector3.z * _valueZ);
      return _splitAddedVector3;
    }

    /// <summary>
    /// Adds the X, Y and Z of one Vector3 to the X, Y and Z of another Vector3.
    /// </summary>
    /// <param name="_v1"></param>
    /// <param name="_v2"></param>
    /// <returns></returns>
    public static Vector3 CombinedVector3(Vector3 _v1, Vector3 _v2)
    {
      Vector3 _addedVector3 = new Vector3(_v1.x + _v2.x, _v1.y + _v2.y, _v1.z + _v2.z);
      return _addedVector3;
    }
    /// <summary>
    /// Mulitplies the X, Y and Z of one Vector3 to the X, Y and Z of another Vector3.
    /// </summary>
    /// <param name="_v1"></param>
    /// <param name="_v2"></param>
    /// <returns></returns>
    public static Vector3 MultiplyCombinedVector3(Vector3 _v1, Vector3 _v2)
    {
      Vector3 _addedVector3 = new Vector3(_v1.x * _v2.x, _v1.y * _v2.y, _v1.z * _v2.z);
      return _addedVector3;
    }
    #endregion


    /// <summary>
    /// Divides one int by another and returns a float.
    /// </summary>
    /// <param name="_a"></param>
    /// <param name="_b"></param>
    /// <returns></returns>
    public static float DivideInts(int _a, int _b)
    {
      return ((float)_a / (float)_b);
    }


  }

  public static class BaneRays
  {
    /// <summary>
    /// Casts a ray down. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastDown(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, -_start.up, Color.green, 0, false);

      return Physics.Raycast(_start.position, -_start.up, _dist);
    }

    /// <summary>
    /// Casts a ray up. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastUp(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, _start.up, Color.green, 0, false);

      return Physics.Raycast(_start.position, _start.up, _dist);
    }

    /// <summary>
    /// Casts a ray forward. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastForward(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, _start.forward, Color.blue, 0, false);

      return Physics.Raycast(_start.position, _start.forward, _dist);
    }

    public static RaycastHit RayForward(this Transform _start, float _dist = 100)
    {
      Physics.Raycast(_start.position, _start.forward, out RaycastHit hit, _dist);
      return hit;
    }

    public static RaycastHit NewRay(this Transform _start, Vector3 _dir, float _dist = 100)
    {
      Physics.Raycast(_start.position, _dir, out RaycastHit hit, _dist);
      return hit;
    }

    public static RaycastHit SphereForward(this Transform _start, float _radius = 1, float _dist = 100)
    {
      Physics.SphereCast(_start.position, _radius, _start.forward, out RaycastHit hit, _dist);
      return hit;
    }

    /// <summary>
    /// Casts a ray back. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastBackward(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, -_start.forward, Color.red, 0, false);

      return Physics.Raycast(_start.position, -_start.forward, _dist) ? true : false;
    }

    /// <summary>
    /// Casts a ray forward. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastLeft(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, -_start.right, Color.red, 0, false);

      return Physics.Raycast(_start.position, -_start.right, _dist) ? true : false;
    }

    /// <summary>
    /// Casts a ray back. Returns true if a hit is detected.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dist"></param>
    /// <param name="_debug"></param>
    /// <returns></returns>
    public static bool CastRight(this Transform _start, float _dist, bool _debug = false)
    {
      if (_debug)
        Debug.DrawRay(_start.position, _start.right, Color.red, 0, false);

      return Physics.Raycast(_start.position, _start.right, _dist) ? true : false;
    }

    /// <summary>
    /// In order to avoid the annoyances of Unity's 2D raycast system, this acts like you would expect the 3D raycast to.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_dir"></param>
    /// <param name="_dist"></param>
    /// <param name="_color"></param>
    /// <returns></returns>
    public static RaycastHit2D GetFirstHit(this Vector3 _start, Vector2 _dir, float _dist, Color _color, bool _debug = false)
    {
      RaycastHit2D[] hits = new RaycastHit2D[2];
      if (_debug)
        Debug.DrawRay(_start, _dir, _color, _dist);
      Physics2D.RaycastNonAlloc(_start, _dir, hits, _dist);

      return hits[1];
    }

    /// <summary>
    /// Returns true if there is an unbroken line of sight to the target from the source.
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_target"></param>
    /// <returns></returns>
    public static bool CanSee(this Transform _start, Transform _target)
    {
      RaycastHit hit;
      if (Physics.Linecast(_start.position, _target.position, out hit))
        if (hit.collider.transform != _target)
          return false;
      return true;
    }

    public static float KinematicVelocity(this Transform _object, Vector3 _lastPosition)
    {
      var pos = _object.position;
      var diff = (pos - _lastPosition);
      var velocity = diff / Time.deltaTime;

      var outVel = velocity.magnitude;

      return outVel;
    }
  }

  public static class BaneStrings
  {
    /// <summary>
    /// Formats a string with a color for use with Unity's acceptance of coloured console lines.
    /// Example usage: print(BaneTools.ColorString("MyString", "red"));
    /// </summary>
    /// <param name="_string"></param>
    /// <param name="_colour"></param>
    /// <returns></returns>
    public static string ColorString(this string _string, string _colour)
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
    public static string ColorString(this string _string, Color _colour)
    {
      Color32 colour = _colour;
      string _hex = string.Format("#{0:X2}{1:X2}{2:X2}", colour.r, colour.g, colour.b);

      return string.Format("<color={0}>{1}</color>", _hex, _string);
    }
  }

  public static class BaneColour
  {
    /// <summary>
    /// Returns a Color from given R, G and B values.
    /// </summary>
    /// <param name="_r">Red Channel 0 - 255</param>
    /// <param name="_g">Green Channel 0 - 255</param>
    /// <param name="_b">Blue Channel 0 - 255</param>
    /// <returns></returns>
    public static Color Color255(float _r, float _g, float _b, float _a = 255)
    {
      return new Color(_r / 255, _g / 255, _b / 255, _a / 255);
    }


    public static Vector3 ColourToPercentage(Color _col)
    {
      return BaneMath.MultipliedVector3(ColourToVector3(_col), 100);
    }

    public static Vector3 ColourToVector3(Color _col)
    {
      return new Vector3(_col.r, _col.g, _col.b);
    }

    public static Color ColourFromVector3(Vector3 _col)
    {
      Color newColour = Color.black;
      newColour.r = _col.x;
      newColour.g = _col.y;
      newColour.b = _col.z;
      newColour.a = 1;
      return newColour;
    }
  }

  public static class BaneGizmos
  {
    public static Color defaultColor = Color.white;

    /// <summary>
    /// Currently slightly broken. Draws a shape of n sides.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="direction"></param>
    /// <param name="radius"></param>
    /// <param name="sideCount"></param>
    /// <param name="color"></param>
    public static void DrawNgon(Vector3 pos, Vector3 direction, float radius, int sideCount, Color? color = null)
    {
      if (color != null)
        Gizmos.color = (Color)color;

      float rotVal;
      float nextRotVal;

      for (int i = 0; i < sideCount; i++)
      {
        rotVal = (i == 0 ? 0 : (360 / sideCount) * i);
        nextRotVal = (i == sideCount ? 0 : (360 / sideCount) * (i - 1));

        //Vector3 newRot = (Quaternion.LookRotation(direction) * Quaternion.Euler(0, rotVal + (sideCount == 4 ? 45 : 0), 0) * direction);
        //Vector3 prevRot = (Quaternion.LookRotation(direction) * Quaternion.Euler(0, nextRotVal + (sideCount == 4 ? 45 : 0), 0) * direction); 

        Vector3 newRot = (Quaternion.LookRotation(direction) *
          Quaternion.Euler(0, rotVal, 0) *
          new Vector3(Mathf.RoundToInt(direction.x), 0, 1));
        Vector3 prevRot = (Quaternion.LookRotation(direction) *
          Quaternion.Euler(0, nextRotVal, 0) *
          new Vector3(Mathf.RoundToInt(direction.x), 0, 1));

        Gizmos.DrawLine(pos + newRot * radius, pos + prevRot * radius);
      }
    }

    /// <summary>
    /// Draws an arrow in a direction from a position. Multiply direction by a value to change arrow length. Borrowed from https://forum.unity.com/threads/debug-drawarrow.85980/
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="direction"></param>
    /// <param name="color"></param>
    /// <param name="arrowHeadLength"></param>
    /// <param name="arrowHeadAngle"></param>
    public static void DrawArrow(Vector3 pos, Vector3 direction, Color? color = null, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
      // 
      if (color != null)
        Gizmos.color = (Color)color;

      Gizmos.DrawRay(pos, direction);

      Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
      Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);



      Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
      Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }


  }


  public enum Direction
  {
    Forward = 0,
    Back = 1,
    Left = 2,
    Right = 3,
    Up = 4,
    Down = 5
  }
  public enum Space
  {
    Local = 0,
    World = 1
  }
  public enum Axis
  {
    X = 0,
    Y = 1,
    Z = 2,
    XY = 3,
    XZ = 4,
    YZ = 5,
    XYZ = 6
  }
}