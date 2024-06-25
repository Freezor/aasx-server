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

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedResult
    {
        public List<IClass?>?             result          { get; set; }
        public PagedResultPagingMetadata? paging_metadata { get; set; }

        public static PagedResult ToPagedList<T>(List<T> sourceList, PaginationParameters paginationParameters)
        {
            var outputList = new List<T>();
            var startIndex = paginationParameters.Cursor;
            var endIndex = startIndex + paginationParameters.Limit - 1;

            //cap the endIndex
            if (endIndex > sourceList.Count - 1)
            {
                endIndex = sourceList.Count - 1;
            }

            //If there are less elements in the sourceList than "from"
            if (startIndex > sourceList.Count - 1)
            {
                //TODO:support logger
                Console.WriteLine($"There are less elements in the retrived list than requested pagination - (from: {startIndex}, size:{endIndex})");
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                outputList.Add(sourceList[i]);
            }

            //Creating pagination result
            var pagingMetadata = new PagedResultPagingMetadata();
            if (endIndex < sourceList.Count - 1)
            {
                pagingMetadata.cursor = Convert.ToString(endIndex + 1);
            }

            var paginationResult = new PagedResult()
            {
                result = outputList.ConvertAll(r => (IClass)r),
                paging_metadata = pagingMetadata
            };

            //return paginationResult;
            return paginationResult;
        }
    }
}
