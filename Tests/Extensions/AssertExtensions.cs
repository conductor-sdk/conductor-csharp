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
