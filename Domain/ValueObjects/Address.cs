using Domain.Common;

namespace Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street; 
            yield return City; 
            yield return PostCode;
        }
    }
}
