
CREATE PROCEDURE [Order].[UpdateByOrderId] 
   	@ProductsCount int,
   	@PackerId int,
   	@OrderState int,
   	@TotalPrice decimal

AS   
   UPDATE [dbo].[Order] 
   SET  ProductCount = @ProductsCount
        PackerId = @PackerId
        OrderState = @OrderState
        TotalPrice = @TotalPrice
GO

