
/*
WARNING: THIS FILE IS AUTO-GENERATED. DO NOT MODIFY.

This file was generated from example.idl
using RTI Code Generator (rtiddsgen) version 3.1.0.
The rtiddsgen tool is part of the RTI Connext DDS distribution.
For more information, type 'rtiddsgen -help' at a command shell
or consult the Code Generator User's Manual.
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using Rti.Types;
using System.Linq;
using Omg.Types;

public static class position_topic_name
{
    public const string Value = "PositionTopic";
}
public static class qos_library
{
    public const string Value = "MyLibrary";
}
public static class qos_profile
{
    public const string Value = "MyProfile";
}
public class Point :  IEquatable<Point>
{
    public double x { get; set; }

    public double y { get; set; }

    public double z { get; set; }

    public Point()
    {
    }

    public Point(double  x, double  y, double  z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Point(Point other)
    {
        if (other == null)
        {
            return;
        }

        this.x = other.x;
        this.y = other.y;
        this.z = other.z;

    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(x);
        hash.Add(y);
        hash.Add(z);

        return hash.ToHashCode();
    }

    public bool Equals(Point other)
    {
        if (other == null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return this.x.Equals(other.x) &&
        this.y.Equals(other.y) &&
        this.z.Equals(other.z);
    }

    public override bool Equals(object obj) => this.Equals(obj as Point);

    public override string ToString() => PointSupport.Instance.ToString(this);
}

public class MyType :  IEquatable<MyType>
{
    [Key]
    public int id { get; set; }

    public Point point { get; set; }

    public MyType()
    {
        point = new Point();
    }

    public MyType(int  id, Point  point)
    {
        this.id = id;
        this.point = point;
    }

    public MyType(MyType other)
    {
        if (other == null)
        {
            return;
        }

        this.id = other.id;
        this.point = new Point(other.point);

    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(id);
        hash.Add(point);

        return hash.ToHashCode();
    }

    public bool Equals(MyType other)
    {
        if (other == null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return this.id.Equals(other.id) &&
        this.point.Equals(other.point);
    }

    public override bool Equals(object obj) => this.Equals(obj as MyType);

    public override string ToString() => MyTypeSupport.Instance.ToString(this);
}

