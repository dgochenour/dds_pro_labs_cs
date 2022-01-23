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
