# dds_pro_labs_cs
C# version of Connext Professional hands-on learning material

## 00 - "As generated" code
- Generate type-support code and an example application with the following command:
```
%NDDSHOME%\bin\rtiddsgen.bat -language c# -example net5 -ppDisable example.idl
```
- In the *.csproj file, change 
```
<PackageReference Include="System.CommandLine" Version="2.0.0-*" /> 
```
to
``` 
<PackageReference Include="System.CommandLine" Version="2.0.0-beta1.21308.1" />
```
  - see https://community.rti.com/kb/how-fix-error-cs0234-type-or-namespace-name-commandhandler-does-not-exist-connext-dds-c-examples for more detail regarding why this is needed.