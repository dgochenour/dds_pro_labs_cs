/*
* (c) Copyright, Real-Time Innovations, 2021.  All rights reserved.
* RTI grants Licensee a license to use, modify, compile, and create derivative
* works of the software solely for use with RTI Connext DDS. Licensee may
* redistribute copies of the software provided that all such copies are subject
* to this license. The software is provided "as is", with no warranty of any
* type, including any warranty for fitness for any purpose. RTI is under no
* obligation to maintain or support the software. RTI shall not be liable for
* any incidental or consequential damages arising out of the use or inability
* to use the software.
*/

using System;
using System.Threading;
using Rti.Dds.Core;
using Rti.Dds.Domain;
using Rti.Dds.Publication;
using Rti.Dds.Topics;

/// <summary>
/// Example application that publishes MyType.
/// </summary>
public static class MyTypePublisher
{
    /// <summary>
    /// Runs the publisher example.
    /// </summary>
    public static void RunPublisher(int domainId, int sampleCount)
    {
        // A DomainParticipant allows an application to begin communicating in
        // a DDS domain. Typically there is one DomainParticipant per application.
        // DomainParticipant QoS is configured in USER_QOS_PROFILES.xml
        //
        // A participant needs to be Disposed to release middleware resources.
        // The 'using' keyword indicates that it will be Disposed when this
        // scope ends.
        using DomainParticipant participant = DomainParticipantFactory.Instance.CreateParticipant(domainId);

        // A Topic has a name and a datatype.
        Topic<MyType> topic = participant.CreateTopic<MyType>("Example MyType");

        // A Publisher allows an application to create one or more DataWriters
        // Publisher QoS is configured in USER_QOS_PROFILES.xml
        Publisher publisher = participant.CreatePublisher();

        // This DataWriter will write data on Topic "Example MyType"
        // DataWriter QoS is configured in USER_QOS_PROFILES.xml
        DataWriter<MyType> writer = publisher.CreateDataWriter(topic);

        var sample = new MyType();
        for (int count = 0; count < sampleCount; count++)
        {
            // Modify the data to be sent here
            // LAB #01 - populate each sample with dummy (arbitrary) data
            sample.id = 10;
            sample.point.x = Math.Sin(count);
            sample.point.y = Math.Cos(count);
            sample.point.z = Math.Tan(count);

            Console.WriteLine($"Writing MyType, count {count}");

            writer.Write(sample);

            Thread.Sleep(1000);
        }
    }
}
