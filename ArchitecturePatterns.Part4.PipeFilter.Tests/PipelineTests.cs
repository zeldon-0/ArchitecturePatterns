namespace ArchitecturePatterns.Part4.PipeFilter.Tests;
public class PipelineTests
{
    private Pipeline pipeline;

    [SetUp]
    public void Setup()
    {
        pipeline = new Pipeline();
    }

    [Test]
    public void Process_PassesDataThroughFilters()
    {
        Data input = new Data { Value = "Hello, World!" };

        Filter filter1 = new UppercaseFilter();
        Filter filter2 = new ReverseFilter();

        pipeline.AddFilter(filter1);
        pipeline.AddFilter(filter2);

        Data output = pipeline.Process(input);

        Assert.AreEqual("!DLROW ,OLLEH", output.Value);
    }
}