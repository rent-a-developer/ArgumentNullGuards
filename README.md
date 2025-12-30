[![NuGet Version](https://img.shields.io/nuget/v/RentADeveloper.ArgumentNullGuards)](https://www.nuget.org/packages/RentADeveloper.ArgumentNullGuards/)
[![license](https://img.shields.io/badge/License-MIT-purple.svg)](LICENSE.md)
![semver](https://img.shields.io/badge/semver-1.0.0-blue)

# ![image icon](https://raw.githubusercontent.com/rent-a-developer/ArgumentNullGuards/main/icon32.png) ArgumentNullGuards

A simple .NET library that verifies constructors and methods have guards in place against null arguments.

Inspired by a brilliant idea from Thomas Levesque, see https://thomaslevesque.com/2019/11/19/easy-unit-testing-of-null-argument-validation-c-8-edition/.

## Table of contents
- [ ArgumentNullGuards](#-argumentnullguards)
  - [Table of contents](#table-of-contents)
  - [Installation](#installation)
  - [Quick start](#quick-start)
  - [Contributing](#contributing)
  - [License](#license)
  - [Documentation](#documentation)
  - [Change Log](#change-log)
  - [Contributors](#contributors)

## Installation
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget).

Then install the [NuGet package](https://www.nuget.org/packages/RentADeveloper.ArgumentNullGuards/) from the package
manager console:
~~~shell
PM> Install-Package RentADeveloper.ArgumentNullGuards
~~~

## Quick start
Use the `ArgumentNullGuardVerifier` class to verify that your constructors and methods properly guard against null arguments.  
Call the `Verify` method, passing in a lambda expression that invokes the constructor or method you want to test with valid (non-null) arguments.

If any argument is not properly guarded against null, an exception will be thrown, causing the test to fail.  
If an `ArgumentNullException` is thrown, but with the wrong parameter name, the test will also fail.

~~~csharp
using static RentADeveloper.ArgumentNullGuards;

class UserService
{
	private readonly IUserRepository userRepository;
	
	public UserService(IUserRepository userRepository)
	{
		ArgumentNullException.ThrowIfNull(userRepository);
		this.userRepository = userRepository;
	}

	public IUserPermission[] GetPermissions(User user)
	{
		ArgumentNullException.ThrowIfNull(user);
		...
	}
}

public class UserServiceTests
{
	[Fact]
	public void VerifyNullArgumentGuards()
	{
		var userRepository = Substitute.For<IUserRepository>();
		var user = Substitute.For<User>();

		ArgumentNullGuardVerifier.Verify(() => new UserService(userRepository));
		
		var instance = new UserService(userRepository);

		ArgumentNullGuardVerifier.Verify(() => instance.GetPermissions(user));
	}
}
~~~

## Contributing
Contributions and bug reports are welcome and appreciated.  
Please follow the repository's [CONTRIBUTING.md](CONTRIBUTING.md) and code style.  
Open a GitHub issue for problems or a pull request with tests and a clear description of changes.

## License
This library is licensed under the [MIT license](LICENSE.md).

## Documentation
Full API documentation is available
[here](https://rent-a-developer.github.io/ArgumentNullGuards/api/RentADeveloper.ArgumentNullGuards.html).

## Change Log
The change log is available [here](CHANGELOG.md).

## Contributors
- David Liebeherr ([info@rent-a-developer.de](mailto:info@rent-a-developer.de))

