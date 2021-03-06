﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TeamSupportSDK.NET.Attributes;

namespace TeamSupportSDK.NET.Models
{
    public class Contact
    {
        public string Id { get; set; }

        public string ContactID
        {
            get
            {
                return this.Id;
            }

            set
            {
                this.Id = value;
            }
        }

        public string OrganizationId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }

        public bool IsPortalUser { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Organization { get; set; }

        public string Title { get; set; }

        [JsonIgnoreSerialization]
        [JsonProperty(PropertyName = "DateCreated")]
        public DateTime Created { get; set; }

        [JsonIgnoreSerialization]
        [JsonProperty(PropertyName = "DateModified")]
        public DateTime LastModified { get; set; }
    }
}
