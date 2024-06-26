﻿namespace IO.Swagger.Lib.V3.Interfaces;

using Exceptions;

/// <summary>
/// Service for decoding Base64Url encoded strings.
/// </summary>
public interface IBase64UrlDecoderService
{
    /// <summary>
    /// Decodes a Base64Url encoded string.
    /// </summary>
    /// <param name="fieldName">The name of the field being decoded. Used for exception handling.</param>
    /// <param name="encodedString">The Base64Url encoded string to decode.</param>
    /// <returns>The decoded string, or null if the input string is null or empty.</returns>
    /// <exception cref="Base64UrlDecoderException">Thrown when the input string is not a valid Base64Url encoded string.</exception>
    string? Decode(string fieldName, string? encodedString);
}