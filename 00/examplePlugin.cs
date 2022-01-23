/*
WARNING: THIS FILE IS AUTO-GENERATED. DO NOT MODIFY.

This file was generated from example.idl
using RTI Code Generator (rtiddsgen) version 3.1.0.
The rtiddsgen tool is part of the RTI Connext DDS distribution.
For more information, type 'rtiddsgen -help' at a command shell
or consult the Code Generator User's Manual.
*/

using System;
using System.Runtime.InteropServices;
using Omg.Types;
using Omg.Types.Dynamic;
using Rti.Types;
using Rti.Dds.Core;
using Rti.Types.Dynamic;
using Rti.Dds.NativeInterface.TypePlugin;

namespace Implementation
{
    public struct PointUnmanaged : Rti.Dds.NativeInterface.TypePlugin.INativeTopicType<Point>
    {

        private double x;
        private double y;
        private double z;

        public void Destroy(bool optionalsOnly)
        {
        }

        public void FromNative(Point sample, bool keysOnly = false)
        {

            sample.x = x;
            sample.y = y;
            sample.z = z;
        }

        public void Initialize(bool allocatePointers = true, bool allocateMemory = true)
        {
            x = (double) 0.0;
            y = (double) 0.0;
            z = (double) 0.0;
        }

        public void ToNative(Point sample, bool keysOnly = false)
        {
            x = sample.x;
            y = sample.y;
            z = sample.z;
        }
    }

    internal class PointPlugin : Rti.Dds.NativeInterface.TypePlugin.InterpretedTypePlugin<Point, PointUnmanaged>
    {
        internal PointPlugin() : base("Point", isKeyed: false, CreateDynamicType(isPublic: false))
        {
        }

        public static DynamicType CreateDynamicType(bool isPublic = true)
        {
            var dtf = ServiceEnvironment.Instance.Internal.GetTypeFactory(isPublic);
            var tsf = ServiceEnvironment.Instance.Internal.TypeSupportFactory;

            // Point struct
            var PointStructMembers = new StructMember[]
            {
                new StructMember("x", dtf.GetPrimitiveType<double>(), id: 0),
                new StructMember("y", dtf.GetPrimitiveType<double>(), id: 1),
                new StructMember("z", dtf.GetPrimitiveType<double>(), id: 2)
            };

            return tsf.CreateTypeWithAccessInfo<PointUnmanaged>(
                dtf.BuildStruct()
                .WithExtensibility(ExtensibilityKind.Extensible)
                .WithName("Point")
                .AddMembers(PointStructMembers));
        }
    }
}

public class PointSupport : Rti.Dds.Topics.TypeSupport<Point>
{
    public PointSupport() : base(
        new Implementation.PointPlugin(),
        new Lazy<DynamicType>(() =>Implementation.PointPlugin.CreateDynamicType(isPublic: true)))
    {
    }

    public static PointSupport Instance { get; } =
    ServiceEnvironment.Instance.Internal.TypeSupportFactory.CreateTypeSupport<PointSupport, Point>();
}

namespace Implementation
{
    public struct MyTypeUnmanaged : Rti.Dds.NativeInterface.TypePlugin.INativeTopicType<MyType>
    {

        private int id;
        private global::Implementation.PointUnmanaged point;

        public void Destroy(bool optionalsOnly)
        {
            if (optionalsOnly)
            {
                return;
            }
            point.Destroy(optionalsOnly);
        }

        public void FromNative(MyType sample, bool keysOnly = false)
        {

            sample.id = id;
            if (keysOnly)
            {
                return;
            }
            point.FromNative(sample.point, keysOnly: keysOnly);
        }

        public void Initialize(bool allocatePointers = true, bool allocateMemory = true)
        {
            id = (int) 0;
            point.Initialize(allocatePointers, allocateMemory);
        }

        public void ToNative(MyType sample, bool keysOnly = false)
        {
            id = sample.id;
            if (keysOnly)
            {
                return;
            }
            point.ToNative(sample.point, keysOnly: keysOnly);
        }
    }

    internal class MyTypePlugin : Rti.Dds.NativeInterface.TypePlugin.InterpretedTypePlugin<MyType, MyTypeUnmanaged>
    {
        internal MyTypePlugin() : base("MyType", isKeyed: true, CreateDynamicType(isPublic: false))
        {
        }

        public static DynamicType CreateDynamicType(bool isPublic = true)
        {
            var dtf = ServiceEnvironment.Instance.Internal.GetTypeFactory(isPublic);
            var tsf = ServiceEnvironment.Instance.Internal.TypeSupportFactory;

            // MyType struct
            var MyTypeStructMembers = new StructMember[]
            {
                new StructMember("id", dtf.GetPrimitiveType<int>(), isKey: true, id: 0),
                new StructMember("point", PointSupport.Instance.GetDynamicTypeInternal(isPublic), id: 1)
            };

            return tsf.CreateTypeWithAccessInfo<MyTypeUnmanaged>(
                dtf.BuildStruct()
                .WithExtensibility(ExtensibilityKind.Extensible)
                .WithName("MyType")
                .AddMembers(MyTypeStructMembers));
        }
    }
}

public class MyTypeSupport : Rti.Dds.Topics.TypeSupport<MyType>
{
    public MyTypeSupport() : base(
        new Implementation.MyTypePlugin(),
        new Lazy<DynamicType>(() =>Implementation.MyTypePlugin.CreateDynamicType(isPublic: true)))
    {
    }

    public static MyTypeSupport Instance { get; } =
    ServiceEnvironment.Instance.Internal.TypeSupportFactory.CreateTypeSupport<MyTypeSupport, MyType>();
}

