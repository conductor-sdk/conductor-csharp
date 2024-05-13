/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace conductor_csharp.test.Extensions
{
    /// <summary>
    /// Provides extension methods for asserting response objects.
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// Asserts that a single response object is not null, is of the specified type,
        /// and optionally performs an equality assertion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AssertModelResponse<T>(T response, object expected = null, object actual = null)
        {
            Assert.NotNull(response);
            Assert.IsType<T>(response);

            if (expected != null && actual != null)
            {
                Assert.Equal(expected, actual);
            }
        }

        /// <summary>
        /// Asserts that a list of response objects is not null, contains at least one element,
        /// and each element is of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        public static void AssertModelResponse<T>(IEnumerable<T> response)
        {
            Assert.True(response.Any());
        }
    }
}
