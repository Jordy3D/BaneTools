using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  public static class BaneExtenstions
  {
    #region Maths
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

    #region Rays
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
        Debug.DrawRay(_start.position, -_start.up, BaneTools.Color255(0, 255, 0), 0, false);

      return Physics.Raycast(_start.position, -_start.up, _dist) ? true : false;
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
        Debug.DrawRay(_start.position, _start.up, BaneTools.Color255(0, 255, 0), 0, false);

      return Physics.Raycast(_start.position, _start.up, _dist) ? true : false;
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
        Debug.DrawRay(_start.position, _start.forward, BaneTools.Color255(0, 0, 255), 0, false);

      return Physics.Raycast(_start.position, _start.forward, _dist) ? true : false;
    }

    public static RaycastHit RayForward(this Transform _start, float _dist = 100)
    {
      RaycastHit hit;
      Physics.Raycast(_start.position, _start.forward, out hit, _dist);
      return hit;
    }

    public static RaycastHit NewRay(this Transform _start, Vector3 _dir, float _dist = 100)
    {
      RaycastHit hit;
      Physics.Raycast(_start.position, _dir, out hit, _dist);
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
        Debug.DrawRay(_start.position, -_start.forward, BaneTools.Color255(0, 0, 255), 0, false);

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
        Debug.DrawRay(_start.position, -_start.right, BaneTools.Color255(255, 0, 0), 0, false);

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
        Debug.DrawRay(_start.position, _start.right, BaneTools.Color255(255, 0, 0), 0, false);

      return Physics.Raycast(_start.position, _start.right, _dist) ? true : false;
    }

    public static RaycastHit2D GetFirstHit(this Vector3 _start, Vector2 _dir, float _dist, Color _color)
    {
      RaycastHit2D[] hits = new RaycastHit2D[2];
      Debug.DrawRay(_start, _dir, _color, _dist);
      Physics2D.RaycastNonAlloc(_start, _dir, hits, _dist);

      return hits[1];
    }


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

    #endregion

    #region Checks
    public static bool AllEqual(this bool[] _array, bool _value)
    {
      int count = 0;
      foreach (var element in _array)
      {
        if (element == _value)
        {
          count++;
        }
      }

      return count == _array.Length ? true : false;
    }

    public static bool[] Set(this bool[] _array, bool _value)
    {
      bool[] setArray = _array;
      for (int i = 0; i < setArray.Length; i++)
      {
        setArray[i] = false;
      }

      return setArray;
    }
    #endregion

    #region Strings
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
      Color32 _thing = _colour;
      string _hex = string.Format("#{0:X2}{1:X2}{2:X2}", _thing.r, _thing.g, _thing.b);

      return string.Format("<color={0}>{1}</color>", _hex, _string);
    }
    #endregion
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