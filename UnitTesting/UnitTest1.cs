using SEW0402UnitTesting;
using Xunit;


namespace IT22Gr1SEW4s02ue2OrderServiceUnitTests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CalculateTotal_MultipleItems_ReturnCorrectTotal()
        {
            // Arrange
            OrderService service = new OrderService();
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem("Schnitzel", 2, 15.0), // 30
                new OrderItem("Cola", 1, 4.0),       // 4
                new OrderItem("Salat", 1, 6.0)       // 6
            };

            // Act
            double total = service.CalculateTotal(items);

            // Assert
            Assert.Equal(40.0, total);
        }

        [Fact]
        public void CalculateTotalWith20PercentVat_ReturnsCorrectTotal()
        {
            // Arrange
            OrderService service = new OrderService();
            List<OrderItem> items = new List<OrderItem> { new OrderItem("Schnitzel", 1, 10.0) };

            // Act
            double total = service.CalculateTotalWith20PercentVat(items);

            // Assert
            Assert.Equal(12.0, total); // 10 * 1.20
        }

        [Fact]
        public void CalculateTotalWithMultipleVat_MixedItems_ReturnsCorrectTotal()
        {
            // Arrange
            OrderService service = new OrderService();
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem("Schnitzel", 1, 10.0, false), // Essen: 10 + 10% = 11.0
                new OrderItem("Bier", 1, 5.0, true)         // Getränk: 5 + 20% = 6.0
            };

            // Act
            double total = service.CalculateTotalWithMultipleVat(items);

            // Assert
            Assert.Equal(17.0, total);
        }
    }
}