﻿using Microsoft.HealthVault.Application;
using Microsoft.HealthVault.Clients;
using Microsoft.HealthVault.Connection;
using Microsoft.HealthVault.PlatformInformation;
using Microsoft.HealthVault.Transport;
using Microsoft.HealthVault.UnitTest.Samples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Microsoft.HealthVault.UnitTest.Clients
{
    [TestClass]
    public class PlatformClientTests
    {
        private IConnectionInternal connection;
        private PlatformClient platformClient;

        [TestInitialize]
        public void InitializeTest()
        {
            connection = Substitute.For<IConnectionInternal>();
            platformClient = new PlatformClient {Connection = this.connection};
        }

        [TestMethod]
        public async Task SelectInstanceTest()
        {
            var location = new Location("US", "WA");

            var response = SampleUtils.GetResponseData("InstanceSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.SelectInstance, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);

            var result = await platformClient.SelectInstanceAsync(location).ConfigureAwait(false);

            await this.connection.Received()
                .ExecuteAsync(HealthVaultMethods.SelectInstance, Arg.Any<int>(), Arg.Any<string>());

            Assert.AreEqual(result.Description, "US instance");

        }

        [TestMethod]
        public async Task SelectInstanceLocationNullArgumrentTest()
        {
            Location location = null;
            bool exceptionThrown = false;

            var response = SampleUtils.GetResponseData("InstanceSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.SelectInstance, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);
            try
            {
                var result = await platformClient.SelectInstanceAsync(location).ConfigureAwait(false);
            }
            catch (ArgumentNullException e)
            {
                exceptionThrown = true;
            }

            Assert.AreEqual(exceptionThrown, true);

        }

        [TestMethod]
        public async Task GetServiceDefinitionTest()
        {
            var response = SampleUtils.GetResponseData("ServiceDefinitionSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);

            var result = await platformClient.GetServiceDefinitionAsync().ConfigureAwait(false);
            await this.connection.Received()
                .ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>());

            Assert.AreEqual(result.LastUpdated.ToString(), "3/17/2017 3:24:19 AM");
        }

        [TestMethod]
        public async Task GetServiceDefinitionWithSectionsTest()
        {
            var response = SampleUtils.GetResponseData("ServiceDefinitionSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);
            var result = await platformClient.GetServiceDefinitionAsync(ServiceInfoSections.All).ConfigureAwait(false);
            await this.connection.Received()
                .ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>());

            Assert.AreEqual(result.LastUpdated.ToString(), "3/17/2017 3:24:19 AM");
        }

        [TestMethod]
        public async Task GetServiceDefinitionWithDateTimeTest()
        {
            DateTime lastUpdatedTime = new DateTime(2017, 03, 17, 03, 24, 19);
            var response = SampleUtils.GetResponseData("ServiceDefinitionSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);

            var result = await platformClient.GetServiceDefinitionAsync(lastUpdatedTime).ConfigureAwait(false);
            await this.connection.Received()
                .ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>());

            Assert.AreEqual(result.LastUpdated, lastUpdatedTime);
        }

        [TestMethod]
        public async Task GetServiceDefinitionWithSectionsDateTimeTest()
        {
            DateTime lastUpdatedTime = new DateTime(2017, 03, 17, 03, 24, 19);
            var response = SampleUtils.GetResponseData("ServiceDefinitionSample.xml");

            connection.ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>())
                .Returns(response);

            var result =
                await platformClient.GetServiceDefinitionAsync(ServiceInfoSections.All, lastUpdatedTime)
                    .ConfigureAwait(false);
            await this.connection.Received()
                .ExecuteAsync(HealthVaultMethods.GetServiceDefinition, Arg.Any<int>(), Arg.Any<string>());

            Assert.AreEqual(result.LastUpdated, lastUpdatedTime);
        }
    }
}