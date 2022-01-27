# dds_pro_labs_cs
C# version of Connext Professional hands-on learning material

## Lab 00. "As generated" code

- This lab contains unmodified type-support code and an example application that was generated with the following command:
```
%NDDSHOME%\bin\rtiddsgen.bat -language c# -example net5 -ppDisable example.idl
```
- Note that in the *.csproj file, the line: 
```
<PackageReference Include="System.CommandLine" Version="2.0.0-*" /> 
```
was changed to:
``` 
<PackageReference Include="System.CommandLine" Version="2.0.0-beta1.21308.1" />
```
  - see https://community.rti.com/kb/how-fix-error-cs0234-type-or-namespace-name-commandhandler-does-not-exist-connext-dds-c-examples for more detail regarding why this is needed.

## Lab 01. Add some "dummy data" 

- Let's make the following changes to the publisher. In `examplePublisher.cs` make the following changes in the writing loop:
  - Set `sample.id` to a constant number
  - Give dynamic values to `sample.point.[x|y|z]`

## Lab 02. Deadline QoS

- In `USER_QOS_PROFILES.xml`, add a `deadline` section to the DataReader Qos. 
  - Observe that no data flows; this is because we also need to have the DataWriter offer a deadline 
    - fix the issue in XML
- Use Admin Console to observe that a QoS mismatch exists
- Use handlers in `exampleSubscriber.cs` to programmatically learn about 
  - any QoS mismatch
  - any deadline missed events
  - *NOTE* The waitset must be configured before the handers-- this is due to known issue CORE-11125

## Lab 03. Add constants to IDL, use them in the source

- We can declare const strings in the IDL so that string literals do not have to be manually entered in source. Let's do that for:
  - The Topic name
  - The QoS library and profile
- The type support code now needs to be regenerated, but be careful not to overwrite the example files
```
%NDDSHOME%\bin\rtiddsgen.bat -language c# -update typefiles -ppDisable example.idl

```
- Update `examplePublisher.cs` and `exampleSubscriber.cs` to use these constants.