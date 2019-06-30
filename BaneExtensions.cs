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
      if (_value >= _start && _value <= _end)
      {
        return true;
      }
      return false;
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
      if (_value >= _start && _value <= _end)
      {
        return true;
      }
      return false;
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

    public static bool CanSee(this Transform _start, Transform _target)
    {
      RaycastHit hit;
      if (Physics.Linecast(_start.position, _target.position, out hit))
        if (hit.collider.transform != _target)
          return false;
      return true;
    }
    #endregion
  }
}