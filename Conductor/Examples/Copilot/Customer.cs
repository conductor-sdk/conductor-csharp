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