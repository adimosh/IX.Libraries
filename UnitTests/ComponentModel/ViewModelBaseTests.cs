using Bogus;

using System;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using IX.Library.ComponentModel;

using Xunit;

using T = System.String;
using TState = System.String;

namespace UnitTests.ComponentModel;

/// <summary>
/// Unit tests for the type <see cref="ViewModelBase"/>.
/// </summary>
public class ViewModelBaseTests
{
    private class TestViewModelBase : ViewModelBase
    {
        public TestViewModelBase() : base()
        {
        }

        public TestViewModelBase(SynchronizationContext? synchronizationContext) : base(synchronizationContext)
        {
        }

        public TestViewModelBase(
                                                                                         BusyScope? busyScope,
                                                                                         SynchronizationContext? synchronizationContext = null) : base(busyScope, synchronizationContext)
        {
        }

        public void PublicRaisePropertyChangedWithValidation(string propertyName)
        {
            base.RaisePropertyChangedWithValidation(propertyName);
        }

        public void PublicRaiseErrorsChanged(string propertyName)
        {
            base.RaiseErrorsChanged(propertyName);
        }

        public Task PublicDoWhileBusyAsync(Action action, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync(action, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync<TState>(Action<TState> action, TState state, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync<TState>(action, state, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync(Action<CancellationToken> action, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync(action, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync<TState>(Action<TState, CancellationToken> action, TState state, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync<TState>(action, state, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync(Func<Task> action, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync(action, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync<TState>(Func<TState, Task> action, TState state, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync<TState>(action, state, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync(Func<CancellationToken, Task> action, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync(action, description, cancellationToken);
        }

        public Task PublicDoWhileBusyAsync<TState>(Func<TState, CancellationToken, Task> action, TState state, string description, CancellationToken cancellationToken)
        {
            return base.DoWhileBusyAsync<TState>(action, state, description, cancellationToken);
        }
    }

    private readonly TestViewModelBase _testClass;
    private readonly SynchronizationContext _synchronizationContext;
    private readonly BusyScope _busyScope;
    private readonly Faker _faker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ViewModelBase"/>.
    /// </summary>
    public ViewModelBaseTests()
    {
        _synchronizationContext = new();
        _busyScope = new();
        _testClass = new(_busyScope, _synchronizationContext);
        _faker = new();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [Fact]
    public void CanConstruct()
    {
        // Act
        var instance = new TestViewModelBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new(_synchronizationContext);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new(_busyScope, _synchronizationContext);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the GetErrors method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallGetErrors()
    {
        // Arrange
        var propertyName = _faker.Random.String(5, 10);

        // Act
        var result = _testClass.GetErrors(propertyName);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetErrors method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallGetErrorsWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => _testClass.GetErrors(value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the Validate method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallValidate()
    {
        // Act
        _testClass.Validate();

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithTAndTAndTAndString()
    {
        // Arrange
        var backingField = "TestValue1831873762";
        var value = "TestValue737553615";
        var nameOfProperty = "TestValue1022195628";

        // Act
        _testClass.SetPropertyBackingField<T>(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the backingField parameter is null.
    /// </summary>
    [Fact]
    public void CannotCallSetPropertyBackingFieldWithTAndTAndTAndStringWithNullBackingField()
    {
        var backingField = default(T);
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField<T>(ref backingField, "TestValue44536491", "TestValue372896342")).Should().Throw<ArgumentNullException>().WithParameterName("backingField");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the value parameter is null.
    /// </summary>
    [Fact]
    public void CannotCallSetPropertyBackingFieldWithTAndTAndTAndStringWithNullValue()
    {
        var backingField = "TestValue675649364";
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField<T>(ref backingField, default(T), "TestValue1884171705")).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithTAndTAndTAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = "TestValue397436665";
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField<T>(ref backingField, "TestValue1863440", value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithIntAndIntAndString()
    {
        // Arrange
        var backingField = 802881710;
        var value = 946296716;
        var nameOfProperty = "TestValue1276708906";

        // Act
        _testClass.SetPropertyBackingField(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithIntAndIntAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 1802220882;
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField(ref backingField, 159011265, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithLongAndLongAndString()
    {
        // Arrange
        var backingField = 1443603282L;
        var value = 1075968923L;
        var nameOfProperty = "TestValue1868280846";

        // Act
        _testClass.SetPropertyBackingField(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithLongAndLongAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 1851900617L;
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField(ref backingField, 1432592553L, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithFloatAndFloatAndString()
    {
        // Arrange
        var backingField = 6295.93262F;
        var value = 14982.8545F;
        var nameOfProperty = "TestValue1276921432";

        // Act
        _testClass.SetPropertyBackingField(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithFloatAndFloatAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 2311.073F;
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField(ref backingField, 29107.78F, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithDoubleAndDoubleAndString()
    {
        // Arrange
        var backingField = 676020359.52;
        var value = 509955745.86;
        var nameOfProperty = "TestValue1476501167";

        // Act
        _testClass.SetPropertyBackingField(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithDoubleAndDoubleAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 167895367.2;
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField(ref backingField, 896651302.14, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithIntPtrAndIntPtrAndString()
    {
        // Arrange
        var backingField = new IntPtr();
        var value = new IntPtr();
        var nameOfProperty = "TestValue1271487367";

        // Act
        _testClass.SetPropertyBackingField(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingField method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithIntPtrAndIntPtrAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = new IntPtr();
        FluentActions.Invoking(() => _testClass.SetPropertyBackingField(ref backingField, new(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithValidationWithTAndTAndTAndString()
    {
        // Arrange
        var backingField = "TestValue1063633232";
        var value = "TestValue1314813624";
        var nameOfProperty = "TestValue1604938117";

        // Act
        _testClass.SetPropertyBackingFieldWithValidation<T>(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method throws when the backingField parameter is null.
    /// </summary>
    [Fact]
    public void CannotCallSetPropertyBackingFieldWithValidationWithTAndTAndTAndStringWithNullBackingField()
    {
        var backingField = default(T);
        FluentActions.Invoking(() => _testClass.SetPropertyBackingFieldWithValidation<T>(ref backingField, "TestValue2111422582", "TestValue1040485010")).Should().Throw<ArgumentNullException>().WithParameterName("backingField");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method throws when the value parameter is null.
    /// </summary>
    [Fact]
    public void CannotCallSetPropertyBackingFieldWithValidationWithTAndTAndTAndStringWithNullValue()
    {
        var backingField = "TestValue925718869";
        FluentActions.Invoking(() => _testClass.SetPropertyBackingFieldWithValidation<T>(ref backingField, default(T), "TestValue982870743")).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithValidationWithTAndTAndTAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = "TestValue410350024";
        FluentActions.Invoking(() => _testClass.SetPropertyBackingFieldWithValidation<T>(ref backingField, "TestValue1167036745", value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaisePropertyChangedWithValidationWithIntAndIntAndString()
    {
        // Arrange
        var backingField = 1373520360;
        var value = 1719364781;
        var nameOfProperty = "TestValue1339727737";

        // Act
        _testClass.RaisePropertyChangedWithValidation(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaisePropertyChangedWithValidationWithIntAndIntAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 1920674766;
        FluentActions.Invoking(() => _testClass.RaisePropertyChangedWithValidation(ref backingField, 2058080763, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallSetPropertyBackingFieldWithValidationWithLongAndLongAndString()
    {
        // Arrange
        var backingField = 1211615675L;
        var value = 1410597339L;
        var nameOfProperty = "TestValue907052344";

        // Act
        _testClass.SetPropertyBackingFieldWithValidation(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPropertyBackingFieldWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallSetPropertyBackingFieldWithValidationWithLongAndLongAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 376854584L;
        FluentActions.Invoking(() => _testClass.SetPropertyBackingFieldWithValidation(ref backingField, 1078034522L, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaisePropertyChangedWithValidationWithFloatAndFloatAndString()
    {
        // Arrange
        var backingField = 3784.62F;
        var value = 31116.6348F;
        var nameOfProperty = "TestValue949492468";

        // Act
        _testClass.RaisePropertyChangedWithValidation(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaisePropertyChangedWithValidationWithFloatAndFloatAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 15395.835F;
        FluentActions.Invoking(() => _testClass.RaisePropertyChangedWithValidation(ref backingField, 12968.4678F, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaisePropertyChangedWithValidationWithDoubleAndDoubleAndString()
    {
        // Arrange
        var backingField = 1592034671.7;
        var value = 862025196.78;
        var nameOfProperty = "TestValue924624589";

        // Act
        _testClass.RaisePropertyChangedWithValidation(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaisePropertyChangedWithValidationWithDoubleAndDoubleAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = 1494079577.1;
        FluentActions.Invoking(() => _testClass.RaisePropertyChangedWithValidation(ref backingField, 1985220443.25, value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaisePropertyChangedWithValidationWithIntPtrAndIntPtrAndString()
    {
        // Arrange
        var backingField = new IntPtr();
        var value = new IntPtr();
        var nameOfProperty = "TestValue1346631844";

        // Act
        _testClass.RaisePropertyChangedWithValidation(ref backingField, value, nameOfProperty);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the RaisePropertyChangedWithValidation method throws when the nameOfProperty parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaisePropertyChangedWithValidationWithIntPtrAndIntPtrAndStringWithInvalidNameOfProperty(string value)
    {
        var backingField = new IntPtr();
        FluentActions.Invoking(() => _testClass.RaisePropertyChangedWithValidation(ref backingField, new(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameOfProperty");
    }

    /// <summary>
    /// Checks that the PublicRaisePropertyChangedWithValidation method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaisePropertyChangedWithValidationWithString()
    {
        // Arrange
        var propertyName = "TestValue1714580425";

        // Act
        _testClass.PublicRaisePropertyChangedWithValidation(propertyName);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRaisePropertyChangedWithValidation method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaisePropertyChangedWithValidationWithStringWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => _testClass.PublicRaisePropertyChangedWithValidation(value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the PublicRaiseErrorsChanged method functions correctly.
    /// </summary>
    [Fact]
    public void CanCallRaiseErrorsChanged()
    {
        // Arrange
        var propertyName = "TestValue1639211926";

        // Act
        _testClass.PublicRaiseErrorsChanged(propertyName);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRaiseErrorsChanged method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void CannotCallRaiseErrorsChangedWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => _testClass.PublicRaiseErrorsChanged(value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithActionAndStringAndCancellationToken()
    {
        // Arrange
        Action action = () => { };
        var description = "TestValue877859720";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync(action, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithActionAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(default(Action), "TestValue1886732125", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithActionAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(() => { }, value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithActionOfTStateAndTStateAndStringAndCancellationToken()
    {
        // Arrange
        Action<TState> action = x => { };
        var state = "TestValue1778966739";
        var description = "TestValue1819254436";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync<TState>(action, state, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfTStateAndTStateAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(default(Action<TState>), "TestValue1709465058", "TestValue195072330", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfTStateAndTStateAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(x => { }, "TestValue403118272", value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithActionOfCancellationTokenAndStringAndCancellationToken()
    {
        // Arrange
        Action<CancellationToken> action = x => { };
        var description = "TestValue150250054";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync(action, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfCancellationTokenAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(default(Action<CancellationToken>), "TestValue885410103", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfCancellationTokenAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(x => { }, value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithActionOfTStateAndCancellationTokenAndTStateAndStringAndCancellationToken()
    {
        // Arrange
        Action<TState, CancellationToken> action = (x, y) => { };
        var state = "TestValue1441550593";
        var description = "TestValue265555808";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync<TState>(action, state, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfTStateAndCancellationTokenAndTStateAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(default(Action<TState, CancellationToken>), "TestValue1186586118", "TestValue1410065167", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithActionOfTStateAndCancellationTokenAndTStateAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>((x, y) => { }, "TestValue2084677342", value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithFuncOfTaskAndStringAndCancellationToken()
    {
        // Arrange
        Func<Task> action = () => Task.CompletedTask;
        var description = "TestValue378271987";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync(action, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTaskAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(default(Func<Task>), "TestValue1997068568", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTaskAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(() => Task.CompletedTask, value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithFuncOfTStateAndTaskAndTStateAndStringAndCancellationToken()
    {
        // Arrange
        Func<TState, Task> action = x => Task.CompletedTask;
        var state = "TestValue1618716820";
        var description = "TestValue1251993122";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync<TState>(action, state, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTStateAndTaskAndTStateAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(default(Func<TState, Task>), "TestValue569448823", "TestValue1940220343", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTStateAndTaskAndTStateAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(x => Task.CompletedTask, "TestValue1975157511", value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithFuncOfCancellationTokenAndTaskAndStringAndCancellationToken()
    {
        // Arrange
        Func<CancellationToken, Task> action = x => Task.CompletedTask;
        var description = "TestValue1023450932";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync(action, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfCancellationTokenAndTaskAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(default(Func<CancellationToken, Task>), "TestValue1171794849", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfCancellationTokenAndTaskAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync(x => Task.CompletedTask, value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CanCallDoWhileBusyAsyncWithFuncOfTStateAndCancellationTokenAndTaskAndTStateAndStringAndCancellationToken()
    {
        // Arrange
        Func<TState, CancellationToken, Task> action = (x, y) => Task.CompletedTask;
        var state = "TestValue365321156";
        var description = "TestValue595925888";
        var cancellationToken = CancellationToken.None;

        // Act
        await _testClass.PublicDoWhileBusyAsync<TState>(action, state, description, cancellationToken);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [Fact]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTStateAndCancellationTokenAndTaskAndTStateAndStringAndCancellationTokenWithNullAction()
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>(default(Func<TState, CancellationToken, Task>), "TestValue1390312010", "TestValue503306752", CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the PublicDoWhileBusyAsync method throws when the description parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CannotCallDoWhileBusyAsyncWithFuncOfTStateAndCancellationTokenAndTaskAndTStateAndStringAndCancellationTokenWithInvalidDescription(string value)
    {
        await FluentActions.Invoking(() => _testClass.PublicDoWhileBusyAsync<TState>((x, y) => Task.CompletedTask, "TestValue169752488", value, CancellationToken.None)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("description");
    }

    /// <summary>
    /// Checks that setting the IsBusy property correctly raises PropertyChanged events.
    /// </summary>
    [Fact]
    public void CanSetAndGetIsBusy()
    {
        _testClass.CheckProperty(x => x.IsBusy);
    }

    /// <summary>
    /// Checks that the HasErrors property can be read from.
    /// </summary>
    [Fact]
    public void CanGetHasErrors()
    {
        // Assert
        _testClass.HasErrors.As<object>().Should().BeAssignableTo<bool>();

        throw new NotImplementedException("Create or modify test");
    }
}