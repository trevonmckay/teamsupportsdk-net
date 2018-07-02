using System;
using System.Linq;
using TeamSupportSDK.NET.Models;
using Xunit;

namespace TeamSupportSDK.NET.Tests
{
    public class TeamSupportServiceClientTests : BaseTestClass
    {
        [Fact]
        public async void GetAllCustomersAsync_Success()
        {
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var customers = await tsClient.Customers.Request().GetAsync();

            Assert.NotEmpty(customers);
        }

        [Fact]
        public async void GetCustomerAsync_Success()
        {
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var customers = await tsClient.Customers.Request().GetAsync();

            var customerId = customers.First().Id;
            var result = await tsClient.Customers[customerId].Request().GetAsync();

            Assert.Equal(customerId, result.Id);
        }

        [Fact]
        public async void CreateCustomerAsync_Success()
        {
            // Setup
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var newCustomer = new Customer()
            {
                Name = "TEST_API_GEN",
                Description = "This customer was generated by TSServiceClient Unit Test. This should not be used and is okay to be deleted.",
                IsActive = true
            };

            // Execute
            var result = await tsClient.Customers.Request().AddAsync(newCustomer);

            // Assert
            Assert.IsType<Models.Customer>(result);
            Assert.NotNull(result.Id);
            Assert.Equal(newCustomer.Name, result.Name);
        }

        [Fact]
        public async void GetAllContactsAsync_Success()
        {
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var contacts = await tsClient.Contacts.Request().GetAsync();

            Assert.NotEmpty(contacts);
        }

        [Fact]
        public async void GetContactAsync_Success()
        {
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var contacts = await tsClient.Contacts.Request().GetAsync();

            var contactId = contacts.First().Id;
            var result = await tsClient.Contacts[contactId].Request().GetAsync();

            Assert.Equal(contactId, result.Id);
        }

        [Fact]
        public async void CreateContactAsync_Success()
        {
            // Setup
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var newContact = new Models.Contact()
            {
                Email = "support.user@test.com",
                FirstName = "Johnny",
                LastName = "Appleseed",
                IsPortalUser = true,
                Title = "API Generated User",
                OrganizationId = GetOrganizationId()
            };

            // Execute
            var result = await tsClient.Contacts.Request().AddAsync(newContact);

            // Assert
            Assert.IsType<Models.Contact>(result);
            Assert.NotNull(result.Id);
            Assert.Equal(newContact.Email, result.Email);
        }

        [Fact]
        public async void DeleteContactAsync_Success()
        {
            // Setup
            var defaultAuthenticationProvider = new Providers.DefaultAuthenticationProvider(GetOrganizationId(), GetApiToken());
            var tsClient = new TeamSupportServiceClient(SERVER_NAME, defaultAuthenticationProvider);
            var newContact = new Models.Contact()
            {
                Email = "support.user@test.com",
                FirstName = "Johnny",
                LastName = "Appleseed",
                IsPortalUser = true,
                Title = "API Generated User",
                OrganizationId = GetOrganizationId()
            };
            var contact = await tsClient.Contacts.Request().AddAsync(newContact);

            // Execute
            await tsClient.Contacts[contact.Id].Request().DeleteAsync();
        }
    }
}
