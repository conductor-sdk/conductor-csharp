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

namespace Conductor.Examples.Orkes.Workers
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<object> Addresses { get; set; }

        public UserDetails(string name, string userId, List<object> addresses, string phone = default, string email = default)
        {
            Name = name;
            UserId = userId;
            Phone = phone;
            Email = email;
            Addresses = addresses;
        }
    }
}
