# [RunInBackground.SCU](https://github.com/sapozhnikovv/RunInBackground.SCU)   
    
Simple & fail-safe background task manager.   
It is designed to use closures with 'functor' in 'Run' method.     
   
Feel free to make your own version of this extension or just copy-paste code in your solution and change. It is open source.   
   
# Nuget   
[![NuGet](https://img.shields.io/nuget/v/RunInBackground.SCU)](https://www.nuget.org/packages/RunInBackground.SCU)   
multi-target package:   
✅ .net6.0   
✅ .net7.0   
✅ .net8.0   
✅ .net9.0   

https://www.nuget.org/packages/RunInBackground.SCU

```shell
dotnet add package RunInBackground.SCU
```
or
```shell
NuGet\Install-Package RunInBackground.SCU
```

## Example of using

```c#
using RunInBackground.SCU;

// DI
services.RegisterBackgroundTaskManager();

// Service/Controller code
SomeService(IBackgroundTaskManager bgManager)
{
...
	bgManager.Run(async (scope) => {
		//use your services from the scope
		...
	});
...
}
```

## License
Free MIT license (https://github.com/sapozhnikovv/RunInBackground.SCU/blob/main/LICENSE)