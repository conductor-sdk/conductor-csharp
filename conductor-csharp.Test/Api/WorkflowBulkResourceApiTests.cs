/*
 * Conductor API Server
 *
 * Conductor API Server
 *
 * The version of the OpenAPI document: v0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing WorkflowBulkResourceApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class WorkflowBulkResourceApiTests : IDisposable
    {
        private WorkflowBulkResourceApi instance;

        public WorkflowBulkResourceApiTests()
        {
            instance = new WorkflowBulkResourceApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of WorkflowBulkResourceApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' WorkflowBulkResourceApi
            //Assert.IsType<WorkflowBulkResourceApi>(instance);
        }

        /// <summary>
        /// Test PauseWorkflow
        /// </summary>
        [Fact]
        public void PauseWorkflowTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> requestBody = null;
            //var response = instance.PauseWorkflow(requestBody);
            //Assert.IsType<BulkResponse>(response);
        }

        /// <summary>
        /// Test Restart1
        /// </summary>
        [Fact]
        public void Restart1Test()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> requestBody = null;
            //bool? useLatestDefinitions = null;
            //var response = instance.Restart1(requestBody, useLatestDefinitions);
            //Assert.IsType<BulkResponse>(response);
        }

        /// <summary>
        /// Test ResumeWorkflow
        /// </summary>
        [Fact]
        public void ResumeWorkflowTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> requestBody = null;
            //var response = instance.ResumeWorkflow(requestBody);
            //Assert.IsType<BulkResponse>(response);
        }

        /// <summary>
        /// Test Retry
        /// </summary>
        [Fact]
        public void RetryTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> requestBody = null;
            //var response = instance.Retry(requestBody);
            //Assert.IsType<BulkResponse>(response);
        }

        /// <summary>
        /// Test Terminate1
        /// </summary>
        [Fact]
        public void Terminate1Test()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> requestBody = null;
            //string reason = null;
            //var response = instance.Terminate1(requestBody, reason);
            //Assert.IsType<BulkResponse>(response);
        }
    }
}
