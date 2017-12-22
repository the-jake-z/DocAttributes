# DocAttributes

[![Build status](https://ci.appveyor.com/api/projects/status/xemthlllskj6adu2/branch/master?svg=true)](https://ci.appveyor.com/project/jzarob/docattributes/branch/master)

In .NET, developers have typically used C#/VB XML comments to document their code. This is the officially supported way
to add additional content to IntelliSense.

The XML comments that have been used are parsed at build time and dropped into an XML file of the output directory.
The XML file contains a myriad of targets with no hierarchy. It also dumps information about the entire assembly,
leading to massive XML files that can be megabytes in size. The only distinguishing marks for types,
methods, properties inside of the XML contents are the name prefixes whitch start with T:, M:, and P: respectively.

Additionally, since the data is stored in comments in the code, the documentation for available types, methods,
parameters and other targets is not available at runtime. Creating API's that are self documenting becomes impossible
if you're using XML comments.

However, by moving the metadata stored in the XML comments into attributes, we can make target metadata available at 
runtime by utilizing reflection. Additionally, we can develop an easy to understand hierarchy that takes a more object
oriented approach to representing the target metadata.

Other glaring omissions from the XML comments are types, which aren't included. Although type information may not be
necessary when you have the DLL, when providing a documentation service, the type information is crucial to allow
developers to better understanding the API.

## Example

```csharp
using System;
using DocAttributes;
using DocAttributes.Targets;
using Newtownsoft.Json;

namespace AttributeExample
{
    [Summary("This class is an example class")]
    public class A { }
    
    class Program
    {
        static void Main(string[] args) 
        {
            var typeTarget = new TypeTarget(typeof(A));
            
            Console.WriteLine(JsonConvert.SerializeObject(typeTarget));
        }
    }
}
```

Will write the following to the console:

```js
{
    "Methods": [],
    "Fields": [],
    "Parent": "System.Object, mscorlib, Version=X.X.X.X, Culture=neutral, PublicKeyToken=XXXXXXXXX",
    "Name": "AttributeExample.A, AttributeExample, Version=X.X.X.X, Culture=neutral, PublicKeyToken=XXXXXXXX",
    "Summary": "This is an example class"
}
```

An example documentation structure for the DocAttributes library itself is available [on GitHub](https://github.com/jzarob/DocAttributes/blob/master/Example/DocAttributes.json)

## Available Attributes

### AvailableSince

|Targets                     |Inheritable|Allows Multiple|
|----------------------------|-----------|---------------|
|All                         |True       |False          |

### ModifiedVersion

|Targets                     |Inheritable|Allows Multiple|
|----------------------------|-----------|---------------|
|All                         |True       |True           |

### MustSet

|Targets                     |Inheritable|Allows Multiple|
|----------------------------|-----------|---------------|
|Property, Field, Event      |True       |True           |

### SeeAlso

|Targets                     |Inheritable|Allows Multiple|
|----------------------------|-----------|---------------|
|All                         |False      |False          |

### Summary

|Targets                     |Inheritable|Allows Multiple|
|----------------------------|-----------|---------------|
|All                         |False      |False          |