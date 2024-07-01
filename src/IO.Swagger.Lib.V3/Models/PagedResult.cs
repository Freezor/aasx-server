/*
 * DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository Service Specification
 *
 * The Full Profile of the Asset Administration Shell Repository Service Specification as part of Specification of the Asset Administration Shell: Part 2. Publisher: Industrial Digital Twin Association (IDTA) April 2023
 *
 * OpenAPI spec version: V3.0_SSP-001
 * Contact: info@idtwin.org
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace IO.Swagger.Models;

/// <summary>
/// Represents a paged result containing a list of items and optional paging metadata.
/// </summary>
public class PagedResult
{
    /// <summary>
    /// Gets or sets the list of items in the paged result.
    /// </summary>
    public List<IClass?> result { get; set; }

    /// <summary>
    /// Gets or sets the paging metadata for the paged result.
    /// </summary>
    public PagedResultPagingMetadata? paging_metadata { get; set; }

    /// <summary>
    /// Converts a source list into a paged result based on the provided pagination parameters.
    /// </summary>
    /// <typeparam name="T">The type of items in the source list.</typeparam>
    /// <param name="sourceList">The source list to paginate.</param>
    /// <param name="paginationParameters">The pagination parameters specifying cursor and limit.</param>
    /// <returns>The paged result containing a subset of the source list and paging metadata.</returns>
    public static PagedResult ToPagedList<T>(List<T> sourceList, PaginationParameters paginationParameters)
    {
        ArgumentNullException.ThrowIfNull(sourceList);

        ArgumentNullException.ThrowIfNull(paginationParameters);

        var outputList     = GetPaginatedList(sourceList, paginationParameters);
        var pagingMetadata = CreatePagingMetadata(sourceList, paginationParameters, outputList);

        var convertedList = ConvertToIClassList(outputList);

        return new PagedResult {result = convertedList, paging_metadata = pagingMetadata};
    }

    private static List<T> GetPaginatedList<T>(List<T> sourceList, PaginationParameters paginationParameters)
    {
        var startIndex = paginationParameters.Cursor;
        var endIndex   = startIndex + paginationParameters.Limit - 1;

        // Cap the endIndex to the last index of the sourceList
        endIndex = Math.Min(endIndex, sourceList.Count - 1);

        // Log a warning if startIndex is out of bounds
        if (startIndex > sourceList.Count - 1)
        {
            Console.WriteLine($"Warning: Requested pagination start index ({startIndex}) is greater than the size of the source list ({sourceList.Count}).");
        }

        // Build the outputList with the requested range
        var outputList = new List<T>();
        for (var i = startIndex; i <= endIndex; i++)
        {
            outputList.Add(sourceList[i]);
        }

        return outputList;
    }

    private static PagedResultPagingMetadata? CreatePagingMetadata<T>(List<T> sourceList, PaginationParameters paginationParameters, List<T> outputList)
    {
        var endIndex = paginationParameters.Cursor + paginationParameters.Limit - 1;

        // Create paging metadata if there are more items beyond the current page
        return endIndex < sourceList.Count - 1 ? new PagedResultPagingMetadata {cursor = Convert.ToString(endIndex + 1)} : null;
    }

    private static List<IClass?> ConvertToIClassList<T>(List<T> outputList) => outputList.Select(r => r as IClass).ToList();
}