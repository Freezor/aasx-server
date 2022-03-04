/*
 * DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository
 *
 * An exemplary interface combination for the use case of an Asset Administration Shell Repository
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Key : IEquatable<Key>
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]

        [DataMember(Name = "type")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasKeyElements Type { get; set; }
        public KeyElements Type { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [Required]

        [DataMember(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Key {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Key)obj);
        }

        /// <summary>
        /// Returns true if Key instances are equal
        /// </summary>
        /// <param name="other">Instance of Key to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Key other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) &&
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Key left, Key right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Key left, Key right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}