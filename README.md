# DocAttributes

[![Build status](https://ci.appveyor.com/api/projects/status/xemthlllskj6adu2/branch/master?svg=true)](https://ci.appveyor.com/project/jzarob/docattributes/branch/master)

In .NET, developers have typically used C#/VB XML comments to document their code. Although this has been the most
widely used way for developers to document their code there are inherent challenges with the code being documented
strictly in comments:

1. Unable to access the documentation during runtime
2. Output of the `/doc` argument is a flat list of targets
3. Output of the `/doc` argument doesn't include type information for parameters

DocAttributes is designed to solve these problems by providing a simple set of attributes that can be applied to a
variety of targets. These attributes are then reflected in a simple object structure that can be used to generate
several types of documentation.

## Example

```charp
using System;
using DocAttributes;
using DocAttributes.Targets;
using Newtownsoft.Json;

namespace AttributeExample
{
    [Summary("This class is an example class")]
    public class A { }
    
    static void Main(string[] args) 
    {
        var typeTarget = new TypeTarget(typeof(A));
        
        Console.WriteLine(JsonConvert.SerializeObject(typeTarget));
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