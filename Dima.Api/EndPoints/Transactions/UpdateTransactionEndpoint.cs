﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.EndPoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapPut("/{id}", HandleAsync)
           .WithName("Transactions: Update")
           .WithSummary("Atualiza uma nova transação")
           .WithDescription("Atualiza uma nova transação")
           .WithOrder(2)
           .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            UpdateTransactionRequest request,
            long id
            )
        {
            request.UserId = "test@giuliano.io";
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            //if (result.IsSuccess)
            //{
            //    return TypedResults.Created($"/{result.Data.Id}", result.Data);
            //}

            //return TypedResults.BadRequest(result.Data);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result); 
        }
    }
}
