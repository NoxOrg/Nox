
using FluentAssertions;
using System.Text.Json;

namespace Nox.Types.Tests.Types;

public class JsonTest
{

    [Theory]
    [InlineData("{}")]
    [InlineData("[]")]
    [InlineData("[{}]")]
    [InlineData("{\"name\":\"Merlin\"}")]
    [InlineData("{\"name\":\"Merlin\",\"title\":\"Wizard\"}")]
    [InlineData("{\"key1\":\"value1\",\"key2\":42,\"key3\":[true,false]}")]
    [InlineData("{\r\n  \"orders\": [\r\n    {\r\n      \"order_id\": \"1234\",\r\n      \"date\": \"2022-05-10\",\r\n      \"total_amount\": 245.50,\r\n      \"customer\": {\r\n        \"name\": \"John Doe\",\r\n        \"email\": \"johndoe@example.com\",\r\n        \"address\": {\r\n          \"street\": \"123 Main St\",\r\n          \"city\": \"Anytown\",\r\n          \"state\": \"CA\",\r\n          \"zip\": \"12345\"\r\n        }\r\n      },\r\n      \"items\": [\r\n        {\r\n          \"product_id\": \"6789\",\r\n          \"name\": \"Widget\",\r\n          \"price\": 20.00,\r\n          \"quantity\": 5\r\n        },\r\n        {\r\n          \"product_id\": \"2345\",\r\n          \"name\": \"Gizmo\",\r\n          \"price\": 15.50,\r\n          \"quantity\": 4\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"order_id\": \"5678\",\r\n      \"date\": \"2022-05-09\",\r\n      \"total_amount\": 175.00,\r\n      \"customer\": {\r\n        \"name\": \"Jane Smith\",\r\n        \"email\": \"janesmith@example.com\",\r\n        \"address\": {\r\n          \"street\": \"456 Main St\",\r\n          \"city\": \"Anytown\",\r\n          \"state\": \"CA\",\r\n          \"zip\": \"12345\"\r\n        },\r\n        \"phone\": \"555-555-1212\"\r\n      },\r\n      \"items\": [\r\n        {\r\n          \"product_id\": \"9876\",\r\n          \"name\": \"Thingamajig\",\r\n          \"price\": 25.00,\r\n          \"quantity\": 3\r\n        },\r\n        {\r\n          \"product_id\": \"3456\",\r\n          \"name\": \"Doodad\",\r\n          \"price\": 10.00,\r\n          \"quantity\": 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"order_id\": \"9012\",\r\n      \"date\": \"2022-05-08\",\r\n      \"total_amount\": 150.25,\r\n      \"customer\": {\r\n        \"name\": \"Bob Johnson\",\r\n        \"email\": \"bjohnson@example.com\",\r\n        \"address\": {\r\n          \"street\": \"789 Main St\",\r\n          \"city\": \"Anytown\",\r\n          \"state\": \"CA\",\r\n          \"zip\": \"12345\"\r\n        },\r\n        \"company\": \"ABC Inc.\"\r\n      },\r\n      \"items\": [\r\n        {\r\n          \"product_id\": \"1234\",\r\n          \"name\": \"Whatchamacallit\",\r\n          \"price\": 12.50,\r\n          \"quantity\": 5\r\n        },\r\n        {\r\n          \"product_id\": \"5678\",\r\n          \"name\": \"Doohickey\",\r\n          \"price\": 7.25,\r\n          \"quantity\": 15\r\n        }\r\n      ]\r\n    }\r\n  ]\r\n}")]
    public void Json_Constructor_ValidJson_ReturnObject(string jsonString)
    {
        // Act
        var jsonObject = Json.From(jsonString, new JsonTypeOptions { ReturnPretty = false });

        var jsonExpectedString = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(jsonString));

        // Assert
        jsonObject.Should().NotBeNull();

        jsonObject.Value.Should().Be(jsonExpectedString);

    }

    [Theory]
    [InlineData("{\"name\"}")]
    [InlineData("[\"name\",\"place\",\"animal\"],")]
    [InlineData("[{\"}]")]
    [InlineData("{\"name\":\"Merlin}")]
    [InlineData("{\"name\":\"Merlin\", \"title\": Wizard\"}")]
    public void Json_Constructor_InValidJson_ShouldThrowException(string jsonString)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Json.From(jsonString, new JsonTypeOptions { }));

        //Assert
        exception.Errors.First().ErrorMessage.Should().StartWith($"Could not create a Nox Json type with value {jsonString} due to JsonException");
    }

    [Theory]
    [InlineData("{\"name\":\"Merlin\", \"title\": \"Wizard\"}", "{\"title\": \"Wizard\",\"name\":\"Merlin\"}")]
    [InlineData("{\"array\":[1,2,3]}", "{\"array\":[3,1,2]}")]
    [InlineData("[{},{}]", "[{},{}]")]
    [InlineData("[{\"1\":1},{\"2\":2}]", "[{\"2\":2},{\"1\":1}]")]
    [InlineData("[]", "[]")]
    [InlineData("{\"arr\":[]}", "{\"arr\":[]}")]
    [InlineData("[1,2,3.00,4,5]", "[5,1,4.0,2,3]")]
    [InlineData("{\"orders\":[{\"order_id\":\"1234\",\"date\":\"2022-05-10\",\"total_amount\":245.5,\"customer\":{\"name\":\"John Doe\",\"email\":\"johndoe@example.com\",\"address\":{\"street\":\"123 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"}},\"items\":[{\"product_id\":\"6789\",\"name\":\"Widget\",\"price\":20,\"quantity\":5},{\"product_id\":\"2345\",\"name\":\"Gizmo\",\"price\":15.5,\"quantity\":4}]},{\"order_id\":\"5678\",\"date\":\"2022-05-09\",\"total_amount\":175,\"customer\":{\"name\":\"Jane Smith\",\"email\":\"janesmith@example.com\",\"address\":{\"street\":\"456 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"},\"phone\":\"555-555-1212\"},\"items\":[{\"product_id\":\"9876\",\"name\":\"Thingamajig\",\"price\":25,\"quantity\":3},{\"product_id\":\"3456\",\"name\":\"Doodad\",\"price\":10,\"quantity\":10}]},{\"order_id\":\"9012\",\"date\":\"2022-05-08\",\"total_amount\":150.25,\"customer\":{\"name\":\"Bob Johnson\",\"email\":\"bjohnson@example.com\",\"address\":{\"street\":\"789 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"},\"company\":\"ABC Inc.\"},\"items\":[{\"product_id\":\"1234\",\"name\":\"Whatchamacallit\",\"price\":12.5,\"quantity\":5},{\"product_id\":\"5678\",\"name\":\"Doohickey\",\"price\":7.25,\"quantity\":15}]}]}",
                "{\"orders\":[{\"order_id\":\"1234\",\"date\":\"2022-05-10\",\"total_amount\":245.5,\"customer\":{\"name\":\"John Doe\",\"email\":\"johndoe@example.com\",\"address\":{\"street\":\"123 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"}},\"items\":[{\"product_id\":\"2345\",\"name\":\"Gizmo\",\"price\":15.5,\"quantity\":4},{\"product_id\":\"6789\",\"name\":\"Widget\",\"price\":20,\"quantity\":5}]},{\"order_id\":\"9012\",\"date\":\"2022-05-08\",\"total_amount\":150.25,\"customer\":{\"name\":\"Bob Johnson\",\"email\":\"bjohnson@example.com\",\"address\":{\"street\":\"789 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"},\"company\":\"ABC Inc.\"},\"items\":[{\"product_id\":\"1234\",\"name\":\"Whatchamacallit\",\"price\":12.5,\"quantity\":5},{\"product_id\":\"5678\",\"name\":\"Doohickey\",\"price\":7.25,\"quantity\":15}]},{\"order_id\":\"5678\",\"date\":\"2022-05-09\",\"total_amount\":175,\"customer\":{\"name\":\"Jane Smith\",\"email\":\"janesmith@example.com\",\"address\":{\"street\":\"456 Main St\",\"city\":\"Anytown\",\"state\":\"CA\",\"zip\":\"12345\"},\"phone\":\"555-555-1212\"},\"items\":[{\"product_id\":\"3456\",\"name\":\"Doodad\",\"price\":10,\"quantity\":10},{\"product_id\":\"9876\",\"name\":\"Thingamajig\",\"price\":25,\"quantity\":3}]}]}")]
    public void Json_Value_Equivalence_Tests(string jsonString1, string jsonString2)
    {
        // Arrange & Act
        var json1 = Json.From(jsonString1, new JsonTypeOptions { IgnoreArrayOrder =true });
        var json2 = Json.From(jsonString2, new JsonTypeOptions { IgnoreArrayOrder = true });

        // Assert
        json1.Should().BeEquivalentTo(json2);
    }

    [Theory]
    [InlineData("{\"array\":[1,2,3]}", "{\"array\":[3,1,2]}")]
    [InlineData("[{\"1\":1},{\"2\":2}]", "[{\"2\":2},{\"1\":1}]")]
    [InlineData("[1,2,3.00,4,5]", "[5,1,4.0,2,3]")]
    public void Json_PreserveArrayOrder_NotEquivalence_Tests(string jsonString1, string jsonString2)
    {
        // Arrange & Act
        var json1 = Json.From(jsonString1, new JsonTypeOptions { IgnoreArrayOrder = false });
        var json2 = Json.From(jsonString2, new JsonTypeOptions { IgnoreArrayOrder = false });

        // Assert
        json1.Should().NotBeEquivalentTo(json2);
    }

    [Theory]
    [InlineData("{\"name\":\"Merlin\", \"title\": \"Wizard\"}", "{\"title\": \"Wizard\",\"name\":\"Merlin\", \"age\":105}")]
    [InlineData("{\"array\":[1,2,3]}", "{\"array\":[3,1,3]}")]
    public void Json_Value_NotEqual_Tests(string jsonString1, string jsonString2)
    {
        // Arrange & Act
        var json1 = Json.From(jsonString1);
        var json2 = Json.From(jsonString2);

        // Assert
        json1.Should().NotBeEquivalentTo(json2);
    }

    [Fact]
    public void Json_ToString_ReturnsString()
    {
        // Arrange & Act
        var json = Json.From("{\"name\":\"Merlin\", \"title\": \"Wizard\"}", 
            new JsonTypeOptions { PersistMinified = true, ReturnPretty = false });

        // Assert
        json.ToString().Should().BeEquivalentTo("{\"name\":\"Merlin\",\"title\":\"Wizard\"}");
    }

    [Fact]
    public void Json_ToString_WithNoOptionsAndInvalidJson_ThrowsError()
    {
        // Arrange & Act
        var jsonString = @"{""bad json]";

        // Assert
        var exception = Assert.Throws<TypeValidationException>(() => _ = Json.From(jsonString));
    }

    [Fact]
    public void Json_ToString_WithNoOptions_ReturnMinifiedJsonByDefault()
    {
        // Arrange & Act
        var jsonString = """
            { 
                "key1": "value1",
                "key2": "value2",
                "key3": "value3"
            }
            """;

        // this method should be overrided in Json if options are ommitted, so it too can ApplyOptions - A.Sharpe
        // Alternatively just call ApplyOptions from Validate
        var json1 = Json.From(jsonString); 

        var json2 = Json.From(jsonString, new JsonTypeOptions());

        // Assert
        json1.Value.Should().BeEquivalentTo(json2.Value);
    }
}
