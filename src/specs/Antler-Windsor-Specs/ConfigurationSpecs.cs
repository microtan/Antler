﻿// ReSharper disable InconsistentNaming

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentAssertions;
using NUnit.Framework;
using SmartElk.Antler.Core.Abstractions.Configuration;

namespace SmartElk.Antler.Windsor.Specs
{
    public class ConfigurationSpecs
    {
        [TestFixture]
        [Category("Integration")]
        public class when_trying_to_configure_to_use_container
        {
            [Test]
            public void should_set_container()
            {                                
                //arrange
                var configurator = new AntlerConfigurator();
                
                //act
                configurator.UseWindsorContainer();

                //assert
                configurator.Configuration.Container.Should().BeOfType<WindsorContainerAdapter>();
            }
        }

        [TestFixture]
        [Category("Integration")]
        public class when_trying_to_configure_to_use_existing_container_with_registered_components
        {
            private class TestComponent { }
            
            [Test]
            public void should_set_container_with_registered_components()
            {            
                //arrange
                var container = new WindsorContainer();
                container.Register(Component.For<TestComponent>());
                
                var configurator = new AntlerConfigurator();

                //act
                configurator.UseWindsorContainer(container);

                //assert
                configurator.Configuration.Container.Should().BeOfType<WindsorContainerAdapter>();
                configurator.Configuration.Container.Get<TestComponent>().Should().BeOfType<TestComponent>();
            }
        }


        [TestFixture]
        [Category("Integration")]
        public class when_trying_to_use_configurator_without_container
        {
            [Test]
            public void should_not_have_any_container()
            {
                //arrange
                var configurator = new AntlerConfigurator();
                                
                //assert
                configurator.Configuration.Container.Should().BeNull();
            }
        }                
    }
}
// ReSharper restore InconsistentNaming
