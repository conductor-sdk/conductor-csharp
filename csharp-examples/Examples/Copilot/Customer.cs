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
namespace Conductor.Examples.Copilot
{
    public class Customer
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets AnnualSpend
        /// </summary>
        public double AnnualSpend { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="annualSpend"></param>
        /// <param name="country"></param>
        public Customer(int id = default(int), string name = default(string), double annualSpend = default(double), string country = default(string))
        {
            Id = id;
            Name = name;
            AnnualSpend = annualSpend;
            Country = country;
        }
    }
}